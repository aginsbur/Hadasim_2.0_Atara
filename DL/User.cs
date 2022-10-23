using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class User
    {
        int id;
        string first_name;
        string last_name;
        DateTime date_of_birth;
        string address;
        String phone_Number;
        String cell_Phone_Number;
        public int ID { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name=value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public string Address { get => address; set => address = value; }
        public String Phone_Number { get => phone_Number; set => phone_Number = value; }
        public string Cell_Phone_Number { get => cell_Phone_Number; set => cell_Phone_Number = value; }

    }
}
