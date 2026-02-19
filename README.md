EducationCompany – Datalagring

Detta projekt är en inlämningsuppgift i kursen Datalagring. Systemet representerar ett utbildningsföretag som hanterar kurser, kurstillfällen, studenter, lärare och kursregistreringar.

Backend är byggt med ASP.NET Core Minimal API och Entity Framework Core (Code First) mot en SQLite-databas. En enkel React-frontend används för att testa och demonstrera funktionaliteten.

Projektet är uppdelat enligt DDD och Clean Architecture med separata lager för Domain, Application, Infrastructure, Presentation och Tests.

Funktionalitet

Systemet stödjer:

CRUD för kurser

Skapande av kurstillfällen

Skapande av studenter och lärare

Registrering av studenter till kurstillfällen

Kontroll av maxkapacitet

Skydd mot dubbelregistrering

Databasen är normaliserad och uppfyller minst 3NF.

Tekniker

.NET 8

ASP.NET Core Minimal API

Entity Framework Core (Code First)

SQLite

React (Vite)

xUnit

Köra backend

Från projektets rotmapp:

dotnet run --project EducationCompany.Presentation.Api

Swagger finns på:

http://localhost:5071/swagger
Köra tester
dotnet test
Köra frontend

I en separat terminal:

cd frontend/educationcompany-web
npm install
npm run dev

Frontend öppnas på:

http://127.0.0.1:5173

Backend måste vara igång samtidigt som frontend körs.