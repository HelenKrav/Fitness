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
        public DateTime MomentTime { get; }
        public Dictionary<Food,double> Foods { get;  }
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
        /// <param name="food"> наименование продукта.</param>
        /// <param name="weight"> вес.</param>
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
