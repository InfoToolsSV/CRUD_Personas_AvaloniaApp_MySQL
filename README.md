# PersonaApp - CRUD con Avalonia, EF Core y MySQL

Este proyecto es una aplicación de escritorio construida con [Avalonia UI](https://avaloniaui.net/), que implementa un CRUD (Crear, Leer, Actualizar, Eliminar) para gestionar personas. Utiliza Entity Framework Core junto al proveedor Pomelo para conectarse a una base de datos MySQL. El desarrollo se realizó con JetBrains Rider.

## 🛠 Tecnologías utilizadas

- Avalonia UI (.NET multiplataforma)
- Entity Framework Core
- MySQL + Pomelo.EntityFrameworkCore.MySql
- MVVM (Model-View-ViewModel)
- JetBrains Rider

## 📂 Estructura del Proyecto

```
PersonaApp/
├── Models/             # Modelo de datos Persona
├── Data/               # DbContext para MySQL
├── Service/            # Lógica CRUD
├── ViewModels/         # Lógica de UI con comandos
├── Views/              # Interfaz de usuario (XAML)
├── Helpers/            # RelayCommand para MVVM
└── App.axaml           # Estilos y tema general
```

## ⚙️ Configuración de la Base de Datos

El archivo `AppDbContext.cs` contiene la cadena de conexión:

```csharp
var connectionString = "server=localhost;database=personadb;user=root;password=123John@";
```

Asegúrate de tener una base de datos llamada `personadb` creada en tu servidor MySQL.

## ▶️ Cómo ejecutar el proyecto

1. Clona el repositorio
2. Restaura los paquetes con `dotnet restore`
3. Ejecuta las migraciones si usas una base de datos limpia
4. Compila y ejecuta desde JetBrains Rider o con `dotnet run`

## 📄 Licencia

Este proyecto está bajo la licencia MIT.

## 🙌 Agradecimientos

Gracias a la comunidad de Avalonia y a los desarrolladores del proveedor Pomelo para MySQL.

---

**Desarrollado por [John] | [InfoToolsSV - YouTube]**
