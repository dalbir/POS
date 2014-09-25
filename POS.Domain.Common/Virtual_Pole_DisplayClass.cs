using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Virtual_Pole_DisplayClass
    {
        public string Store_ID { get; set; }
        public int TemplateType { get; set; }
        public string HTMLTemplate { get; set; }
        public string ThemeName { get; set; }
        public int DisplayTime { get; set; }
        public string ImageFolder { get; set; }
        public string Logo { get; set; }
        public string TextSize { get; set; }
        public int DisplaySlideshow { get; set; }
        public int NumDisplayItems { get; set; }
    }
}
