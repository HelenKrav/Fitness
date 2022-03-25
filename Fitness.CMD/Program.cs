using Fitness.BL.Controller;
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
            var name = Console.ReadLine();  //TODO сделать проверку

            var UserController = new UserController(name);
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
            Console.ReadLine();
            
            
            
            //Console.WriteLine("Введите пол пользователя");
            //var gender = Console.ReadLine();  //TODO сделать проверку

            //Console.WriteLine("Введите дату рождения пользователя");
            //DateTime birthDay =DateTime.Parse( Console.ReadLine());  //TODO сделать проверку

            //Console.WriteLine("Введите вес пользователя");
            //double weight = double.Parse( Console.ReadLine());  //TODO сделать проверку

            //Console.WriteLine("Введите рост пользователя");
            //double height =double.Parse(Console.ReadLine());  //TODO сделать проверку


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
                    Console.WriteLine($"Неверный формат {name}!");
                }
            }
            
        }
    }
}
