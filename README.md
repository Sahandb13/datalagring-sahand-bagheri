EducationCompany – Datalagring

Detta projekt är en inlämningsuppgift inom datalagring. Systemet representerar ett utbildningsföretag som erbjuder yrkeskurser via en applikation.

Lösningen består av:

En relationsdatabas (SQLite)

Ett backend-API byggt med ASP.NET Core Minimal API

En frontend byggd i React

Automatiserade tester med xUnit

Projektet är uppbyggt enligt principerna för Domain-Driven Design (DDD) och Clean Architecture.

Projektstruktur

Projektet är uppdelat i följande lager:

EducationCompany.Domain

Innehåller domänmodellen, dvs. entiteter och affärsregler.

EducationCompany.Application

Innehåller use cases och abstraktioner (t.ex. IAppDbContext). Här ligger applikationslogik som är oberoende av tekniska implementationer.

EducationCompany.Infrastructure

Innehåller tekniska implementationer, bland annat:

AppDbContext

Entity Framework Core-konfiguration

Databaskoppling

EducationCompany.Presentation.Api

ASP.NET Core Minimal API med alla endpoints och Swagger.

EducationCompany.Tests

xUnit-tester som verifierar affärsregler och funktionalitet.

frontend/educationcompany-web

En enkel React-applikation som används för att interagera med API:et.

Funktionalitet

Systemet hanterar:

Kurser

Kurstillfällen

Studenter

Lärare

Kursregistreringar

Det finns stöd för:

CRUD-operationer för kurser

Skapa kurstillfällen kopplade till en kurs

Skapa studenter och lärare

Registrera studenter till kurstillfällen

Kontroll av maxkapacitet på kurstillfällen

Förhindra dubbelregistrering av samma student

Databasen är modellerad enligt relationsprinciper och uppfyller minst 3NF.

Tekniker

.NET 8

ASP.NET Core Minimal API

Entity Framework Core (Code First)

SQLite

xUnit

React (Vite)

Förutsättningar

För att köra projektet krävs:

.NET 8 SDK

Node.js (LTS-version rekommenderas)

npm

Köra backend

Stå i projektets rotmapp (där EducationCompany.sln ligger) och kör:

dotnet run --project EducationCompany.Presentation.Api

Swagger nås via:

http://localhost:5071/swagger

API:t körs på:

http://localhost:5071
Databas och migrationer

Projektet använder Entity Framework Core Code First.

Köra tester

Tester körs med:

dotnet test

Testerna verifierar bland annat att:

Ett kurstillfälle inte kan överskrida sin kapacitet

En student inte kan registreras två gånger till samma tillfälle

Köra frontend

Öppna en separat terminal och navigera till frontend-mappen:

cd frontend/educationcompany-web
npm install
npm run dev

Frontend öppnas normalt på:

http://127.0.0.1:5173

Frontend kommunicerar med backend via:

http://localhost:5071

Backend måste vara igång samtidigt som frontend körs.

Sammanfattning

Projektet uppfyller kraven för:

Relationsdatabas i minst 3NF

Entity Framework Core enligt Code First

ASP.NET Core Minimal API

Tydlig lagerindelning enligt DDD och Clean Architecture

CRUD-funktionalitet

Minst ett automatiserat test

En fungerande frontend som interagerar med API:t