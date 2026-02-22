# 🛒 E-Commerce API

scalable RESTful API for an e-commerce platform built with **ASP.NET Core** following **Clean Architecture** principles. The API supports product management, order processing, and payment integration via **Stripe**.

---

## 🏗️ Architecture

The project follows **Clean Architecture** (Onion Architecture), separating concerns into four distinct layers:

```
E-Commerce API
├── E-Commerce.Domain           → Entities, Enums, Domain Logic
├── E-Commerce.Application      → Use Cases, Interfaces, DTOs, Services
├── E-Commerce.Infrastructure   → EF Core, Repositories, External Services
└── Presentation Layer          → ASP.NET Core Web API, Controllers, Middleware
```

### Layer Responsibilities

**Domain** — The core of the application. Contains all business entities (e.g., `Product`, `Order`, `PaymentMethod`, `Cart`) with no external dependencies.

**Application** — Contains the business logic, service interfaces, DTOs, and use case implementations. Depends only on the Domain layer.

**Infrastructure** — Handles data persistence using Entity Framework Core with SQL Server, repository implementations, Stripe payment integration, and other external service concerns.

**Presentation Layer** — ASP.NET Core Web API controllers that expose HTTP endpoints. Handles request/response mapping, authentication middleware, and API configuration.

---

## 🚀 Features

- ✅ Clean Architecture with separation of concerns
- ✅ RESTful API design
- ✅ Entity Framework Core with Code First Migrations
- ✅ Stripe Payment Integration
- ✅ Multiple Payment Methods support (Credit Card, Cash, etc.)
- ✅ JWT Authentication & Authorization
- ✅ Product & Category Management
- ✅ Order & Cart Management
- ✅ Data Seeding for static lookup data

---

## 🧰 Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core | Web API Framework |
| Entity Framework Core | ORM & Database Migrations |
| SQL Server | Database |
| Stripe .NET SDK | Payment Processing |
| AutoMapper | Object Mapping |
| JWT Bearer | Authentication |

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Stripe Account](https://stripe.com) (for payment features)

### 1. Clone the Repository

```bash
git clone https://github.com/Ibrahim-Omar-dev/E-Commerce-API.git
cd E-Commerce-API
```

### 2. Configure appsettings

In `Presentation Layer/appsettings.json`, set your connection string and Stripe keys:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ECommerceDb;Trusted_Connection=True;"
  },
  "Stripe": {
    "SecretKey": "your-stripe-secret-key",
    "PublishableKey": "your-stripe-publishable-key"
  },
  "Jwt": {
    "Key": "your-jwt-secret-key",
    "Issuer": "ECommerceAPI"
  }
}
```

> ⚠️ **Never commit real API keys to source control.** Use [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) for local development:
> ```bash
> dotnet user-secrets set "Stripe:SecretKey" "sk_test_xxxx"
> ```

### 3. Apply Migrations

```bash
cd "Presentation Layer"
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

The API will be available at `https://localhost:5001` (or the port shown in your terminal).

---

## 📁 Project Structure

```
E-Commerce.Domain/
├── Entities/
│   ├── Product.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── Cart.cs
│   ├── Category.cs
│   └── PaymentMethod.cs
└── Enums/

E-Commerce.Application/
├── DTOs/
├── Interfaces/
│   ├── IProductService.cs
│   ├── IOrderService.cs
│   └── IPaymentService.cs
└── Services/

E-Commerce.Infrastructure/
├── Data/
│   └── AppDbContext.cs
├── Repositories/
└── Migrations/

Presentation Layer/
├── Controllers/
├── Middleware/
├── appsettings.json
└── Program.cs
```

---

## 🔌 API Endpoints

### Products
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/products` | Get all products |
| GET | `/api/products/{id}` | Get product by ID |
| POST | `/api/products` | Create a product |
| PUT | `/api/products/{id}` | Update a product |
| DELETE | `/api/products/{id}` | Delete a product |

### Orders
| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/orders` | Get all orders |
| GET | `/api/orders/{id}` | Get order by ID |
| POST | `/api/orders` | Place a new order |

### Payments
| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/payments/stripe` | Process Stripe payment |
| GET | `/api/payments/methods` | Get available payment methods |

### Authentication
| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Login and get JWT token |

---

## 💳 Payment Methods

The API supports the following payment methods (seeded by default):

- **Credit Card** — via Stripe
- **Cash** — Cash on Delivery

---

## 🗃️ Database Seeding

The application seeds initial data on startup including default payment methods. Seeded records use hardcoded GUIDs to prevent duplicate migrations.

---

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin feature/your-feature`
5. Open a Pull Request



**Ibrahim Omar**  
GitHub: [@Ibrahim-Omar-dev](https://github.com/Ibrahim-Omar-dev)
