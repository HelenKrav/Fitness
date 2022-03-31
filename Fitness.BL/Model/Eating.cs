using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime MomentTime { get; }
        
        /// <summary>
        /// Список продуктов и их вес.
        /// </summary>
        public Dictionary<Food,double> Foods { get;  }
        
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }



        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым",nameof(user));
            MomentTime = DateTime.Now; //UtcNow
            Foods = new Dictionary<Food,double>();
        }


        /// <summary>
        /// Добавление продукта.
        /// </summary>
        /// <param name="food"> Наименование продукта.</param>
        /// <param name="weight"> Вес.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.NameFood.Equals(food.NameFood));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }    
    }
}
