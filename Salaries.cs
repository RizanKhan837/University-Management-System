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
    public partial class Salaries : Form
    {
        public Salaries()
        {
            InitializeComponent();
            GetFacultyId();
            Display();
        }
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");
        private void GetFacultyId()
        {
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Select F_Id from FacultyTbl", Connection);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("F_Id",typeof(int));
                data.Load(Reader);
                Salary_FIdCb.ValueMember = "F_Id";
                Salary_FIdCb.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GetFacultyInfo()
        {
            try
            {
                Connection.Open();
                string Query = "Select * from FacultyTbl where F_Id = " + Salary_FIdCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    Salary_FNameTb.Text = dataRow["Name"].ToString();
                    SalDeptTb.Text = dataRow["Department"].ToString();
                }
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Display()
        {

            try
            {
                DataTable data = new DataTable();
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from SalaryTbl", Connection);
                adapter.Fill(data);
                Sal_DGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Reset()
        {
            Salary_FIdCb.SelectedIndex = -1;
            Salary_FNameTb.Text = "";
            SalDeptTb.Text = "";
            Sal_AmountTb.Text = "";
        }

        private void Course_Lbl_Click(object sender, EventArgs e)
        {
            Courses Course = new Courses();
            this.Hide();
            Course.Show();
        }

        private void Salary_FIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetFacultyInfo();
        }
        int Key = 0;

        private void PayBtn_Click(object sender, EventArgs e)
        {
            if (Salary_FNameTb.Text == "" || Salary_FIdCb.SelectedIndex == -1 || SalDeptTb.Text == "" || Sal_AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into SalaryTbl(F_Id,F_Name,Salary,Department,PayDate)values(@FId,@FN,@Sal,@Dept,@Date)", Connection);
                    cmd.Parameters.AddWithValue("@FId", Salary_FIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FN", Salary_FNameTb.Text);
                    cmd.Parameters.AddWithValue("@Sal", Sal_AmountTb.Text);
                    cmd.Parameters.AddWithValue("@Dept", SalDeptTb.Text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Today.Date);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Salary Paid");
                    Db.ShowDialog();
                    Connection.Close();
                    Display();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            Reset();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (Salary_FNameTb.Text == "" || Salary_FIdCb.SelectedIndex == -1 || SalDeptTb.Text == "" || Sal_AmountTb.Text == "")
            {
                MessageBox.Show("Select a Faculty...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from SalaryTbl where Salary_Id=@SKey", Connection);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Record Deleted");
                    Db.ShowDialog();
                    Connection.Close();
                    Display();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Reset();
            }
        }

        private void Sal_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Salary_FIdCb.SelectedValue = Sal_DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                Salary_FNameTb.Text = Sal_DGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                Sal_AmountTb.Text = Sal_DGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                SalDeptTb.Text = Sal_DGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (Salary_FNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = int.Parse(Sal_DGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void Fac_Lbl_Click(object sender, EventArgs e)
        {
            Faculty Fac = new Faculty();
            this.Hide();
            Fac.Show();
        }

        private void Dept_Lbl_Click(object sender, EventArgs e)
        {
            Department Dept = new Department();
            this.Hide();
            Dept.Show();
        }

        private void Student_Lbl_Click(object sender, EventArgs e)
        {
            Student Std = new Student();
            this.Hide();
            Std.Show();
        }

        private void Home_Lbl_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void Salaries_Load(object sender, EventArgs e)
        {

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
