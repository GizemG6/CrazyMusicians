# CrazyMusicians

Overview
--------------
Crazy Musicians API is a simple ASP.NET Core Web API that provides CRUD (Create, Read, Update, Delete) operations for managing a list of humorous and fictional musicians. Each musician has unique traits, making the API fun to use while also demonstrating essential RESTful API features.

Features
--------------
1- CRUD Operations:

•Create a new musician.

•Read all musicians or search by specific attributes.

•Update an existing musician.

•Delete a musician by ID.

2- Validation:

•Ensures required fields are provided and valid.

•Returns appropriate error messages for invalid inputs.

3- Flexible Querying:

•Supports filtering musicians using FromQuery.

Endpoints
--------------
1- GET /api/Musicians

Retrieves the full list of musicians.

Response Example:
```json
[
  {
    "id": 1,
    "name": "Ahmet Çalgı",
    "profession": "Ünlü Çalgı Çalar",
    "funnyTrait": "Her zaman yanlış nota çalar, ama çok eğlenceli"
  },
  ...
]
```

2- GET /api/Musicians/search?name={name}

Searches for musicians by name.

Response Example:
```json
[
  {
    "id": 1,
    "name": "Ahmet Çalgı",
    "profession": "Ünlü Çalgı Çalar",
    "funnyTrait": "Her zaman yanlış nota çalar, ama çok eğlenceli"
  }
]
```

3- POST /api/Musicians

Creates a new musician.

Request Body:
```json
{
  "name": "New Musician",
  "profession": "Crazy Guitarist",
  "funnyTrait": "Makes unexpected guitar sounds"
}
```

Response Example:
```json
{
  "data": {
    "id": 11,
    "name": "New Musician",
    "profession": "Crazy Guitarist",
    "funnyTrait": "Makes unexpected guitar sounds"
  }
}
```

4- PUT /api/Musicians/{id}

Updates an existing musician.

Request Body:
```json
{
  "id": 3,
  "name": "Cemil Akor",
  "profession": "Çılgın Akorist",
  "funnyTrait": "Plays crazy chords with a surprising twist"
}
```

Response Example:
```json
{
  "data": {
    "id": 3,
    "name": "Cemil Akor",
    "profession": "Çılgın Akorist",
    "funnyTrait": "Plays crazy chords with a surprising twist"
  }
}
```

5- PATCH /api/Musicians/{id}

Updates only a musician's funny trait.

Request Body:
```json
{
  "funnyTrait": "Writes melodies with a unique twist"
}
```

Response Example:
```json
{
  "data": {
    "id": 2,
    "name": "Zeynep Melodi",
    "profession": "Popüler Melodi Yazarı",
    "funnyTrait": "Writes melodies with a unique twist"
  }
}
```

6- DELETE /api/Musicians/{id}

Deletes a musician by ID.

Response Example:
```json
{
  "message": "Musician deleted successfully"
}
```

How to Run
---------------
1- Clone the repository:

```csharp
git clone https://github.com/GizemG6/CrazyMusicians
cd CrazyMusicians
```

2- Restore dependencies:

```csharp
dotnet restore
```

3- Run the application:

```csharp
dotnet run
```

4- The API will be available at:

```csharp
https://localhost:7201/api/Musicians
```
