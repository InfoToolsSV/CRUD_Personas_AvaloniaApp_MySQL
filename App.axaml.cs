using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using PersonaApp.Data;

namespace PersonaApp;

public partial class App : Application
{
    private readonly AppDbContext _db = new AppDbContext();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        // dotnet ef database update
        _db.Database.Migrate();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}