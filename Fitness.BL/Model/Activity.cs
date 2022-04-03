using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        /// <summary>
        /// Название активности.
        /// </summary>
        public string NameActivity { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        /// <summary>
        /// Количество калорий, сжигающих за минуту
        /// </summary>
        public double CaloriesInMinute { get; set; }

        public Activity()
        {
                
        }

        /// <summary>
        /// Активность.
        /// </summary>
        /// <param name="nameActivity">Вид активности. </param>
        /// <param name="сaloriesInMinute">Количество калорий, сжигающих за минуту.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Activity(string nameActivity, double сaloriesInMinute)
        {
            if (сaloriesInMinute < 0)
            {
                throw new ArgumentException("Неверный диапазон, должен быть отрицательным ", nameof(сaloriesInMinute));
            }

            NameActivity = nameActivity ?? throw new ArgumentNullException("Вид активности не может быть пустым", nameof(nameActivity));
            CaloriesInMinute = сaloriesInMinute;
        }

        public override string ToString()
        {
            return NameActivity;
        }
    }
}
