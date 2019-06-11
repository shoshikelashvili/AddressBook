using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.App
{
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void BackToLogin(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Close();
        }

        public void SendMail(object sender, EventArgs e)
        {
            string[] data = new string[3];
            data = Data.DataFunctions.FindByEmail(textBox1.Text);
            if (data.Length == 0)
            {
                DialogResult result = MessageBox.Show($"User with such email doesn't exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                Core.CoreFunctions.send_Email($"Hello there {data[0]}, your username is {data[1]} and your password is {data[2]}", textBox1.Text);
                DialogResult result = MessageBox.Show($"Message sent succesfully! Please check your email", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
        }

    }
}
