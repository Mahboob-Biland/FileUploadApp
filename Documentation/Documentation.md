# File Upload App

This is a simple demo app for uploading text file and finding any banned word used in that file.

# Features / Implementations

## Database

Please run python script 'create_db.py' in directory 'FileUploadApp\Database' which will create a sqlite database named 'files_db.sqlite' in same folder, application will use this database.

## Bankend

Backend is class libraries, the concept is in class library each class should server one purpose, methods should not be more than 30 lines of code, if exceeds create new methods, method should also serve one purpose.
 We have store class library which is responsible all database operations, and file library which manages files and banned words and act as link between api and store.
classes from store are injected into files class library. 
Please note application will create a folder 'Resources' for saving all uploaded files, application should have access right to do so.

## Web API

We have a web api in the project which provide routes for all functionality we have for files and banned words.
OpenAPI support is added to api and can be access through http://localhost:8081/swagger/ . Although it need a bit more work to make it more explanatory specially for add/update operations.

## Frontend Angular

I am a learner of Angular currently and created a basic app to consume api, its currently doing all operations for api, a bit more validation and UI work is needed.
I have used i have used following versions
Node: 14.15.4 
Angular: 11.2.14

Angular application can be run by simply going into FileUploadApp\FileUpload-Web directory and run command "ng serve --open" using cmd or PowerShell.

## Unit Tests

I Wrote tests for one class banned words, similarly we can add tests for file class, we can add tests for API as well, also we can add integration tests.

## TODO

- Write all tests, code should be as covered as possible.
- Currently implemented very simple implementation for search banned word in file, if files are huge and we have lots of banned words may be better to implement Elastic search.
- Improve front end application.
- Add more comments to code.
- implement health and performance metrics to monitor the service.
