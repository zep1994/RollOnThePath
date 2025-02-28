# RollOnThePath

**RollOnThePath** is a full-stack **.NET MAUI** mobile application designed to help users **track and manage jiujitsu training sessions, log progress, and analyze performance over time**. This project utilizes **.NET Core, C#, and Entity Framework** for backend development, **PostgreSQL** for data storage, and **RESTful APIs** for seamless communication between the frontend and backend.

## 🚀 Features

- **User Authentication** – Secure login and session management  
- **Training Logs** – Record and analyze training sessions  
- **Performance Analytics** – Track progress and insights over time  
- **Cloud-Based Syncing** – Store and retrieve data across multiple devices  
- **Responsive UI** – Optimized for iOS and Android with .NET MAUI  

## 🛠 Technologies Used

### **Backend**
- **.NET Core 7** – Backend API  
- **C#** – Primary backend language  
- **Entity Framework Core** – ORM for database management  
- **PostgreSQL** – Relational database  

### **Frontend**
- **.NET MAUI** – Cross-platform mobile development  
- **XAML** – UI components and layout  
- **MVVM Pattern** – Clean architecture and state management  

### **DevOps & Cloud**
- **Azure App Services** – Hosting and deployment  
- **CI/CD Pipelines** – Automated builds and deployments  
- **Docker** – Containerized backend services  
- **GitHub Actions** – Continuous integration  

---

## 📦 Installation & Setup

### **Prerequisites**
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with MAUI workload installed)  
- [PostgreSQL](https://www.postgresql.org/download/)  
- [Android/iOS Emulator](https://developer.android.com/studio/run/emulator)  

### **Clone the Repository**
```sh
git clone https://github.com/zep1994/RollOnThePath.git
cd RollOnThePath
```

### **Backend Setup**
Navigate to the API project directory:
```sh
cd RollOnThePath_API
```
Restore dependencies and build the project:
```sh
dotnet restore
dotnet build
```
Update the `appsettings.json` file with your PostgreSQL connection string.

Apply database migrations:
```sh
dotnet ef database update
```
Run the API:
```sh
dotnet run
```

### **Frontend Setup**
Navigate to the .NET MAUI project:
```sh
cd ../RollOnThePath_Mobile
```
Restore dependencies:
```sh
dotnet restore
```
Run the application on an emulator or a physical device:
```sh
dotnet build
dotnet run
```

---

## 📖 Usage

1. **Log in/Register**: Create an account and securely authenticate.  
2. **Track Training Sessions**: Add new sessions with timestamps, locations, and notes.  
3. **Analyze Progress**: View graphs and performance metrics based on training history.  
4. **Sync Data**: Automatically save progress to the cloud and retrieve data from any device.  

---

## 🤝 Contributing

We welcome contributions! Follow these steps to contribute:

1. **Fork** the repository.
2. **Create a feature branch**:  
   ```sh
   git checkout -b feature-branch
   ```
3. **Commit your changes**:  
   ```sh
   git commit -m "Added new feature"
   ```
4. **Push to your branch**:  
   ```sh
   git push origin feature-branch
   ```
5. **Open a Pull Request** and describe your changes.

---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📞 Contact

**Thomas Matlock**  
📧 Email: [thomasmatlockbba@gmail.com](mailto:thomasmatlockbba@gmail.com)  
📞 Phone: (601) 812-8079  
🔗 LinkedIn: [linkedin.com/in/tmatlockCISA](https://linkedin.com/in/tmatlockCISA)  
📂 Portfolio: [thomas-matlock.onrender.com](https://thomas-matlock.onrender.com)
