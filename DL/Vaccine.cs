using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{  
    public enum Dose_Num { first=1,second,third,fourth}
    public class Vaccine
    {
         String manufacturer;
        Dose_Num dose_number;
        DateTime date_of_vac;
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public Dose_Num Dose_Number { get => dose_number; set => dose_number = value; }
        public DateTime Date_Of_Vac { get => date_of_vac; set => date_of_vac = value; }
    }
}
