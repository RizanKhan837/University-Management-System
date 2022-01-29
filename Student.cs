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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            Display();
            GetDeptId();
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
                St_DeptIdCb.ValueMember = "DeptId";
                St_DeptIdCb.DataSource = data;
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
                string Query = "Select * from DepartmentTbl where DeptId = " + St_DeptIdCb.SelectedValue.ToString() + " ";
                SqlCommand cmd = new SqlCommand(Query, Connection);
                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                foreach (DataRow dataRow in data.Rows)
                {
                    St_DeptTb.Text = dataRow["DeptName"].ToString();
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
                SqlDataAdapter adapter = new SqlDataAdapter("select * from StudentTbl", Connection);
                adapter.Fill(data);
                StDGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Reset()
        {
            StNameTb.Text = "";
            St_PhoneTb.Text = "";
            StAddressTb.Text = "";
            St_DeptTb.Text = "";
            StGenderCb.SelectedIndex = -1;
            St_DeptIdCb.SelectedIndex = -1;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void St_DeptIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDeptName();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || St_PhoneTb.Text == "" || StAddressTb.Text == "" || St_DeptIdCb.SelectedIndex == -1 || St_DeptTb.Text == "" || St_SemesterCb.SelectedIndex == -1 || StGenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into StudentTbl(StName,StDOB,StGender,StAddress,StDeptId,StDepName,StPhone,StSemester)values(@SN,@SDOB,@SGen,@SAdd,@SDeptId,@SDept,@SPh,@Sem)", Connection);
                    cmd.Parameters.AddWithValue("@SN", StNameTb.Text);
                    cmd.Parameters.AddWithValue("@SDOB", StDOBdt.Value.Date);
                    cmd.Parameters.AddWithValue("@SGen", StGenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SAdd", StAddressTb.Text);
                    cmd.Parameters.AddWithValue("@SDeptId", St_DeptIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SDept", St_DeptTb.Text);
                    cmd.Parameters.AddWithValue("@SPh", St_PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Sem", St_SemesterCb.SelectedItem.ToString()); ;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Added", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Student...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from StudentTbl where StId=@StKey", Connection);
                    cmd.Parameters.AddWithValue("@StKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void StDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                StNameTb.Text = StDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                StDOBdt.Text = StDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                StGenderCb.SelectedItem = StDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                StAddressTb.Text = StDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                St_DeptIdCb.SelectedValue = StDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                St_DeptTb.Text = StDGV.Rows[e.RowIndex].Cells[6].Value.ToString();
                St_PhoneTb.Text = StDGV.Rows[e.RowIndex].Cells[7].Value.ToString();
                St_SemesterCb.SelectedItem = StDGV.Rows[e.RowIndex].Cells[8].Value.ToString();
                if (StNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = int.Parse(StDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || St_PhoneTb.Text == "" || StAddressTb.Text == "" || St_DeptIdCb.SelectedIndex == -1 || St_DeptTb.Text == "" || St_SemesterCb.SelectedIndex == -1 || StGenderCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Update StudentTblSet StName=@SN,StDOB=@SDOB,StGender=@SGen,StAddress=@SAdd,StDeptId=@SDeptId,StDepName=@SDept,StPhone=@SPh,StSemester=@Sem where StId=@SKey", Connection);
                    cmd.Parameters.AddWithValue("@SN", StNameTb.Text);
                    cmd.Parameters.AddWithValue("@SDOB", StDOBdt.Value.Date);
                    cmd.Parameters.AddWithValue("@SGen", StGenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SAdd", StAddressTb.Text);
                    cmd.Parameters.AddWithValue("@SDeptId", St_DeptIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SDept", St_DeptTb.Text);
                    cmd.Parameters.AddWithValue("@SPh", St_PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Sem", St_SemesterCb.SelectedItem.ToString()); ;
                    cmd.Parameters.AddWithValue("@SKey", Key); ;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Dept_Lbl_Click(object sender, EventArgs e)
        {
            Department Dept = new Department();
            this.Hide();
            Dept.Show();
        }
    }
}
