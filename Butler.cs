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
    class Butler
    {
        Random random = new Random();
        MainWindow mainWindow;
        Score score;
        List<string> lstDialog = new List<string>();
        int firstDialog;

        public Butler(MainWindow m)
        {
            mainWindow = m;
        }

        public void CharacterDisplay()
        {
            firstDialog = new int();
            score = new Score(mainWindow);
            BitmapImage bitmapImage = new BitmapImage(new Uri("Butler.png", UriKind.Relative));
            ImageBrush img = new ImageBrush(bitmapImage);
            mainWindow.CharaceterRectangle.Fill = img;
        }

        public void Introduction()
        {
            
            StreamReader streamButler = new StreamReader("ButlerInteraction.txt");
            for (int i = 0; i < 6; i++)
            {
                lstDialog.Add(streamButler.ReadLine());
                //MessageBox.Show(lstDialog[i]);
            }

            firstDialog = random.Next(0, 2);///selects one of the intros
            string choosenSpeech = lstDialog[firstDialog];

            if (firstDialog == 0)
            {
                mainWindow.CharacterSpeech.Content += lstDialog[0].Substring(0, 40) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += lstDialog[0].Substring(41);
            }
            else if (firstDialog == 1)
            {
                mainWindow.CharacterSpeech.Content += lstDialog[1].Substring(0, 40) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += lstDialog[1].Substring(41, 39) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += lstDialog[1].Substring(80);
            }
        }

        public void YesResponse()
        {
            int respondToStart = firstDialog + 2;///picks answer depending on intro
            string YesAnswer = lstDialog[respondToStart];

            if (respondToStart == 2)
            {
                mainWindow.CharacterSpeech.Content = lstDialog[respondToStart];
                mainWindow.Money -= 5;
                mainWindow.Happiness += 10;
            }
            else if (respondToStart == 3)
            {
                mainWindow.CharacterSpeech.Content = lstDialog[respondToStart].Substring(0, 36) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += lstDialog[respondToStart].Substring(36);
                mainWindow.Happiness += 20;
            }
        }

        public void NoResponse()
        {
            int RespondToStart = firstDialog + 4;///picks answer depending on intro
            string NoAnswer = lstDialog[RespondToStart];

            if (RespondToStart == 4)
            {
                mainWindow.CharacterSpeech.Content = lstDialog[RespondToStart];
                mainWindow.Happiness -= 5;
            }
            else if (RespondToStart == 5)
            {
                mainWindow.CharacterSpeech.Content = lstDialog[RespondToStart].Substring(0, 38) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += lstDialog[RespondToStart].Substring(38);
                mainWindow.Happiness -= 25;
            }
        }
    }
}
