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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-19K5BPL\SQLEXPRESS;Initial Catalog=loginApplication;Integrated Security=True");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username;
            String password;

            username = txtUsername.Text;
            password = txtPassword.Text;

            try
            {
                String query = "SELECT * FROM LoginData WHERE username = '"+username+"' AND password = '"+password+"' "; // Change to own database connection string
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    frmMenu frmMenu = new frmMenu();
                    frmMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Clear();

                    txtUsername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Could not connect to database!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            this.Hide();
        }
    }
}
