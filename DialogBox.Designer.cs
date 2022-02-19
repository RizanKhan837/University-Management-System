
namespace University_Management_System_2
{
    partial class DialogBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBox));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.icon = new System.Windows.Forms.PictureBox();
            this.icon_Delay = new System.Windows.Forms.Timer(this.components);
            this.Ok_Btn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.DialogBox_Msg = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // icon
            // 
            this.icon.Image = ((System.Drawing.Image)(resources.GetObject("icon.Image")));
            this.icon.Location = new System.Drawing.Point(49, -18);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(283, 189);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // icon_Delay
            // 
            this.icon_Delay.Enabled = true;
            this.icon_Delay.Interval = 5000;
            this.icon_Delay.Tick += new System.EventHandler(this.icon_Delay_Tick);
            // 
            // Ok_Btn
            // 
            this.Ok_Btn.ActiveBorderThickness = 1;
            this.Ok_Btn.ActiveCornerRadius = 20;
            this.Ok_Btn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(180)))), ((int)(((byte)(63)))));
            this.Ok_Btn.ActiveForecolor = System.Drawing.Color.White;
            this.Ok_Btn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(180)))), ((int)(((byte)(63)))));
            this.Ok_Btn.BackColor = System.Drawing.Color.White;
            this.Ok_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Ok_Btn.BackgroundImage")));
            this.Ok_Btn.ButtonText = "OK";
            this.Ok_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ok_Btn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ok_Btn.ForeColor = System.Drawing.Color.SeaGreen;
            this.Ok_Btn.IdleBorderThickness = 1;
            this.Ok_Btn.IdleCornerRadius = 25;
            this.Ok_Btn.IdleFillColor = System.Drawing.Color.White;
            this.Ok_Btn.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.Ok_Btn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.Ok_Btn.Location = new System.Drawing.Point(137, 177);
            this.Ok_Btn.Margin = new System.Windows.Forms.Padding(5);
            this.Ok_Btn.Name = "Ok_Btn";
            this.Ok_Btn.Size = new System.Drawing.Size(106, 39);
            this.Ok_Btn.TabIndex = 1;
            this.Ok_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ok_Btn.Click += new System.EventHandler(this.Ok_Btn_Click);
            // 
            // DialogBox_Msg
            // 
            this.DialogBox_Msg.AllowParentOverrides = false;
            this.DialogBox_Msg.AutoEllipsis = true;
            this.DialogBox_Msg.AutoSize = false;
            this.DialogBox_Msg.CursorType = null;
            this.DialogBox_Msg.Font = new System.Drawing.Font("Lucida Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DialogBox_Msg.ForeColor = System.Drawing.Color.Gray;
            this.DialogBox_Msg.Location = new System.Drawing.Point(-16, 141);
            this.DialogBox_Msg.Name = "DialogBox_Msg";
            this.DialogBox_Msg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DialogBox_Msg.Size = new System.Drawing.Size(412, 37);
            this.DialogBox_Msg.TabIndex = 2;
            this.DialogBox_Msg.Text = "Success";
            this.DialogBox_Msg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.DialogBox_Msg.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 223);
            this.Controls.Add(this.DialogBox_Msg);
            this.Controls.Add(this.Ok_Btn);
            this.Controls.Add(this.icon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogBox";
            this.Load += new System.EventHandler(this.DialogBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Timer icon_Delay;
        private Bunifu.Framework.UI.BunifuThinButton2 Ok_Btn;
        private Bunifu.UI.WinForms.BunifuLabel DialogBox_Msg;
    }
}