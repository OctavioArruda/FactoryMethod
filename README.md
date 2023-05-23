# FactoryMethod

## How to run the application
- Build and run the application using visual studio 2022 or visual studio code with the properly C# .NET tools and CLI
- Build and run using DOCKER
    - `docker run -d -p 8080:80 factory-method-example`

## How to create the docker image
- `docker build -t factory-method-example .`

## Factory method design pattern applied to a dummy PaymentService
- The idea is to abstract the many payment services that may be required

### Concepts applied: 
- Clean architecture structure
- Factory method design pattern
- Docker
