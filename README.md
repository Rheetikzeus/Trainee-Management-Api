# Trainee Management Api
---

## Technology Used
- C# 14
- .NET 10

## How to Run

### Clone Repository
`git clone https://github.com/Rheetikzeus/Trainee-Management-Api`

### Navigate to Project directory
`cd Trainee-Management-Api`

### Modify Connection string in appsettings.json
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost;port=3306;database=trainee_management_db;user=root;password=root;"
    }
}
```

### Apply migration to database
`dotnet ef database update`


### Run Application
`dotnet run`


## API List

|Method| Endpoint|
|:---|:---|
|`GET` | ` /api/health` |
|`GET` | ` /api/trainees` |
|`GET` | ` /api/trainees/{id}` |
|`POST` | ` /api/trainees` |
|`PUT` | ` /api/trainees/{id}` |
|`DELETE` | ` /api/trainees/{id}` |
|`GET` | ` /api/trainees?search={query}` |

### `GET` `/api/health`

#### Sample Request 

```bash
curl -X 'GET' \
  'https://localhost:7249/api/health' \
  -H 'accept: */*'
```


#### Sample Response 
```json
{
  "status": "running",
  "application": "Trainee Management API",
  "timestamp": "2026-06-08T13:01:14"
}
```


### `GET` `/api/trainee`

#### Sample Request 

```bash
curl -X 'GET' \
  'https://localhost:7249/api/trainees' \
  -H 'accept: */*'
```


#### Sample Response 
```json
[
  {
    "id": 1,
    "firstName": "Rheetik",
    "lastName": "Sharma",
    "email": "rheetik@gmail.com",
    "techStack": "HTML",
    "status": "Active",
    "createdDate": "2026-06-08T12:39:46.8994826Z",
    "updatedDate": "2026-06-08T12:39:46.8995949Z"
  },
  {
    "id": 2,
    "firstName": "Jay",
    "lastName": "Sharma",
    "email": "Jay@gmail.com",
    "techStack": "HTML",
    "status": "Active",
    "createdDate": "2026-06-08T12:50:48.2246143Z",
    "updatedDate": "2026-06-08T12:50:48.2246145Z"
  }
]
```


### `GET` `/api/trainees/{Id}`

#### Sample Request 

```bash
curl -X 'GET' \
  'https://localhost:7249/api/trainees/1' \
  -H 'accept: */*'
```


#### Sample Response 
```json
{
  "id": 1,
  "firstName": "Rheetik",
  "lastName": "Sharma",
  "email": "rheetik@gmail.com",
  "techStack": "HTML",
  "status": "Active",
  "createdDate": "2026-06-08T12:39:46.8994826Z",
  "updatedDate": "2026-06-08T12:39:46.8995949Z"
}
```

### `POST` `/api/trainees`
#### Sample Request 

```bash
curl -X 'POST' \
  'https://localhost:7249/api/trainees' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "Rheetik",
  "lastName": "Sharma",
  "email": "rheetik@gmail.com",
  "techStack": "HTML",
  "status": "Active"
}'
```


#### Sample Response 
```json
{
  "id": 1,
  "firstName": "Rheetik",
  "lastName": "Sharma",
  "email": "rheetik@gmail.com",
  "techStack": "HTML",
  "status": "Active",
  "createdDate": "2026-06-08T12:39:46.8994826Z",
  "updatedDate": "2026-06-08T12:39:46.8995949Z"
}
```

### `PUT` `/api/trainees/{Id}`

#### Sample Request 

```bash
curl -X 'PUT' \
  'https://localhost:7249/api/trainees/2' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "firstName": "Jay",
  "lastName": "Sharma",
  "email": "jayprakash@gmail.com",
  "techStack": "CSS",
  "status": "Inactive"
}'
```


#### Sample Response 
```json
{
  "id": 2,
  "firstName": "Jay",
  "lastName": "Sharma",
  "email": "jayprakash@gmail.com", 
  "techStack": "CSS",
  "status": "Inactive",
  "createdDate": "2026-06-08T12:50:48.2246143Z",
  "updatedDate": "2026-06-08T12:54:56.5855716Z"
}
```

### `DELETE` `/api/trainees/{Id}`

#### Sample Request 

```bash
curl -X 'DELETE' \
  'https://localhost:7249/api/trainees/2' \
  -H 'accept: */*'
```

### `GET` `/api/trainees?search={query}`
#### Sample Request 

```bash
curl -X 'GET' \
  'https://localhost:7249/api/trainees?search=HTML' \
  -H 'accept: */*'
```


#### Sample Response 
```json
[
  {
    "id": 1,
    "firstName": "Rheetik",
    "lastName": "Sharma",
    "email": "rheetik@gmail.com",
    "techStack": "HTML",
    "status": "Active",
    "createdDate": "2026-06-08T13:04:17.2030743Z",
    "updatedDate": "2026-06-08T13:04:17.2030753Z"
  },
  {
    "id": 2,
    "firstName": "Jay",
    "lastName": "Sharma",
    "email": "Jay@gmail.com",
    "techStack": "HTML",
    "status": "Active",
    "createdDate": "2026-06-08T13:03:43.7584587Z",
    "updatedDate": "2026-06-08T13:03:43.758504Z"
  }
]
```


