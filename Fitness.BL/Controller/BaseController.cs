using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Базовый контроллер.
    /// </summary>
    public abstract class BaseController   // базовый контроллер, от которого будут наследоваться другие
    {
        /// <summary>
        /// Сохранить.
        /// </summary>
        /// <typeparam name="T">тип данных. </typeparam>
        /// <param name="fileName"> имя файла. </param>
        /// <param name="item"> наименование данных. </param>
        public void Save<T>(string fileName, T item) // используем дженерик, так как методы используются для разных типов данных
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }


        /// <summary>
        /// Загрузить данные
        /// </summary>
        /// <typeparam name="T"> тип данных. </typeparam>
        /// <param name="fileName"> имя файла. </param>
        /// <returns></returns>
        public T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default;
                }
            }
        }


    }
}
