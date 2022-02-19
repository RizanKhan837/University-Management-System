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
    public partial class Faculty : Form
    {
        public Faculty()
        {
            InitializeComponent();
            GetDeptId();
            Display();
        }
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");
        private void GetDeptId()
        {
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Select DeptId from DepartmentTbl", Connection);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("DeptId", typeof(int));
                data.Load(Reader);
                F_DeptIdCb.ValueMember = "DeptId";
                F_DeptIdCb.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GetDeptName()
        {
            try
            {
                Connection.Open();
                string Query = "Select * from DepartmentTbl where DeptId = " + F_DeptIdCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    F_DeptTb.Text = dataRow["Name"].ToString();
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
                SqlDataAdapter adapter = new SqlDataAdapter("select * from FacultyTbl", Connection);
                adapter.Fill(data);
                Fac_DGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Reset()
        {
            F_NameTb.Text = "";
            ExperienceTb.Text = "";
            F_AddressTb.Text = "";
            F_DeptTb.Text = "";
            F_DeptTb.Text = "";
            QualificationCb.SelectedIndex = -1;
            F_GenderCb.SelectedIndex = -1;
            F_DeptIdCb.SelectedIndex = -1;
        }

        private void F_DeptIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDeptName();
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (F_NameTb.Text == "" || ExperienceTb.Text == "" || F_AddressTb.Text == "" || QualificationCb.SelectedIndex == -1 || F_DeptTb.Text == "" || F_GenderCb.SelectedIndex == -1 || F_DeptIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into FacultyTbl(Name,DOB,Gender,Address,Qualification,Experience,DeptId,Department,Salary)values(@FN,@FDOB,@FGen,@FAdd,@FQ,@FE,@FDeptId,@FDept,@FSal)", Connection);
                    cmd.Parameters.AddWithValue("@FN", F_NameTb.Text);
                    cmd.Parameters.AddWithValue("@FDOB", F_DOBdt.Value.Date);
                    cmd.Parameters.AddWithValue("@FGen", F_GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FAdd", F_AddressTb.Text);
                    cmd.Parameters.AddWithValue("@FQ", QualificationCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FE", ExperienceTb.Text);
                    cmd.Parameters.AddWithValue("@FDeptId", F_DeptIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FDept", F_DeptTb.Text);
                    cmd.Parameters.AddWithValue("@FSal", F_SalaryTb.Text);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Faculty Added");
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
        private void Fac_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                F_NameTb.Text = Fac_DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                F_DOBdt.Text = Fac_DGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                F_GenderCb.SelectedItem = Fac_DGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                F_AddressTb.Text = Fac_DGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                QualificationCb.SelectedItem = Fac_DGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                ExperienceTb.Text = Fac_DGV.Rows[e.RowIndex].Cells[6].Value.ToString();
                F_DeptIdCb.SelectedValue = Fac_DGV.Rows[e.RowIndex].Cells[7].Value.ToString();
                F_DeptTb.Text = Fac_DGV.Rows[e.RowIndex].Cells[8].Value.ToString();
                F_SalaryTb.Text = Fac_DGV.Rows[e.RowIndex].Cells[9].Value.ToString();
                if (F_NameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = int.Parse(Fac_DGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (F_NameTb.Text == "" || ExperienceTb.Text == "" || F_AddressTb.Text == "" || QualificationCb.SelectedIndex == -1 || F_DeptTb.Text == "" || F_GenderCb.SelectedIndex == -1 || F_DeptIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Update FacultyTbl Set Name=@FN,DOB=@FDOB,Gender=@FGen,Address=@FAdd,Qualification=@FQ,Experience=@FE,DeptId=@FDeptId,Department=@FDept,Salary=@FSal where F_Id=@FKey", Connection);
                    cmd.Parameters.AddWithValue("@FN", F_NameTb.Text);
                    cmd.Parameters.AddWithValue("@FDOB", F_DOBdt.Value.Date);
                    cmd.Parameters.AddWithValue("@FGen", F_GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FAdd", F_AddressTb.Text);
                    cmd.Parameters.AddWithValue("@FQ", QualificationCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FE", ExperienceTb.Text);
                    cmd.Parameters.AddWithValue("@FDeptId", F_DeptIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FDept", F_DeptTb.Text);
                    cmd.Parameters.AddWithValue("@FSal", F_SalaryTb.Text); ;
                    cmd.Parameters.AddWithValue("@FKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Faculty Updated");
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
                MessageBox.Show("Select The Faculty...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from FacultyTbl where F_Id=@FKey", Connection);
                    cmd.Parameters.AddWithValue("@FKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Faculty Deleted");
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

        private void Home_Lbl_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void Course_Lbl_Click(object sender, EventArgs e)
        {
            Courses Course = new Courses();
            this.Hide();
            Course.Show();
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

        private void Camp_Lbl_Click(object sender, EventArgs e)
        {
            Campus Camp = new Campus();
            this.Hide();
            Camp.Show();
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
