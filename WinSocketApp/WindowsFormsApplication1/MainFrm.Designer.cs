namespace WindowsFormsApplication1
{
    partial class MainFrm
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
            this.lstboxclients = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnsendfile = new System.Windows.Forms.Button();
            this.rchbox_sendmsg = new System.Windows.Forms.RichTextBox();
            this.btnselectfile = new System.Windows.Forms.Button();
            this.txtfile = new System.Windows.Forms.TextBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.txtIpport = new System.Windows.Forms.TextBox();
            this.rchbox_sate = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lstboxclients
            // 
            this.lstboxclients.FormattingEnabled = true;
            this.lstboxclients.ItemHeight = 12;
            this.lstboxclients.Location = new System.Drawing.Point(346, 13);
            this.lstboxclients.Name = "lstboxclients";
            this.lstboxclients.Size = new System.Drawing.Size(159, 16);
            this.lstboxclients.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(424, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 21);
            this.button3.TabIndex = 16;
            this.button3.Text = "发送消息";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnsendfile
            // 
            this.btnsendfile.Location = new System.Drawing.Point(336, 308);
            this.btnsendfile.Name = "btnsendfile";
            this.btnsendfile.Size = new System.Drawing.Size(82, 21);
            this.btnsendfile.TabIndex = 15;
            this.btnsendfile.Text = "发送文件";
            this.btnsendfile.UseVisualStyleBackColor = true;
            // 
            // rchbox_sendmsg
            // 
            this.rchbox_sendmsg.Location = new System.Drawing.Point(24, 164);
            this.rchbox_sendmsg.Name = "rchbox_sendmsg";
            this.rchbox_sendmsg.Size = new System.Drawing.Size(482, 105);
            this.rchbox_sendmsg.TabIndex = 14;
            this.rchbox_sendmsg.Text = "";
            // 
            // btnselectfile
            // 
            this.btnselectfile.Location = new System.Drawing.Point(234, 308);
            this.btnselectfile.Name = "btnselectfile";
            this.btnselectfile.Size = new System.Drawing.Size(82, 21);
            this.btnselectfile.TabIndex = 13;
            this.btnselectfile.Text = "选择文件";
            this.btnselectfile.UseVisualStyleBackColor = true;
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(24, 309);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(191, 21);
            this.txtfile.TabIndex = 12;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(166, 10);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(59, 21);
            this.btnstart.TabIndex = 11;
            this.btnstart.Text = "监听";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txtIpport
            // 
            this.txtIpport.Location = new System.Drawing.Point(24, 10);
            this.txtIpport.Name = "txtIpport";
            this.txtIpport.Size = new System.Drawing.Size(119, 21);
            this.txtIpport.TabIndex = 10;
            // 
            // rchbox_sate
            // 
            this.rchbox_sate.Location = new System.Drawing.Point(24, 54);
            this.rchbox_sate.Name = "rchbox_sate";
            this.rchbox_sate.Size = new System.Drawing.Size(482, 105);
            this.rchbox_sate.TabIndex = 9;
            this.rchbox_sate.Text = "";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 346);
            this.Controls.Add(this.lstboxclients);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnsendfile);
            this.Controls.Add(this.rchbox_sendmsg);
            this.Controls.Add(this.btnselectfile);
            this.Controls.Add(this.txtfile);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.txtIpport);
            this.Controls.Add(this.rchbox_sate);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstboxclients;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnsendfile;
        private System.Windows.Forms.RichTextBox rchbox_sendmsg;
        private System.Windows.Forms.Button btnselectfile;
        private System.Windows.Forms.TextBox txtfile;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.TextBox txtIpport;
        private System.Windows.Forms.RichTextBox rchbox_sate;
    }
}

