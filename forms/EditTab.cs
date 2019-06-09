using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard.forms
{
    public partial class EditTab : Form
    {
        public string newTabName { get; set; }

        public EditTab(string tabName)
        {
            InitializeComponent();
            this.Text = Properties.Resources.EditTabTitle + " " + tabName;
            label1.Text = Properties.Resources.EditTabLabel;
            this.tabName.Text = tabName;
            btAccept.Text = Properties.Resources.ButtonAccept;
            btCancel.Text = Properties.Resources.ButtonCancel;
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            if (tabName.Text.ToString().Length < 3)
            {
                MessageBox.Show(Properties.Resources.EditTabNameTooShort, Properties.Resources.Warning);
            }
            else if (tabName.Text.ToString().Length > 15)
            {
                MessageBox.Show(Properties.Resources.EditTabNameTooLong, Properties.Resources.Warning);
            }
            else if (tabName.Text.ToString() == Properties.Resources.Settings)
            {
                MessageBox.Show(Properties.Resources.EditTabNameSettings + " " + Properties.Resources.Settings, Properties.Resources.Warning);
            }
            else
            {
                this.newTabName = tabName.Text.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tabName_KeyPress(object sender, KeyPressEventArgs e)
        {
            String allowedChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_ ";
            if (!char.IsControl(e.KeyChar) && !allowedChars.Contains(e.KeyChar.ToString().ToLower()))
            {
                e.Handled = true;
            }
        }
    }
}
