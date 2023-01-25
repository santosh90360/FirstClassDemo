using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace FirstClassDemo
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool result = CreateNewuser();
            if (result==true)
            {
                lblMesssage.Text = "Success! You are registered successfully.";
                lblMesssage.ForeColor = Color.Green;
            }
            else
            {
                lblMesssage.Text = "Failed! You are notregister successfully.";
                lblMesssage.ForeColor = Color.Red;
            }
        }

        private bool CreateNewuser()
        {
            bool result = false;
            try
            {
                string connString = @"Data Source=servername; database=dbAnkitDemo; integrated security=true;";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("insert into Registration(Name,Email,Password) values(@Name,@Email,@Password)", connection);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    connection.Open();
                    int temp = cmd.ExecuteNonQuery(); // insert, update, delete
                    connection.Close();
                    if (temp > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}