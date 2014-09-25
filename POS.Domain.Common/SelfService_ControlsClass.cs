using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class SelfService_ControlsClass
    {
        public string StoreID { get; set; }
        public int ControlID { get; set; }
        public int ParentControlID { get; set; }
        public int ControlType { get; set; }
        public string ControlName { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public string Text { get; set; }
        public string TextFont { get; set; }
        public string TextFontSize { get; set; }
        public int TextAlignment { get; set; }
        public string PictureURI { get; set; }
        public int PictureSizeMode { get; set; }
        public string ClickTarget { get; set; }
        public int ClickTargetType { get; set; }
        public int RelativePosition { get; set; }
        public int PictureAlignment { get; set; }
        public string BackColorSelected { get; set; }
        public int Identifier { get; set; }
        public string ModifierParentItemNum { get; set; }
        public string ModifierGroupNum { get; set; }
    }
}
