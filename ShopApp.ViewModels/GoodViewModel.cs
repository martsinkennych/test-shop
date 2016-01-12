using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ViewModels
{
    public class GoodViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Amoubt must be between 0 and 10000")]
        public int Amount { get; set; }
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "Bar-code must be between 10000000 and 99999999")]
        public int BarCode { get; set; }
    }
}
