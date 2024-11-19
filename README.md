# Task

Create and implement a backend system that is called from the sample UI that we have provided for you in the index.html file. It must meet the following requirements:

- The user identifier specified in the input field must be passed to the backend
- The backend must return appropriate data to the client so that an image will be displayed
- These rules must be applied in the following order of precedence to determine which data to return to the client:
    - If the last character of the user identifier is [6, 7, 8, 9], retrieve the image URL from `https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{lastDigitOfUserIdentifier}` where `{lastDigitOfUserIdentifier}` is the last digit of the identifier
    - If the user last character of the user identifier is [1, 2, 3, 4, 5], retrieve the image URL from the `data.db` Sqlite database where the `images.id` value matches the last digit of the identifier
    - If the user identifier contains at least one vowel character (`aeiou`), display the image from `https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150`
    - If the user identifier contains a non-alphanumeric character, pick a random number between 1-5 and display the image with the appropriate seed (e.g. `https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150`)
    - If none of the above conditions are met, display the image from `https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150`

Once you are happy with your solution, please answer the following questions. There is no need for an essay - bullet pointing the key bits is completely fine!

1. How did you verify that everything works correctly?
2. How long did it take you to complete the task?
3. What else could be done to your solution to make it ready for production?
=============================================================================
## Design Pattern
- I've Used Design Patterns like Repository and Strategy in this project.
- Also I've defined a service to call external API
- Unit test is implemented.

###  Use a Local Server for the index.html
 http-server . -p 8080

## Response Question 1 :How did you verify that everything works correctly?
    
    1.1 To test the backend logic, including both the JSON file and database repository implementations, we can use xUnit along with Moq for mocking dependencies. 

    1.2 I've tested all cases manually by Postman and UI interface.

    1.3 I've tested all cases manually by  UI interface.

### Response Question 2. How long did it take you to complete the task?
  2. Three hours

### 3. What else could be done to your solution to make it ready for production?
3.1- Error Handling
    Introduce global error handling middleware (e.g., UseExceptionHandler) to catch unhandled exceptions and return appropriate error responses.
3.2-Monitoring and Alerts 
   Implement logging (using libraries like Serilog or NLog) for detailed request and error logging.
3.3- Security
    Add security layers for input validation to prevent SQL Injection and other attack vectors.
    Ensure that the API is protected by authentication/authorization (e.g., JWT tokens, OAuth) if required.
    Protect sensitive data (like database connection strings) using tools like Azure Key Vault 
3.4- Unit testing
  Add more unit tests
3.5 Scalability
    Ensure the database is optimized for production, such as creating indexes on frequently queried columns (e.g., id).
3.6- Code Review    
3.7- Documentation
    Create API documentation (e.g., using Swagger already is done for Dev).
    Provide clear comments and explanations for the code, especially for complex sections like the strategies.
3.8- CI/CD
    Set up a CI/CD pipeline (e.g., Azure DevOps, GitHub Actions) to
3.9- Caching
    Implement caching for image URLs to reduce the load on external services and databases for frequently requested identifiers.
    Consider using MemoryCache or a distributed cache like Redis to store results for a short duration (e.g., 5-10 minutes).

