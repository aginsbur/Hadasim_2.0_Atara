using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Illness_Recovery
    {
        DateTime illness;
        DateTime recovery;
        public DateTime Illness { get => illness; set => illness = value; }
        public DateTime Recovery { get => recovery; set => recovery = value; }
    }
}
