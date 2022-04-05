using Fitness.BL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class BaseSQLController
    {

        protected readonly IDataSaverSQL manager = new DataBaseSaverSQL();


        public void Save<T>(T item) where T : class
        {
            manager.Save(item);
        }


        public List<T> Load<T>() where T : class
        {
            return manager.Load<T>();

        }
    }
}
