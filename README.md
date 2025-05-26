# workshop identity-server en RBAC

Welkom bij de workshop! In deze workshop gaan we ervoor zorgen dat identity server werkt zodat we succesvol in kunnen loggen en de juiste rol aan de gebruiker kunnen koppelen. Vervolgens moeten we ervoor zorgen dat gebruikers geen informatie te zien krijgen dat ze niet mogen zien, namelijk door middel van Role Based Access Control. Een leerling mag bijvoorbeeld geen gevoelige informatie over andere leerlingen of toetsen inzien. 

Als je er niet uitkomt, kijk in de public folder in de front-end voor de werkende implementatie.

## Voorbereiding
Begin met het clonen van de repository:
https://github.com/SLBrusse/workshop-identity-server.git

Installeer benodigde packages:
```bash
npm install
 ```

## Stap 1
- Open postman. Start een `POST` request naar `https://{plaats hier jouw localhost adres}/connect/token`. Open het `body` tabje, klik op `x-www-form-urlencoded` en voeg dit toe:

| Key           | Value          |
|:--------------|:---------------|
| client_id     | workshop-client  |
| client_secret | secret         |
| grant_type    | password       |
| username      | alice          |
| password      | ditiseenveiligwachtwoord       |

- Klik dan op send. Als het goed is krijg je een error te zien... :(

## Stap 2
Zorg dat IdentityServer werkt en je een geldige jwt token terugkrijgt. Dit gaan we doen door:
- In de back-end folder, open het IdentityServer bestand. Voeg de `Duende.IdentityServer` NuGet package toe aan het project. 
- Config.cs moet juist opgebouwd worden. Gebruik hiervoor de blauwdruk van Config.cs en deze documentatie:
[Quickstart 5: Using ASP.NET Identity – Duende IdentityServer](https://docs.duendesoftware.com/identityserver/quickstarts/5-aspnetid/)
- **Clients**: hoe definieer je toegestane grant types, scopes en redirect URIs?
- **ApiScopes**: hoe definieer je welke informatie gedeeld mag worden?
- **IdentityResources**: hoe zorg je ervoor dat de `role` meegegeven wordt in het token?
- Tip: kijk naar de waardes die je via postman mee moet sturen. 

## Stap 3
- Testen of het werkt. Voer de post-request weer uit via postman en kijk of je een token terugkrijgt.
- Kopieer de token en gebruik [jwt.io](https://jwt.io) om de inhoud van de token in te zien. Als je de rol van 'Alice' kan achterhalen, werkt het. 

## Stap 4
- Open nu de front-end en run de applicatie met `npm start`. De volgende stap is om het inloggen werkend te krijgen met de identityServer (run dit project dus in de back-end).
- Open nu het bestand `IndexPage.js`. In functie handleLogin moet je een fetch request naar de identityServer doen om een geldige token terug te krijgen. 
- Voeg `const formData = new URLSearchParams();` toe en gebruik `formdata.append` om de benodigde waardes in de body mee te kunnen sturen die je ook nodig had met Postman (tip: dit zijn er 5). 
- Sla vervolgens de token op in de `localStorage` onder de naam `token`. Open nu de applicatie, log in en bekijk de token onder `inspect -> application -> localstorage`. Het kan zijn dat je deze eerst moet clearen. Kopieer de token weer en gebruik [jwt.io](https://jwt.io) om de rol te controlleren. 
- Om te testen of je met andere accounts ook in kan loggen en andere rollen te zien krijgt, moet je TestUsers.cs openen in de identityServer back-end. Probeer ook met deze accounts in te loggen en controlleer de token. 

## Stap 5
Op de landingspagina zie je dat je allerlij informatie te zien krijgt, waaronder ook gevoelige informatie dat een Alice als leerling niet mag zien! Dit gaan we voorkomen door RBAC toe te passen in de resource back-end. 
- Kijk op het scherm naar de presentatie. Hier staat welke rol wat in mag zien. 
- Open workshopApi. Open Program.cs en voeg authorization toe: `builder.Services.AddAuthorization`.
- Open nu de Controllers. Gebruik `Authorize` bij de endpoints om ervoor te zorgen dat alleen die rol dat endpoint op kan halen. Tip: je kan meerdere rollen hierbij toevoegen.
- Doe dit voor ieder endpoint. Log in op de 4 mogelijke accounts (met verschillende rollen) en kijk of je de gevoelige informatie nu succesvol hebt afgeschermd. 

### Klaar!
