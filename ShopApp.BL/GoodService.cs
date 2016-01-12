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

        public void AddGood(GoodViewModel good)
        {
            context.AddGood(good.Name, good.Amount, good.BarCode);
        }

        public void DeleteGood(int id)
        {
            throw new NotImplementedException();
        }

        public void EditGood(GoodViewModel good)
        {
            context.EditGood(good.Id, good.Name, good.Amount, good.BarCode);
        }

        public List<GoodViewModel> GetAll()
        {
            var result = new List<GoodViewModel>();

            var goods = context.GetAll();

            foreach (var item in goods)
                result.Add(new GoodViewModel { Id = item.Id, Name = item.Name, Amount = item.Amount, BarCode = item.BarCode });

            return result;
        }

        public GoodViewModel GetGood(int id)
        {
            GoodViewModel result = new GoodViewModel();

            var good = context.GetGood(id);

            result.Id = good.Id;
            result.Name = good.Name;
            result.Amount = good.Amount;
            result.BarCode = good.BarCode;

            return result;
        }
    }
}
