using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Loading
{
    class TestClass
    {
        public void Image(out Image image)
        {
            BitmapImage SousImage = new BitmapImage();
            SousImage.BeginInit();
            SousImage.UriSource = new Uri(@"E:\Monopoly\Monopoly\LoadingScreen.jpg");
            SousImage.DecodePixelWidth = 600;
            SousImage.EndInit();

            image = new Image();
            image.Source = SousImage;
        }

        public void Exit(out Button exit)
        {
            exit = new Button();
            exit.Content = "Quitter";
            exit.Height = 50;
            exit.Width = 50;
            exit.VerticalAlignment = VerticalAlignment.Bottom;
            exit.HorizontalAlignment = HorizontalAlignment.Right;
        }
    }
}
