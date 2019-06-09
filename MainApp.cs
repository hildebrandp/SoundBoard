using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoundBoard
{
    public partial class MainApp : Form
    {
        HelperClass helperClass = new HelperClass();
        List<configItem> configItems = new List<configItem>();
        List<buttonItem> buttonItems = new List<buttonItem>();

        List<List<Button>> buttons = new List<List<Button>>();

        private const int buttonSize = 150;
        private const int buttonLocation = 6;
        private const int buttonMargin = 5;

        public MainApp()
        {
            InitializeComponent();
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "SoundBoard - Version: " + version;

            if (!helperClass.checkIfFilesExists())
            {
                if (!helperClass.createFiles())
                {
                    DialogResult dialogResult = MessageBox.Show("Error creating Config File!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialogResult == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
            }

            loadWindow();

        }

        private void loadWindow()
        {
            configItems = helperClass.readConfigFile();
            buttonItems = helperClass.readButtonFile();

            foreach (configItem tabInfo in configItems)
            {
                tabControl1.TabPages[tabInfo.TabIndex].Text = tabInfo.TabName;
                buttons.Add(new List<Button>());
            }

            foreach (buttonItem button in buttonItems)
            {
                Button newButton = new Button();
                newButton.Font = new Font("Microsoft Tai Le", 12, FontStyle.Bold);
                newButton.TextAlign = ContentAlignment.BottomCenter;
                newButton.Text = button.ButtonName;
                newButton.Name = button.ButtonID.ToString();
                newButton.Size = new Size(buttonSize, buttonSize);
                newButton.Margin = new Padding(buttonMargin);
                newButton.BackgroundImageLayout = ImageLayout.Stretch;

                if (button.ButtonPicture == "default")
                {
                    newButton.BackgroundImage = Properties.Resources.ic_action_play;
                } else
                {
                    Bitmap bit = new Bitmap(button.ButtonPicture);
                    newButton.BackgroundImage = bit;
                }

                buttons[button.ButtonTab].Add(newButton);
                tabControl1.TabPages[button.ButtonTab].Controls.Add(newButton);
            }
            this.OnResize(EventArgs.Empty);
        }

        private void MainApp_Resize(object sender, EventArgs e)
        {
            int windowHeight = tabControl1.TabPages[0].Height;
            int windowWidth = tabControl1.TabPages[0].Width;

            int minHeight;
            int minWidth;

            int maxButtonsHorizontal = windowWidth / (buttonSize + buttonMargin);

            if (buttons.Count == 0)
            {
                return;
            }

            foreach (configItem tabInfo in configItems)
            {
                if (tabInfo.TabName != "Settings")
                {
                    int[] buttonCount = new int[20];
                    int rowNumber = 0;
                    
                    foreach (Button button in buttons[tabInfo.TabIndex])
                    {
                        if (buttonCount[rowNumber] != 0 && buttonCount[rowNumber] % maxButtonsHorizontal == 0)
                        {
                            rowNumber++;
                        }

                        int x_location = buttonLocation + ((button.Margin.All + buttonSize) * buttonCount[rowNumber]);
                        int y_location = buttonLocation + ((button.Margin.All + buttonSize) * rowNumber);
                        button.Location = new Point(x_location, y_location);

                        buttonCount[rowNumber]++;
                    }
                }
            }

            tabControl1.Refresh();
        }
    }

    
}
