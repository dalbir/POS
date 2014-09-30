using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Time_Clock_Cash_CountClass
    {
        public string Store_ID { get; set; }
        public int ID { get; set; }
        public int NumPennies { get; set; }
        public int NumNickels { get; set; }
        public int NumDimes { get; set; }
        public int NumQuarters { get; set; }
        public int NumHalfDollars { get; set; }
        public int NumDollars { get; set; }
        public int NumFives { get; set; }
        public int NumTens { get; set; }
        public int NumTwenties { get; set; }
        public int NumFifties { get; set; }
        public int NumHundreds { get; set; }  
    }
}
