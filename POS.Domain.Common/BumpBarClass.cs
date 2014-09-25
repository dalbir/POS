using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class BumpBarClass
    {
        public string Store_ID { get; set; }
        public int BumpBarID { get; set; }
        public int NumberOfPanels { get; set; }
        public int DelayedOrderColor1 { get; set; }
        public int DelayedOrderColor2 { get; set; }
        public int DelayedOrderColor3 { get; set; }
        public int DelayedTime1 { get; set; }
        public int DelayedTime2 { get; set; }
        public int DelayedTime3 { get; set; }
        public int DefaultBackGround { get; set; }
        public int DefaultForeGround { get; set; }
        public int BeepOnNewOrder { get; set; }
        public int Enabled { get; set; }
        public int DisplayCashierID { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int BumpBarController { get; set; }
        public int NumBumpBarsControlled { get; set; }
        public string ObjectID { get; set; }
        public string Name { get; set; }
        public int NumberOfPanelRows { get; set; }
        public int PanelHeaderBackColor { get; set; }
        public int PanelHeaderForeColor { get; set; }
        public int ScreenWidth { get; set; }
    }
}
