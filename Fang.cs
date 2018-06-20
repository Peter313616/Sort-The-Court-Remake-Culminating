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
    class Fang
    {
        int IndexOfSpace = 0;
        Random random = new Random();
        MainWindow mainWindow;
        StreamReader FangReader = new StreamReader("FangInteraction.txt");
        public Fang(MainWindow m)
        {
            mainWindow = m;
        }

        public void CharacterSpeech()
        {
            string FirstLine = FangReader.ReadLine();
            if (FirstLine.Length > 30)
            {
                int speechLength = 0;
                int LeftOverNumbers = FirstLine.Length % 40;
                int ClosestForty = FirstLine.Length - LeftOverNumbers;

                for (int i = 0; i < ClosestForty / 40; i++)
                {
                    string LineOutput = "";
                    string tempReadLine = FirstLine.Substring(speechLength, 40) + "\r" + "\n";
                    IndexOfSpace = tempReadLine.IndexOf(" ") - 1;
                    if (i == 0)
                    {
                        LineOutput = FirstLine.Substring(0, 40 + IndexOfSpace) + "\r" + "\n";
                    }
                    else
                    {
                        LineOutput = FirstLine.Substring(speechLength + IndexOfSpace, 40 + IndexOfSpace) + "\r" + "\n";
                    }
                    mainWindow.CharacterSpeech.Content += LineOutput;
                    speechLength += 40;
                }

                mainWindow.CharacterSpeech.Content += FirstLine.Substring(ClosestForty + IndexOfSpace + 1);
            }
        }

        public void YesResponse()
        {
            mainWindow.CharacterSpeech.Content = "";
            int LineResponse = random.Next(1, 3);
            string Response = "";

            for (int i = 0; i <= LineResponse - 1; i++)
            {
                Response = FangReader.ReadLine();
            }
            MessageBox.Show(LineResponse.ToString());
            if (LineResponse == 1)
            {
                mainWindow.CharacterSpeech.Content = Response;
            }
            else if (LineResponse == 2)
            {
                MessageBox.Show(Response.Length.ToString());
                mainWindow.CharacterSpeech.Content += Response.Substring(0, 40) + "\r" + "\n";
                mainWindow.CharacterSpeech.Content += Response.Substring(40);
            }
        }


        public void CharacterDisplay()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri("Fang.png", UriKind.Relative));
            ImageBrush img = new ImageBrush(bitmapImage);
            mainWindow.CharaceterRectangle.Fill = img;
        }
    }
}
