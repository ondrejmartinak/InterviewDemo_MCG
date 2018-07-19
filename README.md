# InterviewDemo_MCG

## Technologies
The demo is writen as ASP.Net Core 2.1 app and utilises Angular 6 as the front end framework

## Prerequisites
* Download and install .NET Core 2.1 SDK from https://www.microsoft.com/net/download/dotnet-core/2.1
* Download Node.Js from the official site: https://nodejs.org/en/ direct download link: https://nodejs.org/dist/v8.11.3/node-v8.11.3-x64.msi

## Building and running the demo app
* Open command line, navigate to "Microgen\Sites\Microgen.Sites.Interview\ClientApp" folder and run "npm install" command
* Open the Microgen.sln in Visual Studio IDE (First time the solution isopened Visual Studio will restore nuget packages, this will take while)
* Once nugets are restored select the "Microgen.Sites.Interview" as start up project and click run.


## Site mapp
Root home page:
https://localhost:44315/

### Api end point:
Method: Post

Headers: Content-Type - application/json

Url: https://localhost:44315/api/transactions?sortby=value

Body: 
```json
	[
		 {  
		 	"value": 123.56,
			"currency": "usd",
			"date": "2012-04-23T18:25:43.511Z",
			"sourceAccNo": "123456789",
            "destinationAccNo": "987654321"
		 },
		 {  
		 	"value": 321.56,
			"currency": "eur",
			"date": "2012-04-23T18:25:43.511Z",
			"sourceAccNo": "123456789",
            "destinationAccNo": "987654321"
		 }
	]
  ```
