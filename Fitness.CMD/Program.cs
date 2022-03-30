using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    internal class Program
    {
        
         static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");   //делаем языковую настройку 
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);


            Console.WriteLine(resourceManager.GetString("Hello",culture));  //Вас приветствует приложение Fitness

            Console.WriteLine(resourceManager.GetString("EnterName",culture)); //Введите имя пользователя
            var name = Console.ReadLine(); 

            var UserController = new UserController(name);
            var eatincontroller = new EatingContoller(UserController.CurrentUser);

            if (UserController.IsNewUser)
            {
                Console.WriteLine("EnterGender", culture); // Ведите пол
                var gender = Console.ReadLine();

                var birthDay = ParseBirthDay();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                UserController.SetNewUserData(gender, birthDay, weight, height);
            }

            Console.WriteLine(UserController.CurrentUser);

            Console.WriteLine(resourceManager.GetString("QuestionWhatDoYouDo", culture)); //"Что вы хотите сделать?"  
            Console.WriteLine(resourceManager.GetString("LetterE", culture)); //"Е - вести прием пищи"
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
