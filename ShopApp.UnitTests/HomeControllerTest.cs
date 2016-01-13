using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp.Controllers;
using System.Web.Mvc;
using ShopApp.BL;
using ShopApp.Dal;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Configuration;
using ShopApp.ViewModels;
using Moq;

namespace ShopApp.UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestHomeController_Edit_ModelIsNotNull()
        {
            // Arrange
            var goodResult = new GoodViewModel { Id = 1, Name = "Bread Borodinskiy", Amount = 80, BarCode = 54329876 };
            var mock = new Mock<IGoodService>();
            mock.Setup(m => m.GetGood(1)).Returns(goodResult);
            HomeController controller = new HomeController(mock.Object);
            
            // Act
            ViewResult result = controller.Edit(1) as ViewResult;
            
            // Assert
            Assert.IsNotNull(result.Model);
        }
    }    
}
