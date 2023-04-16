
namespace FitnessLub.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity(string name, double caloriesPerMinute)
        {
            // Verification
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
        public Activity() { }
    }
}
