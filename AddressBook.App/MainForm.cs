using System;
using System.Windows.Forms;

namespace AddressBook.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Design code
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
        #endregion

        // Code for Register redirect
        public void RegisterRedirect(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }

        public void LogInClick(object sender, EventArgs e)
        {
            switch (Core.CoreFunctions.LogIn(UsernameInput.Text, PasswordInput.Text))
            {
                case -1:
                    MessageBox.Show($"Please fill all the fields!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    break;
                case 1:
                    Core.CoreFunctions.LoggedinUsername = UsernameInput.Text;
                    this.Hide();
                    LoggedIn loggedInForm = new LoggedIn();
                    loggedInForm.ShowDialog();
                    this.Close();
                    break;
                case 0:
                    MessageBox.Show($"User with such username and password doesn't exist!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    break;
            }
        }
        

        public void ForgotPassClick(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPass form = new ForgotPass();
            form.ShowDialog();
            this.Close();
        }


    }
}
