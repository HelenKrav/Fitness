﻿using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController :BaseSQLController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        
        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="userName"> Имя.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();//Получить сохраненный список пользователей

            CurrentUser = Users.SingleOrDefault(u=> u.Name == userName);//Найти текущего пользователя из списка

            if(CurrentUser == null) // Если пользователя в базе нет, создаем нового
            {
                CurrentUser =new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Установить нового пользователя.
        /// </summary>
        /// <param name="genderName"> Пол.</param>
        /// <param name="birthDay">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public void SetNewUserData(string genderName, DateTime birthDay,double weight=1, double height=1) //рост и вес добавили параметрами по умолчанию
        {
            var genderController = new GenderController(genderName);

          //  CurrentUser.Gender = genderController.CurrentGender;// new Gender(genderName);                      
            CurrentUser.GenderId = genderController.CurrentGender.Id;
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        private List<User> GetUsersData()
        {
           return  Load<User>() ?? new List<User>();
        }



        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(CurrentUser);//Users
        }
    
    }
}
