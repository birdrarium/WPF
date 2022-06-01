using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private List<Person> ListOfPersons = null;
        private List<string> Genders { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitBinding();
        }
        private void InitBinding()
        {
            ListOfPersons = new List<Person>();
            ListOfPersons.Add(new Person(1, "Adam", "Kowalski", 24, "Mężczyzna"));
            ListOfPersons.Add(new Person(2, "Jan", "Kowalski", 23, "Mężczyzna"));
            ListOfPersons.Add(new Person(3, "Agnieszka", "Kowalczyk", 28, "Kobieta"));
            ListOfPersons.Add(new Person(4, "Janusz", "Abacki", 25, "Mężczyzna"));
            ourGrid.ItemsSource = ListOfPersons;
            Genders = new List<string>();
            Genders.Add("Mężczyzna");
            Genders.Add("Kobieta");
            ourGrid.ItemsSource = ListOfPersons;
            Gender.ItemsSource = Genders;
        }
    }
}
// -------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    public class Person
    {
        public string Gender { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(int nPersonId, string sFirstName, string sLastName, int nAge, string plec)
        {
            PersonId = nPersonId;
            FirstName = sFirstName;
            LastName = sLastName;
            Age = nAge;
            Gender = plec;
        }
        public Person() // Konstruktor domyślny dla DataGrid (w celu dodania nowego rekordu)
        { }
        public override string ToString()
        {
            return $"{PersonId} {FirstName} {LastName} {Age} {Gender}";
        }
    }
}
// -------------------------------------------------------------------------------------

<Window x:Class="WpfApp5.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp5"
        mc:Ignorable="d"
        Title="Lista Osób" Height="180" Width="350">
    <Grid Margin="10">
        <DataGrid x:Name="ourGrid" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Id" Binding="{Binding PersonId}" />
                <DataGridTextColumn Header="Imię" Binding="{Binding FirstName}" />
                <DataGridTextColumn Header="Nazwisko" Binding="{Binding LastName}" />
                <DataGridTextColumn Header="Wiek" Binding="{Binding Age}" />
                <DataGridComboBoxColumn x:Name="Gender" Header="Płeć" SelectedItemBinding="{Binding Gender}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
</Window>
