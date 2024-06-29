# Football API --

Football API is CRUD API on temporary data source of football teams.  
ITeamDataSource is contract which anyone can implement and get data from actual source

## Prerequisite

VSCode >= 1.41.1 or Visual Studio 2019.            
Dot-net core >=3.0.0   
.Net Test Explorer for VS Code 0.7.1  
NugetPackageManager for VSCode 1.1.6

## Run API, Unit Test and Integration Test

For VSCode    
1. Restore the Nuget Packages using Nuget Package manager(Popup comes in bottom of VS Code when you open folder and ask for restore).    
2. Go to Debug button and Click on > button with combobox containing .Net Core launch (Web).  
3. It would open explorer and will hit http://localhost:3000 and now try to GET /teams and you will get list of teams.
4. For Running Unit Test and integration Test, Go to Test Explorer of VS Code and run the test shown in test explorer window.

For Visual Studio
1. Open .sln file in Visual Studio
2. Build the solution. After building solution, all Nuget Packages would be restored.
3. Click IIS Express Button next to > button in the top and Chrome will be opened with url https://localhost:44364/teams and you will get the array of teams.
4. For Running Unit and Integration Test, Right the project and Click on Debug/ Run Test.

## Usage

GET /teams  
It will retrieve the list of teams
Success Response: 200OK

```
GET http://localhost:3000/teams  
Set Content-Type as application/json in Header  

Response 200 OK:  
[
    {
        "name": "Arsenal",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/632.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Bournemouth",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/631.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Brighton & Hove Albion",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/2465.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Burnley",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/650.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Cardiff City",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5542.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Chelsea",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/635.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Crystal Palace",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/637.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Everton",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/639.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Fulham",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5770.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Huddersfield Town",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/2464.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Manchester United",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/645.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Liverpool",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/646.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Leicester City",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/633.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Manchester City",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/642.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Newcastle United",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/2463.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Wolverhampton",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/5543.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Tottenham Hotspur",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/648.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Southampton",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/647.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "West Ham United",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/640.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    },
    {
        "name": "Watford",
        "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/638.jpg",
        "createdBy": "Gheri.Rupchandani@gmail.com",
        "createdAt": "2020-01-30T20:19:34Z",
        "modifiedBy": null,
        "modifiedAt": null
    }
]
```

GET /teams/{team_name}  
It will retrieve the team record  
Success Response: 200OK  
Error Response: NOT FOUND

```
GET http://localhost:3000/teams/Arsenal  
Set Content-Type as application/json in Header  
Response  200 OK
{
    "name": "Arsenal",
    "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/632.jpg",
    "createdBy": "Gheri.Rupchandani@gmail.com",
    "createdAt": "2020-01-30T20:19:34Z",
    "modifiedBy": null,
    "modifiedAt": null
}
```

POST /teams  
It creates the team record  
Success Response: 200OK  
Error Response: 201Created, 00BadRequest, 422UnprocessableEntity

```
POST http://localhost:3000/teams  
Set Content-Type as application/json in Header  
Request body  
{
    "name": "Ars",
    "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/6321.jpg"
}

Response  201 Created
{
    "name": "Ars",
    "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/6321.jpg",
    "createdBy": "Gheri.Rupchandani@gmail.com",
    "createdAt": "2020-01-30T20:23:17Z",
    "modifiedBy": null,
    "modifiedAt": null
}
```

PUT /teams/{team_name}  
It sets the whole team record with new one.  
Success Response: 200OK  
Error Response: 404NotFound, 400BadRequest  

```
PUT http://localhost:3000/teams/Ars
Set Content-Type as application/json in Header  
Request body  
{
    "name": "Ars",
    "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/6321.jpg"
}

Response  200OK
{
    "name": "Ars",
    "img": "https://s3-eu-west-1.amazonaws.com/inconbucket/images/entities/original/6321.jpg",
    "createdBy": "Gheri.Rupchandani@gmail.com",
    "createdAt": "2020-01-30T20:23:17Z",
    "modifiedBy": "Gheri.Rupchandani@gmail.com",
    "modifiedAt": "2020-01-30T20:25:23Z"
}
```

Note: 
1. API End Points are not secure. One must implement Jwt Token or any other authentication/ authorization method
2. If Real Data Source is being in place of dummy data source, One must follow async await for IO calls.

Author = "gheri.rupchandani@gmail.com"
userName= "G"