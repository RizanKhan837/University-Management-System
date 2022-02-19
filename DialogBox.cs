using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System_2
{
    public partial class DialogBox : Form
    {
        public DialogBox(string _Message)
        {
            InitializeComponent();
            DialogBox_Msg.Text = _Message;
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            icon_Delay.Start();
            icon.Enabled = true;
            Ok_Btn.Hide();
        }

        private void icon_Delay_Tick(object sender, EventArgs e)
        {
            icon.Enabled = false;
            icon_Delay.Stop();
            Ok_Btn.Show();
        }
        private static void ShowDialog(string Message) 
        {
            DialogBox Db = new DialogBox(Message);
            Db.ShowDialog();
        }

        private void Ok_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
