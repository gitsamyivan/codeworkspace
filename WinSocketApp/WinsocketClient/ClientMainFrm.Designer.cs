namespace WinsocketClient
{
    partial class ClientMainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.rchbox_sendmsg = new System.Windows.Forms.RichTextBox();
            this.lstbox_sate = new System.Windows.Forms.ListBox();
            this.btn_sendmsg = new System.Windows.Forms.Button();
            this.txt_firend = new System.Windows.Forms.TextBox();
            this.txt_NickName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_shaken = new System.Windows.Forms.Button();
            this.btnsendfile = new System.Windows.Forms.Button();
            this.btnselectfile = new System.Windows.Forms.Button();
            this.txtfile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(251, 21);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(89, 21);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "连接服务器";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(37, 21);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(127, 21);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "192.168.1.200";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(170, 20);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(62, 21);
            this.txt_port.TabIndex = 2;
            this.txt_port.Text = "9000";
            // 
            // rchbox_sendmsg
            // 
            this.rchbox_sendmsg.Location = new System.Drawing.Point(37, 164);
            this.rchbox_sendmsg.Name = "rchbox_sendmsg";
            this.rchbox_sendmsg.Size = new System.Drawing.Size(442, 96);
            this.rchbox_sendmsg.TabIndex = 3;
            this.rchbox_sendmsg.Text = "";
            this.rchbox_sendmsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchbox_sendmsg_KeyDown);
            // 
            // lstbox_sate
            // 
            this.lstbox_sate.FormattingEnabled = true;
            this.lstbox_sate.ItemHeight = 12;
            this.lstbox_sate.Location = new System.Drawing.Point(37, 60);
            this.lstbox_sate.Name = "lstbox_sate";
            this.lstbox_sate.Size = new System.Drawing.Size(442, 88);
            this.lstbox_sate.TabIndex = 4;
            // 
            // btn_sendmsg
            // 
            this.btn_sendmsg.Location = new System.Drawing.Point(404, 278);
            this.btn_sendmsg.Name = "btn_sendmsg";
            this.btn_sendmsg.Size = new System.Drawing.Size(75, 23);
            this.btn_sendmsg.TabIndex = 5;
            this.btn_sendmsg.Text = "发送消息";
            this.btn_sendmsg.UseVisualStyleBackColor = true;
            this.btn_sendmsg.Click += new System.EventHandler(this.btn_sendmsg_Click);
            // 
            // txt_firend
            // 
            this.txt_firend.Location = new System.Drawing.Point(379, 21);
            this.txt_firend.Name = "txt_firend";
            this.txt_firend.Size = new System.Drawing.Size(100, 21);
            this.txt_firend.TabIndex = 6;
            // 
            // txt_NickName
            // 
            this.txt_NickName.Location = new System.Drawing.Point(78, 278);
            this.txt_NickName.Name = "txt_NickName";
            this.txt_NickName.Size = new System.Drawing.Size(100, 21);
            this.txt_NickName.TabIndex = 7;
            this.txt_NickName.Text = "00001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "昵称";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(184, 276);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(59, 23);
            this.btn_login.TabIndex = 9;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_shaken
            // 
            this.btn_shaken.Location = new System.Drawing.Point(324, 277);
            this.btn_shaken.Name = "btn_shaken";
            this.btn_shaken.Size = new System.Drawing.Size(63, 24);
            this.btn_shaken.TabIndex = 10;
            this.btn_shaken.Text = "震动";
            this.btn_shaken.UseVisualStyleBackColor = true;
            this.btn_shaken.Click += new System.EventHandler(this.btn_shaken_Click);
            // 
            // btnsendfile
            // 
            this.btnsendfile.Location = new System.Drawing.Point(374, 321);
            this.btnsendfile.Name = "btnsendfile";
            this.btnsendfile.Size = new System.Drawing.Size(82, 21);
            this.btnsendfile.TabIndex = 27;
            this.btnsendfile.Text = "发送文件";
            this.btnsendfile.UseVisualStyleBackColor = true;
            this.btnsendfile.Click += new System.EventHandler(this.btnsendfile_Click);
            // 
            // btnselectfile
            // 
            this.btnselectfile.Location = new System.Drawing.Point(272, 320);
            this.btnselectfile.Name = "btnselectfile";
            this.btnselectfile.Size = new System.Drawing.Size(82, 21);
            this.btnselectfile.TabIndex = 26;
            this.btnselectfile.Text = "选择文件";
            this.btnselectfile.UseVisualStyleBackColor = true;
            this.btnselectfile.Click += new System.EventHandler(this.btnselectfile_Click);
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(62, 321);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(191, 21);
            this.txtfile.TabIndex = 25;
            // 
            // ClientMainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 363);
            this.Controls.Add(this.btnsendfile);
            this.Controls.Add(this.btnselectfile);
            this.Controls.Add(this.txtfile);
            this.Controls.Add(this.btn_shaken);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_NickName);
            this.Controls.Add(this.txt_firend);
            this.Controls.Add(this.btn_sendmsg);
            this.Controls.Add(this.lstbox_sate);
            this.Controls.Add(this.rchbox_sendmsg);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.btn_start);
            this.Name = "ClientMainFrm";
            this.Text = "ClientMainFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.RichTextBox rchbox_sendmsg;
        private System.Windows.Forms.ListBox lstbox_sate;
        private System.Windows.Forms.Button btn_sendmsg;
        private System.Windows.Forms.TextBox txt_firend;
        private System.Windows.Forms.TextBox txt_NickName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_shaken;
        private System.Windows.Forms.Button btnsendfile;
        private System.Windows.Forms.Button btnselectfile;
        private System.Windows.Forms.TextBox txtfile;
    }
}

