using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.RegisterAndLogin
{
    public partial class RegisterForm : Form
    {
        public delegate void Form_Changed();
        public event Form_Changed SwapToLoginForm;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            SwapToLoginForm?.Invoke();
        }
    }
}
