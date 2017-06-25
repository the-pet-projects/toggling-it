[![CircleCI](https://circleci.com/gh/pedromsmoreira/feature-toggle-map/tree/master.svg?style=svg&circle-token=5dc31e02b7463a26dad858e031a207a2967d5983)](https://circleci.com/gh/pedromsmoreira/feature-toggle-map/tree/master)

# feature-toggle-map
Feature Toggle Map with Neo4j

## Overview

FTM is an application that let's you create toggles for your applications based on toggle-groups, tags and whatever you desire.
It also let's you check which applications are using a toggle and let's you analyze the impact when you turn a toggle on ot off.

## Getting Started

You need to setup the Neo4j Community Database and Kafka connections. This can be done on the appsettings.json file.
 - For the database edit the connection string. 

```
      "Neo4j": {
		"username": "user1",
		"password": "pass1",
		"boltEndpoint": "http://localhost:7476/"
	}
```

 - To configure the Kafka connection edit the following json object in appsettings:

```
  "Kafka": {
    "Endpoint": "http://localhost:9092" 
  } 
```

## Credits

Feature-Toggle-Map is built using the following projects:

- [ASP.NET Core](https://github.com/aspnet/Home)
- [Json.Net](http://james.newtonking.com/json)
- [neo4j Community](https://neo4j.com/)
- [Docker](https://www.docker.com/)
- [Apache Kafka](https://kafka.apache.org/)
- [Confluent Kafka](https://github.com/confluentinc/confluent-kafka-dotnet)
- [TopShelf](https://github.com/topshelf/topshelf)

##Development

Fork it
Create your feature branch: git checkout -b my-new-feature
Commit your changes: git commit -am 'Add some feature'
Push to the branch: git push origin my-new-feature
Submit a pull request!