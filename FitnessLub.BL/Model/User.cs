
namespace FitnessLub.BL.Model
{/// <summary>
 /// User.
 /// </summary>
    [Serializable]
    public class User
    {
        #region Properties

        /// <summary>
        /// User ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name. 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gender.
        /// </summary>
        
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        /// <summary>
        /// Birth Data.
        /// </summary>
        public DateTime BirthData { get; set; }
        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthData.Year; }}
        public User() { }

        #endregion
        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthData">Birth Data.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name,
                    Gender gender,
                    DateTime birthData,
                    double weight,
                    double height)
        {

            #region Verification of data
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User Name cannot be empty or null!", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("User Gender cannot be null!", nameof(gender));
            }
            if (birthData < DateTime.Parse("01.01.1900") || birthData >= DateTime.Now)
            {
                throw new ArgumentException("Incorrect BirthData Value!", nameof(birthData));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Incorrect Weight Value!", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Incorrect Height Value!", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthData = birthData;
            Weight = weight;
            Height = height;
        }


        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User Name cannot be empty or null!", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }


    }
}
