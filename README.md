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

## AI-användning

AI-baserade verktyg har använts som stöd vid utveckling av frontend och vissa tester.
All kod är granskad och förstådd.


Självutvärdering – EducationCompany

I denna uppgift har jag utvecklat ett system för hantering av kurser, kurstillfällen, studenter, lärare och kursregistreringar med fokus på datalagring och backendutveckling i .NET.

Jag har modellerat databasen enligt principerna för relationsdatabaser och säkerställt att den är normaliserad till minst tredje normalformen (3NF). Relationer mellan entiteter är tydligt definierade och affärsregler, såsom maxkapacitet och skydd mot dubbelregistrering, hanteras i applikationslogiken.

Backend är implementerat som ett ASP.NET Core Minimal API och följer principerna för Domain-Driven Design (DDD) och Clean Architecture. Lösningen är uppdelad i lager (Presentation, Application, Domain, Infrastructure och Tests) med tydlig ansvarsfördelning och korrekt beroenderiktning mellan lagren.

Entity Framework Core har använts enligt Code First-principen för att hantera databasen. Jag har även implementerat enhetstester för att verifiera central funktionalitet i systemet.

En enkel frontend i React har utvecklats för att kunna interagera med backend-API:et och demonstrera att systemet fungerar som avsett. Frontenden används för att skapa och hämta data samt testa registreringslogik.

AI-baserade verktyg har använts som stöd under utvecklingen, främst för frontend och vissa tester. All kod har granskats, anpassats och förståtts innan den inkluderats i projektet.

Sammanfattningsvis uppfyller lösningen kraven för uppgiften genom korrekt databashantering, tydlig arkitektur, fungerande API, tester samt en frontend som demonstrerar systemets funktionalitet.
