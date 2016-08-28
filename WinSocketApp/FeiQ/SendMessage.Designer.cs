namespace FeiQ
{
    partial class SendMessage
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
            this.rch_sendtxt = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_shaken = new System.Windows.Forms.Button();
            this.rch_recivetxt = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_myhead = new System.Windows.Forms.PictureBox();
            this.pic_firendhead = new System.Windows.Forms.PictureBox();
            this.lbl_myname = new System.Windows.Forms.Label();
            this.lbl_friendname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_myhead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firendhead)).BeginInit();
            this.SuspendLayout();
            // 
            // rch_sendtxt
            // 
            this.rch_sendtxt.Location = new System.Drawing.Point(29, 203);
            this.rch_sendtxt.Name = "rch_sendtxt";
            this.rch_sendtxt.Size = new System.Drawing.Size(377, 77);
            this.rch_sendtxt.TabIndex = 0;
            this.rch_sendtxt.Text = "";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(331, 298);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_shaken
            // 
            this.btn_shaken.Location = new System.Drawing.Point(226, 298);
            this.btn_shaken.Name = "btn_shaken";
            this.btn_shaken.Size = new System.Drawing.Size(75, 23);
            this.btn_shaken.TabIndex = 2;
            this.btn_shaken.Text = "震动";
            this.btn_shaken.UseVisualStyleBackColor = true;
            // 
            // rch_recivetxt
            // 
            this.rch_recivetxt.Location = new System.Drawing.Point(28, 13);
            this.rch_recivetxt.Name = "rch_recivetxt";
            this.rch_recivetxt.Size = new System.Drawing.Size(377, 177);
            this.rch_recivetxt.TabIndex = 3;
            this.rch_recivetxt.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pic_myhead);
            this.panel1.Controls.Add(this.pic_firendhead);
            this.panel1.Controls.Add(this.lbl_myname);
            this.panel1.Controls.Add(this.lbl_friendname);
            this.panel1.Location = new System.Drawing.Point(409, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 263);
            this.panel1.TabIndex = 4;
            // 
            // pic_myhead
            // 
            this.pic_myhead.Location = new System.Drawing.Point(23, 177);
            this.pic_myhead.Name = "pic_myhead";
            this.pic_myhead.Size = new System.Drawing.Size(85, 71);
            this.pic_myhead.TabIndex = 3;
            this.pic_myhead.TabStop = false;
            // 
            // pic_firendhead
            // 
            this.pic_firendhead.Location = new System.Drawing.Point(22, 35);
            this.pic_firendhead.Name = "pic_firendhead";
            this.pic_firendhead.Size = new System.Drawing.Size(87, 68);
            this.pic_firendhead.TabIndex = 2;
            this.pic_firendhead.TabStop = false;
            // 
            // lbl_myname
            // 
            this.lbl_myname.AutoSize = true;
            this.lbl_myname.Location = new System.Drawing.Point(20, 153);
            this.lbl_myname.Name = "lbl_myname";
            this.lbl_myname.Size = new System.Drawing.Size(41, 12);
            this.lbl_myname.TabIndex = 1;
            this.lbl_myname.Text = "label2";
            // 
            // lbl_friendname
            // 
            this.lbl_friendname.AutoSize = true;
            this.lbl_friendname.Location = new System.Drawing.Point(20, 20);
            this.lbl_friendname.Name = "lbl_friendname";
            this.lbl_friendname.Size = new System.Drawing.Size(41, 12);
            this.lbl_friendname.TabIndex = 0;
            this.lbl_friendname.Text = "label1";
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 333);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rch_recivetxt);
            this.Controls.Add(this.btn_shaken);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.rch_sendtxt);
            this.Name = "SendMessage";
            this.Text = "聊天消息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendMessage_FormClosed);
            this.Load += new System.EventHandler(this.SendMessage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_myhead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_firendhead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rch_sendtxt;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_shaken;
        private System.Windows.Forms.RichTextBox rch_recivetxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_myhead;
        private System.Windows.Forms.PictureBox pic_firendhead;
        private System.Windows.Forms.Label lbl_myname;
        private System.Windows.Forms.Label lbl_friendname;
    }
}