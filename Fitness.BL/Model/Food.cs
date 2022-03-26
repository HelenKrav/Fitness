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
        public string NameFood { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbs { get; }
        public double Calories { get; }


        private double CaloriesOneGramm
        {
            get { return Calories / 100d; }
        }
        private double ProteinsOneGramm
        {
            get { return Proteins / 100d; }
        }
        private double FatsOneGramm
        {
            get { return Fats / 100d; }
        }
        private double CarbsOneGramm
        {
            get { return Carbs / 100d; }
        }

        public Food(string name): this(name, 0, 0, 0, 0)
        { }

        public Food(string name, double calories, double proteins, double fats, double carbs)
        {
            //проверку
            NameFood = name;
            Calories = calories / 100d;
            Proteins = proteins / 100d;
            Fats = fats / 100d;
            Carbs = carbs / 100d;

        }
    }
}
