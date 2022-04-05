using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Core
{
    public interface IDataSaverSQL
    {

        //для сохранения коллекции элементов
        void Save<T>(T item) where T : class;// используем дженерик, так как методы используются для разных типов данных

        //загрузить коллекцию элементов
        List<T> Load<T>() where T : class;
    }
}
