using System;
using System.Collections.Generic;
using System.Drawing;
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
using Brushes = System.Windows.Media.Brushes;

namespace WpfApp4
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

        private void txtBokA_TextChanged(object sender, TextChangedEventArgs e)
        {


            if(txtBokA.Text == "0")
            {
                txtBokA.Background = Brushes.Red;
                txtBokA.Opacity = 0.4;
                btnSubBokA.IsEnabled = false;
            }
            else
            {
                txtBokA.Background = Brushes.White;
                txtBokA.Opacity = 1;
                btnSubBokA.IsEnabled = true;
            }

        }

        private void btnAddBokA_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(txtBokA.Text);
            ++i;
            txtBokA.Text = i.ToString();

        }

        private void btnSubBokA_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(txtBokA.Text);
            if (i != 0)
                --i;
            txtBokA.Text = i.ToString();
        }

        private void btnAddBokB_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(txtBokB.Text);
            ++i;
            txtBokB.Text = i.ToString();
        }

        private void btnSubBokB_Click(object sender, RoutedEventArgs e)
        {
            int i = int.Parse(txtBokB.Text);
            if(i != 0)
                --i;
            txtBokB.Text = i.ToString();
        }

        private void txtBokB_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (txtBokB.Text == "0")
            {
                txtBokB.Background = Brushes.Red;
                txtBokB.Opacity = 0.4;
                btnSubBokB.IsEnabled = false;
            }
            else
            {
                txtBokB.Background = Brushes.White;
                txtBokB.Opacity = 1;
                btnSubBokB.IsEnabled = true;
            }
        }

        private void btnKalkuluj_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txtBokA.Text);
            int b = int.Parse(txtBokB.Text);

            int pole = a * b;
            int obwod = 2 * a + 2 * b;
            if (a == 0 || b == 0)
            {
                MessageBoxResult result = MessageBox.Show("Wartości dla boków muszą być większe od zera", "BŁĄD");
            }
            else
            {
                if ((a == b) && a != 0 && b != 0)
                {
                    txtKwadrat.Opacity = 1;
                }
                else
                {
                    txtKwadrat.Opacity = 0;
                }
                txtPole.Text = pole.ToString();
                txtObwod.Text = obwod.ToString();
            }
        }
    }
}

// -------------------------------------------------------------------------------------------------------------------

<Window x:Class="WpfApp4.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp4"
        mc:Ignorable="d"
        Title="Kalkulator" Height="350" Width="300" Icon="/toppng.com-building-png-1150x559.png"  >
    <Grid>
        <Label Content="Bok A" HorizontalAlignment="Left" Height="26" Margin="22,13,0,0" VerticalAlignment="Top" Width="66"/>
        <Label Content="Bok B" HorizontalAlignment="Left" Height="26" Margin="174,13,0,0" VerticalAlignment="Top" Width="66"/>
        <Label Content="Pole" HorizontalAlignment="Left" Height="28" Margin="22,92,0,0" VerticalAlignment="Top" Width="66"/>
        <Label Content="Obwód" HorizontalAlignment="Left" Height="27" Margin="22,158,0,0" VerticalAlignment="Top" Width="66"/>
        <Button x:Name="btnKalkuluj" Content="Kalkuluj" HorizontalAlignment="Left" Height="39" Margin="100,273,0,0" VerticalAlignment="Top" Width="110" Click="btnKalkuluj_Click"/>
        <Button x:Name="btnAddBokA" Content="+" HorizontalAlignment="Left" Height="18" Margin="119,44,0,0" VerticalAlignment="Top" Width="26" Click="btnAddBokA_Click"/>
        <Button x:Name="btnSubBokA" Content="-" HorizontalAlignment="Left" Height="18" Margin="119,67,0,0" VerticalAlignment="Top" Width="26" Click="btnSubBokA_Click"/>
        <Button x:Name="btnAddBokB" Content="+" HorizontalAlignment="Left" Height="18" Margin="259,44,0,0" VerticalAlignment="Top" Width="26" Click="btnAddBokB_Click"/>
        <Button x:Name="btnSubBokB" Content="-" HorizontalAlignment="Left" Height="18" Margin="259,67,0,0" VerticalAlignment="Top" Width="26" Click="btnSubBokB_Click"/>
        <TextBox x:Name="txtBokA" FontSize="24" TextAlignment="Right" HorizontalAlignment="Left" Height="41" Margin="14,44,0,0" TextWrapping="Wrap" Text="0" VerticalAlignment="Top" Width="100" IsEnabled="False" TextChanged="txtBokA_TextChanged" />
        <TextBox x:Name="txtPole" FontSize="24" TextAlignment="Center" HorizontalAlignment="Center" Height="41" Margin="0,120,0,0" TextWrapping="Wrap" Text="0" VerticalAlignment="Top" Width="271" IsEnabled="False"/>
        <TextBox x:Name="txtBokB" FontSize="24" TextAlignment="Right" HorizontalAlignment="Left" Height="41" Margin="154,44,0,0" TextWrapping="Wrap" Text="0" VerticalAlignment="Top" Width="100" IsEnabled="False" TextChanged="txtBokB_TextChanged"/>
        <TextBox x:Name="txtObwod" FontSize="24" TextAlignment="Center" HorizontalAlignment="Center" Height="41" Margin="0,185,0,0" TextWrapping="Wrap" Text="0" VerticalAlignment="Top" Width="271" IsEnabled="False"/>
        <TextBlock x:Name="txtKwadrat" HorizontalAlignment="Left" FontSize="24" TextAlignment="Center" Margin="81,237,0,0" TextWrapping="Wrap" Opacity="0" Text="Kwadrat" VerticalAlignment="Top" Height="36" Width="148"/>
    </Grid>
</Window>
