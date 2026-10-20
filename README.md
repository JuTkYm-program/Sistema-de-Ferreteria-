# 🛠️ Sistema de Gestión - Ferretería (Mesa de Partes Digital)
---

## 📌 Descripción del Proyecto

Este proyecto es un prototipo funcional desarrollado en **C#** para el curso de **Fundamentos de Programación (CIIN1205P)** de la **Universidad Privada del Norte (UPN)**. 

Inspirado en la necesidad de cumplimiento de la **Ley N.° 31170** (Ley de implementación de mesas de partes digitales y notificaciones electrónicas en el Estado peruano), el sistema transforma un proceso manual llevado en cuadernos físicos a una solución digital centralizada para la microempresa **INVERCIONES GARRUCHAS KARIM S.A.C.**.

El prototipo gestiona tres flujos críticos mediante un menú interactivo en consola:
1. **Módulo de Clientes:** Registro y consulta validada de clientes (DNI/RUC y teléfono).
2. **Módulo de Inventario:** Control de stock y precios ordenados alfabéticamente.
3. **Módulo de Solicitudes:** Registro, seguimiento y resumen estadístico de requerimientos.

---

## 📂 Estructura del Repositorio

```text
Sistema-de-Ferreteria-/
├── .gitignore                   <-- Exclusión de archivos compilados (bin/, obj/)
├── Program.cs                   <-- Código fuente principal en C# (Menú y Funciones)
├── SistemaFerreteria.csproj    <-- Archivo de configuración del proyecto .NET
└── README.md                    <-- Documentación principal del repositorio
```

---

## 🚀 Características y Módulos del Sistema

### 👤 1. Módulo de Gestión de Clientes
* **Registrar Cliente:** Valida la longitud y formato numérico de DNI (8 dígitos) y RUC (11 dígitos), además del teléfono (9 dígitos).
* **Ver Lista:** Muestra una tabla formateada en consola con los datos guardados.
* **Buscar Cliente:** Búsqueda secuencial por número de documento ($O(n)$).

### 📦 2. Módulo de Gestión de Inventario
* **Registrar Producto:** Captura código (5 dígitos), nombre, stock y precio con validación de tipos de datos.
* **Ver Inventario Completo:** Muestra los productos **ordenados alfabéticamente por nombre** utilizando el **Algoritmo de Ordenamiento por Burbuja** ($O(n^2)$) sobre arreglos paralelos.
* **Búsqueda y Edición:** Módulos para consultar por código y actualizar stock (*en desarrollo*).

### 📋 3. Módulo de Solicitudes / Trámites
* **Registrar Solicitud:** Asigna código único, documento del cliente, descripción del producto y cantidad requerida.
* **Buscar por Código:** Búsqueda sin distinción de mayúsculas/minúsculas (`OrdinalIgnoreCase`).
* **Resumen Estadístico:** Calcula el total de solicitudes, pedidos pendientes y suma total de unidades requeridas.

---

## 🛠️ Conceptos de Programación Aplicados

* **Estructuras de Control:** Bucles `while`, `do-while`, `for` y condicionales `switch` / `if-else`.
* **Arreglos Paralelos:** Manejo de datos relacionados en memoria utilizando múltiples arreglos unidimensionales sincronizados por índice.
* **Validaciones de Cadenas:** Métodos como  `.Length`.
* **Algoritmos Fundamentales:** Búsqueda secuencial lineal y ordenamiento por intercambio (Burbuja).
* **Control de Versiones:** Desarrollo colaborativo con Git y GitHub mediante flujo de trabajo por ramas (`branches`) y commits fechados.

---

## ⚙️ Instrucciones de Ejecución Local

### Prerrequisitos
* Teniendo instalado el SDK de **.NET 6.0** o superior.

### Pasos
1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/JuTkYm-program/Sistema-de-Ferreteria-.git
   ```
2. **Navegar a la carpeta del proyecto:**
   ```bash
   cd Sistema-de-Ferreteria-/SistemaFerreteria
   ```
3. **Compilar y ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

---

## 👥 Equipo de Desarrollo

| Estudiante | Código / Rol | Módulo Asignado |
| :--- | :--- | :--- |
| **Ordoñez Monago, Justyn Karim** | Líder / Desarrollador | Módulo de Clientes & Estructura Principal |
| **Tacca Moran, Paola Milagros** | Desarrolladora | Módulo de Inventario |
| **Rodriguez Agila, Jeerson Raul** | Desarrollador | Módulo de Solicitudes |
| **Tacanga Reynoso, Samantha Helena** | Desarrolladora | Soporte & Documentación |

---

## 🎓 Información Académica

* **Institución:** Universidad Privada del Norte (UPN)
* **Facultad:** Ingeniería
* **Curso:** Fundamentos de Programación (`CIIN1205P`)
* **Docente:** Danny Manuel Herrera Najar
* **Semestre:** 2026-2
