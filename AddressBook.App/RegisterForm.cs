using AddressBook.Core;
using AddressBook.Data;
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
    public partial class RegisterForm : Form
    {
        // This function tells us if all the fields are filled in or not

        public RegisterForm()
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

        private void RegisterClick(object sender, EventArgs e)
        {
            List<string> all_fields = new List<string> { FirstNameText.Text, LastNameText.Text, UserNameText.Text, PasswordText.Text, EmailText.Text };
            switch (Core.CoreFunctions.Register(all_fields))
            {
                case 1:
                    MessageBox.Show($"Registration successful!\nGoing back to login page", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    BackToLogin(sender, e);
                    break;
                case 0:
                    throw new Exception("All fields must be filled!");
                case -1:
                    throw new Exception("User with such Username or Email already exists!");
            }
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            Data.DataFunctions.Test();
        }
    }
}
