using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool?[] game = new bool?[9];
        bool turn = true;
        // X = true;
        // O = false;
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
                game[i] = null;
        }
        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (game[itemGridView.SelectedIndex] == null)
            {
                game[itemGridView.SelectedIndex] = turn;
                Change(itemGridView.SelectedIndex);
                turn = !turn;
                TextBox10.Text = XorO();
                if (TextBox10.Foreground == Blue.Foreground)
                    TextBox10.Foreground = Red.Foreground;
                else
                    TextBox10.Foreground = Blue.Foreground;
                bool? f = isfinish();
                if (f == true)
                {
                    TextBox11.Text = " الفائز هو:";
                    TextBox10.Text = "X";
                    TextBox10.Foreground = Blue.Foreground;
                    Rectangle1.Visibility = Visibility.Visible;
                }
                if (f == false)
                {
                    TextBox11.Text = " الفائز هو:";
                    TextBox10.Text = "O";
                    TextBox10.Foreground = Red.Foreground;
                    Rectangle1.Visibility = Visibility.Visible;
                }
            }
        }
        private void Change(int i)
        {
            switch (i)
            {
                case 0:
                    TextBox1.Text = XorO();
                    TextBox1.Foreground = Color();
                    break;
                case 1:
                    TextBox2.Text = XorO();
                    TextBox2.Foreground = Color();
                    break;
                case 2:
                    TextBox3.Text = XorO();
                    TextBox3.Foreground = Color();
                    break;
                case 3:
                    TextBox4.Text = XorO();
                    TextBox4.Foreground = Color();
                    break;
                case 4:
                    TextBox5.Text = XorO();
                    TextBox5.Foreground = Color();
                    break;
                case 5:
                    TextBox6.Text = XorO();
                    TextBox6.Foreground = Color();
                    break;
                case 6:
                    TextBox7.Text = XorO();
                    TextBox7.Foreground = Color();
                    break;
                case 7:
                    TextBox8.Text = XorO();
                    TextBox8.Foreground = Color();
                    break;
                case 8:
                    TextBox9.Text = XorO();
                    TextBox9.Foreground = Color();
                    break;
                default:
                    break;
            }
        }
        private string XorO()
        {
            if (turn)
                return "X";
            else
                return "O";
        }
        private Brush Color()
        {
            if (!turn)
                return Red.Foreground;
            else
                return Blue.Foreground;
        }
        private bool? isfinish()
        {
            if (game[0] == true && game[3] == true && game[6] == true)
            {
                TextBox1.Background = Green.Foreground;
                TextBox4.Background = Green.Foreground;
                TextBox7.Background = Green.Foreground;
                return true;
            }
            if (game[1] == true && game[4] == true && game[7] == true)
            {
                TextBox2.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox8.Background = Green.Foreground;
                return true;
            }
            if (game[2] == true && game[5] == true && game[8] == true)
            {
                TextBox3.Background = Green.Foreground;
                TextBox6.Background = Green.Foreground;
                TextBox9.Background = Green.Foreground;
                return true;
            }
            if (game[0] == true && game[1] == true && game[2] == true)
            {
                TextBox1.Background = Green.Foreground;
                TextBox2.Background = Green.Foreground;
                TextBox3.Background = Green.Foreground;
                return true;
            }
            if (game[3] == true && game[4] == true && game[5] == true)
            {
                TextBox4.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox6.Background = Green.Foreground;
                return true;
            }
            if (game[6] == true && game[7] == true && game[8] == true)
            {
                TextBox7.Background = Green.Foreground;
                TextBox8.Background = Green.Foreground;
                TextBox9.Background = Green.Foreground;
                return true;
            }
            if (game[0] == true && game[4] == true && game[8] == true)
            {
                TextBox1.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox9.Background = Green.Foreground;
                return true;
            }
            if (game[6] == true && game[4] == true && game[2] == true)
            {
                TextBox7.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox3.Background = Green.Foreground;
                return true;
            }
            if (game[0] == false && game[3] == false && game[6] == false)
            {
                TextBox1.Background = Green.Foreground;
                TextBox4.Background = Green.Foreground;
                TextBox7.Background = Green.Foreground;
                return false;
            }
            if (game[1] == false && game[4] == false && game[7] == false)
            {
                TextBox2.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox8.Background = Green.Foreground;
                return false;
            }
            if (game[2] == false && game[5] == false && game[8] == false)
            {
                TextBox3.Background = Green.Foreground;
                TextBox6.Background = Green.Foreground;
                TextBox9.Background = Green.Foreground;
                return false;
            }
            if (game[0] == false && game[1] == false && game[2] == false)
            {
                TextBox1.Background = Green.Foreground;
                TextBox2.Background = Green.Foreground;
                TextBox3.Background = Green.Foreground;
                return false;
            }
            if (game[3] == false && game[4] == false && game[5] == false)
            {
                TextBox4.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox6.Background = Green.Foreground;
                return false;
            }
            if (game[6] == false && game[7] == false && game[8] == false)
            {
                TextBox7.Background = Green.Foreground;
                TextBox8.Background = Green.Foreground;
                TextBox9.Background = Green.Foreground;
                return false;
            }
            if (game[0] == false && game[4] == false && game[8] == false)
            {
                TextBox1.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox9.Background = Green.Foreground;
                return false;
            }
            if (game[6] == false && game[4] == false && game[2] == false)
            {
                TextBox7.Background = Green.Foreground;
                TextBox5.Background = Green.Foreground;
                TextBox3.Background = Green.Foreground;
                return false;
            }
            return null;
        }
    }
}
