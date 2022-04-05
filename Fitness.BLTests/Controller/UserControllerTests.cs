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
        public void SetNewUserDataTest()
        {
            //arrange
            var userName = Guid.NewGuid().ToString();

            var controller = new UserController(userName);

            var gender = "womanaswamp";
            var birthDay = DateTime.Now.AddYears(-18);
            var weight = 50d;
            var height = 160d;


            //act 
            controller.SetNewUserData(gender, birthDay, weight, height);
 

            //assert
            Assert.IsNotNull(controller.CurrentUser.Name);

                    
        }

        
    }
}