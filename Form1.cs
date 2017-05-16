using System;
using System.Windows.Forms;

namespace IEDriver
{
    public partial class Form1 : Form
    {
        public string User { get; set; }
        public string Password { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.User = textBox2.Text;
            this.Password = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = User;
            this.textBox1.Text = Password;
        }
    }
}
