using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DL
{
    public class DLImp : IDL
    {
        #region *Singelton* 
        //c-tor
        private DLImp() { }
        //initialized when app is run
        static readonly DLImp instance = new DLImp();
        //public c-tor 
         public static DLImp Instance => instance;
         #endregion
        #region *Helper Methods*
        /// <summary>
        /// executes an sql script on the local data base
        /// </summary>
        /// <param name="com">sql command to execute</param>
        /// <returns>returns the result of the execution</returns>
        SqlCommand execute_Sql_Script(String com)
        {
            try
            {
                SqlConnection connection = new SqlConnection($"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\Owner\\source\\repos\\Hadasim_Project_Atara\\DL\\Database.mdf; Integrated Security = True");
                connection.Open();
                SqlCommand command = new SqlCommand(com, connection);
                command.ExecuteNonQuery();
                if (command.Parameters != null)
                {
                    return command;
                }
                return command;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region *CRUD*
        public void addNewUser(User_Corona_info U)
        {
            try
            {
                execute_Sql_Script(" INSERT INTO Users " +
                "(First_Name, Last_Name, ID, Date_Of_Birth, Address, Phone_Number, Cell_Phone_Number) " +
                $"VALUES ('{U.First_name}', '{U.Last_name}', {U.ID}, " +
                $"CONVERT(DATETIME,'{U.Date_of_birth.Month}-{U.Date_of_birth.Day}-{U.Date_of_birth.Year}'), " +
                $"'{U.Address}','{U.Phone_Number}','{U.Cell_Phone_Number}');");
                U.Covid_History.ForEach(x => addIllness(x,U.ID));
                U.Vaccines.ForEach(x => addVaccine(x, U.ID));

            }
            catch(Exception ex)
            {
                throw new Exception($"Error, a User with id {U.ID} already exhists in the system");
            }
        }
        public void addVaccine(Vaccine v, int id)
        {
            try
            {
                execute_Sql_Script("INSERT INTO Covid_Vac_Records (ID, Date_Of_Vac,Manufacturer) " +
                        $"VALUES({id} ,CONVERT(DATETIME,'{v.Date_Of_Vac}'),'{v.Manufacturer}');");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error,{id} already received a vaccine on {v.Date_Of_Vac.ToString()}");
            }
        }

        public void addIllness(Ilness_Recovery i_r,int id)
        {
            try
            {
                execute_Sql_Script("INSERT INTO Covid_History (ID,Illness,Recovery) " +
                        $"VALUES({id} ,CONVERT(DATETIME,'{i_r.Illness}'),CONVERT(DATETIME,'{i_r.Recovery}'));");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error,{id} already fell ill on {i_r.Illness.ToString()}");
            }
        }
        public void deleteUser(int id)
        {
            try
            {
                getUser(id).Vaccines.ForEach(x => deleteVaccine(id, x));
                getUser(id).Covid_History.ForEach(x => deleteIllness(id, x));
                execute_Sql_Script($"Delete Users Where ID={id};");

            }
            catch (Exception ex)
            {
                throw new Exception($"Error,User {id} could not be found in the system");
            }
        }
       public void deleteVaccine(int id,Vaccine v)
        {
            try
            {
                execute_Sql_Script($"Delete Covid_Vac_Records Where ID={id} AND DATE_Of_Vac='{v.Date_Of_Vac.ToString()}';");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error,User {id} could not be found in the system");
            }
        }
        public void deleteIllness(int id, Ilness_Recovery i_r)
        {
            try
            {

                execute_Sql_Script($"Delete Covid_History Where ID={id} AND Illness='{i_r.Illness.ToString()}';");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error,User {id} could not be found in the system");
            }
        }

        public User_Corona_info getUser(int id)
        {
            try
            {
                User_Corona_info u = new User_Corona_info();
                SqlDataReader dr;
                //get user basic info
                SqlCommand cmd = execute_Sql_Script($"Select * From Users Where ID={id};");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    u.ID = int.Parse(((IDataRecord)dr)[0].ToString());
                    u.First_name = ((IDataRecord)dr)[1].ToString();
                    u.Last_name = ((IDataRecord)dr)[2].ToString();
                    u.Address = ((IDataRecord)dr)[3].ToString();
                    u.Date_of_birth = DateTime.Parse(((IDataRecord)dr)[4].ToString());
                    u.Phone_Number = ((IDataRecord)dr)[5].ToString();
                    u.Cell_Phone_Number = ((IDataRecord)dr)[6].ToString();
                }
                //get user vaccines
                cmd = execute_Sql_Script($"Select * From Covid_Vac_Records Where ID={id};");
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    Vaccine v=new Vaccine
                    {
                        Dose_Number = (Dose_Num)i,
                        Date_Of_Vac = DateTime.Parse(((IDataRecord)dr)[1].ToString()),
                        Manufacturer = ((IDataRecord)dr)[2].ToString()
                    };
                    u.Vaccines.Add(v);
                    i++;
                }
                //get user ilnesses
                cmd = execute_Sql_Script($"Select * From Covid_History Where ID={id};");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   Ilness_Recovery i_r=new Ilness_Recovery
                    {
                        Illness = DateTime.Parse(((IDataRecord)dr)[1].ToString()),
                        Recovery = DateTime.Parse(((IDataRecord)dr)[2].ToString()),
                    };
                    u.Covid_History.Add(i_r);
                }
                return u;
            }
            catch
            {
                throw new Exception($"Error,User {id} could not be found");
 
            }
       }
        public List<User> getUsers()
        {
            
            List<User> l = new List<User>();
            SqlDataReader dr;
            SqlCommand cmd = execute_Sql_Script($"Select * From Users");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User u = new User
                {
                    ID = int.Parse(((IDataRecord)dr)[0].ToString()),
                    First_name = ((IDataRecord)dr)[1].ToString(),
                    Last_name = ((IDataRecord)dr)[2].ToString(),
                    Address = ((IDataRecord)dr)[3].ToString(),
                    Date_of_birth = DateTime.Parse(((IDataRecord)dr)[4].ToString()),
                    Phone_Number = ((IDataRecord)dr)[5].ToString(),
                    Cell_Phone_Number = ((IDataRecord)dr)[6].ToString()
                };
                l.Add(u);
                
            }
            return l;
        }

        public void updateUser(User_Corona_info old_user, User_Corona_info new_user)
        {
            try
            {
                deleteUser(old_user.ID);
                addNewUser(new_user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateVaccine(int old_id,int new_id, Vaccine old_v, Vaccine new_v)
        {
            try
            {
                deleteVaccine(old_id, old_v);
                addVaccine(new_v,new_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateIllness(int old_id, int new_id,Ilness_Recovery old_i_r, Ilness_Recovery new_i_r)
        {
            try
            {
                deleteIllness(old_id, old_i_r);
                addIllness(new_i_r, new_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}



