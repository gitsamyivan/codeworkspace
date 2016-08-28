namespace FeiQ
{
    partial class MainForm
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
            this.pic_header = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.tabPage_friend = new System.Windows.Forms.TabPage();
            this.lstvw_myfirends = new System.Windows.Forms.ListView();
            this.tabPage_setting = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pic_header)).BeginInit();
            this.panel2.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tabPage_friend.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_header
            // 
            this.pic_header.Location = new System.Drawing.Point(12, 12);
            this.pic_header.Name = "pic_header";
            this.pic_header.Size = new System.Drawing.Size(65, 50);
            this.pic_header.TabIndex = 0;
            this.pic_header.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_change);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Location = new System.Drawing.Point(14, 455);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 38);
            this.panel2.TabIndex = 2;
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(122, 6);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(62, 23);
            this.btn_change.TabIndex = 1;
            this.btn_change.Text = "刷新好友";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(3, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(87, 23);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "添加远程好友";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // tab_main
            // 
            this.tab_main.Controls.Add(this.tabPage_friend);
            this.tab_main.Controls.Add(this.tabPage_setting);
            this.tab_main.Location = new System.Drawing.Point(5, 67);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(203, 379);
            this.tab_main.TabIndex = 3;
            // 
            // tabPage_friend
            // 
            this.tabPage_friend.Controls.Add(this.lstvw_myfirends);
            this.tabPage_friend.Location = new System.Drawing.Point(4, 22);
            this.tabPage_friend.Name = "tabPage_friend";
            this.tabPage_friend.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_friend.Size = new System.Drawing.Size(195, 353);
            this.tabPage_friend.TabIndex = 0;
            this.tabPage_friend.Text = "我的好友";
            this.tabPage_friend.UseVisualStyleBackColor = true;
            // 
            // lstvw_myfirends
            // 
            this.lstvw_myfirends.Location = new System.Drawing.Point(0, 0);
            this.lstvw_myfirends.Name = "lstvw_myfirends";
            this.lstvw_myfirends.Size = new System.Drawing.Size(195, 357);
            this.lstvw_myfirends.TabIndex = 0;
            this.lstvw_myfirends.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage_setting
            // 
            this.tabPage_setting.Location = new System.Drawing.Point(4, 22);
            this.tabPage_setting.Name = "tabPage_setting";
            this.tabPage_setting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_setting.Size = new System.Drawing.Size(195, 353);
            this.tabPage_setting.TabIndex = 1;
            this.tabPage_setting.Text = "设置";
            this.tabPage_setting.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 496);
            this.Controls.Add(this.tab_main);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pic_header);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_header)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tab_main.ResumeLayout(false);
            this.tabPage_friend.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_header;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.TabPage tabPage_friend;
        private System.Windows.Forms.TabPage tabPage_setting;
        private System.Windows.Forms.ListView lstvw_myfirends;
    }
}