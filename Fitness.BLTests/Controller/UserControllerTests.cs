using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    // TODO доделать тесты для неправильных, критических значений

namespace Fitness.BL.Controller.Tests   //делаем проект тестов с помощью VS  и нужного нам класса . Создаются заглушки для все публичных методов класса
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()  //в принципе не нужен тест конструктора по умолчанию
        {
            int a = 5;
            int b= 2;
            //arrange

            //act
            int c = a / b;

            //assert

            Assert.AreEqual(2,c);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthDay = DateTime.Now.AddYears(-18);
            var weight = 80d;
            var height = 160d;

            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthDay, weight, height);

            var controller2 = new UserController(userName);
            
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDay, controller2.CurrentUser.BirthDay);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
                    
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            
            var controller = new UserController(userName);
            
            Assert.AreEqual(userName, controller.CurrentUser.Name); 
        }
    }
}