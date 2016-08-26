using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FeiQ
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Name.Text))
            {
                MessageBox.Show("请输入用户名", "提示");
                return;
            }
            MainForm m = new MainForm(this.txt_Name.Text);
            this.Hide();
            m.ShowDialog();
        }
    }
}
