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

namespace ShopApp.UnitTests
{
    [TestClass]
    public class GoodServiceTest
    {
        [TestMethod]
        public void TestGoodService_GetGood_ShouldReturnGood()
        {
            // Arrange
            var goodResult = new GoodViewModel { Id = 1, Name = "Bread Borodinskiy", Amount = 80, BarCode = 54329876 };
            GoodService ps = new GoodService(new FakeContext());
            // Act
            var result = ps.GetGood(1);
            // Assert
            Assert.AreEqual(true, (goodResult.Id == result.Id) 
                                  && (goodResult.Amount == result.Amount) 
                                  && (goodResult.Name == result.Name) 
                                  && (goodResult.BarCode == result.BarCode));
        }

        [TestMethod]
        public void TestGoodService_GetAll_ShouldReturnAllGoods()
        {
            // Arrange
            var goodResult = new List<GoodViewModel>
            {
                new GoodViewModel { Id = 1, Name = "Bread Borodinskiy", Amount = 80, BarCode = 54329876 },
                new GoodViewModel { Id = 4, Name = "Ice-cream Gosha 80 gr", Amount = 120, BarCode = 99990000 },
                new GoodViewModel { Id = 5, Name = "Cigarettes Monte Carlo", Amount = 30, BarCode = 92926741 },
                new GoodViewModel { Id = 8, Name = "Chocolate Alpen Gold", Amount = 120, BarCode = 33445522 }
            };
            GoodService ps = new GoodService(new FakeContext());
            // Act
            var result = ps.GetAll();
            // Assert
            Assert.AreEqual(true, (goodResult[0].Id == result[0].Id) 
                                    && (goodResult[1].Name == result[1].Name)
                                    && (goodResult[2].Amount == result[2].Amount) 
                                    && (goodResult[3].BarCode == result[3].BarCode));
        }
    }

    class FakeContext : IContext
    {
        public string ConnString
        {
            get
            {
                return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\!!!TEST\\ShopApp\\ShopApp\\App_Data\\ShopDB.mdb";
            }
        }

        public Good GetGood(int id)
        {
            Good result = new Good();

            string query = "select * from [GoodsTable] where Id = " + id.ToString();
            OleDbConnection cnn = new OleDbConnection(ConnString);
            OleDbCommand cmd = new OleDbCommand(query, cnn);
            cmd.CommandType = System.Data.CommandType.Text;

            cnn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            object[] data;

            reader.Read();

            data = new object[reader.FieldCount];
            reader.GetValues(data);

            result.Id = Convert.ToInt32(data[0]);
            result.Name = data[1].ToString();
            result.Amount = Convert.ToInt32(data[2]);
            result.BarCode = Convert.ToInt32(data[3]);

            reader.Close();
            cnn.Close();

            return result;
        }

        public List<Good> GetAll()
        {
            List<Good> result = new List<Good>();

            string query = "select * from [GoodsTable]";
            OleDbConnection cnn = new OleDbConnection(ConnString);
            OleDbCommand cmd = new OleDbCommand(query, cnn);
            cmd.CommandType = System.Data.CommandType.Text;

            cnn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            object[] data;

            while (reader.Read())
            {
                data = new object[reader.FieldCount];
                reader.GetValues(data);

                result.Add(
                    new Good
                    {
                        Id = Convert.ToInt32(data[0]),
                        Name = data[1].ToString(),
                        Amount = Convert.ToInt32(data[2]),
                        BarCode = Convert.ToInt32(data[3])
                    });
            }

            reader.Close();
            cnn.Close();

            return result;
        }

        public void AddGood(string name, int amount, int barcode)
        {
            throw new NotImplementedException();
        }

        public void DeleteGood(int id)
        {
            throw new NotImplementedException();
        }

        public void EditGood(int id, string name, int amount, int barcode)
        {
            throw new NotImplementedException();
        }            
    }
}
