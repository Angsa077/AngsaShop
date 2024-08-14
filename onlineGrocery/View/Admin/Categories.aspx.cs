using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineGrocery.View.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void ShowCategories()
        {
            string Query = "SELECT * FROM [dbo].[Category]";
            CategoryGV.DataSource = Con.GetData(Query, null);
            CategoryGV.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryName.Value) ||
                    string.IsNullOrWhiteSpace(categoryRemarks.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    string CatName = categoryName.Value;
                    string CatRemarks = categoryRemarks.Value;

                    string checkCatNameQuery = "SELECT COUNT(*) FROM [dbo].[Category] WHERE Name = @Name";
                    var parametersCheck = new Dictionary<string, object>
                    {
                        {"@Name", CatName}
                    };

                    int count = (int)Con.GetData(checkCatNameQuery, parametersCheck).Rows[0][0];

                    if (count > 0)
                    {
                        msg.InnerText = "Category with this name already exists.";
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO [dbo].[Category] (Name, Description) VALUES (@Name, @Description)";
                        var parametersInsert = new Dictionary<string, object>
                        {
                            {"@Name", CatName},
                            {"@Description", CatRemarks}
                        };

                        Con.SetData(insertQuery, parametersInsert);
                        msg.InnerText = "Category " + CatName + " Added!!!";
                        ShowCategories();

                        categoryName.Value = string.Empty;
                        categoryRemarks.Value = string.Empty;
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

        protected void CategoryGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            categoryName.Value = CategoryGV.SelectedRow.Cells[2].Text;
            categoryRemarks.Value = CategoryGV.SelectedRow.Cells[3].Text;
            if (categoryName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoryGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryName.Value) ||
                    string.IsNullOrWhiteSpace(categoryRemarks.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    int Id = Convert.ToInt32(CategoryGV.SelectedRow.Cells[1].Text);
                    string CatName = categoryName.Value;
                    string CatRemarks = categoryRemarks.Value;

                    string checkCatNameQuery = "SELECT COUNT(*) FROM [dbo].[Category] WHERE Name = @Name and id != @Id";
                    var parametersCheck = new Dictionary<string, object>
                    {
                        {"@Name", CatName},
                        {"@Id", Id}
                    };

                    int count = (int)Con.GetData(checkCatNameQuery, parametersCheck).Rows[0][0];

                    if (count > 0)
                    {
                        msg.InnerText = "Category with this name already exists.";
                    }
                    else
                    {
                        string updateQuery = "UPDATE [dbo].[Category] SET Name = @Name, Description = @Description where id = @Id";
                        var parametersUpdate = new Dictionary<string, object>
                        {
                            {"@Name", CatName},
                            {"@Description", CatRemarks},
                            {"@Id", Id}
                        };

                        Con.SetData(updateQuery, parametersUpdate);
                        msg.InnerText = "Category " + CatName + " Has Been Updated!!!";
                        ShowCategories();
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
                if (string.IsNullOrWhiteSpace(categoryName.Value) ||
                   string.IsNullOrWhiteSpace(categoryRemarks.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    int Id = Convert.ToInt32(CategoryGV.SelectedRow.Cells[1].Text);
                    string CatName = categoryName.Value;

                    string deleteQuery = "DELETE FROM [dbo].[Category] WHERE Id = @Id";
                    var parametersDelete = new Dictionary<string, object>

                {
                    {"@Id", Id}
                };

                    Con.SetData(deleteQuery, parametersDelete);

                    msg.InnerText = "Category " + CatName + " Has Been Deleted!!!";
                    ShowCategories();

                    categoryName.Value = string.Empty;
                    categoryRemarks.Value = string.Empty;
                }
            }
            catch (Exception Ex)
            {
                msg.InnerText = "Error: " + Ex.Message + " " + Ex.StackTrace;
            }
        }
    }
}