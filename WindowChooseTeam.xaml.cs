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
using WPF_TicTacToe.Controlls;

namespace WPF_TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для WindowChooseTeam.xaml
    /// </summary>
    public partial class WindowChooseTeam : Window
    {
        public WindowChooseTeam()
        {
            InitializeComponent();
        }

        private void SightX_Click(object sender, RoutedEventArgs e)
        {
            GameController.PlayerSight = true;
            Close();
        }

        private void SightO_Click(object sender, RoutedEventArgs e)
        {
            GameController.PlayerSight = false;
            Close();
        }
    }
}
