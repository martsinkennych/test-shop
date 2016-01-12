﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;
using System.Web;

namespace ShopApp.Dal
{
    public class GoodRepository : IContext
    {
        public string ConnString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
            }
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
            string query = "update GoodsTable set Name = '" + name + "', Amount = " + amount.ToString();
                   query += ", BarCode = " + barcode.ToString() + " where Id = " + id.ToString();

            OleDbConnection cnn = new OleDbConnection(ConnString);
            OleDbCommand cmd = new OleDbCommand(query, cnn);
            cmd.CommandType = System.Data.CommandType.Text;

            cnn.Open();

            cmd.ExecuteNonQuery();
            
            cnn.Close();
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
    }
}
