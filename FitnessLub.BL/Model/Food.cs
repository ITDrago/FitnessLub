using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessLub.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Food name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Proteins
        /// </summary>
        public double Proteins { get;}
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats{ get; }
        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Calories
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: Verification
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
