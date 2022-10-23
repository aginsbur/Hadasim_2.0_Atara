using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DLFactory
    { 
        public static IDL GetDL() {

            return DLImp.Instance;
        }
    }
}
