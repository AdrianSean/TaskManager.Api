Contains the service's REST resource types (or models).
We seperate these into their own class library just to make unit testing a little easier.
But remember that the client/caller never gets this DLL, because resource type definitions are not shared with REST service clients.