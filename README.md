# Trainee Management Api
---

## Technology Used
- C#
- .NET

## How to Run

### Clone Repository
`git clone https://github.com/Rheetikzeus/Trainee-Management-Api`

### Navigate to Project directory
`cd Trainee-Management-Api`

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
  'https://localhost:7249/api/trainee' \
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


### `GET` `/api/trainee/{Id}`

#### Sample Request 

```bash
curl -X 'GET' \
  'https://localhost:7249/api/trainee/1' \
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

### `POST` `/api/trainee`
#### Sample Request 

```bash
curl -X 'POST' \
  'https://localhost:7249/api/trainee' \
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

### `PUT` `/api/trainee/{Id}`

#### Sample Request 

```bash
curl -X 'PUT' \
  'https://localhost:7249/api/trainee/2' \
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

### `DELETE` `/api/trainee/{Id}`

#### Sample Request 

```bash
curl -X 'DELETE' \
  'https://localhost:7249/api/trainee/2' \
  -H 'accept: */*'
```

### `GET` `/api/trainee?search={query}`
#### Sample Request 

```bash
curl -X 'GET' \
  'https://localhost:7249/api/trainee?search=HTML' \
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


## Known Limitations
- In Memory Database (Not Persistent)

