using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineGrocery.View.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            GetCategories();
            ShowProducts();
        }

        private void GetCategories()
        {
            string Query = "Select Id, Name from Category";
            productCategory.DataTextField = Con.GetData(Query, null).Columns["Name"].ToString();
            productCategory.DataValueField = Con.GetData(Query, null).Columns["Id"].ToString();
            productCategory.DataSource = Con.GetData(Query, null);
            productCategory.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowProducts()
        {
            string Query = "SELECT P.Id, P.Name, C.Name as Category, P.Price, P.Qty, P.Photo, P.ExpDate, P.InsertedDatetime, P.UpdatedDatetime FROM [dbo].[Product] P LEFT JOIN [dbo].[Category] C ON P.CategoryId = C.Id";
            ProductGV.DataSource = Con.GetData(Query, null);
            ProductGV.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName.Value) ||
                    string.IsNullOrWhiteSpace(productCategory.SelectedValue) ||
                    string.IsNullOrWhiteSpace(productPrice.Value) ||
                    string.IsNullOrWhiteSpace(productQuantity.Value) ||
                    string.IsNullOrWhiteSpace(productExpDate.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    string PName = productName.Value;
                    string PCategory = productCategory.SelectedValue;
                    string PPrice = productPrice.Value;
                    string PQuantity = productQuantity.Value;
                    string PPhoto = "";
                    string PExpDate = productExpDate.Value;

                    if (productPhoto.PostedFile != null && productPhoto.PostedFile.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(productPhoto.PostedFile.FileName);
                        string fileName = PName + extension;
                        string filePath = Server.MapPath("../../Asset/Images/Product/") + fileName;
                        productPhoto.PostedFile.SaveAs(filePath);
                        PPhoto = "../../Asset/Images/Product/" + fileName;
                    }

                    string insertQuery = "INSERT INTO [dbo].[Product] (Name, CategoryId, Price, Qty, Photo, ExpDate, InsertedDatetime) VALUES (@Name, @CategoryId, @Price, @Quantity, @Photo, @ExpDate, GETDATE())";
                    var parametersInsert = new Dictionary<string, object>
                    {
                        {"@Name", PName},
                        {"@CategoryId", PCategory},
                        {"@Price", PPrice},
                        {"@Quantity", PQuantity},
                        {"@Photo", PPhoto},
                        {"@ExpDate", PExpDate}
                    };

                    Con.SetData(insertQuery, parametersInsert);
                    msg.InnerText = "Product " + PName + " Added!!!";
                    ShowProducts();

                    productName.Value = string.Empty;
                    productPrice.Value = string.Empty;
                    productQuantity.Value = string.Empty;
                    productExpDate.Value = string.Empty;
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
        protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            productName.Value = ProductGV.SelectedRow.Cells[2].Text;
            productCategory.DataValueField = ProductGV.SelectedRow.Cells[3].Text;
            productPrice.Value = ProductGV.SelectedRow.Cells[4].Text;
            productQuantity.Value = ProductGV.SelectedRow.Cells[5].Text;
            productExpDate.Value = ProductGV.SelectedRow.Cells[7].Text;
            if (productName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName.Value) ||
                    string.IsNullOrWhiteSpace(productCategory.SelectedValue) ||
                    string.IsNullOrWhiteSpace(productPrice.Value) ||
                    string.IsNullOrWhiteSpace(productQuantity.Value) ||
                    string.IsNullOrWhiteSpace(productExpDate.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    int Id = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
                    string PName = productName.Value;
                    string PCategory = productCategory.SelectedValue;
                    string PPrice = productPrice.Value;
                    string PQuantity = productQuantity.Value;
                    string PPhoto = "";
                    string PExpDate = productExpDate.Value;
                    string getImagePathQuery = "SELECT Photo FROM [dbo].[Product] WHERE Id = @Id";

                    var parametersGetImagePath = new Dictionary<string, object>
                    {
                        {"@Id", Id}
                    };

                    DataTable dt = Con.GetData(getImagePathQuery, parametersGetImagePath);
                    string imagePath = dt.Rows.Count > 0 ? dt.Rows[0]["Photo"].ToString() : string.Empty;

                    if (productPhoto.PostedFile != null && productPhoto.PostedFile.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(productPhoto.PostedFile.FileName);
                        string fileName = PName + extension;
                        string filePath = Server.MapPath("../../Asset/Images/Product/") + fileName;
                        productPhoto.PostedFile.SaveAs(filePath);
                        PPhoto = "../../Asset/Images/Product/" + fileName;
                    }
                    else
                    {
                        PPhoto = imagePath;
                    }

                    string updateQuery = "UPDATE [dbo].[Product] SET Name = @Name, CategoryId = @CategoryId, Price = @Price, Qty = @Quantity, Photo = @Photo, ExpDate = @ExpDate, UpdatedDateTime = GETDATE() where id = @Id";
                    var parametersUpdate = new Dictionary<string, object>
                    {
                        {"@Name", PName},
                        {"@CategoryId", PCategory},
                        {"@Price", PPrice},
                        {"@Quantity", PQuantity},
                        {"@Photo", PPhoto},
                        {"@ExpDate", PExpDate},
                        {"@Id", Id}
                    };

                    Con.SetData(updateQuery, parametersUpdate);
                    msg.InnerText = "Product " + PName + " Has Been Updated!!!";
                    ShowProducts();
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
                if (string.IsNullOrWhiteSpace(productName.Value) ||
                    string.IsNullOrWhiteSpace(productCategory.SelectedValue) ||
                    string.IsNullOrWhiteSpace(productPrice.Value) ||
                    string.IsNullOrWhiteSpace(productQuantity.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    int Id = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
                    string PName = productName.Value;

                    string getImagePathQuery = "SELECT Photo FROM [dbo].[Product] WHERE Id = @Id";
                    var parametersGetImagePath = new Dictionary<string, object>
                {
                    {"@Id", Id}
                };

                    DataTable dt = Con.GetData(getImagePathQuery, parametersGetImagePath);
                    string imagePath = dt.Rows.Count > 0 ? dt.Rows[0]["Photo"].ToString() : string.Empty;

                    string deleteQuery = "DELETE FROM [dbo].[Product] WHERE Id = @Id";
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

                    msg.InnerText = "Product " + PName + " Has Been Deleted!!!";
                    ShowProducts();

                    productName.Value = string.Empty;
                    productPrice.Value = string.Empty;
                    productQuantity.Value = string.Empty;
                    productExpDate.Value = string.Empty;
                }
            }
            catch (Exception Ex)
            {
                msg.InnerText = "Error: " + Ex.Message + " " + Ex.StackTrace;
            }
        }
    }
}