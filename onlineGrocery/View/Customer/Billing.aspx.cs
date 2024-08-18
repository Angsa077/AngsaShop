using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineGrocery.View.Customer
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowProducts();
            ShowBills();
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

        private void ShowBills()
        {
            string Query = "SELECT B.Id, B.Date, P.Name as NameProduct, B.Nominal, B.Amount , B.Total, B.Status, B.InsertedDatetime, B.UpdatedDatetime FROM [dbo].[Bill] B LEFT JOIN [dbo].[Product] P ON B.ProductId = P.Id";
            BillGV.DataSource = Con.GetData(Query, null);
            BillGV.DataBind();
        }

        int Key = 0;
        protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            productName.Value = ProductGV.SelectedRow.Cells[2].Text;
            productPrice.Value = ProductGV.SelectedRow.Cells[4].Text;
            productQuantity.Value = ProductGV.SelectedRow.Cells[5].Text;
            if (productName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName.Value) ||
                    string.IsNullOrWhiteSpace(productPrice.Value) ||
                    string.IsNullOrWhiteSpace(productQuantity.Value))
                {
                    msg.InnerText = "Missing Data";
                }
                else
                {
                    string BPDate = DateTime.Now.ToString("yyyy-MM-dd");
                    int BPId = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
                    decimal BPNominal = Convert.ToDecimal(productPrice.Value);
                    int BPAmount = Convert.ToInt32(productQuantity.Value);
                    decimal BPTotal = BPNominal * BPAmount;
                    string BPStatus = "process";
                    int BPUserID = 7;

                    string insertQuery = "INSERT INTO [dbo].[Bill] (Date, UserId, ProductId, Nominal, Amount, Total, Status, InsertedDatetime, UpdatedDatetime) VALUES (@Date, @UserId, @ProductId, @Nominal, @Amount, @Total, @Status, GETDATE(), NULL)";
                    var parametersInsert = new Dictionary<string, object>
                    {
                        {"@Date", BPDate},
                        {"@UserId", BPUserID},
                        {"@ProductId", BPId},
                        {"@Nominal", BPNominal},
                        {"@Amount", BPAmount},
                        {"@Total", BPTotal},
                        {"@Status", BPStatus}
                    };

                    Con.SetData(insertQuery, parametersInsert);
                    msg.InnerText = "BIlling Added!!!";
                    ShowBills();

                    productName.Value = string.Empty;
                    productPrice.Value = string.Empty;
                    productQuantity.Value = string.Empty;
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

        protected void BillGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            productName.Value = BillGV.SelectedRow.Cells[3].Text;
            productPrice.Value = BillGV.SelectedRow.Cells[4].Text;
            productQuantity.Value = BillGV.SelectedRow.Cells[5].Text;
            if (productName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
            }
        }
    }
}