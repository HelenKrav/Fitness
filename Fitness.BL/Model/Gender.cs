﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        [XmlIgnoreAttribute]
        public virtual ICollection<User> Users { get; set; }

        public Gender()
        {

        }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или пустым", nameof(name));
            }

            Name = name;

        }


        public override string ToString()
        {
            return Name;

        }
    }
}
