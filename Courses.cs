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
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
            GetDeptId();
            GetFacId();
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
                data.Columns.Add("DeptId");
                data.Load(Reader);
                C_DeptIdCb.ValueMember = "DeptId";
                C_DeptIdCb.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GetFacId()
        {
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Select F_Id from FacultyTbl", Connection);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("F_Id");
                data.Load(Reader);
                C_FacIdCb.ValueMember = "F_Id";
                C_FacIdCb.DataSource = data;
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
                string Query = "Select * from DepartmentTbl where DeptId = " + C_DeptIdCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    C_DeptNameTb.Text = dataRow["Name"].ToString();
                }
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GetFacName()
        {
            try
            {
                Connection.Open();
                string Query = "Select * from FacultyTbl where F_Id = " + C_FacIdCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    C_FNameTb.Text = dataRow["Name"].ToString();
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
                SqlDataAdapter adapter = new SqlDataAdapter("select * from CourseTbl", Connection);
                adapter.Fill(data);
                Course_DGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Reset()
        {
            CNameTb.Text = "";
            CreditHrsTb.Text = "";
            C_DeptIdCb.SelectedIndex = -1;
            C_DeptNameTb.Text = "";
            C_FacIdCb.SelectedIndex = -1;
            C_FNameTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CreditHrsTb.Text == "" || C_DeptIdCb.SelectedIndex == -1 || C_DeptNameTb.Text == "" || C_FacIdCb.SelectedIndex == -1 || C_FNameTb.Text == "")
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into CourseTbl(Course_Name,Credit_Hrs,DeptId,Department,Fac_Id,Fac_Name)values(@CN,@CH,@DeptId,@DepName,@FacId,@FacName)", Connection);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CH", CreditHrsTb.Text);
                    cmd.Parameters.AddWithValue("@DeptId", C_DeptIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DepName", C_DeptNameTb.Text);
                    cmd.Parameters.AddWithValue("@FacId", C_FacIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FacName", C_FNameTb.Text);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Course Added");
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

        private void C_DeptIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDeptName();
        }

        private void C_FacIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetFacName();
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CreditHrsTb.Text == "" || C_DeptIdCb.SelectedIndex == -1 || C_DeptNameTb.Text == "" || C_FacIdCb.SelectedIndex == -1 || C_FNameTb.Text == "")
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Update CourseTbl Set Course_Name=@CN,Credit_Hrs=@CH,DeptId=@DeptId,Department=@Dept,Fac_Id=@FId,Fac_Name=@FN where Course_Id=@CKey", Connection);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CH", CreditHrsTb.Text);
                    cmd.Parameters.AddWithValue("@DeptId", C_DeptIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Dept", C_DeptNameTb.Text);
                    cmd.Parameters.AddWithValue("@FId", C_FacIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@FN", C_FNameTb.Text); ;
                    cmd.Parameters.AddWithValue("@CKey", Key); ;
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Course Updated");
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
        private void Course_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CNameTb.Text = Course_DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                CreditHrsTb.Text = Course_DGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                C_DeptIdCb.SelectedValue = Course_DGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                C_DeptNameTb.Text = Course_DGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                C_FacIdCb.SelectedValue = Course_DGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                C_FNameTb.Text = Course_DGV.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (CNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = int.Parse(Course_DGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Course...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from CourseTbl where Course_Id=@CKey", Connection);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Course Deleted");
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
