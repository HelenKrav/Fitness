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

            Console.WriteLine("Введите пол пользователя");
            var gender = Console.ReadLine();  //TODO сделать проверку

            Console.WriteLine("Введите дату рождения пользователя");
            DateTime birthDay =DateTime.Parse( Console.ReadLine());  //TODO сделать проверку

            Console.WriteLine("Введите вес пользователя");
            double weight = double.Parse( Console.ReadLine());  //TODO сделать проверку

            Console.WriteLine("Введите рост пользователя");
            double height =double.Parse(Console.ReadLine());  //TODO сделать проверку

            var userController = new UserController(name, gender, birthDay, weight, height);
            userController.Save();
        }
    }
}
