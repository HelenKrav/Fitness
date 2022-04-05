using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fitness.BL.Controller
{
    public class SerializeXmlDataSaver: IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var formatter = new XmlSerializer(typeof(T));
            var fileName = typeof(T).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var formatter = new XmlSerializer(typeof(List<T>));
            var fileName = typeof(T).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
