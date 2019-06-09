using SoundBoard.forms;
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

        ContextMenuStrip contexMenuTab = new ContextMenuStrip();
        ContextMenuStrip contexMenuButton = new ContextMenuStrip();

        private const int buttonSize = 150;
        private const int buttonLocation = 6;
        private const int buttonMargin = 5;

        private Boolean configItemsChanged = false;
        private Boolean buttonItemsChanged = false;

        public MainApp()
        {
            InitializeComponent();
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "SoundBoard - Version: " + version;

            contexMenuTab.Items.Add(Properties.Resources.contextMenuStripTabEdit);
            contexMenuTab.Items.Add(Properties.Resources.contextMenuStripTabAddButton);
            //contexMenuTab.Items.Add("Remove Tab");
            //contexMenuTab.Items.Add("Add Tab");
            contexMenuTab.ItemClicked += new ToolStripItemClickedEventHandler(contexMenuTab_ItemClicked);
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabPage.ContextMenuStrip = contexMenuTab;
            }

            contexMenuButton.Items.Add(Properties.Resources.contextMenuStripButtonEdit);
            contexMenuButton.Items.Add(Properties.Resources.contextMenuStripButtonRemove);
            contexMenuButton.Items.Add(Properties.Resources.contextMenuStripButtonMoveTab);
            //contexMenuTab.Items.Add("Move Button");
            //contexMenuTab.Items.Add("Add Tab");
            contexMenuButton.ItemClicked += new ToolStripItemClickedEventHandler(contexMenuButton_ItemClicked);

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
                tabControl1.TabPages[tabInfo.TabIndex].Font = new Font("Microsoft Sans Serif", 10);
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
                newButton.ContextMenuStrip = contexMenuButton;
                newButton.Click += new EventHandler(button_Click);

                if (button.ButtonPicture == "default")
                {
                    newButton.BackgroundImage = Properties.Resources.ic_action_play;
                }
                else
                {
                    Bitmap bit = new Bitmap(button.ButtonPicture);
                    newButton.BackgroundImage = bit;
                }

                buttons[button.ButtonTab].Add(newButton);
                tabControl1.TabPages[button.ButtonTab].Controls.Add(newButton);
            }
            this.Height = Properties.Settings.Default.WindowHeight;
            this.Width = Properties.Settings.Default.WindowWidth;

            this.OnResize(EventArgs.Empty);
        }

        private void MainApp_Resize(object sender, EventArgs e)
        {
            int windowHeight = tabControl1.TabPages[0].Height;
            int windowWidth = tabControl1.TabPages[0].Width;

            int maxButtonsHorizontal = windowWidth / (buttonSize + buttonMargin);

            if (buttons.Count == 0)
            {
                return;
            }
            else
            {
                Properties.Settings.Default.WindowHeight = windowHeight;
                Properties.Settings.Default.WindowWidth = windowWidth;
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

        void contexMenuTab_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            ContextMenuStrip menu = sender as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;

            if (item.Text == Properties.Resources.contextMenuStripTabEdit)
            {
                using (var tabEdit = new EditTab(sourceControl.Text))
                {
                    tabEdit.StartPosition = FormStartPosition.CenterParent;
                    var dialogResult = tabEdit.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        tabControl1.TabPages[sourceControl.TabIndex].Text = tabEdit.newTabName;
                        tabControl1.TabPages[sourceControl.TabIndex].Font = new Font("Microsoft Sans Serif", 10);

                        configItems[sourceControl.TabIndex].TabName = tabEdit.newTabName;
                        configItemsChanged = true;
                        this.tabControl1.Refresh();
                    }
                }
            }
            else if (item.Text == Properties.Resources.contextMenuStripTabAddButton)
            {
                using (var buttonEdit = new EditButton(Properties.Resources.contextMenuStripTabAddButton))
                {
                    buttonEdit.StartPosition = FormStartPosition.CenterParent;
                    var dialogResult = buttonEdit.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        Button newButton = new Button();
                        newButton.Font = new Font("Microsoft Tai Le", 12, FontStyle.Bold);
                        newButton.TextAlign = ContentAlignment.BottomCenter;
                        newButton.Text = buttonEdit.ButtonName;
                        newButton.Name = buttonItems.Count().ToString();
                        newButton.Size = new Size(buttonSize, buttonSize);
                        newButton.Margin = new Padding(buttonMargin);
                        newButton.BackgroundImageLayout = ImageLayout.Stretch;
                        newButton.ContextMenuStrip = contexMenuButton;
                        newButton.Click += new EventHandler(button_Click);

                        if (buttonEdit.ButtonPicture == null || buttonEdit.ButtonPicture == "default")
                        {
                            newButton.BackgroundImage = Properties.Resources.ic_action_play;
                        }
                        else
                        {
                            Bitmap bit = new Bitmap(buttonEdit.ButtonPicture);
                            newButton.BackgroundImage = bit;
                        }

                        buttons[sourceControl.TabIndex].Add(newButton);
                        tabControl1.TabPages[sourceControl.TabIndex].Controls.Add(newButton);

                        this.OnResize(EventArgs.Empty);
                    }
                }
            }
        }

        void contexMenuButton_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            ContextMenuStrip menu = sender as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;


            Console.WriteLine("Clicked: " + sourceControl.Name + "  " + item.Text);
        }

        void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Console.WriteLine("Clicked: " + button.Name);
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Properties.Resources.ApplicationCloseText, Properties.Resources.ApplicationCloseCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (configItemsChanged)
                {
                    helperClass.writeConfigFile(configItems);
                }

                if (buttonItemsChanged)
                {
                    helperClass.writeButtonFile(buttonItems);
                }

                Properties.Settings.Default.Save();
                Console.WriteLine("Closing Application");
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
