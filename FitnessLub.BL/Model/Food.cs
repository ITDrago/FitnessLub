
namespace FitnessLub.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Food ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Food name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Proteins
        /// </summary>
        public double Callories { get; set; }
        public double Proteins { get; set; }
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats{ get; set; }
        /// <summary>
        /// Carbohydrates
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories
        /// </summary>

        public virtual ICollection<Eating> Eatings { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        
        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            // TODO: Verification
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            
        }

        public override string ToString()
        {
            return Name;
        }
        public Food() { }
    }

}
