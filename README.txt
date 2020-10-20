There are some tips about the use of the Sorting Algorithm App:

-Make sure you have the runtime of .NET Core installed on your PC at least in the version 3.1;
	Link for download: https://dotnet.microsoft.com/download/dotnet-core/3.1

-Just use json files (could be a .txt file too but in a struct of json);
	-Follow the model from the class Image.cs, but basically can be:
[
	{
		"ScaneId":"29489674-438c-4b3e-8f12-307d7b9707de",
		"PassingDate": "2015-08-17T18:24:00-03:00",
		"Latitude":120,
		"Longitude":40		
	},
	{
		...
	}
]

It's an array of Image, the only properties that will imapct in the sort algorithm are the latitude and the longitude, the ScaneId is just to identify each image as unique, and the PassingDate is just a show off, to represent an satellite image.
