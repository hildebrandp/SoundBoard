using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard
{
    class ConfigFiles
    {
        private int maxTabs = 7;
        private int defaultButtons = 5;


        public List<configItem> GetConfigItems()
        {
            List<configItem> configItems = new List<configItem>();
            configItem newConfigItem;

            for (int i = 0; i < maxTabs - 1; i++)
            {
                newConfigItem = new configItem(i, "Sounds " + (i + 1), true);
                configItems.Add(newConfigItem);
            }

            newConfigItem = new configItem(maxTabs - 1, Properties.Resources.Settings, true);
            configItems.Add(newConfigItem);

            return configItems;
        }

        public List<buttonItem> GetButtonItems()
        {
            List<buttonItem> buttonItems = new List<buttonItem>();
            buttonItem newButtonItem;

            for (int b = 0; b < defaultButtons; b++)
            {
                newButtonItem = new buttonItem(b, 0, "Sound " + (b + 1), "default", "default", "default", false, false, 0, 0);
                buttonItems.Add(newButtonItem);
            }

            return buttonItems;
        }
    }
}
