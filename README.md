# InterviewDemo_MCG

## Technologies
The demo is writen as ASP.Net Core 2.1 app and utilises Angular 6 as the front end framework

## Prerequisites
* Download and install .NET Core 2.1 SDK from https://www.microsoft.com/net/download/dotnet-core/2.1
* Download Node.Js from the official site: https://nodejs.org/en/ direct download link: https://nodejs.org/dist/v8.11.3/node-v8.11.3-x64.msi

## Building the demo app
* Open command line, navigate to "Microgen\Sites\Microgen.Sites.Interview\ClientApp" folder and run "npm install" command
* Open the Microgen.sln in Visual Studio IDE (First time the solution isopened Visual Studio will restore nuget packages, this will take while)
* Once nugets are restored select the "Microgen.Sites.Interview" as start up project and click run.

## Code quality
There mstest is used to test important business logic

## Site mapp
Root home page:
http://localhost:5000/

### Api end point:
Method: Post

Headers: Content-Type - application/json

Url: http://localhost:5000/api/transactions?sortby=value  

Body: 
```json
	[
	 {  
	    "value": 123.56,
	    "currency": "gbp",
	    "date": "2012-04-23T18:25:43.511Z",
            "sourceAccNo": "123456789",
            "destinationAccNo": "987654321"
	 },
	 {  
	    "value": 123.56,
	    "currency": "usd",
	    "date": "2012-04-23T18:25:43.511Z",
	    "sourceAccNo": "123456789",
            "destinationAccNo": "987654321"
	 },
	 {  
	    "value": 321.56,
	    "currency": "usd",
	    "date": "2012-04-23T18:25:43.511Z",
	    "sourceAccNo": "123456789",
            "destinationAccNo": "987654321"
	 }
	]
  ```
## Running the application 
* Extract the zip file - demo_app.zip
* navigate to ./win-x86 and start Microgen.Sites.Interview.exe
* open postman or other rest clients and use the example header and body as per above

Url example: http://localhost:5000/api/transactions?sortby=value  - sort transactions by value

Url example: http://localhost:5000/api/transactions?sortby=date  - sort transactions by date
