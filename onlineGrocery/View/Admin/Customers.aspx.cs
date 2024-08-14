using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using onlineGrocery.Helpers;

namespace onlineGrocery.View.Admin
{
    public partial class Customers : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCustomers();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowCustomers()
        {
            string Query = "SELECT U.Id, U.Name, U.Email, U.Phone, U.Address, R.Name as Role, U.Photo FROM [dbo].[User] U LEFT JOIN [dbo].[Role] R ON U.RoleId = R.Id";
            CustomerGV.DataSource = Con.GetData(Query, null);
            CustomerGV.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CustomerName.Value) ||
                    string.IsNullOrWhiteSpace(CustomerEmail.Value) ||
                    string.IsNullOrWhiteSpace(CustomerPhone.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    string CName = CustomerName.Value;
                    string CEmail = CustomerEmail.Value;
                    string CPassword = "Ngopibarengyuk2022";
                    string CPhone = CustomerPhone.Value;
                    string CAddress = CustomerAddress.Value;
                    string CPhoto = "";
                    string CRole = "2";

                    if (CustomerPhoto.PostedFile != null && CustomerPhoto.PostedFile.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(CustomerPhoto.PostedFile.FileName);
                        string fileName = CName + extension;
                        string filePath = Server.MapPath("../../Asset/Images/User/") + fileName;
                        CustomerPhoto.PostedFile.SaveAs(filePath);
                        CPhoto = "../../Asset/Images/User/" + fileName;
                    }

                    string checkEmailQuery = "SELECT COUNT(*) FROM [dbo].[User] WHERE Email = @Email";
                    var parametersCheck = new Dictionary<string, object>
                    {
                        {"@Email", CEmail}
                    };

                    int count = (int)Con.GetData(checkEmailQuery, parametersCheck).Rows[0][0];

                    if (count > 0)
                    {
                        msg.InnerText = "Customer with this email already exists.";
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO [dbo].[User] (Name, Email, Password, Phone, Address, Photo, RoleId) VALUES (@Name, @Email, @Password, @Phone, @Address, @Photo, @RoleId)";
                        var parametersInsert = new Dictionary<string, object>
                        {
                            {"@Name", CName},
                            {"@Email", CEmail},
                            {"@Password", Cryptography.HashPassword(CPassword)},
                            {"@Phone", CPhone},
                            {"@Address", CAddress},
                            {"@Photo", CPhoto},
                            {"@RoleId", CRole}
                        };

                        Con.SetData(insertQuery, parametersInsert);
                        msg.InnerText = "Customer " + CName + " Added!!!";
                        ShowCustomers();

                        CustomerName.Value = string.Empty;
                        CustomerEmail.Value = string.Empty;
                        CustomerPhone.Value = string.Empty;
                        CustomerAddress.Value = string.Empty;
                    }
                }
            }
            catch (Exception Ex)
            {
                msg.InnerText = "Error: " + Ex.Message + " " + Ex.StackTrace;
            }
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
            msg.InnerText = "Clear";
        }

        int Key = 0;
        protected void CustomerGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            CustomerName.Value = CustomerGV.SelectedRow.Cells[2].Text;
            CustomerEmail.Value = CustomerGV.SelectedRow.Cells[3].Text;
            CustomerPhone.Value = CustomerGV.SelectedRow.Cells[4].Text;
            CustomerAddress.Value = CustomerGV.SelectedRow.Cells[5].Text;
            if (CustomerName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CustomerName.Value) ||
                    string.IsNullOrWhiteSpace(CustomerEmail.Value) ||
                    string.IsNullOrWhiteSpace(CustomerPhone.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    int Id = Convert.ToInt32(CustomerGV.SelectedRow.Cells[1].Text);
                    string CName = CustomerName.Value;
                    string CEmail = CustomerEmail.Value;
                    string CPhone = CustomerPhone.Value;
                    string CAddress = CustomerAddress.Value;
                    string CPhoto = "";
                    string getImagePathQuery = "SELECT Photo FROM [dbo].[User] WHERE Id = @Id";

                    var parametersGetImagePath = new Dictionary<string, object>
                    {
                        {"@Id", Id}
                    };

                    DataTable dt = Con.GetData(getImagePathQuery, parametersGetImagePath);
                    string imagePath = dt.Rows.Count > 0 ? dt.Rows[0]["Photo"].ToString() : string.Empty;

                    if (CustomerPhoto.PostedFile != null && CustomerPhoto.PostedFile.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(CustomerPhoto.PostedFile.FileName);
                        string fileName = CName + extension;
                        string filePath = Server.MapPath("../../Asset/Images/User/") + fileName;
                        CustomerPhoto.PostedFile.SaveAs(filePath);
                        CPhoto = "../../Asset/Images/User/" + fileName;
                    }
                    else
                    {
                        CPhoto = imagePath;
                    }

                    string checkEmailQuery = "SELECT COUNT(*) FROM [dbo].[User] WHERE Email = @Email and id != @Id";
                    var parametersCheck = new Dictionary<string, object>
                    {
                        {"@Email", CEmail},
                        {"@Id", Id}
                    };

                    int count = (int)Con.GetData(checkEmailQuery, parametersCheck).Rows[0][0];

                    if (count > 0)
                    {
                        msg.InnerText = "Customer with this email already exists.";
                    }
                    else
                    {
                        string updateQuery = "UPDATE [dbo].[User] SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address, Photo = @Photo where id = @Id";
                        var parametersUpdate = new Dictionary<string, object>
                        {
                            {"@Name", CName},
                            {"@Email", CEmail},
                            {"@Phone", CPhone},
                            {"@Address", CAddress},
                            {"@Photo", CPhoto},
                            {"@Id", Id}
                        };

                        Con.SetData(updateQuery, parametersUpdate);
                        msg.InnerText = "Customer " + CName + " Has Been Updated!!!";
                        ShowCustomers();
                    }
                }
            }
            catch (Exception Ex)
            {
                msg.InnerText = "Error: " + Ex.Message + " " + Ex.StackTrace;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CustomerName.Value) ||
                    string.IsNullOrWhiteSpace(CustomerEmail.Value) ||
                    string.IsNullOrWhiteSpace(CustomerPhone.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    int Id = Convert.ToInt32(CustomerGV.SelectedRow.Cells[1].Text);
                    string CName = CustomerName.Value;

                    string getImagePathQuery = "SELECT Photo FROM [dbo].[User] WHERE Id = @Id";
                    var parametersGetImagePath = new Dictionary<string, object>
                {
                    {"@Id", Id}
                };

                    DataTable dt = Con.GetData(getImagePathQuery, parametersGetImagePath);
                    string imagePath = dt.Rows.Count > 0 ? dt.Rows[0]["Photo"].ToString() : string.Empty;

                    string deleteQuery = "DELETE FROM [dbo].[User] WHERE Id = @Id";
                    var parametersDelete = new Dictionary<string, object>

                {
                    {"@Id", Id}
                };

                    Con.SetData(deleteQuery, parametersDelete);

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        string fullPath = Server.MapPath(imagePath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }

                    msg.InnerText = "Customer " + CName + " Has Been Deleted!!!";
                    ShowCustomers();

                    CustomerName.Value = string.Empty;
                    CustomerEmail.Value = string.Empty;
                    CustomerPhone.Value = string.Empty;
                    CustomerAddress.Value = string.Empty;
                }
            }
            catch (Exception Ex)
            {
                msg.InnerText = "Error: " + Ex.Message + " " + Ex.StackTrace;
            }
        }
    }
}