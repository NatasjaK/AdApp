# 📢 AdApp  
En Windows Forms-applikation för att hantera annonser med inloggning och databaskoppling.  

---

## ✨ Funktioner  
### 👤 Användarhantering  
- Registrering av nya användare  
- Inloggning / utloggning  
- Endast inloggade användare kan skapa, uppdatera och ta bort sina egna annonser  

### 📋 Annonsfunktioner  
- Skapa, visa, uppdatera och ta bort annonser (CRUD)  
- Kategorier för annonser  
- Sökning via titel och kategori  
- Sortering av annonser (datum, pris stigande/fallande)  

---

## 🗄️ Databasstruktur  
Projektet använder en SQL Server-databas med följande tabeller:  

**Users**  
- `Id` (PK)  
- `Username`  
- `Password`  

**Categories**  
- `Id` (PK)  
- `Name`  

**Ads**  
- `Id` (PK)  
- `Title`  
- `Description`  
- `Price`  
- `CreatedAt`  
- `CategoryId` (FK → Categories.Id)  
- `UserId` (FK → Users.Id)  

---

## 🛠️ Teknik  
- Språk: **C# (.NET)**  
- UI: **Windows Forms**  
- Databas: **SQL Server**  
- Data Access: **ADO.NET (SqlClient)**  


 
