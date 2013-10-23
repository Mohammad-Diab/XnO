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

namespace XO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool is_x_turn = true;
        bool win = false;
        int[][] state = new int[3][];
        Button[] buttons = new Button[9];
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (!win && ((Button)sender).Content == null)
            {
                Image image = new Image();
                int index = GetIndex((Button)sender);
                int raw = index / 3;
                int column = index % 3;
                if (is_x_turn)
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/XO;component/Images/x.png"));
                    state[raw][column] = 1;
                }
                else
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/XO;component/Images/o.png"));
                    state[raw][column] = -1;
                }
                ((Button)sender).Content = image;
                if (CheckWin(index))
                {
                    if (is_x_turn)
                        for_x.Text = (int.Parse(for_x.Text) + 1).ToString();
                    else
                        for_o.Text = (int.Parse(for_o.Text) + 1).ToString();
                    MessageBox.Show((is_x_turn ? "X" : "O") + " wins", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    NewGame_Click(null, null);
                }
                if (!win && CheckDraw())
                {
                    MessageBox.Show("Draw", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    NewGame_Click(null, null);
                }
                if (!win)
                    is_x_turn = !is_x_turn;                    
            }
        }

        private int GetIndex(Button sender)
        {
            for (int i = 0; i < 9; i++)
                if (sender == buttons[i])
                    return i;
            return -1;
        }

        private bool CheckWin(int index)
        {
            int raw = index / 3;
            int column = index % 3;
            int sumRaw = 0, sumColumn = 0, primaryDiam = 0, secondaryDia = 0;
            for (int i = 0; i < 3; i++)
            {
                sumRaw += state[raw][i];
                sumColumn += state[i][column];
                primaryDiam += state[i][i];
                secondaryDia += state[i][3 - i - 1];
            }
            if (3 == Math.Abs(sumRaw) || 3 == Math.Abs(sumColumn) || 3 == Math.Abs(primaryDiam) || 3 == Math.Abs(secondaryDia))
                return true;
            else
                return false;
        }

        private bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (state[i][j] == 0)
                        return false;
            return true;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            buttons[0] = b1;
            buttons[1] = b2;
            buttons[2] = b3;
            buttons[3] = b4;
            buttons[4] = b5;
            buttons[5] = b6;
            buttons[6] = b7;
            buttons[7] = b8;
            buttons[8] = b9;
            state[0] = new int[3];
            state[1] = new int[3];
            state[2] = new int[3];
            RestState();
            for_o.Text = "0";
            for_x.Text = "0";
        }

        private void RestState()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    state[i][j] = 0;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in buttons)
                i.Content = null;
            RestState();
            win = false;
        }

        private void Rest_Click(object sender, RoutedEventArgs e)
        {
            NewGame_Click(null, null);
            for_o.Text = "0";
            for_x.Text = "0";
        }
    }
}
