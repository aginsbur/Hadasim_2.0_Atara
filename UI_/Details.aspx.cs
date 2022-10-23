using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
namespace UI_
{
    public partial class Details : System.Web.UI.Page
    {
        User_Corona_Info currentUser;
        IBL bl = SiteVariables.BL;
        #region*Helper Methods*
        void refreshTable()
        {   if (currentUser != null)
            {
                gv_Vaccines.DataSource = currentUser.Vaccines.ToList();
                gv_Vaccines.DataBind();
                gv_Covid_His.DataSource = currentUser.Covid_History.ToList();
                gv_Covid_His.DataBind();
            }
        }
        void refreshDetails()
        {
            if (currentUser != null)
            {
                tb_id.Text = currentUser.ID.ToString();
                tb_fn.Text = currentUser.First_name;
                tb_ln.Text = currentUser.Last_name;
                tb_dob.Text = currentUser.Date_of_birth.Date.ToString();
                tb_ad.Text = currentUser.Address;
                tb_pn.Text = currentUser.Phone_Number.ToString();
                tb_cell_pn.Text = currentUser.Cell_Phone_Number.ToString();
            }
        }
        public void check_user_fields()
        {
            //check that all of the fields are filled
            if (tb_id.Text == "")
                throw new Exception("Please fill in  the Users id");
            if (tb_fn.Text == "")
                throw new Exception("Please fill in  the Users first name");
            if (tb_ln.Text == "")
                throw new Exception("Please fill in  the  Users second name");
            if (tb_dob.Text == "")
                throw new Exception("Please fill in  the  Users date of birth");
            if (tb_pn.Text == "")
                throw new Exception("Please fill in  the  Users phone numebr");
            if (tb_cell_pn.Text == "")
                throw new Exception("Please fill in  the  Users cell phone number");


        }
        void CheckNewIllness()
        {
            if (tb_ill.Text == "")
                throw new Exception("Please fill in  the  date of illness");
            if (tb_reco.Text == "")
                throw new Exception("Please fill in  the  date of recovery");
        }
        void checkNewVac()
        {
            if (tb_man.Text == "")
                throw new Exception("Please fill in  the manufacterer");
            if (tb_dt.Text == "")
                throw new Exception("Please fill in  the  date of vaccination");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {  //if came through a selected user
            if (Request.QueryString["Parameter"] != null)
            {
                int id = int.Parse(Request.QueryString["Parameter"].ToString());
                currentUser = bl.getUser(id);
            }
            //first time page is loaded
            if (!Page.IsPostBack)
            {
                refreshDetails();
                refreshTable();
            }
           
        }


        protected void Button_update_Click1(object sender, EventArgs e)
        {
            try
            {
                check_user_fields();
                User_Corona_Info updatedUser = new User_Corona_Info
                {
                    ID = int.Parse(tb_id.Text),
                    First_name = tb_fn.Text,
                    Last_name = tb_ln.Text,
                    Date_of_birth = DateTime.Parse(tb_dob.Text),
                    Address = tb_ad.Text,
                    Phone_Number = tb_pn.Text,
                    Cell_Phone_Number = tb_cell_pn.Text,
                    Vaccines = currentUser.Vaccines,
                    Covid_History = currentUser.Covid_History
                };
                bl.updateUser(currentUser, updatedUser);
                currentUser = bl.getUser(updatedUser.ID);
                refreshTable();
                refreshDetails();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "User updates succesfully", true);
            
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
            }
            
            
    }

        protected void Button_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                check_user_fields();
                User_Corona_Info u = new User_Corona_Info
                {
                    ID = int.Parse(tb_id.Text),
                    First_name = tb_fn.Text,
                    Last_name = tb_ln.Text,
                    Date_of_birth = DateTime.Parse(tb_dob.Text),
                    Address = tb_ad.Text,
                    Phone_Number = tb_pn.Text,
                    Cell_Phone_Number = tb_cell_pn.Text
                };
                bl.addNewUser(u);
                refreshTable();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "User added succesfully", true);
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btn_vac_Click(object sender, EventArgs e)
        {
            try
            {   checkNewVac();
                bl.addVaccine(new Vaccine {Date_Of_Vac=DateTime.ParseExact(tb_dt.Text,"dd/MM/yyyy",null),Manufacturer=tb_man.Text,Dose_Number=(Dose_Num)currentUser.Vaccines.Count()+1}, currentUser.ID);
                refreshTable();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btn_ill_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNewIllness();
                bl.addIllness(new Illness_Recovery { Illness = DateTime.ParseExact(tb_ill.Text, "dd/MM/yyyy", null), Recovery = DateTime.ParseExact(tb_reco.Text, "dd/MM/yyyy", null) }, currentUser.ID);
                refreshTable();

              }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}