<<<<<<< HEAD
[![CircleCI](https://circleci.com/gh/pedromsmoreira/feature-toggle-map/tree/master.svg?style=svg&circle-token=5dc31e02b7463a26dad858e031a207a2967d5983)](https://circleci.com/gh/pedromsmoreira/feature-toggle-map/tree/master)
=======
## # Build [![Build Status](http://dev01-petproject.westeurope.cloudapp.azure.com:8080/buildStatus/icon?job=TogglingItAPI-Stage1-Build&style=plastic)](http://dev01-petproject.westeurope.cloudapp.azure.com:8080/view/Toggling-It/view/Toggling-It%20API%20Pipeline/job/TogglingItAPI-Stage1-Build/) # Unit Tests [![Build Status](http://dev01-petproject.westeurope.cloudapp.azure.com:8080/buildStatus/icon?job=TogglingItAPI-Stage1-UnitTests&style=plastic)](http://dev01-petproject.westeurope.cloudapp.azure.com:8080/view/Toggling-It/view/Toggling-It%20API%20Pipeline/job/TogglingItAPI-Stage1-UnitTests/) # Integration Tests [![Build Status](http://dev01-petproject.westeurope.cloudapp.azure.com:8080/buildStatus/icon?job=TogglingItAPI-Stage2-IntegrationTests&style=plastic&label=healthinesses)](http://dev01-petproject.westeurope.cloudapp.azure.com:8080/view/Toggling-It/view/Toggling-It%20API%20Pipeline/job/TogglingItAPI-Stage2-IntegrationTests/)

>>>>>>> 694324a... added CD pipeline scripts and docker compose files

# feature-toggle-map
Feature Toggle Map with Neo4j

## Overview

FTM is an application that let's you create toggles for your applications based on toggle-groups, tags and whatever you desire.
It also let's you check which applications are using a toggle and let's you analyze the impact when you turn a toggle on ot off.

## Graph Schema

![Schema](https://github.com/the-pet-projects/toggling-it/blob/master/docs/img/GraphSchema.JPG)

## Graph Initial Design

![Graph](https://github.com/the-pet-projects/toggling-it/blob/master/docs/img/InitialGraph.JPG)


## Getting Started

You need to setup the Neo4j Community Database and Kafka connections. This can be done on the appsettings.json file.
 - For the database edit the connection string. 

 - To configure the Kafka connection edit the following json object in appsettings
 
```
	
	{
	  "Logging": {
		"IncludeScopes": false,
		"LogLevel": {
		  "Default": "Warning"
		}
	  },
	  "Neo4j": {
		"username": "user1",
		"password": "pass1",
		"boltEndpoint": "http://localhost:7476/"
	  },
	  "Kafka": {
		"Endpoint": "http://localhost:9092"
	  } 
	}

```


## Credits

Toggling-It is built using the following projects:

- [ASP.NET Core](https://github.com/aspnet/Home)
- [Json.Net](http://james.newtonking.com/json)
- [neo4j Community](https://neo4j.com/)
- [Docker](https://www.docker.com/)
- [Apache Kafka](https://kafka.apache.org/)
- [Confluent Kafka](https://github.com/confluentinc/confluent-kafka-dotnet)
- [TopShelf](https://github.com/topshelf/topshelf)

## Development

Fork it
- Create your feature branch: git checkout -b my-new-feature
- Commit your changes: git commit -am 'Add some feature'
- Push to the branch: git push origin my-new-feature
- Submit a pull request!
