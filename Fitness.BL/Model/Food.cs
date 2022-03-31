using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string NameFood { get; }
       
        /// <summary>
        /// Количество белков.
        /// </summary>
        public double Proteins { get; }
        
        /// <summary>
        /// Количество жиров.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Количество углеводов.
        /// </summary>
        public double Carbs { get; }

        /// <summary>
        /// Калории.
        /// </summary>
        public double Calories { get; }


        /// <summary>
        /// Количество калорий на грамм
        /// </summary>
        private double CaloriesOneGramm
        {
            get { return Calories / 100d; }
        }

        /// <summary>
        /// Количество белков на грамм
        /// </summary>
        private double ProteinsOneGramm
        {
            get { return Proteins / 100d; }
        }

        /// <summary>
        /// Количество жиров на грамм
        /// </summary>
        private double FatsOneGramm
        {
            get { return Fats / 100d; }
        }

        /// <summary>
        /// Количество углеводов на грамм
        /// </summary>
        private double CarbsOneGramm
        {
            get { return Carbs / 100d; }
        }

        public Food(string name): this(name, 0, 0, 0, 0)
        {
            
        }

        public Food(string nameFood, double calories, double proteins, double fats, double carbs)
        {
            if(calories<0)
            {
                throw new ArgumentException("Калории не могут быть отрицательным значением",nameof(calories));
            }
            if (proteins < 0)
            {
                throw new ArgumentException("Белки не могут быть отрицательным значением", nameof(proteins));
            }
            if (fats < 0)
            {
                throw new ArgumentException("Жиры не могут быть отрицательным значением", nameof(fats));
            }
            if (carbs < 0)
            {
                throw new ArgumentException("Углеводы не могут быть отрицательным значением", nameof(carbs));
            }
            NameFood = nameFood ?? throw new ArgumentNullException("Наименование продукта не может быть пустым", nameof(nameFood));
            Calories = calories / 100d;
            Proteins = proteins / 100d;
            Fats = fats / 100d;
            Carbs = carbs / 100d;

        }
    }
}
