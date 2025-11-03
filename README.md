## Project Overview

This project wraps calls to the Bureau of Labor Statistics public API using a supplied "seriesId", "month" and "year".

 - **seriesId** - ID of the data collection in BLS that we are working with
   (eg. LAUCN040010000000005, CUUR0000SA0) 
 - **month** - Month of the year that we are interested in spelled out fully
   (eg. January, March, December) 
   
   
 - **year** - Year we are interested in using 4 digits (eg. 2023,    2024)

## Requirements

**Task:** 

Build a scalable, C#, ASP.NET Core Restful API service that will call the public version of the CPI service of Bureau of Labor Statistics and provides the CPI value (as integer)  and notes (text) for a given month and year. 
Your service will call the CPI service to get the real data, and caches the data for any additional calls so our application doesn’t call the real service more than their allowable limit.

Here is the public version of the site: https://www.bls.gov/developers/api_signature.htm . 

Use the V1 version of the CPI service. For example:  https://api.bls.gov/publicAPI/v1/timeseries/data/LAUCN040010000000005

The CPI website is a public web service that has a limit on the number of times any given IP range can call it. (The current limit seems to be 25). For instance, if I call the web service by providing “May 2020” as the input, it will return an int with the CPI along with any notes. For that reason, your Web service will call the real CPI web service and cache the results for 1 day.  You can imagine a service like this allowing our application to get CPI information as needed, without exceeding the 25-call limit imposed by the real service.

**Bonus:**
- Add JWT-based authentication and authorization
- Containerize the service via Docker
- Deploy the service to AWS cloud and if deploying is not possible, providing code to deploy the service to AWS cloud platform is good or provide the details of the services you’ll deploy the code components to
- Include time complexity and space complexity for the API as comments in the code

## Assumptions

This API will assume the user is to provide the following 3 inputs:
- SeriesID - a multi-digit, alpha numeric code to the series data on the BLS website (eg. LAUCN040010000000005, CUUR0000SA0)
- Year - a four digit year (eg. 2023, 2024 or 2025)
- Month - a string value representing the full month name
 (eg. January, March, October, December)

 The output will be a single record containing the CLI value for the given month and year as an integer with any notes (footnotes) found in thed data.

 `{
    ValueAsInt,
    Notes
 }`

 Eg. `{
    321, "Code: P, Text: Preliminary"
 }`

## Design Considerations

We are caching each call for the specified seriesID for 24 hours using ASP.NET's built-in InMemoryCache which operates as a Singleton.

We developed two end-points that effectively execute the same code. One end-point requires the Request to have a JWT token added to the Request header "/api/blsauth/{seriesId}/{year}/{month}" and the other doesn't "/api/bls/{seriesId}/{year}/{month}".

Simple validation is done on the input such as ensuring the seriesId is not an empty string, year is a 4 digit year and month is the fully spelled out month. Not all of the data at BLS uses the fully spelled out month so this validation would need to change should other seriesID's wish to be queried for. For example, sometimes the periodName field (which contains the fully name of the month) will say things like "1st Quarter" or "Annual". However, based on the requirements specified in the Task description, we are assuming a full month name so our validation reflects that (as well as the unit tests).

## Installation and Execution

 - Download all of the code from GitHub
 - Open CPIService.sln in Visual Studio. 
 - Run the web application using Visual Studio and IIS Express (eg. F5).
 - The Swagger page will load.
 - Use the POST Login to generate a JWT token that you can copy and paste into the CPIService.http file for testing the rest of the API's.
 - Example http requests shown below
 

`GET https://localhost:44371/api/bls/LAUCN040010000000005/2025/February`

// example showing validation with bad year and month

`GET https://localhost:44371/api/bls/LAUCN040010000000005/24/M01`


// Authorization / Authentication via JWT

`GET https://localhost:44371/api/blsauth/LAUCN040010000000005/2025/August
Authorization: Bearer {token_value}`

// example showing validation with authentication (bad year and month)

`GET https://localhost:44371/api/blsauth/LAUCN040010000000005/24/M01
Authorization: Bearer {token_value}`


## Unit Tests

Run the Unit Tests located inside the test project **BlsApi.Tests**