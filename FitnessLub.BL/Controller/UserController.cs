using FitnessLub.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessLub.BL.Controller
{   /// <summary>
    /// User Controller.  
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Application user.
        /// </summary>
        private User User { get; }
        /// <summary>
        /// Create new user controller.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName,
                              string genderName,
                              DateTime birthData,
                              double weight,
                              double height )
        {
            // TODO: Verification of data
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthData, weight, height);
            
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream,User);
            }
        }
        /// <summary>
        /// Load user data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fileStream) is User user)
                {
                    User = user;
                }
                // TODO: What doing if User file not read ?  
            }
        }
    }
}
