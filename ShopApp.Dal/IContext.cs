using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dal
{
    public interface IContext
    {
        void AddGood(string name, int amount, int barcode);
        void EditGood(int id, string name, int amount, int barcode);
        void DeleteGood(int id);
        Good GetGood(int id);
        List<Good> GetAll();
    }
}
