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

namespace WpfApp1
{
    // <summary>
    // Interaction logic for MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTak_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTak.Content = "Nie";
            btnNie.Content = "Tak";
            //Thickness btnN = btnNie.Margin;
            //Thickness btnT = btnTak.Margin;
            //Thickness btnT = new Thickness(111, 198, 0, 0);
            //Thickness btnN = new Thickness(477, 198, 0, 0);
            //btnTak.Margin = btnN;
            //btnNie.Margin = btnT;
            //btnNie.Margin = new Thickness(111,198,0,0);
        }

        private void btnTak_MouseLeave(object sender, MouseEventArgs e)
        {
            btnTak.Content = "Tak";
            btnNie.Content = "Nie";
            //Thickness btnT = new Thickness(111, 198, 0, 0);
            //Thickness btnN = new Thickness(477, 198, 0, 0);
            //btnTak.Margin = btnT;
            //btnNie.Margin = btnN;
        }

        private void btnNie_Click(object sender, RoutedEventArgs e) => MessageBox.Show(":(");

        private void btnTak_Click(object sender, RoutedEventArgs e) => MessageBox.Show(":(");

    }
}

/*-------------------------------------------------------------------------------------------------------------------*/

<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Label Content="Czy chcesz podwyżkę?" HorizontalAlignment="Center" Height="58" Margin="0,82,0,0" VerticalAlignment="Top" Width="372" FontSize="40" FontFamily="Corbel Light" RenderTransformOrigin="0.502,0.977"  />
        <Button x:Name="btnTak" Content="Tak" HorizontalAlignment="Left" Height="78" Margin="111,198,0,0" VerticalAlignment="Top" Width="207" FontSize="36" FontFamily="Corbel Light" MouseEnter="btnTak_MouseEnter" MouseLeave="btnTak_MouseLeave" Click="btnTak_Click"/>
        <Button x:Name="btnNie" Content="Nie" HorizontalAlignment="Left" Height="78" Margin="477,198,0,0" VerticalAlignment="Top" Width="207" FontSize="36" FontFamily="Corbel Light" Click="btnNie_Click"/>
    </Grid>
</Window>
