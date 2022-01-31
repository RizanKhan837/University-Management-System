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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Count_Students();
            Count_Department();
            Count_Faculty();
            Count_Campus();
            SumFinances();
            SumSalary();
        }
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");

        private void Count_Students() 
        {
            Connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("Select Count(*) from StudentTbl",Connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            Student_Num.Text = data.Rows[0][0].ToString();
            Connection.Close();
        }
        private void Count_Faculty()
        {
            Connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("Select Count(*) from FacultyTbl", Connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            Faculty_Lbl.Text = data.Rows[0][0].ToString();
            Connection.Close();
        }
        private void Count_Department()
        {
            Connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("Select Count(*) from DepartmentTbl", Connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            Dept_Num.Text = data.Rows[0][0].ToString();
            Connection.Close();
        }
        private void Count_Campus()
        {
            Connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("Select Count(*) from CampusTbl", Connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            Camp_Num.Text = data.Rows[0][0].ToString();
            Connection.Close();
        }
        private void SumFinances() 
        {
            Connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("Select Sum(Amount) from FeesTbl", Connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            FinancesLbl.Text = "Rs. " + data.Rows[0][0].ToString();
            Connection.Close();
        }
        private void SumSalary()
        {
            Connection.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter("Select Sum(Salary) from SalaryTbl", Connection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            Salary_Lbl.Text = "Rs. " + data.Rows[0][0].ToString();
            Connection.Close();
        }
        private void Student_Lbl_Click(object sender, EventArgs e)
        {
            Student Std = new Student();
            this.Hide();
            Std.Show();
        }

        private void Dept_Lbl_Click(object sender, EventArgs e)
        {
            Department Dept = new Department();
            this.Hide();
            Dept.Show();
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

        private void FeeLbl_Click(object sender, EventArgs e)
        {
            Fees Fee = new Fees();
            this.Hide();
            Fee.Show();
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

        private void Sal_Lbl_Click(object sender, EventArgs e)
        {
            Salaries Sal = new Salaries();
            this.Hide();
            Sal.Show();
        }
    }
}
