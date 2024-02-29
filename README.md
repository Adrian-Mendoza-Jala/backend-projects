# Backend Projects

## Backend II

### ✅ Script and Diagram for SkillMastery

### ✅ SQL statements

___
## Backend I

### ✅ Class 1 - Language Infrastructures Comparison

### ✅ Class 2 - Console App | Task Manager

### ✅ Class 3 - Console App | Input Commands

### ✅ Class 4 - Console App | Add Calculator

### ✅ Class 5 - Console App | Quiz Game

### ✅ Class 6 - Console App | Vehicle Structure

### ✅ Class 7 - Console App | Generic Class

### ✅ Class 8 - Console App | Exceptions

### ✅ Class 9 - Research

### ✅ Class 10 - Design an Application for Skill Mastery

### ✅ Class 20 - LinQ Exercises

### ✅ Class 21 - Struct, Record and Class

### ✅ Class 25 - Exercise ValidBrackets

### ✅ Class 27 - Factory Method

### ✅ Builder Pattern

### ✅ Desktop App

### ✅ Concurrent Task Manager

---

## SkillMasteryAPI

- ✅ Skill (GetAll, GetById, Post, Put, Delete, Get with Pagination) Connection with Microsoft SQL Server
- ✅ Interfaces for Services and Repositories
- ✅ Dependency Injection
- ✅ Domain Centric Architecture
- ✅ Global Exception handler Middleware
- ✅ Response Compression using gzip
- ✅ Versioning
- ✅ Fluent Validation
- ✅ Health Checker
- ✅ Status Code
- ✅ Authentication
- ✅ Unit Tests for each Layer 

___

# API Documentation for Skill Mastery API

## Overview

The API is structured around REST principles, providing standard CRUD operations for resources like `Goals` and `Skills`. 

Please note that the `Auth` endpoints are currently not operational. 

The API is accessible via the following base URLs:

- Main API: [https://bootcamp-test-web-ap.azurewebsites.net/](https://bootcamp-test-web-ap.azurewebsites.net/)
- Swagger Documentation: [https://bootcamp-test-web-ap.azurewebsites.net/swagger/index.html](https://bootcamp-test-web-ap.azurewebsites.net/swagger/index.html)
- Database Host: [ep-wandering-lab-a5xn2zgj.us-east-2.aws.neon.tech](ep-wandering-lab-a5xn2zgj.us-east-2.aws.neon.tech)

## Endpoints

### Goals
- **GET** `/api/{version}/goals`  
  Retrieve a list of all goals.

- **POST** `/api/{version}/goals`  
  Create a new goal.

- **GET** `/api/{version}/goals/{id}`  
  Retrieve a goal by its unique ID.

- **PUT** `/api/{version}/goals/{id}`  
  Update an existing goal.

- **DELETE** `/api/{version}/goals/{id}`  
  Delete a goal by ID.

### Skills
- **GET** `/api/{version}/skills`  
  Fetch all skills.

- **POST** `/api/{version}/skills`  
  Add a new skill to the database.

- **GET** `/api/{version}/skills/{id}`  
  Get a skill's details by ID.

- **PUT** `/api/{version}/skills/{id}`  
  Modify an existing skill.

- **DELETE** `/api/{version}/skills/{id}`  
  Remove a skill from the database.

- **GET** `/api/{version}/skills/paginated`  
  Get a paginated list of skills.

### Authentication (Currently Unavailable)
- **POST** `/api/auth/register`  
  Endpoint for user registration (not functional).

- **POST** `/api/auth/login`  
  Endpoint for user login (not functional).

## Usage

Replace `{version}` with the actual version number, e.g., `1`.

## Error Handling

Errors are returned using standard HTTP response codes. 

In the case of an error, the response will contain additional information in the body to help diagnose the issue.
