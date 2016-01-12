﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dal
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int BarCode { get; set; }
    }
}
