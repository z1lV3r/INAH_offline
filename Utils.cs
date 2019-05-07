using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace INAH
{
    class Utils
    {
        public static string getHashSha256(string text)
        {
            /*            byte[] bytes = Encoding.UTF8.GetBytes(text);
                        SHA256Managed hashstring = new SHA256Managed();
                        byte[] hash = hashstring.ComputeHash(bytes);
                        string hashString = string.Empty;
                        foreach (byte x in hash)
                        {
                            hashString += String.Format("{0:x2}", x);
                        }
                        return hashString;*/
            return text;
        }

        public static Grid GetCollectionsItem(String imageUrl, String title, String buttonText, string id, RoutedEventHandler detailClick, MouseEventHandler mouseEnter, MouseEventHandler mouseLeave)
        {
            Grid frontContainer = new Grid();
            frontContainer.Width = 200;
            frontContainer.Height = 180;
            frontContainer.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            frontContainer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            Thickness margin = frontContainer.Margin;
            margin.Left = 10;
            margin.Top = 10;
            margin.Right = 10;
            margin.Bottom = 10;
            frontContainer.Margin = margin;

            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri(imageUrl, UriKind.Relative)); ;
            image.Stretch = Stretch.UniformToFill;
            frontContainer.Background = image;

            Grid backContainer = new Grid();
            backContainer.Background = new SolidColorBrush(Color.FromArgb(150, 100, 100, 100));
            backContainer.Width = frontContainer.Width;
            backContainer.Height = frontContainer.Height;
            for (int i = 0; i < 5; i++)
            {
                backContainer.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                backContainer.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }

            Label titleLbl = new Label();
            titleLbl.Foreground = new SolidColorBrush(Colors.White);
            titleLbl.HorizontalContentAlignment = HorizontalAlignment.Center;
            titleLbl.VerticalContentAlignment = VerticalAlignment.Center;
            titleLbl.Background = new SolidColorBrush(Colors.Black);
            titleLbl.Content = title;
            backContainer.Children.Add(titleLbl);
            Grid.SetRow(titleLbl, 1);
            Grid.SetColumn(titleLbl, 0);
            Grid.SetColumnSpan(titleLbl, 5);

            Button detailButton = new Button();
            detailButton.Content = buttonText;
            detailButton.Tag = id;
            detailButton.Click += new RoutedEventHandler(detailClick);
            backContainer.Children.Add(detailButton);
            Grid.SetRow(detailButton, 3);
            Grid.SetColumn(detailButton, 1);
            Grid.SetColumnSpan(detailButton, 3);

            backContainer.Opacity = 0;
            backContainer.Visibility = Visibility.Collapsed;
            frontContainer.MouseEnter += mouseEnter;
            frontContainer.MouseLeave += mouseLeave;
            frontContainer.Children.Add(backContainer);
            return frontContainer;
        }
    }
}
