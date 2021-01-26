<p align="center">
    <img src="https://naval.cat/dyn_static/kaeri_logo.svg" width="300">
  </a>
</p>

# Kaeri Endpoint

## What's Kaeri?

Kaeri is an open source public API for testing and development purposes that holds the data in memory and deletes it periodically. Nothing is saved on the server.

The project is for everyone that needs to check REST API Rest iterations in their projects, use this endpoint to develop and test you applications through
a functional and complete REST service.

## Continuous delivery

For provide an available and auditable service, in each commit of this repository a Docker container 
will be build to be published in the free PaaS provider Heroku that hosts this project. See [Actions](https://github.com/aeri/Kaeri/actions) of this project for build details.


## Getting Started

The API uses an ```KaeriObject```, a very simple schema to making simple tests with only key-value pair. A key represented as a STRING, which is a constant that defines the data set (e.g., gender, color, price), and a value represented as a STRING, which is a variable that belongs to the set (e.g., male/female, green, 100).


```json
{
	"key": "season",
	"value": "april"
}
```
The API endpoint entry is at [```https://kaeri.herokuapp.com```](https://kaeri.herokuapp.com)

These are available the following REST operations:

* **`POST`** Create a KaeriObject
* **`PUT`** Update a KaeriObject
* **`GET`** Get a resource or list of KaeriObject
* **`DELETE`** Delete a KaeriObject

The full documentation of this endpoint is automatically generated and available in:

[![View in Swagger](http://jessemillar.github.io/view-in-swagger-button/button.svg)](https://kaeri.herokuapp.com/swagger/index.html)

## Contributing

I love that you contribute to Kaeri suggesting new functionalities, reporting bugs or generating new pull requests :)
