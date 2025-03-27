📌 Project Overview

AutoStand is a comprehensive vehicle dealership management system designed to streamline inventory management, customer relations, and sales tracking for automotive businesses.

🚀 Features

Customer Management: Track customer details, purchases, and interactions

Inventory Control: Monitor vehicle stock and movement history

Sales Tracking: Record transactions and generate reports

Data Integrity: Soft-delete functionality for all entities

🛠️ Database Schema

The system uses a SQL Server database with the following main tables:

Customers (dbo.Customers)
Stores client information including:

Personal details (name, NIF, contact info)

Registration dates

Soft-delete tracking

Vehicles (implied table)
Contains vehicle specifications:

Make, model, year

VIN numbers

Pricing information

Inventory Movements (dbo.InventoryMovements)
Tracks all stock transactions:

Movement types (in/out)

Purchase/sale prices

Supplier information

Timestamps for all actions

🔧 Setup Instructions

Database Setup:

sql
Copy
-- Run the schema creation script
-- Execute the data insertion script for sample data
Configuration:

Update connection strings in appsettings.json

Configure any business rules as needed

Migrations:

Copy
dotnet ef database update
📊 Sample Data

The database comes pre-loaded with:

5 sample customers

5 vehicle models

7 inventory movement records

Realistic Portuguese NIFs and contact information
