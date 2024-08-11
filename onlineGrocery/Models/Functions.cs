using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace onlineGrocery.Models
{
    public class Functions
    {
        private readonly SqlConnection Con;
        private readonly SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private readonly string ConnString;

        public Functions()
        {
            ConnString = ConfigurationManager.ConnectionStrings["applicationContext"].ConnectionString;
            Con = new SqlConnection(ConnString);
            cmd = new SqlCommand();
            cmd.Connection = Con;
        }

        public DataTable GetData(string Query, Dictionary<string, object> parameters)
        {
            dt = new DataTable();

            using (cmd)
            {
                cmd.CommandText = Query;
                cmd.Parameters.Clear();

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }

            return dt;
        }

        public int SetData(string Query, Dictionary<string, object> parameters)
        {
            int Count = 0;

            using (cmd)
            {
                cmd.CommandText = Query;
                cmd.Parameters.Clear();

                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                Count = cmd.ExecuteNonQuery();
                Con.Close();
            }

            return Count;
        }
    }
}