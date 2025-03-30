# API-Auth

[![Build Status](https://img.shields.io/travis/Avb-rubns/API-Auth.svg)](https://travis-ci.org/Avb-rubns/API-Auth)  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)


## 📌 Descripción

**API-Auth** es una API de autenticación desarrollada en ASP.NET Core que implementa múltiples métodos de autenticación, incluyendo JWT, refresh tokens, OAuth (para futuros desarrollos) y autenticación basada en API keys. La solución combina Entity Framework Core (EFC) y Dapper para gestionar el acceso a datos, permitiendo flexibilidad en las consultas y operaciones CRUD.

Esta API está diseñada para:
- Proveer autenticación mediante JWT de corta duración (por ejemplo, 15 minutos).
- Implementar un mecanismo de refresh token (con expiración configurable, por ejemplo, 7 días) que se actualiza de forma "rolling" al renovar el token.
- Validar y gestionar sesiones de usuarios, utilizando un middleware personalizado para filtrar rutas protegidas y permitir excepciones (endpoints públicos como login y refresh).


## Características

- **JWT Authentication:** Genera tokens JWT para usuarios autenticados.
- **Refresh Tokens:** Permite la renovación del JWT mediante un refresh token rodante.
- **Middleware personalizado:** Valida el JWT en cada solicitud, con posibilidad de excluir endpoints públicos (login, registro, refresh).
- **Integración con Repositories:** Uso combinado de EFC y Dapper para el acceso a datos, separando la lógica de usuarios y sesiones.
- **Estructura modular:** Controladores separados para autenticación (login, logout, refresh) y registro, con soporte para futuros métodos como OAuth y API Keys.


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
