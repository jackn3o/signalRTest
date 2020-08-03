# Code Challenge - Golden Bridge Drive (SG)

Code Challenge for Developer position @ Golden Bridge Drive (SG)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

You need to have those cli command ready, you can skipped if already installed
else please download from the provided link 

(dotnet) .NETCore SDK : https://dotnet.microsoft.com/download
(npm) Node.js: https://nodejs.org/en/
(git) git cli: https://git-scm.com/downloads


### Installing

1. Clone current repo to your local, open CMD and run below script to clone

```
git clone https://github.com/jackn3o/signalRTest.git {optional: preferred repo name}
```

2. Once complete, cd to repo directory

```
cd signalRTest 
```
(or your optional name)

3. Restore dependencies

```
dotnet restore
```

3. Execute the web api and client app with below cmd

```
dotnet run
```

wait until above cmd execute completely and you will saw message like Microsoft.Hosting.Lifttime...


## Testing

1. Open 2 Tab/Window of browser
2. Open the url that print at cmd, default url will be 

```
http://localhost:5000 or https://localhost:5001
```

3. A mockup login screen will appear (but not a working login page,just ui)
4. 1 tab/window of browser click admin to access Admin Dashboard,
the other 1 click user to access eCommerce shopping list

5. admin tab try to create some product by CREATE button
6. user tab will refresh real time if any product published, price or qty change


## What i use

1. Backend: .NETCore + SignalR
2. Frontend: Angular 8 + Angular Material UI Framework + SignalR
3. DB: Sqlite


