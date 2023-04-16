
namespace FitnessLub.BL.Model
{   /// <summary>
    /// Gender.     
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Gender ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// Create new Gender.
        /// </summary>
        /// <param name="name">Gender name. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender name cannot be empty or null!", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        public Gender() { }
    }
}

