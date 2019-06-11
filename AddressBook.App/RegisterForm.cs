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
        private bool FieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(UserNameText.Text) || string.IsNullOrWhiteSpace(FirstNameText.Text) || string.IsNullOrWhiteSpace(LastNameText.Text) || string.IsNullOrWhiteSpace(PasswordText.Text) || string.IsNullOrWhiteSpace(EmailText.Text))
            {
                return false;
            }
            return true;
        }

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
            if (FieldsFilled() && DataFunctions.IsUnique(UserNameText.Text,EmailText.Text))
            {
                Domain.User user = CoreFunctions.CreateUser(FirstNameText.Text,LastNameText.Text,UserNameText.Text,PasswordText.Text,EmailText.Text);
                DataFunctions.AddUser(user);
                DialogResult result = MessageBox.Show($"Registration successful!\nGoing back to login page", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                BackToLogin(sender, e);
            }
            else if(!FieldsFilled())
            {
                DialogResult result = MessageBox.Show($"Please fill all the fields!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                DialogResult result = MessageBox.Show($"User with said Username or Email already exists!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.DataFunctions.Test();
        }
    }
}
