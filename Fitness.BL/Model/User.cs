using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }
       /// <summary>
       /// Дата рождения.
       /// </summary>
        public DateTime BirthDay { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол. </param>
        /// <param name="birthDay">День рождения. </param>
        /// <param name="weight">Вес. </param>
        /// <param name="height">Рост. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDay, 
                    double weight, 
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.",nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым Или null.", nameof(gender));
            }
            if(birthDay < DateTime.Parse("01.01.1900") || birthDay>=DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDay));
            }
            if(weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше либо равен нулю.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше либо равен нулю.", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Weight = weight;
            Height = height;

        }

        public override string ToString()
        {
            return Name;
        }

    }
}
