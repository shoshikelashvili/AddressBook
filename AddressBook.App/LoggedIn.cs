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
            WelcomeScreen.Text = $"Hello {Data.DataFunctions.ReturnFullName(MainForm.LoggedinUsername)}, we're happy to see you!"; 
        }

      
    }
}
