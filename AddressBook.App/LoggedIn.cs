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
    public partial class LoggedIn : Form
    {
        public LoggedIn()
        {
            InitializeComponent();
        }

        private void LoggedIn_Load(object sender, EventArgs e)
        {
            WelcomeScreen.Text = $"Hello {(Data.DataFunctions.FindUser(Core.CoreFunctions.LoggedinUsername)).FirstName}, we're happy to see you!";
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            Core.CoreFunctions.LoggedinUsername = null;
            this.Close();
        }
    }
}
