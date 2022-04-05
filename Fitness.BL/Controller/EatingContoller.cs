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
    public class EatingContoller :BaseSQLController
    {

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
        public void AddFood(Food food , double weight)
        {
            var product = Foods.SingleOrDefault(f => f.NameFood == food.NameFood);
            if(product == null)
            {
                Foods.Add(food);
                SaveFood();
                Eating.AddEating(food, weight);
                Eating.FoodId = food.Id;
                SaveEating();

            }
            else 
            { 
                Eating.AddEating(product, weight);
                SaveEating();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        /// <summary>
        /// Список продуктов.
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        /// <summary>
        /// Сохранить.
        /// </summary>
        private void SaveFood()
        {
            Save(Foods.LastOrDefault());
        }

        private void SaveEating()
        {
            Save(Eating); //new List<Eating> { Eating }
        }
    }
}
