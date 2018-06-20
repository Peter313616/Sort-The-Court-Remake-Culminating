using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Sort_The_Court_Remake_Culminating
{
    class OutputCharactrer///selects a random character and corrisponding interactions
    {
        Georgie georgie;
        Butler butler;
        MainWindow mainWindow;

        public OutputCharactrer(MainWindow m)
        {
            mainWindow = m;
        }

        public void CharacterDisplay()
        {
            if (mainWindow.SelectCharcter == 1) 
            {
                georgie = new Georgie(mainWindow);
                georgie.CharacterDisplay();
            } 
            else if (mainWindow.SelectCharcter == 2)
            {
                butler = new Butler(mainWindow);
                butler.CharacterDisplay();
            }
        }

        public void CharacterIntro()
        {
            if (mainWindow.SelectCharcter == 1)
            {
                georgie.Introduction();
            }
            else if (mainWindow.SelectCharcter == 2)
            {
                butler.Introduction();
            }
        }

        public void CharacterYes()
        {
            if (mainWindow.SelectCharcter == 1)
            {
                georgie.YesResponse();
            }
            else if (mainWindow.SelectCharcter == 2)
            {
                butler.YesResponse();
            }
        }

        public void CharacterNo()
        {
            if (mainWindow.SelectCharcter == 1)
            {
                georgie.NoResponse();
            }
            else if (mainWindow.SelectCharcter == 2)
            {
                butler.NoResponse();
            }
        }
    }
}
