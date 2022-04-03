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

  //      protected readonly IDataSaver manager = new SerializeDataSaver();

         protected readonly IDataSaver manager = new DataBaseSaver();

        
        public void Save<T>(List<T> item) where T: class 
        {
            manager.Save(item);
        }

      
        public List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
           
        }


    }
}
