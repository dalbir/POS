﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Pizza_RegionsClass
    {
        public int ID { get; set; }
        public string Store_ID { get; set; }
        public string Name { get; set; }
        public float PriceMultiplier { get; set; }
        public float QuantityMultiplier { get; set; }
    }
}
