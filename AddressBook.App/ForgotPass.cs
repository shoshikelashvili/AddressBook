using AddressBook.Data;
using AddressBook.Domain;
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
            User user = Data.DataFunctions.FindUser(InputEmailorUsername.Text);
            Core.CoreFunctions.send_Email($"Hello there {user.FirstName + " " + user.LastName}, your username is {user.Username} and your password is {user.Password}", user.Email );
            DialogResult result = MessageBox.Show($"Message sent succesfully! Please check your email", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }

    }
}
