using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness");
           
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine(); 

            var UserController = new UserController(name);
            var eatincontroller = new EatingContoller(UserController.CurrentUser);

            if (UserController.IsNewUser)
            {
                Console.WriteLine("Ведите пол ");
                var gender = Console.ReadLine();

                var birthDay = ParseBirthDay();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                UserController.SetNewUserData(gender, birthDay, weight, height);
            }

            Console.WriteLine(UserController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - вести прием пищи");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E) 
            {
              var foods = EnterEating();
              eatincontroller.Add(foods.Food, foods.Weight);
              
            }
            foreach(var item in eatincontroller.Eating.Foods)
            {
                Console.WriteLine($"\t {item.Key.NameFood} - {item.Value}");
            }
            Console.ReadLine();
        }




        private static (Food Food , double Weight) EnterEating()  // немножко кортежей
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            var product = new Food(food,calories,proteins,fats,carbs);

            return (Food: product,Weight: weight);

        }

        private static DateTime ParseBirthDay()
        {
            DateTime birthDay;
            while (true)
            {
                Console.WriteLine("Ведите дату рождения dd.mm.yyyy ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }
            return birthDay;
        }


        private static double ParseDouble(string name)  //попробовать расширить потом на большее количество вводных данных
        {
            while (true)
            {
                Console.WriteLine($"Ведите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                        {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}!");
                }
            }
            
        }
    }
}
