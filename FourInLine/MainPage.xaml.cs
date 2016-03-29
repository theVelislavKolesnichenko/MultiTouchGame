using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FoueInLine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool first = true;

        int[] full = new int[36];

        
        bool second = false;

        bool isFinal = false;

        public MainPage()
        {
            this.InitializeComponent();
            //Ellipse[] ellipse = new Ellipse[36];
            //SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            //mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);

            for (int i = 0; i < 36; i++)
            {
                full[i] = 0;
            }

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //elips.PointerMoved();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Row_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Row.Text) && !string.IsNullOrEmpty(Column.Text))
            {
                Pull.Text = Convert.ToString((
                    Convert.ToInt32(Row.Text) + Convert.ToInt32(Column.Text)) / 2);
            }
        }

        private void elips0_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if(!isFinal)
            {
                Ellipse  ellipse = (Ellipse)sender;
                int tag = Convert.ToInt32(ellipse.Tag);

                if (first)
                {
                    if(tag > 29)
                    {
                        ((Ellipse)sender).Fill = GetSolidColorBrush();
                        first = false;
                        full[tag] = second ? 2 : 1;
                    }
                }
                else
                {
                    bool b0, b1, b2, b3;

                    b0 = b1 = b2 = b3 = false;

                    if ((tag - 1) > -1)
                    {
                        if(full[tag - 1] != 0)
                        {
                            b0 = true;
                        }
                    }
                    if ((tag + 1) < 36)
                    {
                        if (full[tag + 1] != 0)
                        {
                            b1 = true;
                        }
                    }
                    if ((tag - 6) > -1)
                    {
                        if (full[tag - 6] != 0)
                        {
                            b2 = true;
                        }
                    }

                    if ((tag + 6) < 36)
                    {
                        if (full[tag + 6] != 0)
                        {
                            b3 = true;
                        }
                    }

                    if (full[tag] == 0 && (b0 || b1 || b3 || b2 ))
                    {
                        ((Ellipse)sender).Fill = GetSolidColorBrush();
                        full[tag] = second ? 2 : 1;
                    }
                }

                value();



            }
        }

        SolidColorBrush GetSolidColorBrush()
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            if (second)
            {
                mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
                second = false;
                o.Visibility = Visibility.Visible;
                t.Visibility = Visibility.Collapsed;
            }
            else
            {
                mySolidColorBrush.Color = Color.FromArgb(255, 255, 0, 0);
                second = true;
                o.Visibility = Visibility.Collapsed;
                t.Visibility = Visibility.Visible;
            }

            return mySolidColorBrush;
        }

        void value()
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            int d = 0, count = 0;

            string win = string.Empty;

            for (int i = 0; i <= 30; i += 6)
            {
                if (full[i] != d)
                {
                    d = full[i];
                    count = 0;
                }

                if (d != 0)
                {
                    count++;
                }

                d = full[i];

                if (count >= 3)
                {
                    isFinal = true;
                    win = d == 2 ? "ЧЕРВЕНИЯ" : "ЖЪЛТИЯ";
                    mySolidColorBrush.Color = d == 2 ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 0);
                    //Pull.Text = Convert.ToString(d);
                }
            }

            d = 0; count = 0;
            for (int i = 1; i <= 31; i += 6)
            {
                if (full[i] != d)
                {
                    d = full[i];
                    count = 0;
                }

                if (d != 0)
                {
                    count++;
                }

                d = full[i];

                if (count >= 3)
                {
                    isFinal = true;
                    win = d == 2 ? "ЧЕРВЕНИЯ" : "ЖЪЛТИЯ";
                    mySolidColorBrush.Color = d == 2 ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 0);
                    //Pull.Text = Convert.ToString(d);
                }

            }

            d = 0; count = 0;
            for (int i = 2; i <= 32; i += 6)
            {

                if (full[i] != d)
                {
                    d = full[i];
                    count = 0;
                }

                if (d != 0)
                {
                    count++;
                }

                d = full[i];

                if (count >= 3)
                {
                    isFinal = true;
                    win = d == 2 ? "ЧЕРВЕНИЯ" : "ЖЪЛТИЯ";
                    mySolidColorBrush.Color = d == 2 ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 0);
                    //Pull.Text = Convert.ToString(d);
                }

            }

            d = 0; count = 0;
            for (int i = 3; i <= 33; i += 6)
            {

                if (full[i] != d)
                {
                    d = full[i];
                    count = 0;
                }

                if (d != 0)
                {
                    count++;
                }

                d = full[i];

                if (count >= 3)
                {
                    isFinal = true;
                    win = d == 2 ? "ЧЕРВЕНИЯ" : "ЖЪЛТИЯ";
                    mySolidColorBrush.Color = d == 2 ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 0);
                    //Pull.Text = Convert.ToString(d);
                }
            }

            d = 0; count = 0;
            for (int i = 4; i <= 34; i += 6)
            {

                if (full[i] != d)
                {
                    d = full[i];
                    count = 0;
                }

                if (d != 0)
                {
                    count++;
                }

                d = full[i];

                if (count >= 3)
                {
                    isFinal = true;
                    win = d == 2 ? "ЧЕРВЕНИЯ" : "ЖЪЛТИЯ";
                    mySolidColorBrush.Color = d == 2 ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 0);
                    //Pull.Text = Convert.ToString(d);
                }
            }

            d = 0; count = 0;
            for (int i = 5; i <= 35; i += 6)
            {
                if (full[i] != d)
                {
                    d = full[i];
                    count = 0;
                }

                if (d != 0)
                {
                    count++;
                }

                d = full[i];
                
                if (count >= 3)
                {
                    isFinal = true;
                    //Pull.Text = Convert.ToString(d);
                    win = d == 2 ? "ЧЕРВЕНИЯ" : "ЖЪЛТИЯ";
                    mySolidColorBrush.Color = d == 2 ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 0);
                }

            }

            if (isFinal)
            {
                gameover.Text = string.Format("Край на играта\n{0} печели", win);
                o.Visibility = t.Visibility = Visibility.Collapsed;
                gameover.Visibility = Visibility.Visible;
                gameover.Foreground = mySolidColorBrush;

            }
        }
    }
}
