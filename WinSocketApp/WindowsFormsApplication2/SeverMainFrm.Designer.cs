namespace WinsocketServer
{
    partial class SeverMainFrm
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
            this.lstbox_state = new System.Windows.Forms.ListBox();
            this.btnsendmsg = new System.Windows.Forms.Button();
            this.btnsendfile = new System.Windows.Forms.Button();
            this.btnselectfile = new System.Windows.Forms.Button();
            this.txtfile = new System.Windows.Forms.TextBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.combox_clients = new System.Windows.Forms.ComboBox();
            this.rchbox_sendmsg = new System.Windows.Forms.RichTextBox();
            this.btn_shaken = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstbox_state
            // 
            this.lstbox_state.FormattingEnabled = true;
            this.lstbox_state.ItemHeight = 12;
            this.lstbox_state.Location = new System.Drawing.Point(27, 50);
            this.lstbox_state.Name = "lstbox_state";
            this.lstbox_state.Size = new System.Drawing.Size(444, 100);
            this.lstbox_state.TabIndex = 26;
            // 
            // btnsendmsg
            // 
            this.btnsendmsg.Location = new System.Drawing.Point(389, 273);
            this.btnsendmsg.Name = "btnsendmsg";
            this.btnsendmsg.Size = new System.Drawing.Size(82, 21);
            this.btnsendmsg.TabIndex = 25;
            this.btnsendmsg.Text = "发送消息";
            this.btnsendmsg.UseVisualStyleBackColor = true;
            this.btnsendmsg.Click += new System.EventHandler(this.btnsendmsg_Click);
            // 
            // btnsendfile
            // 
            this.btnsendfile.Location = new System.Drawing.Point(339, 307);
            this.btnsendfile.Name = "btnsendfile";
            this.btnsendfile.Size = new System.Drawing.Size(82, 21);
            this.btnsendfile.TabIndex = 24;
            this.btnsendfile.Text = "发送文件";
            this.btnsendfile.UseVisualStyleBackColor = true;
            this.btnsendfile.Click += new System.EventHandler(this.btnsendfile_Click);
            // 
            // btnselectfile
            // 
            this.btnselectfile.Location = new System.Drawing.Point(237, 306);
            this.btnselectfile.Name = "btnselectfile";
            this.btnselectfile.Size = new System.Drawing.Size(82, 21);
            this.btnselectfile.TabIndex = 22;
            this.btnselectfile.Text = "选择文件";
            this.btnselectfile.UseVisualStyleBackColor = true;
            this.btnselectfile.Click += new System.EventHandler(this.btnselectfile_Click);
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(27, 307);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(191, 21);
            this.txtfile.TabIndex = 21;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(214, 8);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(59, 21);
            this.btnstart.TabIndex = 20;
            this.btnstart.Text = "监听";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(27, 8);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(119, 21);
            this.txt_ip.TabIndex = 19;
            this.txt_ip.Text = "192.168.1.200";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(152, 8);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(56, 21);
            this.txt_port.TabIndex = 27;
            this.txt_port.Text = "9000";
            // 
            // combox_clients
            // 
            this.combox_clients.FormattingEnabled = true;
            this.combox_clients.Location = new System.Drawing.Point(339, 12);
            this.combox_clients.Name = "combox_clients";
            this.combox_clients.Size = new System.Drawing.Size(129, 20);
            this.combox_clients.TabIndex = 28;
            // 
            // rchbox_sendmsg
            // 
            this.rchbox_sendmsg.Location = new System.Drawing.Point(27, 165);
            this.rchbox_sendmsg.Name = "rchbox_sendmsg";
            this.rchbox_sendmsg.Size = new System.Drawing.Size(444, 96);
            this.rchbox_sendmsg.TabIndex = 29;
            this.rchbox_sendmsg.Text = "";
            this.rchbox_sendmsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchbox_sendmsg_KeyDown);
            // 
            // btn_shaken
            // 
            this.btn_shaken.Location = new System.Drawing.Point(289, 271);
            this.btn_shaken.Name = "btn_shaken";
            this.btn_shaken.Size = new System.Drawing.Size(75, 23);
            this.btn_shaken.TabIndex = 30;
            this.btn_shaken.Text = "震动";
            this.btn_shaken.UseVisualStyleBackColor = true;
            this.btn_shaken.Click += new System.EventHandler(this.btn_shaken_Click);
            // 
            // SeverMainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 348);
            this.Controls.Add(this.btn_shaken);
            this.Controls.Add(this.rchbox_sendmsg);
            this.Controls.Add(this.combox_clients);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lstbox_state);
            this.Controls.Add(this.btnsendmsg);
            this.Controls.Add(this.btnsendfile);
            this.Controls.Add(this.btnselectfile);
            this.Controls.Add(this.txtfile);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.txt_ip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SeverMainFrm";
            this.Text = "ServerMainFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbox_state;
        private System.Windows.Forms.Button btnsendmsg;
        private System.Windows.Forms.Button btnsendfile;
        private System.Windows.Forms.Button btnselectfile;
        private System.Windows.Forms.TextBox txtfile;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.ComboBox combox_clients;
        private System.Windows.Forms.RichTextBox rchbox_sendmsg;
        private System.Windows.Forms.Button btn_shaken;
    }
}

