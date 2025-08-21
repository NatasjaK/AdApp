using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var u = txtUsername.Text.Trim();
            var p = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(p))
            {
                MessageBox.Show("Fyll i användarnamn och lösenord."); return;
            }

            using var conn = new Database().GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO Users(Username, Password) VALUES (@u,@p)", conn);
            cmd.Parameters.AddWithValue("@u", u);
            cmd.Parameters.AddWithValue("@p", p); 
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Konto skapat. Logga in nu.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 2627) 
            {
                MessageBox.Show("Användarnamnet är upptaget.");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
