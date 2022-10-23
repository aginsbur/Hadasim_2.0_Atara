using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class Program
    {
        static void Main(string[] args)
        {
            //  IDL i=DLFactory.GetDL();
            IDL i = DLFactory.GetDL();
            try
            {
                i.addNewUser(new User_Corona_info
                {
                    ID = 777777777,
                    First_name = "Yissi",
                    Last_name = "Rose",
                    Date_of_birth = DateTime.ParseExact("21/11/1999", "dd/MM/yyyy", null),
                    Address = "bla",
                    Cell_Phone_Number = "0527633232",
                    Phone_Number = "999999999"
                }
            );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                i.addIllness(new Ilness_Recovery
                {
                    Illness = DateTime.ParseExact("04/04/1967", "dd/MM/yyyy", null),
                    Recovery = DateTime.ParseExact("20/12/1999", "dd/MM/yyyy", null)
                }, 777777777);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                i.addVaccine(new Vaccine
                {
                    Date_Of_Vac = DateTime.ParseExact("04/10/2010", "dd/MM/yyyy", null),
                    Manufacturer = "pfeizer",
                    Dose_Number = (Dose_Num)1
                }, 777777777);
                i.addVaccine(new Vaccine
                {
                    Date_Of_Vac = DateTime.ParseExact("02/10/2010", "dd/MM/yyyy", null),
                    Manufacturer = "pfeizer",
                    Dose_Number = (Dose_Num)1
                }, 777777777);
                i.addVaccine(new Vaccine
                {
                    Date_Of_Vac = DateTime.ParseExact("02/11/2010", "dd/MM/yyyy", null),
                    Manufacturer = "pfeizer",
                    Dose_Number = (Dose_Num)1
                }, 777777777);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                i.getUser(0000111);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                i.deleteUser(111111111);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            i.getUser(888888888);
            i.deleteUser(88888888);
            Console.ReadKey();

        }
    }
}
