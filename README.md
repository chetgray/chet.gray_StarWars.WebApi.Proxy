StarWars.WebApi.Proxy
=====================

User Story #211926: API Proxies: Create and use API Proxy for Star Wars
API
------------------------------------------------------------------------

> Create an API Proxy for your Star Wars API (US #211916, #211918,
> #211920).
>
> - [x] The API Proxy should be in .Net Standard 2.0.
> - [x] Be sure to add at least one Unit Test to the API Proxy.
> - [x] You should create a Nuget Package from the Proxy and publish it
>   to Local Nuget.
> - Create a simple console app that pulls in the Nuget package and uses
>   the Proxy methods to:
>   - Get a list of all the character information
>   - Get a character's information by their name
>   - Get a list of character information by allegiance
>   - Get a list of character information by trilogy
> - The console app should have a main menu where you can choose which
>   of the above you want to do.
> - Once done, it should ask if you want to do it again. If so,
>   represent the main menu.
> - Do NOT call the API directly - use the proxy methods from the Nuget
>   package!
