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
    public partial class Campus : Form
    {
        public Campus()
        {
            InitializeComponent();
            Display();
        }

        SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\OneDrive\University Management System 2\UniversityDataBase.mdf;Integrated Security=True");
        int Key = 0;
        private void Display()
        {
            try
            {
                DataTable data = new DataTable();
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from CampusTbl", Connection);
                adapter.Fill(data);
                Camp_DGV.DataSource = data;
                Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Reset()
        {
            Camp_NameTb.Text = "";
            Camp_CityTb.Text = "";
            Camp_DirTb.Text = "";
            Dir_RankTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Camp_NameTb.Text == "" || Camp_CityTb.Text == "" || Camp_DirTb.Text == "" || Dir_RankTb.Text == "" )
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into CampusTbl(Name,City,Director,Rank,Join_Date)values(@CN,@City,@Dir,@Rank,@Date)", Connection);
                    cmd.Parameters.AddWithValue("@CN", Camp_NameTb.Text);
                    cmd.Parameters.AddWithValue("@City", Camp_CityTb.Text);
                    cmd.Parameters.AddWithValue("@Dir", Camp_DirTb.Text);
                    cmd.Parameters.AddWithValue("@Rank", Dir_RankTb.Text);
                    cmd.Parameters.AddWithValue("@Date", Camp_DateDt.Value.Date);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Campus Added");
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
        private void Camp_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Camp_NameTb.Text = Camp_DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                Camp_CityTb.Text = Camp_DGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                Camp_DirTb.Text = Camp_DGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                Dir_RankTb.Text = Camp_DGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                Camp_DateDt.Text = Camp_DGV.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (Camp_NameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = int.Parse(Camp_DGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (Camp_NameTb.Text == "" || Camp_CityTb.Text == "" || Camp_DirTb.Text == "" || Dir_RankTb.Text == "")
            {
                MessageBox.Show("Missing Information...", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Update CampusTbl Set Name=@CN,City=@City,Director=@Dir,Rank=@Rank,Join_Date=@Date where Camp_Id=@CKey", Connection);
                    cmd.Parameters.AddWithValue("@CN", Camp_NameTb.Text);
                    cmd.Parameters.AddWithValue("@City", Camp_CityTb.Text);
                    cmd.Parameters.AddWithValue("@Dir", Camp_DirTb.Text);
                    cmd.Parameters.AddWithValue("@Rank", Dir_RankTb.Text);
                    cmd.Parameters.AddWithValue("@Date", Camp_DateDt.Value.Date);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Campus Updated");
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
                MessageBox.Show("Select The Campus...!!", "University Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete from CampusTbl where Camp_Id=@CKey", Connection);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    DialogBox Db = new DialogBox("Campus Deleted");
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

        private void Course_Lbl_Click(object sender, EventArgs e)
        {
            Courses Course = new Courses();
            this.Hide();
            Course.Show();
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

        private void FeeLbl_Click(object sender, EventArgs e)
        {
            Fees Fee = new Fees();
            this.Hide();
            Fee.Show();
        }

        private void Home_Lbl_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
