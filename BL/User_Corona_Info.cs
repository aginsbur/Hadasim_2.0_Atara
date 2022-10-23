using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class User_Corona_Info: User
    {
        List<Vaccine> vaccines = new List<Vaccine>(4);
        List<Illness_Recovery> covid_history = new List<Illness_Recovery>();
        public List<Vaccine> Vaccines { get => vaccines; set => vaccines = value; }
        public List<Illness_Recovery> Covid_History {  get => covid_history; set => covid_history = value;
        }

    }

}
