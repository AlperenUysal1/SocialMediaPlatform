# Social Media Platform

A modern, full-stack social media application built with **.NET 8**, **Blazor Server**, and **Clean Architecture**.

## 🚀 Tech Stack

- **Backend:** ASP.NET Core Web API (.NET 8)
- **Frontend:** Blazor Web App (Interactive Server Mode)
- **Database:** SQLite (with Entity Framework Core)
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API, UI)
- **Styling:** Custom CSS (Facebook-inspired design) + Bootstrap 5

## ✨ Features

- **Create Post:** Share your thoughts with text and images.
- **News Feed:** View posts from users in a modern card layout.
- **Interactive UI:** 
  - Sidebar navigation
  - Trending topics section
  - Randomly generated user avatars (using UI Avatars API)
- **Real-time-ready:** Built on Blazor Server for seamless interactions.

## 🛠️ Getting Started

1. **Clone the repository**
2. **Run the Backend API:**
   ```bash
   cd src/SocialMedia.API
   dotnet run
   ```
3. **Run the Frontend UI:**
   ```bash
   cd src/SocialMedia.UI
   dotnet run
   ```
4. **Open in Browser:**
   - UI: `http://localhost:5251`
   - API Swagger: `http://localhost:5241/swagger`

## 🏗️ Project Structure

- `SocialMedia.Domain`: Entities and core logic.
- `SocialMedia.Application`: Interfaces, DTOs, and business rules.
- `SocialMedia.Infrastructure`: Database context and repositories.
- `SocialMedia.API`: RESTful API endpoints.
- `SocialMedia.UI`: Blazor Server frontend.

