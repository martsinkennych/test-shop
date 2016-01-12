using ShopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.BL
{
    public interface IGoodService
    {
        void AddGood(string name, int amount, int barcode);
        void EditGood(int id);
        void DeleteGood(int id);
        GoodViewModel GetGood();
        List<GoodViewModel> GetAll();
    }
}
