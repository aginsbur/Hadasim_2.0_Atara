using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using BL;
using System.Data;
using System.Data.SqlClient;

namespace UI_
{
    /// <summary>
    /// static variable to be used accross the website
    /// </summary>
    public class SiteVariables
    {
        private static IBL bl = BLFactory.GetBL();
    public static IBL BL
        {
            get { return bl; }
        }
    }
        public partial class _Default : Page
    {

        IBL bl = SiteVariables.BL;

        protected void Page_Load(object sender, EventArgs e)
        {
            refresh_table();
        }
        #region *Helper Methods*
        public void refresh_table()
        {
            GridView1.DataSource = bl.getUsers().ToList();
            GridView1.DataBind();

        }
        #endregion   
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(GridView1.SelectedDataKey.Value);

        }
        protected void Select(object sender,GridViewSelectEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.NewSelectedIndex];
            Response.Redirect("Details.aspx?Parameter=" + int.Parse(row.Cells[0].Text));

        }

        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            bl.deleteUser(int.Parse(row.Cells[0].Text));
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "User Succefully deleted" + "');", true);
            refresh_table();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Details.aspx");
        }
    }
}