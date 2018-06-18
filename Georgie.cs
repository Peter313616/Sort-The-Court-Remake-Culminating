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
        StreamReader GeorgieReader = new StreamReader("GeorgieInteraction.txt");
        List<string> lstStream = new List<string>();
        Score score;

        public Georgie(MainWindow m)
        {
            mainWindow = m;
        }

        public void CharacterSpeech()
        {
            for (int i = 0; i <= 5; i++)
            {
                lstStream.Add(GeorgieReader.ReadLine());
            }

            mainWindow.CharacterSpeech.Content += lstStream[0].Substring(0, 40)
                + "\r" + "\n";
            mainWindow.CharacterSpeech.Content += lstStream[0].Substring(40);
        }

        public void YesResponse()
        {
            mainWindow.CharacterSpeech.Content = "";
            int LineResponse = random.Next(1, 3);
            string Response = "";

            Response = lstStream[LineResponse];
         
            if (LineResponse == 1)
            {
                mainWindow.CharacterSpeech.Content = Response;

            }
            else if (LineResponse == 2)
            {
                mainWindow.CharacterSpeech.Content += Response.Substring(0, 40) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += Response.Substring(41);
                mainWindow.Money -= 100;;
            }
        }

        public void NoResponse()
        {
            mainWindow.CharacterSpeech.Content = "";
            int LineResponse = random.Next(4, 6);
            string Response = "";

            Response = lstStream[LineResponse - 1];

            if (LineResponse == 4)
            {
                mainWindow.CharacterSpeech.Content = Response;
            }
            else if (LineResponse == 5)
            {
                mainWindow.CharacterSpeech.Content += Response.Substring(0, 42) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += Response.Substring(43);
                mainWindow.Population = mainWindow.Population - 50;
                mainWindow.Happiness = mainWindow.Happiness - 20;
            }
        }

        public void CharacterDisplay()
        {
            score = new Score(mainWindow);
            BitmapImage bitmapImage = new BitmapImage(new Uri("Georgie.png", UriKind.Relative));
            ImageBrush img = new ImageBrush(bitmapImage);
            mainWindow.CharaceterRectangle.Fill = img;
        }
    }
}
