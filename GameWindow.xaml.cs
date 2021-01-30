using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
       bool PlayerTurn;
       bool win = false;
       bool draw = false;
       BindingList<Button> ButtonList = new BindingList<Button>();

        public delegate void StateHandler(object sender, RoutedEventArgs e);
        public event StateHandler PlayerTurnChanged;

       

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   ButtonList.Add(I);
            ButtonList.Add(II);
            ButtonList.Add(III);
            ButtonList.Add(IV);
            ButtonList.Add(V);
            ButtonList.Add(VI);
            ButtonList.Add(VII);
            ButtonList.Add(VIII);
            ButtonList.Add(IX);
            WindowChooseTeam choosewindow = new WindowChooseTeam();
            choosewindow.ShowDialog();
            PlayerTurnChanged += TurnCanged;
            PlayerTurn = GameController.RandomTurn();
            PlayerTurnChanged?.Invoke(PlayerTurn, (new RoutedEventArgs()));

        }

        private void ButExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TurnCanged(object sender, RoutedEventArgs e)
        {
            if (PlayerTurn == GameController.PlayerSight)
            { ConditionLine.Text = "Ход игрока"; }
            else { ConditionLine.Text = "Ход компьютора"; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            var but = sender as Button;
            var sight = GameController.Turn(PlayerTurn);
            switch (sight)
            {
                case "1":
                    {
                        but.Content = "X";
                        PlayerTurn =! PlayerTurn;
                        PlayerTurnChanged?.Invoke(PlayerTurn, (new RoutedEventArgs()));
                        but.IsEnabled = false;
                        break;
                        
                    }

                case "2":
                    {
                        but.Content = "O";
                        PlayerTurn = !PlayerTurn;
                        PlayerTurnChanged?.Invoke(PlayerTurn, (new RoutedEventArgs()));
                        but.IsEnabled = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            win = GameController.ChekWin(ref ButtonList);
            draw = GameController.ChekDraw(ref ButtonList);
            if (win == true)
            {
                MessageBox.Show($"Победили {but.Content}");
                foreach(Button item in ButtonList)
                {
                    item.IsEnabled = false;
                }
            }
            else if (draw == true)
            {
                MessageBox.Show("Ничья");
            }


           
            e.Handled = true;
        }

        private void SwitchTurn_Click(object sender, RoutedEventArgs e)
        {
            GameController.IsTurned = true;
            if (PlayerTurn != GameController.PlayerSight)
            {
                var Index = GameController.ComputerTurn(ButtonList);
                ButtonList[Index].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            e.Handled = true;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button item in ButtonList)
            {
                item.Content = default;
                item.IsEnabled = true;
            }
            win = false;
            WindowChooseTeam choosewindow = new WindowChooseTeam();
            choosewindow.ShowDialog();
            PlayerTurn = GameController.RandomTurn();
            PlayerTurnChanged?.Invoke(PlayerTurn, (new RoutedEventArgs()));

        }
    }
}
