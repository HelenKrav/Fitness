using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер справочника еды
    /// </summary>
    public class EatingContoller :BaseController
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";
        private readonly User user;

        /// <summary>
        /// Список продкутов.
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Прием пищи.
        /// </summary>
        public Eating Eating { get; }

        public EatingContoller(User user)
        {
            //this , чтобы не было конфликта имен
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым",nameof(user));

            Foods = GetAllFoods();

            Eating = GetEating();
        }

        /// <summary>
        /// Добавление продукта.
        /// </summary>
        /// <param name="food"> Продукт. </param>
        /// <param name="weight"> Вес. </param>
        public void Add(Food food , double weight)
        {
            var product = Foods.SingleOrDefault(f => f.NameFood == food.NameFood);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();

            }
            else 
            { 
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Список продуктов.
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Сохранить.
        /// </summary>
        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
