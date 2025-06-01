# Exercice API – .NET 8 + MongoDB + Docker + GitHub Actions CI/CD

## Overview

This is a .NET 8 Web API project that allows you to:

- Register a product
- Retrieve product details
- Store product data in MongoDB
- Run the app and database using Docker Compose
- Use GitHub Actions to build, test, push Docker images, and submit K8s deployment PRs

---

### Product Schema

```json
{
  "id": "string[36] (uuid)",
  "stock": int,
  "description": "string",
  "categories": ["string[36]"],
  "price": float
}
```

### Register Request
```json
{
  "description": "string",
  "categories": [{ "id": "string", "name": "string" }],
  "price": "string"
}
```

### Retrieve Request
```
GET /api/products/{id}
```

## How To Run Locally

### Run via Docker Compose
```bash
docker compose up
``` 

## Project Structure

### Folders
```
ExerciceApi/           # Web API project
ExerciceApi.Tests/     # Unit tests
Dockerfile             # API container setup
docker-compose.yml     # App + MongoDB orchestration
k8s/                   # Kubernetes deployment YAML
.github/workflows/     # GitHub Actions CI/CD pipeline
```
### Secrets Required

| Secret Name             | Purpose                      |
| ----------------------- | ---------------------------- |
| `DOCKERHUB_USERNAME`    | DockerHub user               |
| `DOCKERHUB_TOKEN`       | DockerHub access token       |
| `PERSONAL_ACCESS_TOKEN` | GitHub PAT for pushing/PR    |
| `DEPLOY_REPO`           | Format: `username/repo-name` |

### Development Approach

- TDD (Test Driven Development)
- TBD (Trunk Based Development)
- Clean Architecture principles
- Separation of Concerns with Services & Repositories

## Conclusions
### Assumptions made
- Price is received as string and parsed to float.
- Product ID and Category IDs are generated UUIDs.
- Category names are not persisted, only their IDs.
- GitHub Actions handles all deploy PR automation.

### Potential improvements
- Add data validation
- Add Swagger annotations for clearer API docs
- Add authentication
- Add error handling