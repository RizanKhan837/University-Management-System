using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System_2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserNameTb.Text == "" || PasswordTb.Text =="")
                {
                    MessageBox.Show("Please Enter Credentials...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * from LoginTbl where Username=@user and Password=@pass", Connection);
                    cmd.Parameters.AddWithValue("@user", UserNameTb.Text);
                    cmd.Parameters.AddWithValue("@pass", PasswordTb.Text);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    Connection.Close();
                    if (dt.Rows.Count == 1)
                    {
                        Home home = new Home();
                        DialogBox Db = new DialogBox("Success");
                        Db.ShowDialog();
                        this.Hide();
                        home.Show();

                    }
                    else
                    {
                        MessageBox.Show("Wrong Username Or Password...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://rizankhan.me");
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseBtn_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void ShowPass_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ShowPass.Checked)
            {
                PasswordTb.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTb.UseSystemPasswordChar = true;
            }
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {
            PasswordTb.UseSystemPasswordChar = true;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.facebook.com/rizankhan837");
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.linkedin.com/in/rizwanakram837/");
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/RizanKhan837");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup Sign = new Signup();
            this.Hide();
            Sign.Show();
        }
    }
}
