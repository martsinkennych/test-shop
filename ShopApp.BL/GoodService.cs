using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.ViewModels;
using ShopApp.Dal;

namespace ShopApp.BL
{
    public class GoodService : IGoodService
    {
        IContext context;

        public GoodService(IContext c)
        {
            context = c;
        }

        public void AddGood(string name, int amount, int barcode)
        {
            throw new NotImplementedException();
        }

        public void DeleteGood(int id)
        {
            throw new NotImplementedException();
        }

        public void EditGood(int id)
        {
            throw new NotImplementedException();
        }

        public List<GoodViewModel> GetAll()
        {
            var result = new List<GoodViewModel>();

            var goods = context.GetAll();

            foreach (var item in goods)
                result.Add(new GoodViewModel { Id = item.Id, Name = item.Name, Amount = item.Amount, BarCode = item.BarCode });

            return result;
        }

        public GoodViewModel GetGood()
        {
            throw new NotImplementedException();
        }
    }
}
