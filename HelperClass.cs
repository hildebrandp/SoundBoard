using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SoundBoard
{
    class HelperClass
    {
        ConfigFiles configFiles = new ConfigFiles();

        string configFilePath = Application.StartupPath + "\\configFile.json";
        string buttonFilePath = Application.StartupPath + "\\buttonFile.json";

        public Boolean checkIfFilesExists()
        {
            return File.Exists(configFilePath) && File.Exists(buttonFilePath);
        }

        public Boolean createFiles()
        {

                writeConfigFile(configFiles.GetConfigItems());
                writeButtonFile(configFiles.GetButtonItems());

                return true;

        }

        public List<configItem> readConfigFile()
        {
            using (StreamReader r = new StreamReader(configFilePath))
            {
                string json = r.ReadToEnd();
                r.Close();
                List<configItem> items = JsonConvert.DeserializeObject<List<configItem>>(json);
                return items;
            }
        }

        public void writeConfigFile(List<configItem> items)
        {
            using (StreamWriter w = new StreamWriter(configFilePath))
            {
                string json = JsonConvert.SerializeObject(items);
                w.WriteLine(json);
                w.Close();
            }
        }

        public List<buttonItem> readButtonFile()
        {
            using (StreamReader r = new StreamReader(buttonFilePath))
            {
                string json = r.ReadToEnd();
                r.Close();
                List<buttonItem> items = JsonConvert.DeserializeObject<List<buttonItem>>(json);
                return items;
            }
        }

        public void writeButtonFile(List<buttonItem> items)
        {
            using(StreamWriter w = new StreamWriter(buttonFilePath))
            {
                string json = JsonConvert.SerializeObject(items);
                w.WriteLine(json);
                w.Close();
            }
        }
    }

    public class buttonItem
    {
        public int ButtonID;
        public int ButtonTab;
        public string ButtonName;
        public string ButtonPicture;
        public string ButtonColor;
        public string ButtonSoundFile;

        public buttonItem(int ButtonID, int ButtonTab, string ButtonName, string ButtonPicture, string ButtonColor, string ButtonSoundFile)
        {
            this.ButtonID = ButtonID;
            this.ButtonTab = ButtonTab;
            this.ButtonName = ButtonName;
            this.ButtonPicture = ButtonPicture;
            this.ButtonColor = ButtonColor;
            this.ButtonSoundFile = ButtonSoundFile;
        }
    }

    public class configItem
    {
        public int TabIndex;
        public string TabName;
        public Boolean TabVisible;

        public configItem(int TabIndex, string TabName, Boolean TabVisible)
        {
            this.TabIndex = TabIndex;
            this.TabName = TabName;
            this.TabVisible = TabVisible;
        }
    }
}
