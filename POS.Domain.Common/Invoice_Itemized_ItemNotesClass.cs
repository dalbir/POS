﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Itemized_ItemNotesClass
    {
        public string Store_ID { get; set; }
        public int Invoice_Number { get; set; }
        public int LineNum { get; set; }
        public string Notes { get; set; }
    }
}
