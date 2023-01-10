using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Loading;

namespace Loading
{
    /// <summary>
    /// Logique d'interaction pour MenuGame.xaml
    /// </summary>
    public partial class MenuGame : Window
    {
        MediaElement music = new MediaElement();
        TestClass Class = new TestClass();
        Principal principal = new Principal();
        public MenuGame()
        {
            InitializeComponent();
            BtnMusic();
            Music();
            PrepareInitialize();
        }

        public void PrepareInitialize()
        {
            //************************Image************************
            Class.Image(out Image image);
            grdMain.Children.Add(image);
            //*****************************************************
            //***********************EXIT**************************
            Class.Exit(out Button exit);
            exit.Click += new RoutedEventHandler(Exit_Click);
            grdMain.Children.Add(exit);
            //*****************************************************
            //*************Bouton met la bordure ne marche pas car c'est de la grosse merde se logiciel merci*************
            Button Jouer = new Button();
            Button reprendre = new Button();
            StackPanel Stack = new StackPanel();
            Border MyBorder = new Border();

            Jouer.Content = "Play";
            Jouer.Height = 60;
            Jouer.Width = 250;
            Jouer.Click += new RoutedEventHandler(Jouer_Click);

            reprendre.Content = "Reprendre";
            reprendre.Height = 60;
            reprendre.Width = 250;

            Stack.VerticalAlignment = VerticalAlignment.Center;
            Stack.HorizontalAlignment = HorizontalAlignment.Center;

            MyBorder.BorderThickness = new Thickness(0);
            MyBorder.CornerRadius = new CornerRadius(20);


            Stack.Children.Add(Jouer);
            Stack.Children.Add(reprendre);

            MyBorder.Child = Stack;

            grdMain.Children.Add(MyBorder);
            //**************************************************************************************************************
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
            music.Source = new Uri(@"E:\Monopoly\Monopoly\MenuPrincipal.mp3");
            music.Volume = 1;

            grdMain.Children.Add(music);
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (music.Volume < 1)
            {
                music.Volume += 0.1;
            }
        }

        private void Low_Click(object sender, RoutedEventArgs e)
        {
            if (music.Volume > 0)
            {
                music.Volume -= 0.1;
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Jouer_Click(object sender, RoutedEventArgs e)
        {
            principal.Show();
            this.Close();
        }
    }
}
