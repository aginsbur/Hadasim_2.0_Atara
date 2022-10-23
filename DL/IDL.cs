using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IDL /*CRUD*/
    {
        void addNewUser(User_Corona_info U);
        void addVaccine(Vaccine v, int id);
        void addIllness(Ilness_Recovery i_r,int id);
        User_Corona_info getUser(int id);
        List<User> getUsers();
        void updateUser(User_Corona_info old_user, User_Corona_info new_user);
        void updateVaccine(int old_id, int new_id,Vaccine old_v, Vaccine new_v);
        void updateIllness(int old_id, int new_id, Ilness_Recovery old_i_r, Ilness_Recovery new_i_r);
        void deleteUser(int id);

    }
}
