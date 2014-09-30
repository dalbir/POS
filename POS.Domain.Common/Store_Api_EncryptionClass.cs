using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Store_Api_EncryptionClass
    {
        public string Store_Id { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
