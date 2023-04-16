using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessLub.BL.Controller
{
    public abstract class ControllerBase
    {

        private readonly IDataSaver dataSaver = new SerializeDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            dataSaver.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return dataSaver.Load<T>();
        }
    }
}
    