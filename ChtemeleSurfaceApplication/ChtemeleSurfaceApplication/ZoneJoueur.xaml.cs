﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Surface.Presentation.Controls;
using System.Media;

namespace ChtemeleSurfaceApplication
{
    /// <summary>
    /// Logique d'interaction pour ZoneJoueur.xaml
    /// </summary>
    public partial class ZoneJoueur : ScatterViewItem
    {
        public bool active = false;

        public ZoneJoueur()
        {
            InitializeComponent();
            ButtonNextPlayer.IsEnabled = false;
        }

        private void ButtonNextPlayer_Click(object sender, RoutedEventArgs e)
        {
            Game_classes.Game.getInstance.nextPlayer();

            using (SoundPlayer player = new SoundPlayer("Resources/lion.wav"))
            {
                player.Play();
            }
        }

        public void update()
        {

            if (active)
            {
                ButtonNextPlayer.IsEnabled = true;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Visible;
                Background = new SolidColorBrush(Colors.Ivory);

            }
            else
            {
                ButtonNextPlayer.IsEnabled = false;
                ButtonNextPlayer.Visibility = System.Windows.Visibility.Hidden;
                Background = new SolidColorBrush(Colors.RosyBrown);
            }
        }
    }
}
