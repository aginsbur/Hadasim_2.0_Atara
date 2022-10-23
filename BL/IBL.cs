using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
namespace BL
{
    public interface IBL /*CRUD*/
    {
        void addNewUser(BL.User_Corona_Info U);
        void addVaccine(BL.Vaccine v, int id);
        void addIllness(BL.Illness_Recovery i_r, int id);
        BL.User_Corona_Info getUser(int id);
        List<BL.User> getUsers();
        void updateUser(BL.User_Corona_Info old_user, BL.User_Corona_Info new_user);
        void updateVaccine(int old_id, int new_id, BL.Vaccine old_v, BL.Vaccine new_v);
        void updateIllness(int old_id, int new_id, BL.Illness_Recovery old_i_r, BL.Illness_Recovery new_i_r);
        void deleteUser(int id);
    }
}
