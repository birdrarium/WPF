<Window x:Class="WpfApp2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp2"
        mc:Ignorable="d"
        Title="Test wiązania danych" Height="200" Width="550
        ">
    <Grid>
        <Label Content="Rozmiar" Margin="16,2,187,-3"/>
        <Label Content="Kolor" Margin="16,32,187,-32"/>
        <Label Content="Tekst" Margin="16,62,187,-61"/>
        <StackPanel Margin="83,5,0,0">
            <Slider x:Name="rozmiarTekstu" Minimum="10" Value="15" Maximum="44" Width="450" Height="30"/>
            <ComboBox x:Name="kolor" Width="300" IsSynchronizedWithCurrentItem="False" HorizontalAlignment="Left" SelectedIndex="0" >
                <ComboBoxItem Content="Blue"></ComboBoxItem>
                <ComboBoxItem Content="Pink"></ComboBoxItem>
                <ComboBoxItem Content="Violet"></ComboBoxItem>
                <ComboBoxItem Content="Black"></ComboBoxItem>
            </ComboBox>
            <TextBox x:Name="txtBox" Text="Kolejny test" TextWrapping="Wrap" Width="300" Margin="0,10,0,0" HorizontalAlignment="Left" Height="22"/>
            <TextBlock FontSize="{Binding Value, ElementName=rozmiarTekstu}" Foreground="{Binding SelectedValue.Content, ElementName=kolor}" Margin="-70,10,0,0"><Run x:Name="txtTest" Text="{Binding Text, ElementName=txtBox}"/></TextBlock>
        </StackPanel>
    </Grid>
</Window>
