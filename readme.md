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

### Run via Docker Desktop
Make sure you have "Enable Kubernets" setting enabled in your settings.

- Clone the [CTT_Exercice_Deploys](https://github.com/Diogo-Maia/CTT_Exercice_Deploys)
```
git clone https://github.com/your-username/CTT_Exercice_API.git
cd CTT_Exercice_API
```
- Apply the manifest
```
kubectl apply -f k8s/exercice-api.yaml
```
- Confirm pod is running
```
kubectl get pods
```
- Expose the service
```
kubectl port-forward service/exercice-api 5000:8080
```
Project should be available [here](http://localhost:5000/swagger)

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