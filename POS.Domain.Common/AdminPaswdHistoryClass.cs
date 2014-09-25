using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common.AdminPswdHistory
{
   public class AdminPaswdHistoryClass
    {
        public string Store_Id { get; set; }
        public string Password { get; set; }
        public string Salt_Key { get; set; }
        public DateTime CreationDatedatetime { get; set; }
    }
}
