# 🧰 Employee Management — Full Stack

This project consists of two applications:
1. **Backend**: .NET 8 API using Entity Framework Core (InMemory)
2. **Frontend**: React + Vite application

---

## 📦 Requirements

Before starting, make sure you have installed:
- [.NET SDK 8+](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js 18+](https://nodejs.org/)
- [npm](https://www.npmjs.com/) or [yarn](https://yarnpkg.com/)

---

## 🖥️ 1. Backend (.NET API)

### 📂 Project Structure

```
EmployeeApi/
├── Controllers/
├── Services/
├── Repositories/
├── Models/
├── Dtos/
├── Middleware/
├── Program.cs
└── ...
```

### ▶️ Run locally

```bash
cd EmployeeApi
dotnet restore
dotnet run
```

By default, the API runs on:
- `http://localhost:5009`

### 🧪 Swagger UI

Access the documentation at:
- `https://localhost:5009/swagger`

---

## 🌐 2. Frontend (React + Vite)

### 📂 Project Structure

```
employee-react/
├── src/
│   ├── api/
│   ├── components/
│   ├── config/
│   ├── pages/
│   ├── router/
│   └── types/
├── .env
├── vite-env.d.ts
└── vite.config.ts
```

### 📝 .env example

```env
VITE_API_URL=http://localhost:5009/api
VITE_API_TOKEN=token-123
```

### ▶️ Run locally

```bash
cd employee-react
npm install
npm run dev
```

The frontend runs on:
- `http://localhost:5173`

---

## 🔗 Connecting Frontend and Backend

- The frontend uses the `VITE_API_URL` from the `.env` file to connect to the API.
- The token `VITE_API_TOKEN` is automatically sent in the `X-Auth-Token` header.
- **Important**: Start the API first and then the frontend.

---

## 🧪 How to test the application

1. **Start the API:**
   ```bash
   cd EmployeeApi
   dotnet run
   ```

2. **Start the frontend:**
   ```bash
   cd employee-react
   npm run dev
   ```

3. **Open:**
   - Frontend: `http://localhost:5173`
   - Swagger: `https://localhost:5009/swagger`

4. **Authorize in Swagger using the token:**
   ```
   token-123
   ```

---

## 🧰 Tech Stack

### Backend
- .NET 8
- Entity Framework Core (InMemory)
- Swagger (Swashbuckle)
- Custom Token Middleware

### Frontend
- React 18
- Vite
- TypeScript
- Fetch API
- Environment variables

---

## 🚀 Future Improvements (Optional)

- [ ] Replace InMemory with SQL Server or Postgres
- [ ] Implement real authentication (e.g., Azure AD)
- [ ] Deploy backend to Azure App Service and frontend to Static Web Apps
- [ ] Add automated tests
- [ ] Add Docker support
- [ ] Implement CI/CD pipeline

---

## 📄 License

This project is for demonstration and learning purposes.