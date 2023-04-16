
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessLub.BL.Model
{
    /// <summary>
    /// Eating food
    /// </summary>
    
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        public DateTime Moment { get; set; }

        [NotMapped]
        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Eating() { }
        public Eating(User User)
        {
            this.User = User ?? throw new ArgumentNullException("User Name cannot be empty or null!", nameof(User));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        { 
            var product =  Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
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
