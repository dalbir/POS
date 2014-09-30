using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class DVRsClass
    {
        public int ObjectID { get; set; }
        public string Store_ID { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int SerialPort { get; set; }
    }
}
