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

            var userController = new UserController(name);
            var eatinController = new EatingContoller(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender"), culture); // Ведите пол
                var gender = Console.ReadLine();

                var birthDay = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDay, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);



            while (true)
            {
                Console.WriteLine(resourceManager.GetString("QuestionWhatDoYouDo", culture)); //"Что вы хотите сделать?"  
                Console.WriteLine(resourceManager.GetString("LetterE", culture)); //"Е - вести прием пищи"
                Console.WriteLine("A - вести упражнение");
                Console.WriteLine("Q - выйти");
                var key = Console.ReadKey();
                Console.WriteLine("");
                
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {
                            var foods = EnterEating();
                            eatinController.Add(foods.Food, foods.Weight);
                            foreach (var item in eatinController.Eating.Foods)
                            {
                                Console.WriteLine($"\t {item.Key.NameFood} - {item.Value}");
                            }
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            var ex = EnterExercise();
                            exerciseController.Add(ex.Activity, ex.Start, ex.Finish);
                            foreach (var item in exerciseController.Exercises)
                            {
                                Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                            }
                            break;
                        }

                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
                Console.ReadLine();
            }            
        }

        private static (DateTime Start, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения");
            var exercise = Console.ReadLine();

            var energy = ParseDouble("расход энергии"); 

            var start = ParseDateTime("начало упражнения");
            var finish = ParseDateTime("конец упражнения");
            var activity = new Activity(exercise, energy);

            return (start, finish, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDay;
            while (true)
            {
                Console.WriteLine($"Ведите {value} в формате dd.mm.yyyy");  
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}!");
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
