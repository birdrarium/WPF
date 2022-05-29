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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool idbool = false, namebool = false, snamebool = false, agebool = false;

        private Person osoba = null;
        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }
        private void InitBinding()
        {
            osoba = new Person(1, "Jan", "Kowalski", 25);
            gridPersonForm.DataContext = osoba;
        }
        private void btnPokaz_Click(object sender, RoutedEventArgs e)
        {
            txtOdczytaj.Text = gridPersonForm.DataContext.ToString();
        }

        private void txtBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isINT = int.TryParse(txtBoxID.Text, out int id);
            if (!isINT)
            {
                lblID.Opacity = 1;
                idbool = false;
            }
            else
            {
                lblID.Opacity = 0;
                idbool = true;
            }
            btnIsEnabled();
        }

        private void txtBoxImie_TextChanged(object sender, TextChangedEventArgs e)
        {
                foreach (char znak in txtBoxImie.Text)
                {
                    if ( !(((byte)znak > 65 && (byte)znak < 91) || ((byte)znak > 97 && (byte)znak < 123)))
                    {
                        lblName.Opacity = 1;
                        namebool = false;
                    }
                    else
                    {
                        lblName.Opacity = 0;
                        namebool = true;
                    }
                }
            btnIsEnabled();
        }

        private void txtBoxNazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char znak in txtBoxNazwisko.Text)
            {
                if (!(((byte)znak > 65 && (byte)znak < 91) || ((byte)znak > 97 && (byte)znak < 123)))
                {
                    lblSName.Opacity = 1;
                    snamebool = false;
                }
                else
                {
                    lblSName.Opacity = 0;
                    snamebool = true;
                }
            }
            btnIsEnabled();

        }

        private void txtBoxWiek_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isINT = int.TryParse(txtBoxWiek.Text, out int wiek);
            if (!isINT || (wiek < 0 || wiek > 130))
            {
                lblAge.Opacity = 1;
                agebool = false;
            }
            else
            {
                lblAge.Opacity = 0;
                agebool = true;
            }
            btnIsEnabled();
        }

        private void btnIsEnabled()
        {
            if (idbool && namebool && snamebool && agebool)
                btnPokaz.IsEnabled = true;
            else
                btnPokaz.IsEnabled = false;
        }
    }
}

// --------------------------------------------------------------------------------------------------------------

<Window x:Class="WpfApp3.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp3"
        mc:Ignorable="d"
        Title="Osoba" Height="270" Width="400">
    <Grid x:Name="gridPersonForm">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Label Content="ID:" Grid.Row="0" Grid.Column="0" Margin="5" />
        <TextBox x:Name="txtBoxID"  Grid.Row="0" Grid.Column="1" Margin="5" Text="{Binding PersonId}" TextChanged="txtBoxID_TextChanged" />
        <Label Content="Imię:" Grid.Row="1" Grid.Column="0" Margin="5" />
        <TextBox x:Name="txtBoxImie" Grid.Row="1" Grid.Column="1" Margin="5" Text="{Binding FirstName}" TextChanged="txtBoxImie_TextChanged" />
        <Label Content="Nazwisko:" Grid.Row="2" Grid.Column="0" Margin="5" />
        <TextBox x:Name="txtBoxNazwisko" Grid.Row="2" Grid.Column="1" Margin="5" Text="{Binding LastName}" TextChanged="txtBoxNazwisko_TextChanged" />
        <Label Content="Wiek:" Grid.Row="3" Grid.Column="0" Margin="5" />
        <TextBox x:Name="txtBoxWiek" Grid.Row="3" Grid.Column="1" Margin="5" Text="{Binding Age}" TextChanged="txtBoxWiek_TextChanged" />
        <Label Content="Osoba:" Grid.Row="4" Grid.Column="0" Margin="5" />
        <TextBox Grid.Row="4" Grid.Column="1" Margin="5" Text="" IsEnabled="False"
x:Name="txtOdczytaj" />
        <Button x:Name="btnPokaz" Grid.Row="5" Grid.Column="0" Margin ="5,5,0,10" MinWidth="120"
HorizontalAlignment="Left" Content="Pokaż" Click="btnPokaz_Click" Width="31" />
        <Label x:Name="lblID" Grid.Column="1" Content="Niedozwolona wartość" Foreground="Red" Opacity="0" HorizontalAlignment="Left" Height="26" VerticalAlignment="Center" Width="145" Margin="108,0,0,0"/>
        <Label x:Name="lblName" Grid.Column="1" Content="Niedozwolone znaki" Foreground="Red" Opacity="0" HorizontalAlignment="Left" Height="26" VerticalAlignment="Center" Width="145" Margin="108,0,0,0" Grid.Row="1"/>
        <Label x:Name="lblSName" Grid.Column="1" Content="Niedozwolone znaki" Foreground="Red" Opacity="0" HorizontalAlignment="Left" Height="26" VerticalAlignment="Center" Width="145" Margin="108,0,0,0" Grid.Row="2"/>
        <Label x:Name="lblAge" Grid.Column="1" Content="Niepoprawna wartość" Foreground="Red" Opacity="0" HorizontalAlignment="Left" Height="26" VerticalAlignment="Center" Width="145" Margin="108,0,0,0" Grid.Row="3"/>
        <Button x:Name="btnOdczytaj" Grid.Row="5" Grid.Column="1" Margin ="10,5,0,10" MinWidth="100"
            HorizontalAlignment="Left" Content="Odczytaj" Width="115" />
        <Button x:Name="btnZapisz" Grid.Row="5" Grid.Column="1" Margin ="133,5,0,10" MinWidth="100"
            HorizontalAlignment="Left" Content="Zapisz" Width="114" />
    </Grid>
</Window>
