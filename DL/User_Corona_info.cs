using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class User_Corona_info: User
    {
        List<Vaccine> vaccines = new List<Vaccine>(4);
        List<Ilness_Recovery> covid_history = new List<Ilness_Recovery>();
        public List<Vaccine> Vaccines { get => vaccines; set => vaccines = value; }
        public List<Ilness_Recovery> Covid_History { get => covid_history; set => covid_history = value; }

    }
}
