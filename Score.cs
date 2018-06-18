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
    class Score
    {
        public Label PopulationLabel;
        public Label HappinessLabel;
        public Label MoneyLabel;
        public bool GameOver = false;
        
        MainWindow mainWindow;

        public Score(MainWindow m)
        {
            mainWindow = m;
        }
        
        public void UpdateLabels(Canvas canvas)
        {
            PopulationLabel.Content = "Population: " + mainWindow.Population;

            HappinessLabel.Content = "Happiness: " + mainWindow.Happiness;

            MoneyLabel.Content = "Coins: " + mainWindow.Money;

            if (mainWindow.Population < 0 || mainWindow.Happiness < 0 || mainWindow.Money < 0)
            {
                mainWindow.CharacterSpeech.Content = "GAME OVER";
                GameOver = true;
            }
        }

        public void CreateLabels(Canvas canvas)
        {
            //mainWindow.canvas.Children.Remove(PopulationLabel);
            PopulationLabel = new Label();
            Canvas.SetLeft(PopulationLabel, 250);
            Canvas.SetTop(PopulationLabel, 10);
            PopulationLabel.Content = "Population: " + mainWindow.Population;
            mainWindow.canvas.Children.Add(PopulationLabel);

           // mainWindow.canvas.Children.Remove(HappinessLabel);
            HappinessLabel = new Label();
            Canvas.SetLeft(HappinessLabel, 250);
            Canvas.SetTop(HappinessLabel, 30);
            HappinessLabel.Content = "Happiness: " + mainWindow.Happiness;
            mainWindow.canvas.Children.Add(HappinessLabel);

            //mainWindow.canvas.Children.Remove(MoneyLabel);
            MoneyLabel = new Label();
            Canvas.SetLeft(MoneyLabel, 250);
            Canvas.SetTop(MoneyLabel, 50);
            MoneyLabel.Content = "Coins: " + mainWindow.Money;
            mainWindow.canvas.Children.Add(MoneyLabel);
        }
    }
}
