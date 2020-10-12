# KneatSoftware.StarWarsCalculator

## Overview
> StarWars Calculator is an application that calculates the number of stops for each Starship by given a distance in Mega Lights.

## How to run the project
1. Install .Net core 3.1
2. Clone this repository in your machine
3. Go to the folder `*\KneatSoftware\Source\Run\KneatSoftware` in the project
4. Run the command `dotnet run`
5. Provide the distance in Mega Lights

## How to run the unit testing
1. Go to the folder `*\KneatSoftware\Tests\UnitTests` in the project
2. Run the command `dotnet test`

## How to run the integration test
1. Go to the folder `*\KneatSoftware\Tests\IntegrationTests` in the project
2. Run the command `dotnet test`

## Explanation of the calculation of stops for starship
* Using the formula `stop = hours / consumable Hours` to calculate the stops from the distance in Megalights, time consumable and the velocity in megaligth of the starship.

* Hours is (distance / velocity in megalights) and consumable Hours is the hours calculated by the consumable of the starship.

Formula:
`stops = (( Distance / Megalights) / Consumables )`

Example:
`stops = ((Distance = 1000000 / megalights = 75) / (consumable = "2 months") = 1460 )`

The StarshipService will get the starships from the API and for each starship will add the stops calling the MegaLightsCalculatorService. For the consumable calculation there is a interface `IHoursCalculator` that implements the proper type via Factory to the concrete class.

For example: Starship: Millennium Falcon has consumables equals "2 months", that means it will call the concrete class that returns number of hours by Month. This formula applies the number of days considering an average in relation of 365 days.

## Project layers

### Contract Layer
This Layer constains the domain classes.

### Core Layer
This Layer constains the declaration of the configurations.

### Application Layer
This Layer constains the abstract class or interfaces that implements the concrete class from Infrastructure layer.

### Infrastructure Layer
This Layer implements the business roles and it is resposible to calculate the Mega Lights and add the result for each starship.

### StarWarsCalculator Console Application
Entry project that will receive the distance in Mega Lights and will call the service to get all the Starships and then displays.