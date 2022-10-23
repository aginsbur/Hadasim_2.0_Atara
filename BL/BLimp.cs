using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
     class BLimp : IBL
    {
        readonly IDL dl = DLFactory.GetDL();

        #region *Singelton* 
        //c-tor
        private BLimp() { }
        //initialized when app is run
        static readonly BLimp instance = new BLimp();
        //public c-tor 
        public static BLimp Instance => instance;
        #endregion
        #region ***Bl2DlConverters***
        private DL.Ilness_Recovery convertBLI2DL(BL.Illness_Recovery i)
        {
            DL.Ilness_Recovery iDL = new DL.Ilness_Recovery();
            i.CopyPropertiesTo(iDL);
            return iDL;
        }
       
        private DL.Vaccine convertBLVac2DL(BL.Vaccine v)
        {
            DL.Vaccine vDO = new DL.Vaccine();
            v.CopyPropertiesTo(vDO);
            return vDO;
        }
      
        private BL.User convertDLUser2BL(DL.User user)
        {
            BL.User UserBL = new BL.User();
            user.CopyPropertiesTo(UserBL);
            return UserBL;
        }
       
        private BL.User_Corona_Info convertDLUser_Det_2BL(DL.User_Corona_info user)
        {
            BL.User_Corona_Info UserBL = new BL.User_Corona_Info();
            user.Vaccines.ForEach(x => UserBL.Vaccines.Add(new BL.Vaccine { Date_Of_Vac = x.Date_Of_Vac,Manufacturer=x.Manufacturer,Dose_Number=(BL.Dose_Num)x.Dose_Number }));
            user.Covid_History.ForEach(x => UserBL.Covid_History.Add(new BL.Illness_Recovery { Illness=x.Illness,Recovery=x.Recovery }));
            user.CopyPropertiesTo(UserBL);
            return UserBL;
        }

        private DL.User_Corona_info convertBLUser_Det_2DL(BL.User_Corona_Info user)
        {
            DL.User_Corona_info UserDL = new DL.User_Corona_info();
            user.Vaccines.ForEach(x => UserDL.Vaccines.Add(new DL.Vaccine { Date_Of_Vac = x.Date_Of_Vac, Manufacturer = x.Manufacturer, Dose_Number = (DL.Dose_Num)x.Dose_Number }));
            user.Covid_History.ForEach(x => UserDL.Covid_History.Add(new DL.Ilness_Recovery { Illness = x.Illness, Recovery = x.Recovery }));

            user.CopyPropertiesTo(UserDL);
            return UserDL;
        }
        #endregion
        #region*Crud User*
        void checkValidity(BL.User_Corona_Info u)
        {
            if (u.ID < 100000000 || u.ID > 999999999)
                throw new Exception("ID must be 9 digits long");
            if (u.Phone_Number.Length < 9 || u.Phone_Number.Length > 9)
                throw new Exception("Phone number must be 9 digits long");
            if (u.Cell_Phone_Number.Length < 10 || u.Cell_Phone_Number.Length > 10)
                throw new Exception("Cell Phone number must be 10 digits long");
        }
        public void addNewUser(BL.User_Corona_Info u)
        {
            try
            {
                checkValidity(u);
                dl.addNewUser(convertBLUser_Det_2DL(u));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public User_Corona_Info getUser(int id)
        {
            try
            {
                return convertDLUser_Det_2BL(dl.getUser(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void updateUser(BL.User_Corona_Info old_user, BL.User_Corona_Info new_user)
        {
            try
            {
                checkValidity(new_user);
                //if the id was changed, then update the vaccine and illness id's
                if (old_user.ID != new_user.ID)
                {
                    foreach (Vaccine v in old_user.Vaccines)
                        dl.updateVaccine(old_user.ID, new_user.ID, convertBLVac2DL(v), convertBLVac2DL(v));
                    foreach (Illness_Recovery i_r in old_user.Covid_History)
                        dl.updateIllness(old_user.ID, new_user.ID, convertBLI2DL(i_r), convertBLI2DL(i_r));

                }
                dl.updateUser(convertBLUser_Det_2DL(old_user), convertBLUser_Det_2DL(new_user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public void deleteUser(int id)
        {
            try
            {
                dl.deleteUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BL.User> getUsers()
        {
            List<DL.User> temp = dl.getUsers().ToList();
            List<BL.User> res = new List<BL.User>();
            temp.ForEach(x => res.Add(convertDLUser2BL(x)));
            return res;
        }
        #endregion


        public void addVaccine(BL.Vaccine v, int id)
        {
           
            try
            {
                List<DL.Vaccine> vac = dl.getUser(id).Vaccines.ToList();
                //check if user already had four doses
                if (vac.Count() == 4)
                    throw new Exception("Error, maximum number of Covid vaccines is 4");
                //check that the new dose is given later then the previous dose
                if (vac.Count()!=0 && vac.Last().Date_Of_Vac.CompareTo(v.Date_Of_Vac) > 1)
                    throw new Exception($"Error, the last dose was given on {vac.Last().Date_Of_Vac.ToString()}, please enter a later date");
                dl.addVaccine(convertBLVac2DL(v), id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addIllness(BL.Illness_Recovery i_r, int id)
        {   
            
            try
            {
                if (i_r.Illness.CompareTo(i_r.Recovery) > 0)
                    throw new Exception("Error, the recovery date must be later than the date of illness");
                dl.addIllness(convertBLI2DL(i_r), id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void updateVaccine(int old_id, int new_id, BL.Vaccine old_v, BL.Vaccine new_v)
        {

            try
            {
                dl.updateVaccine(old_id, new_id, convertBLVac2DL(old_v), convertBLVac2DL(new_v));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateIllness(int old_id, int new_id, BL.Illness_Recovery old_i_r, BL.Illness_Recovery new_i_r)
        {
            try
            {
                if (new_i_r.Illness.CompareTo(new_i_r.Recovery) > 0)
                    throw new Exception("Error, the recovery date must be later than the date of illness");
                dl.updateIllness(old_id, new_id,convertBLI2DL(old_i_r), convertBLI2DL(new_i_r));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
    }
}
