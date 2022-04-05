using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Core
{
    internal class DataBaseSaverSQL : IDataSaverSQL
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(T item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
    }
}
