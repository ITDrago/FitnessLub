using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace FitnessLub.BL.Controller
{
    public class SerializeDataSaver : IDataSaver
    {

        public List<T> Load<T>() where T : class 
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fileStream.Length > 0 && formatter.Deserialize(fileStream) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }

            }
        }

        public void Save<T>(List<T>  item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, item);
            }

        }
    }
}
