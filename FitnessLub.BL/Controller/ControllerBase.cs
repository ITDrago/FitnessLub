using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessLub.BL.Controller
{
    public class ControllerBase
    {
        public void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, item);
            }
        }

        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fileStream.Length > 0 && formatter.Deserialize(fileStream) is T items )
                {
                    return items;
                }
                else
                {
                    return default(T);
                }

            }
        }
    }
}
