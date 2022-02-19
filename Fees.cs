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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
            Display();
            GetStudentId();
        }
        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");
        private void GetStudentId()
        {
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Select StId from StudentTbl", Connection);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("StId", typeof(int));
                data.Load(Reader);
                StIdCb.ValueMember = "StId";
                StIdCb.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GetStudentInfo()
        {
            try
            {
                Connection.Open();
                string Query = "Select * from StudentTbl where StId = " + StIdCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    StNameTb.Text = dataRow["Name"].ToString();
                    StDeptTb.Text = dataRow["Department"].ToString();
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
                SqlDataAdapter adapter = new SqlDataAdapter("select * from FeesTbl", Connection);
                adapter.Fill(data);
                FeeDGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Reset()
        {
            StNameTb.Text = "";
            AmountTb.Text = "";
            StDeptTb.Text = "";
            StIdCb.SelectedIndex = -1;
            SemesterCb.SelectedIndex = -1;
        }
        
        int Key = 0;

        private void StIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetStudentInfo();
        }

        private void PayBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StIdCb.SelectedIndex == -1 || StDeptTb.Text == "" || AmountTb.Text == "" || SemesterCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into FeesTbl(StId,StName,StDept,Amount,Semester,PayDate)values(@SId,@SN,@SDep,@Amount,@Sem,@Date)", Connection);
                    cmd.Parameters.AddWithValue("@SId", StIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SN", StNameTb.Text);
                    cmd.Parameters.AddWithValue("@SDep", StDeptTb.Text);
                    cmd.Parameters.AddWithValue("@Amount", AmountTb.Text);
                    cmd.Parameters.AddWithValue("@Sem", SemesterCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Date", DateTime.Today.Date);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Fee Paid");
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
            if (StNameTb.Text == "" || StIdCb.SelectedIndex == -1 || StDeptTb.Text == "" || AmountTb.Text == "" || SemesterCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Student...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from FeesTbl where Fee_Id=@FKey",Connection);
                    cmd.Parameters.AddWithValue("@FKey", Key);
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

        private void FeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                StIdCb.SelectedValue = FeeDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                StNameTb.Text = FeeDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                StDeptTb.Text = FeeDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                SemesterCb.SelectedItem = FeeDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                AmountTb.Text = FeeDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (StNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = int.Parse(FeeDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Home_Lbl_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();

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
            Courses courses = new Courses();
            this.Hide();
            courses.Show();
        }

        private void Sal_Lbl_Click(object sender, EventArgs e)
        {
            Salaries Sal = new Salaries();
            this.Hide();
            Sal.Show();
        }

        private void Camp_Lbl_Click(object sender, EventArgs e)
        {
            Campus camp = new Campus();
            this.Hide();
            camp.Show();
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
