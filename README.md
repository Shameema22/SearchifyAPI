# SearchifyAPI

The backend API for Searchify is built using ASP.NET Core and provides endpoints for managing search functionality and serving search results. This API will handle search queries ,retrieve relevant data, and respond with the results in a format that the front end can consume.

## Overview 

### Base URL 

Development: http://localhost:56423 

## Endpoints 

### 1. Get Search Results 

Endpoint: /GetSearchResults 

Method: POST 

Description: Fetches search results based on the search query. 


#### Request 

Headers: 

Content-Type: application/json 

Body (JSON): 

    { 
      "query": "your search term" 
    }  

    

#### Response 

Status Code: 200 OK 

Body: 

    { 
      "results": [ 
        { 
          "id": 1, 
          "title": "Eat. Stay. Love.", 
          "description": "An all-in-one experience at Fratelli Vineyards.", 
          "imageUrl": "http://localhost:56423/Images/vineyard.jpg" 
        }, 
        { 
          "id": 2, 
          "title": "Sunset Savour", 
          "description": "Enjoy exclusive experiences at Sula Vineyards.", 
          "imageUrl": "http://localhost:56423/Images/sunset.jpg" 
        } 
      ], 
      "totalRecords": 2 
    } 
     



#### Error Response: 

    { 
      "error": "Invalid search query" 
    } 



     

### 2. Get Search Suggestions 

Endpoint: /GetSearchSuggestions 

Method: GET 

Description: Fetches search suggestions based on the search query entered by the user. 

####Request 

Query Parameters: 

query: The search term for which suggestions are to be fetched. 

Headers: 

Content-Type: application/json (optional if it's a simple GET request without a body) 



####Response 

Status Code: 200 OK 

    Body (JSON): 
    
    { 
      "suggestions": [ 
        "Sula Vineyard", 
        "Fratelli Vineyards", 
        "Sunset Savour", 
        "Eat Stay Love" 
      ] 
    } 
     

Explanation: 

The suggestions array will contain a list of suggested search terms based on the input query. 

#### Error Response 

Status Code: 400 Bad Request 

    Body (JSON): 
    
    { 
      "error": "Invalid search query" 
    } 
 

Explanation: 

This error occurs if the search query is invalid (e.g., if the query is empty or malformed). 




 

### Response Codes 

#### Status Code                                 ### Meaning 

200 OK                                         The request was successful. 

400 Bad Request                                The request was invalid. 

404 Not Found                                  The requested resource was not found. 

500 Internal Server Error                      A server-side error occurred. 




 

### Setup 

Prerequisites 

ASP.NET Core SDK: Download the latest version from Microsoft. 

Database: SSMS  

Database Schema 

The API retrieves search results from the database. Below is the schema for the primary SearchResults table: 




 

### SearchResults Table 

#### Column    ---               #### Type         ---        #### Description 

Id                                 int                   Unique identifier for the result. 

Title                              string                The title of the search result. 

Description                        string                Description of the search result. 

SearchKeys                         string                Keywords associated with the result. 

ImagePath                          string                Path to the image file. 




 

## Project Structure 

SearchifyAPI/ 
├── Controllers/ 

│   └── SearchController.cs    # Handles search-related endpoints 

├── Models/ 

│   └── SearchResult.cs        # Defines the SearchResult model 

├── Services/ 

│   └── SearchService.cs       # Business logic for handling search functionality 

├── Data/ 

│   └── AppDbContext.cs        # Database context 

├── Images/                    # Static images directory 

├── appsettings.json           # Application configuration 

└── Program.cs                 # Entry point of the application  

 




### Search Controller 

The SearchController handles the /GetSearchResults endpoint. 

### Search Service 

The SearchService contains business logic for retrieving search results. 

 




## Testing the API 

Swagger: Add Swagger for API documentation and testing  


Example Swagger Configuration:  

builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddSwaggerGen(); 
 
app.UseSwagger(); 

app.UseSwaggerUI();  

    Access Swagger at http://localhost:56423/swagger. 



 

## CORS Configuration 

CORS (Cross-Origin Resource Sharing) allows your frontend (e.g., http://localhost:3000 for React) to communicate with the backend API. 

Setup CORS in ASP.NET Core 

Modify Program.cs: Add the following configuration to enable CORS: 

 
// Add CORS policy 

    builder.Services.AddCors(options => 
    { 
        options.AddPolicy("AllowFrontendApp", policy => 
        { 
            policy.WithOrigins("http://localhost:3000")  
    
                  .AllowAnyMethod() 
                  .AllowAnyHeader(); 
        }); 
    }); 
 
 
// Use the CORS policy 

    app.UseCors("AllowFrontendApp"); 




 

## Future Enhancements 

Search Filters: Add filtering options like category, date range, etc. 

Pagination: Implement paginated results for large datasets. 

Authorization: Secure endpoints with authentication (e.g., JWT). 

Caching: Use Redis or in-memory caching for frequent queries. 

 

 
