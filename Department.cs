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

namespace University_Management_System_2
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
            Display();
        }
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");
        private void Display() 
        {

            try
            {
                DataTable data = new DataTable();
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from DepartmentTbl", Connection);
                adapter.Fill(data);
                DeptDGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Reset() 
        {
            DeptNameTb.Text = "";
            DeptFeesTb.Text = "";
            DeptIntakeTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (DeptNameTb.Text == "" || DeptIntakeTb.Text == "" || DeptFeesTb.Text == "")
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into DepartmentTbl(Name,Intake,Fees)values(@DN,@DI,@DF)", Connection);
                    cmd.Parameters.AddWithValue("@DN", DeptNameTb.Text);
                    cmd.Parameters.AddWithValue("@DI", DeptIntakeTb.Text);
                    cmd.Parameters.AddWithValue("@DF", DeptFeesTb.Text);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Department Added");
                    Db.ShowDialog();
                    Connection.Close();
                    Display();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                    Reset();
            }
        }
        int Key = 0;
        private void DeptDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DeptNameTb.Text = DeptDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                DeptIntakeTb.Text = DeptDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                DeptFeesTb.Text = DeptDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (DeptNameTb.Text == "")
                {
                    Key = 0;
                    DeptNameTb.Text = "";
                    DeptFeesTb.Text = "";
                    DeptIntakeTb.Text = "";
                }
                else
                {
                    Key = int.Parse(DeptDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (DeptNameTb.Text == "" || DeptIntakeTb.Text == "" || DeptFeesTb.Text == "")
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Update DepartmentTbl Set Name=@DN ,Intake=@DI ,Fees=@DF where DeptId=@DKey", Connection);
                    cmd.Parameters.AddWithValue("@DN", DeptNameTb.Text);
                    cmd.Parameters.AddWithValue("@DI", DeptIntakeTb.Text);
                    cmd.Parameters.AddWithValue("@DF", DeptFeesTb.Text);
                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Department Updated");
                    Db.ShowDialog();
                    Connection.Close();
                    Display();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                Reset();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Department...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from DepartmentTbl where DeptId=@DKey", Connection);
                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Department Deleted");
                    Db.ShowDialog();
                    Connection.Close();
                    Display();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                Reset();
            }
        }

        private void Student_Lbl_Click(object sender, EventArgs e)
        {
            Student Std = new Student();
            this.Hide();
            Std.Show();
        }

        private void Fac_Lbl_Click(object sender, EventArgs e)
        {
            Faculty Fac = new Faculty();
            this.Hide();
            Fac.Show();
        }

        private void Course_Lbl_Click(object sender, EventArgs e)
        {
            Courses Course = new Courses();
            this.Hide();
            Course.Show();
        }

        private void Camp_Lbl_Click(object sender, EventArgs e)
        {
            Campus Camp = new Campus();
            this.Hide();
            Camp.Show();
        }

        private void Home_Lbl_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void FeeLbl_Click(object sender, EventArgs e)
        {
            Fees Fee = new Fees();
            this.Hide();
            Fee.Show();
        }

        private void Sal_Lbl_Click(object sender, EventArgs e)
        {
            Salaries Sal = new Salaries();
            this.Hide();
            Sal.Show();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LogOut_Lbl_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }
    }
}
