# 🌐 Virtual Community Support — Full Stack Project

🚀 A 15-Day Internship Project using Angular + .NET Core API + PostgreSQL + Swagger  
🔐 Includes Authentication, Authorization, Role-based Access (Admin/User), and CRUD operations

📅 15-Day Training Plan:

Day 1: PostgreSQL Basics - Create, Insert, Update, Delete, Subqueries  
Day 2: Angular Setup - Forms, Components  
Day 3: .NET API + Swagger + EF Core + Repository Pattern  
Day 4: Code First Approach + LINQ + Login API  
Day 5: Authentication & Authorization with JWT  
Day 6: Role-Based Access - Admin/User + ACLs  
Day 7: User Data Retrieval - Filtering, Sorting, Paging  
Day 8: User CRUD  
Day 9: Mission & Theme CRUD  
Day 10: Mission Skill CRUD  
Day 11: Mission Listing on User Side  
Day 12: Mission Apply + Application CRUD  
Day 13: My Profile Page + Deployment Strategy  
Day 14: Review & Debug  
Day 15: AWS Hosting Session

🛠️ Tech Stack:

Frontend: Angular 15+  
Backend: .NET Core 6/7 Web API  
Database: PostgreSQL  
API Docs: Swagger (OpenAPI)  
ORM: Entity Framework Core (Code First)  
Authentication: JWT Token  
Authorization: Role-Based (Admin/User)  
Architecture: N-Tier + Repository Pattern  
Deployment: Localhost / AWS  

📁 Project Structure:

📦VirtualCommunitySupport  
┣ 📁ClientApp → Angular Frontend  
┣ 📁API → .NET Web API  
┣ 📁API.Entities → EF Models  
┣ 📁API.Repository → Data Layer  
┣ 📁API.Services → Business Logic  
┗ 📄README.md  

🐘 PostgreSQL Setup:

CREATE DATABASE virtual_community;  

In appsettings.json:
"ConnectionStrings": {  
  "DefaultConnection": "Host=localhost;Port=5432;Database=virtual_community;Username=postgres;Password=your_password"  
}

⚙️ Commands:

EF Core:
dotnet ef migrations add InitCreate  
dotnet ef database update  

Angular:
cd ClientApp  
npm install  
ng serve  

.NET API:
cd API  
dotnet restore  
dotnet run  

Swagger:
Run project → Navigate to: https://localhost:5001/swagger  
Test: /api/auth/login, /api/users, /api/missions  

GitHub:
git init  
git remote add origin https://github.com/your-username/Internship-Project.git  
git add .  
git commit -m "Initial commit"  
git push origin main  
