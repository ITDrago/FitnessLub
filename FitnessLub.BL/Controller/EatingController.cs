using FitnessLub.BL.Model;

namespace FitnessLub.BL.Controller
{
    public class EatingController : ControllerBase
    {

            
        private readonly User User;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User User)
        {
            this.User = User ?? throw new ArgumentNullException("User cannot be empty!", nameof(User));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }

    }
}

