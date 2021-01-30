using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPF_TicTacToe.Controlls
{
    public static class GameController
    {
        public static bool PlayerSight { get; set; }

        public static bool PlayerSign { get; set; }

        public static bool IsTurned;

        



        public static string Turn(bool turn)
        {
            if (IsTurned == true)
            {
                if (PlayerSight == true && PlayerSight == turn) { IsTurned = false; return "1"; }
                else if (PlayerSight == false && PlayerSight == turn) { IsTurned = false; return "2"; }
                else if (PlayerSight != turn && PlayerSight == true) { return "2"; }
                else if (PlayerSight != turn && PlayerSight == false) { return "1"; }
                else { return ""; }
            }
            else { return ""; }
        }


        public static bool ChekWin(ref BindingList<Button> list)
        {
            bool win;
            if (list[0].Content == list[1].Content && list[1].Content == list[2].Content && list[0].Content != null ||
                list[3].Content == list[4].Content && list[4].Content == list[5].Content && list[3].Content != null ||
                list[6].Content == list[7].Content && list[7].Content == list[8].Content && list[6].Content != null ||
                list[0].Content == list[3].Content && list[3].Content == list[6].Content && list[0].Content != null ||
                list[1].Content == list[4].Content && list[4].Content == list[7].Content && list[1].Content != null ||
                list[2].Content == list[5].Content && list[5].Content == list[8].Content && list[2].Content != null ||
                list[0].Content == list[4].Content && list[4].Content == list[8].Content && list[0].Content != null ||
                list[2].Content == list[4].Content && list[4].Content == list[6].Content && list[2].Content != null)
            {
                win = true;
            }
            else { win = false; }
            return win;
        }


        public static bool ChekDraw(ref BindingList<Button> list)
        {
            foreach(Button item in list)
            {
                if (item.IsEnabled == true)
                {
                    return false;
                }
            }
            return true;

        }

        public static bool RandomTurn()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int value = rnd.Next(0, 100);
            bool random;

            if (value < 50) { random = true; }
            else { random = false; }
            if (random == true && PlayerSight == true) { IsTurned = true; }
            else if (random == false && PlayerSight == true) {IsTurned = false; }
            else if (random == true && PlayerSight == false) { IsTurned = false; }
            else if (random == false && PlayerSight == false) { IsTurned = true; }

            return random;
        }


        public static int ComputerTurn(BindingList<Button> ButtonList)
        {

            List<int> PriorButton = new List<int>();
            PriorButton.Add(0);
            PriorButton.Add(2);
            PriorButton.Add(4);
            PriorButton.Add(6);
            PriorButton.Add(8);
            Random rnd = new Random(DateTime.Now.Millisecond);
            var x = rnd.Next(1, 5);
            int ButtonIndex;
            if ((ButtonList[0].Content == ButtonList[1].Content && ButtonList[0].Content != null || ButtonList[5].Content == ButtonList[8].Content && ButtonList[5].Content != null ||
                ButtonList[4].Content == ButtonList[6].Content && ButtonList[4].Content != null) && ButtonList[2].IsEnabled == true) { return 2; }
            
            else if ((ButtonList[1].Content == ButtonList[2].Content && ButtonList[1].Content != null || ButtonList[3].Content == ButtonList[6].Content && ButtonList[3].Content != null ||
                     ButtonList[4].Content == ButtonList[8].Content && ButtonList[4].Content != null) && ButtonList[0].IsEnabled == true) { return 0; }

            else if ((ButtonList[0].Content == ButtonList[2].Content && ButtonList[0].Content != null || ButtonList[4].Content == ButtonList[7].Content && ButtonList[4].Content != null) && ButtonList[1].IsEnabled == true) { return 1; }

            else if ((ButtonList[0].Content == ButtonList[6].Content && ButtonList[0].Content != null || ButtonList[4].Content == ButtonList[5].Content && ButtonList[4].Content != null) && ButtonList[3].IsEnabled == true) { return 3; }

            else if ((ButtonList[0].Content == ButtonList[8].Content && ButtonList[0].Content != null || ButtonList[1].Content == ButtonList[7].Content && ButtonList[1].Content != null ||
                     ButtonList[2].Content == ButtonList[6].Content && ButtonList[2].Content != null || ButtonList[3].Content == ButtonList[5].Content && ButtonList[3].Content != null) && ButtonList[4].IsEnabled == true) { return 4; }

            else if ((ButtonList[2].Content == ButtonList[8].Content && ButtonList[2].Content != null || ButtonList[3].Content == ButtonList[4].Content && ButtonList[3].Content != null) && ButtonList[5].IsEnabled == true) { return 5; }

            else if ((ButtonList[0].Content == ButtonList[3].Content && ButtonList[0].Content != null || ButtonList[7].Content == ButtonList[8].Content && ButtonList[7].Content != null ||
                     ButtonList[2].Content == ButtonList[4].Content && ButtonList[2].Content != null) && ButtonList[6].IsEnabled == true) { return 6; }

            else if ((ButtonList[1].Content == ButtonList[4].Content && ButtonList[1].Content != null || ButtonList[6].Content == ButtonList[8].Content && ButtonList[6].Content != null) && ButtonList[7].IsEnabled == true) { return 7; }

            else if ((ButtonList[2].Content == ButtonList[5].Content && ButtonList[2].Content != null || ButtonList[6].Content == ButtonList[7].Content && ButtonList[6].Content != null ||
                     ButtonList[0].Content == ButtonList[4].Content && ButtonList[0].Content != null) && ButtonList[8].IsEnabled == true) { return 8; }
            else if (ButtonList[0].IsEnabled == true || ButtonList[2].IsEnabled == true || ButtonList[4].IsEnabled == true || ButtonList[6].IsEnabled == true || ButtonList[8].IsEnabled == true)
            {
                Link2:
                var PriorIndex = rnd.Next(0, PriorButton.Count-1);
                if (ButtonList[PriorButton[PriorIndex]].IsEnabled == true)
                {
                    return PriorButton[PriorIndex];
                }
                else
                {
                    PriorButton.RemoveAt(PriorIndex);
                    goto Link2;
                }
            }
            else
            {
            Link1:
                ButtonIndex = rnd.Next(0, 8);

                if (ButtonList[ButtonIndex].IsEnabled == true)
                {

                    return ButtonIndex;
                }
                else
                {
                    goto Link1;
                }
            }
            
       
        }

    }
}
