🎓 EducationCompany – Datalagring

Ett system som representerar ett utbildningsföretag som hanterar:

Kurser

Kurstillfällen

Studenter

Lärare

Kursregistreringar

Projektet är byggt med ASP.NET Core Minimal API och Entity Framework Core (Code First) mot en SQLite-databas.
En enkel React-frontend (Vite) används för att testa och demonstrera funktionaliteten.

Arkitekturen följer DDD (Domain-Driven Design) och Clean Architecture med tydlig lagerindelning.

🏗️ Arkitektur

Projektet är uppdelat i följande lager:

EducationCompany
│
├── Domain          → Entiteter och affärsregler
├── Application     → Use cases och affärslogik
├── Infrastructure  → Databas och externa implementationer
├── Presentation    → API (Minimal API)
└── Tests           → Enhetstester (xUnit)

Databasen är normaliserad och uppfyller minst 3NF.

✨ Funktionalitet

Systemet stödjer:

✅ CRUD för kurser

✅ Skapande av kurstillfällen

✅ Skapande av studenter och lärare

✅ Registrering av studenter till kurstillfällen

✅ Kontroll av maxkapacitet

✅ Skydd mot dubbelregistrering

🛠️ Tekniker

.NET 8

ASP.NET Core Minimal API

Entity Framework Core (Code First)

SQLite

React (Vite)

xUnit



📋 Förutsättningar

- .NET 8 SDK
- Node.js (v18 eller senare)
  
🚀 Kom igång

1️⃣ Starta Backend

Från projektets rotmapp:

dotnet run --project EducationCompany.Presentation.Api

Swagger UI finns på:

http://localhost:5071/swagger
2️⃣ Kör tester
dotnet test
3️⃣ Starta Frontend

I en separat terminal:

cd frontend/educationcompany-web
npm install
npm run dev

Frontend öppnas på:

http://127.0.0.1:5173

⚠️ Backend måste vara igång samtidigt som frontend körs.
