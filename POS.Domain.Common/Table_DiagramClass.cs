using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Table_DiagramClass
    {
        public string Store_ID { get; set; }
        public string Section_ID { get; set; }
        public string Table_Number { get; set; }
        public int ShapeType { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Cost_Center_Index { get; set; }
        public int NumSeats { get; set; }
        public int ObjectType { get; set; }
        public int Filled { get; set; }
        public string Description { get; set; }
        public int objectColor { get; set; }
        public int objectTextColor { get; set; } 
    }
}
