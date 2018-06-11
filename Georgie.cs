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

    
    class Georgie
    {
        Random random = new Random();
        MainWindow mainWindow;

        public Georgie(MainWindow m)
        {
            mainWindow = m;
        }

        public void CharacterSpeech()
        {
            
            StreamReader GeorgieReader = new StreamReader("GeorgieInteraction.txt");
            string FirstLine = GeorgieReader.ReadLine();
            if (FirstLine.Length > 30)
            {
                string tempReadLine = FirstLine.Substring();
            }
            mainWindow.CharacterSpeech.Content = FirstLine;
            int PickLine = random.Next(2, 4);
            //mainWindow.CharaterSpeech = StreamReader.
        }

        public void CharacterDisplay()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri("Georgie.png", UriKind.Relative));
            ImageBrush img = new ImageBrush(bitmapImage);
            mainWindow.temp.Fill = img;
        }
    }
}
