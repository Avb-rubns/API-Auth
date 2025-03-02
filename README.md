# API-Auth

## 📌 Descripción

**API-Auth** es un servicio diseñado para el registro y la generación de **API Keys** para aplicaciones.  
Implementa **Arquitectura Limpia (Clean Architecture)** y utiliza **Entity Framework Core (EFC)** y **Dapper** para la gestión de datos.  

---

## 🚀 Tecnologías Utilizadas

- **.NET 9**  
- **Entity Framework Core (EFC)**  
- **Dapper**  
- **Inyección de Dependencias**  
- **Scala** (para documentación)  
- **SQL Server** (como base de datos)  

---

## 📂 Arquitectura

El proyecto sigue los principios de **Clean Architecture**, dividiendo la solución en las siguientes capas:

1. **Application** → Contiene los casos de uso y lógica de negocio.  
2. **Domain** → Define las entidades y reglas de negocio.  
3. **Infrastructure** → Implementa la persistencia de datos con EFC y Dapper.  
4. **Presentation (WebAPI)** → Expone los endpoints y gestiona las solicitudes HTTP.  

---

## 📌 Instalación y Configuración

### 🔹 Requisitos previos
- .NET 9 instalado  
- SQL Server configurado  
- Configurar la cadena de conexión en `appsettings.json`  

### 🔹 Clonar el repositorio
```sh
git clone https://github.com/Avb-rubns/API-Auth.git
cd API-Auth
