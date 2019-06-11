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

namespace AddressBook.App {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        public static string LoggedinUsername = null;

        // Code for placeholder effect on Username
        public void RemoveUsernameText(object sender, EventArgs e)
        {
            if (UsernameInput.Text == "Username")
            {
                UsernameInput.Text = "";
            }
        }

        public void AddUsernameText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameInput.Text))
            {
                UsernameInput.Text = "Username";
            }
        }

        // Code for placeholder effect on Password
        public void RemovePasswordText(object sender, EventArgs e)
        {
            if (PasswordInput.Text == "Password")
            {
                PasswordInput.Text = "";
            }
            PasswordInput.PasswordChar = '*';
        }

        public void AddPasswordText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                PasswordInput.PasswordChar = '\0';
                PasswordInput.Text = "Password";
            }
        }

        // Code for Register redirect
        public void RegisterRedirect(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }

        //public void LogInClick(object sender, EventArgs e)
        //{
        //    DataFunctions functions = new DataFunctions();
        //    if (string.IsNullOrWhiteSpace(PasswordInput.Text) || PasswordInput.Text == "Password" || string.IsNullOrWhiteSpace(UsernameInput.Text) ||UsernameInput.Text == "Username")
        //    {
        //        DialogResult result = MessageBox.Show($"Please fill all the fields!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        //    }
        //    else if(functions.CheckCredentials(UsernameInput.Text, PasswordInput.Text))
        //    {
        //        DialogResult result = MessageBox.Show($"Log in Succesfull!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        //        LoggedinUsername = UsernameInput.Text;
        //        this.Hide();
        //        LoggedIn loggedInForm = new LoggedIn();
        //        loggedInForm.ShowDialog();
        //        this.Close();
        //    }
        //    else
        //    {
        //        DialogResult result = MessageBox.Show($"User with such username and password doesn't exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        //    }
        //}
         
        public void ForgotPassClick(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPass form = new ForgotPass();
            form.ShowDialog();
            this.Close();
        }

         
    }
}
