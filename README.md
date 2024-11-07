# Grocery Store Application

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Modules Overview](#modules-overview)
  - [Login and User Authentication](#login-and-user-authentication)
  - [User Management (CRUD)](#user-management-crud)
  - [Category Management](#category-management)
  - [Shopping Cart and Navigation](#shopping-cart-and-navigation)
  - [Search and Filters](#search-and-filters)
  - [Session and Activity Tracking](#session-and-activity-tracking)

## Introduction

**Grocery Store Application** is a web-based app aimed at simplifying grocery shopping. It enables users to browse products, manage categories, add items to their shopping cart, and more. This application is designed for ease of use, with features that streamline the shopping experience for both visitors and administrators.

## Features
- User authentication (sign up, login, logout)
- CRUD operations for user and category management
- Cart management with item count display
- Search and filter functionalities
- User activity logging and session management

## Technologies Used
- ASP.NET Web Forms
- C#
- SQL Server for data storage
- Bootstrap for responsive design

## Architecture
The application follows a modular structure with distinct roles for each component:
1. **Login** - User authentication and session handling.
2. **User Management** - Add, update, delete user accounts with validation checks.
3. **Category Management** - Manage product categories for a streamlined shopping experience.
4. **Shopping Cart** - Dynamic display of cart items and total count.
5. **Search** - Search functionality for navigating products.

## Getting Started
To run this application:
1. Clone the repository: `git clone https://github.com/yourusername/grocery-store-app.git`
2. Open the project in Visual Studio.
3. Set up the database with `database.mdf` and configure the connection strings.
4. Run the application through Visual Studio IIS Express.

## Modules Overview

### Login and User Authentication
**Screenshots**:  
- **Input Fields and Button**: Utilizes `runat="server"` to make elements accessible in the C# event handler.
- **SignIn Method**: Authenticates users by checking email and password against the database, redirects based on user type (admin/visitor).
- **Session Management**: Session is cleared on logout, and user type is checked to assign roles appropriately.

### User Management (CRUD)
**Screenshots**:  
- **Add User**: Validates user data (email, name, phone, etc.), adds to `Customer` table in the database.
- **Update/Delete User**: Users can be updated or deleted from the database based on email.
- **Field Reset and Notifications**: Fields reset after CRUD operations; success messages displayed using Bootstrap alerts.

### Category Management
**Screenshots**:  
- **Add Category**: Users can add new categories with name and description. The data is saved in `Product_Category`.
- **Update/Delete Category**: Allows modification and deletion of categories by ID.
- **Grid Selection**: Displays category information in a `GridView` for easy management.

### Shopping Cart and Navigation
**Screenshots**:  
- **Cart Item Count**: Displays a dynamic count of items in the cart.
- **Main Navigation Bar**: Provides links to main sections such as products, home, etc.
- **Search and Redirect**: Allows users to search for products and redirects to results.

### Search and Filters
**Screenshots**:  
- **Filter and Sort Options**: Enables filtering and sorting of products.
- **Redirection**: Updates page links with filter data to maintain state across pages.

### Session and Activity Tracking
- **Session Management**: Tracks and resets session data on login/logout.
- **Activity Logging**: Records user activities (e.g., login) in the `Activity` table with timestamps.

---

For more detailed screenshots and walkthroughs, refer to the provided `.aspx.cs` files for each module.