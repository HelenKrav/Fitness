using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class GenderControllerTests
    {
        [TestMethod()]
        public void GenderControllerTest()
        {
            var gender = "womanas";
            
            var genderController = new GenderController(gender);

           // genderController.SetNewGenderData(gender);           


            Assert.AreEqual(gender, genderController.CurrentGender.Name);

        }
    }
}