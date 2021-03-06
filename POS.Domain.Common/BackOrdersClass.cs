﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace POS.Domain.Common
{
   public class BackOrdersClass
    {
        public int BONum { get; set; }
        public string Store_ID { get; set; }
        public DateTime DateTime { get; set; }
        public string CustNum { get; set; }
        public string ItemNum { get; set; }
        public double Quan { get; set; } //updated from float to double
        public string Type { get; set; }
        public string Status { get; set; }
        public int Invoice_Number { get; set; }
        public DateTime FillDate { get; set; }
        public int Dirty { get; set; } 

       //
        public string backOrederPosition { get; set; }
       //update
        public DataTable LoadOrderes { get; set; }
        public string flage { get; set; }
    }
}
