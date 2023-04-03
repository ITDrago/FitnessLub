using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessLub.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessLub.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            // Arrange 
            var userName = Guid.NewGuid().ToString();

            //Act 
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName,controller.CurrentUser.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        { 
            //Arrage
            var userName = Guid.NewGuid().ToString();
            var birthData = DateTime.Now.AddYears(-23);
            var weight = 90;
            var height = 180;
            var gender = "man";
            var controller = new UserController(userName);
            // Act 
            controller.SetNewUserData(gender, birthData, weight, height);
            var controller2 = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
        }
    }
}