
# Powerplant Dispatch API

This project is a .NET 6 Web API that calculates the optimal power output for a set of power plants based on given fuel prices, load requirements, and power plant characteristics. The API uses MediatR for handling business logic and AutoMapper for object mapping.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
  - [Running the Application with Docker](#running-the-application-with-docker)
  - [Running Tests with Postman](#running-tests-with-postman)
- [API Endpoints](#api-endpoints)
  - [Calculate Production Plan](#calculate-production-plan)
- [Technologies Used](#technologies-used)


## Features

- Calculates the optimal power output for each power plant.
- Considers fuel costs, plant efficiency, and other factors.
- Supports multiple types of power plants, including gas-fired, turbojets, and wind turbines.
- Simple API with endpoints for calculation and retrieval of production plans.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Optional, if using a database)
- [Docker](https://www.docker.com/products/docker-desktop) (if running the application in a container)

### Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/PowerplantDispatch.git
   cd PowerplantDispatch
   ```

2. **Open the Solution**

   Open the solution file `PowerplantDispatch.sln` in Visual Studio 2022.

3. **Restore Dependencies**

   Visual Studio will automatically restore the necessary NuGet packages when you open the solution. If it doesn't, run:

   ```bash
   dotnet restore
   ```

### Running the Application

#### Option 1: Run Normally

1. **Build the Project**

   In Visual Studio, build the solution using the Build menu or by pressing `Ctrl+Shift+B`.

2. **Run the Application**

   You can run the application using Visual Studio by pressing `F5` or by running:

   ```bash
   dotnet run --project PowerplantDispatch.API
   ```

3. **Access the API**

   The API will be available at `https://localhost:5001` or `http://localhost:5000`.

#### Option 2: Run the Application with Docker

If you prefer to run the application in a Docker container, follow these steps:

1. **Build the Docker Image**

   In the root directory of the project, where your `Dockerfile` is located, run the following command:

   ```bash
   docker build -t powerplant-dispatch-api .
   ```

   This command builds a Docker image named `powerplant-dispatch-api` based on your `Dockerfile`.

2. **Run the Docker Container**

   After the image is built, you can run it using:

   ```bash
   docker run -d -p 5000:80 -p 5001:443 --name powerplant-dispatch-container powerplant-dispatch-api
   ```

   - `-d`: Runs the container in detached mode.
   - `-p 5000:80`: Maps port 5000 on your local machine to port 80 in the container (for HTTP).
   - `-p 5001:443`: Maps port 5001 on your local machine to port 443 in the container (for HTTPS).
   - `--name powerplant-dispatch-container`: Names the running container `powerplant-dispatch-container`.

3. **Access the API**

   The API will be available at `https://localhost:5001` or `http://localhost:5000`, just as if you were running it locally.

4. **Stop and Remove the Docker Container**

   To stop the running container:

   ```bash
   docker stop powerplant-dispatch-container
   ```

   To remove the container:

   ```bash
   docker rm powerplant-dispatch-container
   ```

### Running Tests with Postman

1. **Open Postman**

   Download and install [Postman](https://www.postman.com/downloads/) if you haven't already.

2. **Import Collection**

   Create a new collection in Postman or use the provided API endpoints directly.

3. **Test Endpoints**

   - **Calculate Production Plan:**

     - **Method:** `POST`
     - **URL:** `https://localhost:{portNumber}/api/ProductionPlan/calculate`
     - **Body:** Raw JSON (example below)

     ```json
     {
       "load": 480,
       "fuels": {
         "gas(euro/MWh)": 13.4,
         "kerosine(euro/MWh)": 50.8,
         "co2(euro/ton)": 20,
         "wind(%)": 0
       },
       "powerplants": [
         {
           "name": "gasfiredbig1",
           "type": "gasfired",
           "efficiency": 0.53,
           "pmin": 100,
           "pmax": 460
         },
         {
           "name": "gasfiredbig2",
           "type": "gasfired",
           "efficiency": 0.53,
           "pmin": 100,
           "pmax": 460
         },
         {
           "name": "gasfiredsomewhatsmaller",
           "type": "gasfired",
           "efficiency": 0.37,
           "pmin": 40,
           "pmax": 210
         },
         {
           "name": "tj1",
           "type": "turbojet",
           "efficiency": 0.3,
           "pmin": 0,
           "pmax": 16
         },
         {
           "name": "windpark1",
           "type": "windturbine",
           "efficiency": 1,
           "pmin": 0,
           "pmax": 150
         },
         {
           "name": "windpark2",
           "type": "windturbine",
           "efficiency": 1,
           "pmin": 0,
           "pmax": 36
         }
       ]
     }
     ```


## API Endpoints

### Calculate Production Plan

- **POST** `/api/ProductionPlan/calculate`
- **Description:** Calculates the optimal power output for each power plant based on the input data.
- **Request Body:** `ProductionPlanDto` JSON
- **Response:** List of `PowerOutputDto` JSON


## Technologies Used

- **.NET 6**
- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **MediatR**
- **AutoMapper**
- **FluentValidation**
- **Docker** for containerization


## Contributing

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
