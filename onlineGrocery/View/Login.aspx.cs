using onlineGrocery.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineGrocery.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }
        public static string LName;
        int LKey;

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        Models.Functions Con;
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string LEmail = Email.Value;
            string LPassword = Password.Value;
            string query = "SELECT U.Id, U.Name, U.Email, U.Password, R.Name as Role FROM [dbo].[User] U LEFT JOIN [dbo].[Role] R ON U.RoleId = R.Id where U.Email = @Email and U.Password = @Password";
            var parametersLogin = new Dictionary<string, object>
                {
                    {"@Email", LEmail},
                    {"@Password", Cryptography.HashPassword(LPassword)}
                };

            DataTable dt = Con.GetData(query, parametersLogin);
            string Role = dt.Rows.Count > 0 ? dt.Rows[0]["Role"].ToString() : string.Empty;
            if(dt.Rows.Count == 0)
            {
                msg.InnerText = "Invalid User!!!";
            }
            else if(dt.Rows.Count > 0)
            {
                if(Role == "Admin")
                {
                    LName = Email.Value;
                    LKey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Admin/Dashboard.aspx");
                }
                else if (Role == "Customer")
                {
                    LName = Email.Value;
                    LKey = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Customer/Biling.aspx");
                }
            }
        }
    }
}