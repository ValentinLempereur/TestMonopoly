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
//ajout pour l'animation de la barre
using System.Windows.Media.Animation;
//**********
//pour les timer
using System.Windows.Threading;
//**********
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Loading;

namespace Loading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MenuGame menu = new MenuGame();
        MediaElement music = new MediaElement();
        TestClass Class = new TestClass();


        DispatcherTimer timer = new DispatcherTimer();
        int tempsEcoule = 0;

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            Music();
            BtnMusic();
            PrepareInitialize();
        }

        public void PrepareInitialize()
        {

            //********************Image*************************************
            Class.Image(out Image image);
            grdMain.Children.Add(image);
            //**************************************************************
            //************************Exit**********************************
            Class.Exit(out Button exit);
            exit.Click += new RoutedEventHandler(Exit_Click);
            grdMain.Children.Add(exit);

            //**************************************************************

            //***************************chargement******************************************
            ProgressBar test = new ProgressBar();
            test.Height = 10;
            Duration duration = new Duration(TimeSpan.FromSeconds(6));
            DoubleAnimation db = new DoubleAnimation(100, duration);
            test.BeginAnimation(ProgressBar.ValueProperty, db);
            test.VerticalAlignment = VerticalAlignment.Bottom;
            test.Foreground = Brushes.Black;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();

            grdMain.Children.Add(test);

            //*************************************************************************
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempsEcoule++;
            if (tempsEcoule >= 6)
            {
                timer.Stop();
                menu.Show();
                this.Close();
            }
        }

        public void BtnMusic()
        {
            StackPanel stkBloc1 = new StackPanel();
            Button VolumeUp = new Button();
            Button VolumeLow = new Button();
            Thickness myThickness = new Thickness();

            stkBloc1.VerticalAlignment = VerticalAlignment.Bottom;

            VolumeUp.Content = "Up";
            VolumeLow.Content = "Low";

            VolumeUp.Click += new RoutedEventHandler(Up_Click);
            VolumeLow.Click += new RoutedEventHandler(Low_Click);

            VolumeUp.Height = 40;
            VolumeLow.Height = 40;
            VolumeUp.Width = 30;
            VolumeLow.Width = 30;


            VolumeUp.HorizontalAlignment = HorizontalAlignment.Left;
            VolumeLow.HorizontalAlignment = HorizontalAlignment.Left;


            myThickness.Left = 10;
            myThickness.Top = 0;
            myThickness.Right = 0;
            myThickness.Bottom = 10;

            VolumeUp.Margin = myThickness;
            VolumeLow.Margin = myThickness;

            stkBloc1.Children.Add(VolumeUp);
            stkBloc1.Children.Add(VolumeLow);

            grdMain.Children.Add(stkBloc1);
        }
        public void Music()
        {
            music.Source = new Uri(@"E:\Monopoly\Monopoly\ChargementMusic.mp3");
            music.Volume = 1;

            grdMain.Children.Add(music);
        }

        public void Low_Click(object sender, RoutedEventArgs e)
        {
            if (music.Volume > 0)
            {
                music.Volume -= 0.1;
            }
        }

        public void Up_Click(object sender, RoutedEventArgs e)
        {
            if (music.Volume < 1)
            {
                music.Volume += 0.1;
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
