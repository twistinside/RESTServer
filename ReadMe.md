### Directions:
Use any resources on the internet to help you complete the challenge.

### Instructions:
Implement a service in a framework of your choice (preferred: C# ASP.NET, Golang, Python).  If you choose an exotic framework, please be prepared to explain why you chose it. 
The service must accept a JSON POST to /events path with the payload as shown below. The endpoint should return a 200 OK upon a successful request.

```
{
  "user_events": [
    {
      "app": "MyApp",
      "user_id": "UserID1",
      "session_id": "f7b4cfbcea3a4a189b3d021153ca1a19",
      "local_time": "2021-07-25T15:45:25.8032356-07:00",
      "action": "Action1",
      "context": "Context1",
      "value": "bacon ipsum"
    },
    {
      "app": "MyApp",
      "user_id": "UserID1",
      "session_id": "f7b4cfbcea3a4a189b3d021153ca1a19",
      "local_time": "2021-07-25T15:45:25.8032356-07:00",
      "action": "Action2",
      "context": "Context2",
      "value": "pork belly tri-tip frankfurter"
    },
    {
      "app": "MyApp",
      "user_id": "UserID1",
      "session_id": "f7b4cfbcea3a4a189b3d021153ca1a19",
      "local_time": "2021-07-25T15:45:25.8032356-07:00",
      "action": "Action3",
      "context": "Context3",
      "value": "jerky bacon pork chop shoulder"
    },
    {
      "app": "MyApp",
      "user_id": "UserID1",
      "session_id": "f7b4cfbcea3a4a189b3d021153ca1a19",
      "local_time": "2021-07-25T15:45:25.8032356-07:00",
      "action": "Action1",
      "context": "Context1",
      "value": "Capicola t-bone ham hock kevin chislic"
    }
  ]
}
```

When the payload(s) are received by the service, sum the number of times each action is present in the payload and save the summed value to Redis (or another key/value store).  It should accumulate the total number of times an action has been posted and persist it outside of the process.
Create an endpoint that queries the service for a given action.  The endpoint should return a 200 OK status along with the summed number of times action has been posted.  This endpoint should accept query parameters and return JSON like below:

```
{
  "action": "Action1",
  "count": 2
}
```

Stretch Goals:
Save the events to a Postgres database and create a separate endpoint to query the database directly for the count of events.
Allow specifying the Accept header to return the data in a different format. (XML, text, etc.)
Allow querying for all fields in the payload and return a count matching the query parameter.

Examples Request/Reply:
GET total number of events collected where action = Action1

`curl -X GET -H “Accept: application/json” http://localhost/events/?action=Action1`

```
Reply (200 OK)
{
“action”: “Action1”,
“count”: 4123
}
```


Sample POST

`curl -X POST -H “Content-Type: application/json” -d @events.json http://localhost/events/`

```
Reply (200 OK)
{
“count”: 2
}
```