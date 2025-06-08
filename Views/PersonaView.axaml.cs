using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PersonaApp.ViewModels;

namespace PersonaApp.Views;

public partial class PersonaView : UserControl
{
    public PersonaView()
    {
        InitializeComponent();
        DataContext = new PersonaViewModel();
    }
}