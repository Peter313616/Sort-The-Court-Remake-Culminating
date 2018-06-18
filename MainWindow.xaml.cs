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
        public Rectangle CharaceterRectangle;
        public Label CharacterSpeech;
        Georgie georgie;
        int TempCounter = 0;
        public int Population = 100;
        public int Happiness = 100;
        public int Money = 200;
        Score score;
        Butler butler;

        public MainWindow()
        {
            InitializeComponent();

            georgie = new Georgie(this);
            score = new Score(this);
            butler = new Butler(this);

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            gameTimer.Start();

            score.CreateLabels(canvas);

            CharaceterRectangle = new Rectangle();
            CharaceterRectangle.Width = 125;
            CharaceterRectangle.Height = 125;
            Canvas.SetTop(CharaceterRectangle, 125);
            canvas.Children.Add(CharaceterRectangle);

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
                Canvas.SetLeft(CharaceterRectangle, CurrentCharacterPosition);
                CurrentCharacterPosition = CurrentCharacterPosition - 2;
            }

            if (Leaving == true)
            {
                CounterLeaving++;
                if (CounterLeaving > 20 && CurrentCharacterPosition != 900)
                {
                    TempCounter = 0;
                    Canvas.SetLeft(CharaceterRectangle, CurrentCharacterPosition);
                    CurrentCharacterPosition = CurrentCharacterPosition + 2;
                }
            }

            if (CurrentCharacterPosition == 898)
            {
                butler.CharacterDisplay();
                //georgie.CharacterDisplay();
                CharacterSpeech.Content = "";
                if (score.GameOver == false)
                {
                    Leaving = false;
                }
            }

            if (CurrentCharacterPosition == 550 && TempCounter == 0)
            {
                //georgie.CharacterSpeech();
                butler.Introduction();
                TempCounter++;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCharacterPosition == 550)
            {
                Leaving = true;
                CounterLeaving = 0;
                //georgie.YesResponse();
                score.UpdateLabels(canvas);
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCharacterPosition == 550)
            {
                //georgie.NoResponse();
                Leaving = true;                
                CounterLeaving = 0;
                score.UpdateLabels(canvas);
            }
        }
    }
}
