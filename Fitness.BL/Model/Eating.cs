using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime MomentTime { get; set; }

        /// <summary>
        /// Список продуктов и их вес.
        /// </summary>
        [XmlIgnoreAttribute]
        public Dictionary<Food,double> Foods { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        [XmlIgnoreAttribute]
        public virtual User User { get; set; }

        public int UserId { get; set; }


        public Eating()
        {
                
        }

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
