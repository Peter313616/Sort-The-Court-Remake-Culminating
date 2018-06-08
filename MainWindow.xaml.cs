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
        int i = 900;
        bool Leaving = false;
        int CounterLeaving = 0;
        int CounterEntering = 0;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            gameTimer.Start();

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            if (i > 550 && Leaving == false)
            {
                Canvas.SetLeft(tempRect, i);
                i = i - 2;
            }               
            
            if (Leaving == true)
            {
                CounterLeaving++;
                if (CounterLeaving > 50 && i != 900)
                {                   
                    Canvas.SetLeft(tempRect, i);
                    i = i + 2;
                }
            }

            if (i == 900 && Leaving == true)
            {
                CounterEntering = 0;
            }

            if (i == 900)
            {
                Leaving = false;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Leaving = true;
            CounterLeaving = 0;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Leaving = true;
            CounterLeaving = 0;
        }
    }
}
