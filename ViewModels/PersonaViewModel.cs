using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PersonaApp.Helpers;
using PersonaApp.Models;
using PersonaApp.Service;

namespace PersonaApp.ViewModels;

public class PersonaViewModel : INotifyPropertyChanged
{
    private readonly PersonaService _service = new();

    public ObservableCollection<Persona> Personas { get; } = new();

    public ICommand AgregarCommand { get; }
    public ICommand ActualizarCommand { get; }
    public ICommand EliminarCommand { get; }
    public ICommand LimpiarCommand { get; }

    public PersonaViewModel()
    {
        AgregarCommand = new RelayCommand(Agregar);
        ActualizarCommand = new RelayCommand(Actualizar);
        EliminarCommand = new RelayCommand(Eliminar);
        LimpiarCommand = new RelayCommand(LimpiarCampos);

        CargarPersonas();
        LimpiarCampos();
    }

    private Persona _personaSeleccionada;

    public Persona PersonaSeleccionada
    {
        get => _personaSeleccionada;
        set
        {
            if (_personaSeleccionada != value)
            {
                _personaSeleccionada = value;
                OnPropertyChanged();
                if (value != null)
                {
                    Nombre = value.Nombre;
                    FechaNacimiento = value.FechaNacimiento;
                    Genero = value.Genero;
                    AceptaTerminos = value.AceptaTerminos;
                }
                else
                {
                    LimpiarCampos();
                }
            }
        }
    }

    private string _nombre;

    public string Nombre
    {
        get => _nombre;
        set
        {
            _nombre = value;
            OnPropertyChanged();
        }
    }

    private DateTimeOffset? _fechaNacimiento;

    public DateTimeOffset? FechaNacimiento
    {
        get => _fechaNacimiento;
        set
        {
            _fechaNacimiento = value;
            OnPropertyChanged();
        }
    }

    private string _genero;

    public string Genero
    {
        get => _genero;
        set
        {
            _genero = value;
            OnPropertyChanged();
        }
    }

    private bool _aceptaTerminos;

    public bool AceptaTerminos
    {
        get => _aceptaTerminos;
        set
        {
            _aceptaTerminos = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void CargarPersonas()
    {
        Personas.Clear();
        foreach (var p in _service.ObtenerPersonas())
        {
            Personas.Add(p);
        }
    }

    public void LimpiarCampos()
    {
        Nombre = string.Empty;
        FechaNacimiento = null;
        Genero = string.Empty;
        AceptaTerminos = false;
        PersonaSeleccionada = null;
    }

    public bool Validar() =>
        !string.IsNullOrWhiteSpace(Nombre) &&
        FechaNacimiento.HasValue && !string.IsNullOrWhiteSpace(Genero);

    public void Agregar()
    {
        if (!Validar()) return;

        var nuevaPersona = new Persona
        {
            Nombre = Nombre.Trim(),
            FechaNacimiento = FechaNacimiento.Value,
            Genero = Genero,
            AceptaTerminos = AceptaTerminos,
        };
        
        _service.AgregarPersona(nuevaPersona);
        CargarPersonas();
        LimpiarCampos();
    }

    public void Actualizar()
    {
        if (PersonaSeleccionada == null || !Validar()) return;
        
        PersonaSeleccionada.Nombre = Nombre.Trim();
        PersonaSeleccionada.FechaNacimiento = FechaNacimiento.Value;
        PersonaSeleccionada.Genero = Genero;
        PersonaSeleccionada.AceptaTerminos = AceptaTerminos;
        
        _service.ActualizarPersona(PersonaSeleccionada);
        CargarPersonas();
        LimpiarCampos();
    }

    public void Eliminar()
    {
        if (PersonaSeleccionada == null) return;
        
        _service.EliminarPersona(PersonaSeleccionada);
        CargarPersonas();
        LimpiarCampos();
    }
}