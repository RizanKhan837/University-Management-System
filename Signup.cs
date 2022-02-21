using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System_2
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");


        private void bunifuTextBox1_Enter(object sender, EventArgs e)
        {
            bunifuColorTransition1.Start();
            PasswordTb.UseSystemPasswordChar = true;
        }

        private void ShowPassBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassBtn.CheckState == CheckState.Checked)
            {
                PasswordTb.UseSystemPasswordChar = false;
                Cnfrm_PasswordTb.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTb.UseSystemPasswordChar = true;
                Cnfrm_PasswordTb.UseSystemPasswordChar = true;
            }
        }

        private void Cnfrm_SignupPass_TextChanged(object sender, EventArgs e)
        {
            Cnfrm_PasswordTb.UseSystemPasswordChar = true;
        }

        private void SignupBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTb.Text == Cnfrm_PasswordTb.Text)
                {
                    if (UsernameTb.Text == "" || PasswordTb.Text == "" || Cnfrm_PasswordTb.Text == "")
                    {
                        MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            Connection.Open();
                            SqlCommand cmd = new SqlCommand("Insert into LoginTbl(UserName,Password)values(@UN,@Pass)", Connection);
                            cmd.Parameters.AddWithValue("@UN", UsernameTb.Text);
                            cmd.Parameters.AddWithValue("@Pass", PasswordTb.Text);
                            cmd.ExecuteNonQuery();
                            DialogBox Db = new DialogBox("Account Created");
                            Db.ShowDialog();
                            Connection.Close();
                            Login login = new Login();
                            this.Hide();
                            login.Show();
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Do Not Matched...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
