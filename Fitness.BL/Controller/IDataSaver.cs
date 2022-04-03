using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public interface IDataSaver
    {
        //для сохранения коллекции элементов
        void Save<T>(List<T> item) where T : class;// используем дженерик, так как методы используются для разных типов данных

        //загрузить коллекцию элементов
        List<T> Load<T>() where T:class;

    }
}
