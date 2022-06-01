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
using System.Xml.Linq;

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        static public string pathToData = @"Persons.xml";
        static public string pathToData1 = @"Persons1.xml";
        private List<string> Genders { get; set; }
        private XElement peopleList;
        public MainWindow()
        {
            InitializeComponent();
            peopleList = XElement.Load(pathToData);
            this.dataGrid.DataContext = peopleList;
            Genders = new List<string>();
            Genders.Add("Mężczyzna");
            Genders.Add("Kobieta");
            Gender.ItemsSource = Genders;
        
        }
        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            peopleList.Save(pathToData1);
            MessageBox.Show("Pomyślnie zapisano dane do pliku");
        }
    }
}

// ------------------------------------------------------------------------------------------------

<Window x:Class="WpfApp6.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp6"
        mc:Ignorable="d"
        Title="MainWindow" Height="250" Width="350">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <DataGrid AutoGenerateColumns="False" HorizontalAlignment="Left" x:Name="dataGrid" VerticalAlignment="Top" Height="120" Width="328" Grid.Column="1" ItemsSource="{Binding Path=Elements[Person]}" >
            <DataGrid.Columns>
                <DataGridTextColumn Header="Id" Binding="{Binding Path=Element[PersonId].Value}" />
                <DataGridTextColumn Header="Imię" Binding="{Binding Path=Element[FirstName].Value}"/>
                <DataGridTextColumn Header="Nazwisko" Binding="{Binding Path=Element[LastName].Value}"/>
                <DataGridTextColumn Header="Wiek" Binding="{Binding Path=Element[Age].Value}"/>
                <DataGridComboBoxColumn Width="80" x:Name="Gender" Header="Płeć" SelectedValueBinding="{Binding Path=Element[Gender].Value, Mode=TwoWay}" DisplayMemberPath="{Binding Path=Element[Gender].Value}"></DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
        <Button Grid.Row="1" Grid.Column="1" Margin ="5" MinWidth="120" HorizontalAlignment="Right" Height="30" Content="Zapisz" Click="btnZapisz_Click" />
    </Grid>
</Window>

