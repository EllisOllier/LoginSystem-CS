using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// Login System can also be changed easily to a license key system instead by changing the tables in database and vars

namespace LoginSystem
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-19K5BPL\SQLEXPRESS;Initial Catalog=loginApplication;Integrated Security=True"); // Change to own database connection string

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            try
            {
                if (txtUsername.Text.Length >= 4 && txtPassword.Text.Length >= 8 )
                {
                    String query = "INSERT INTO LoginData VALUES ('" + username + "', '" + password + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);

                    frmLogin frmLogin = new frmLogin();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password or Username is too short!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Could not connect to database!");
            }
            
                
                
            

            
        }
    }
}
