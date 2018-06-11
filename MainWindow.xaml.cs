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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random random = new Random();
        int CurrentCharacterPosition = 900;
        bool Leaving = false;
        int CounterLeaving = 0;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        public Rectangle temp;
        public Label CharacterSpeech;
        Georgie georgie;

        public MainWindow()
        {
            InitializeComponent();

            georgie =   new Georgie(this);

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            gameTimer.Start();

            temp = new Rectangle();
            temp.Fill = Brushes.Blue;
            temp.Width = 125;
            temp.Height = 125;
            Canvas.SetTop(temp, 125);
            canvas.Children.Add(temp);

            CharacterSpeech = new Label();
            Canvas.SetLeft(CharacterSpeech, 500);
            Canvas.SetTop(CharacterSpeech, 30);
            canvas.Children.Add(CharacterSpeech);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            this.Title = CurrentCharacterPosition.ToString();
            ///Character Movement - Peter
            if (CurrentCharacterPosition >= 552 && Leaving == false)
            {
                Canvas.SetLeft(temp, CurrentCharacterPosition);
                CurrentCharacterPosition = CurrentCharacterPosition - 2;
            }               
            
            if (Leaving == true)
            {
                CounterLeaving++;
                if (CounterLeaving > 20 && CurrentCharacterPosition != 900)
                {                   
                    Canvas.SetLeft(temp, CurrentCharacterPosition);
                    CurrentCharacterPosition = CurrentCharacterPosition + 2;
                }
            }

            if (CurrentCharacterPosition == 898)
            {
                georgie.CharacterDisplay();             
                Leaving = false;
            }

            if (CurrentCharacterPosition == 550)
            {
                georgie.CharacterSpeech();
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCharacterPosition == 550)
            {
                Leaving = true;
                CounterLeaving = 0;
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCharacterPosition == 550)
            {
                Leaving = true;                
                CounterLeaving = 0;
            }
        }
    }
}
