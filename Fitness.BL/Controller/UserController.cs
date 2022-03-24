using Fitness.BL.Model;
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
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName,DateTime birthDay, double weight, double height)
        {
            //TODO сделать проверку
            var gender = new Gender(userName);
            User = new User(userName, gender,birthDay,weight,height);
            
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                { 
                    User = user; 
                }
                //TODO:что делать, если пользователя не прочитали
            }
        }


        //public UserController()
        //{
        //    var formatter = new BinaryFormatter();
        //    using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
        //    {
        //        if (formatter.Deserialize(fs) is User user)
        //        {
        //            User = user;
        //        }
        //        //TODO:что делать, если пользователя не прочитали
        //    }
        //}
    }
}
