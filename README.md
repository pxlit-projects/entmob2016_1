# Enterprise and mobile 2016

## Groepsleden
- Kevin Strijbos
- Bram Van Vleymen
- Joran Claessens
- Sacha Reyskens

## Omschrijving
### Algemeen 
We zullen een app creëeren voor een transportbedrijf. Er zullen sensoren gebruikt worden om de cargo te controleren op grenswaarden. De app zal zowel het management aspect als het cargo aspect beheren.   
### Desktop-app
Management zal werken met een desktop-app. In deze desktop-app zal een overzicht van alle sensoren met hun verantwoordelijke (de chauffeur) te zien zijn. Verder zal het mogelijk zijn om sensoren toe te voegen, te verwijderen en aan te passen in de desktop app. Ook kunnen er categoriëen van producten met hun bijbehorende grenswaarden toegevoegd, verwijderd en aangepast kunnen worden. Verder kunnen er chauffeurs toegevoegd, verwijderd en aangepast worden. Een ander aspect is de geschiedenis per chauffeur. Deze geschiedenis omvat sensor gebruik, producten vervoerd, grenswaarde overschrijdingen enzovoort. 
### Smartphone-app
Een chauffeur kan een sensor in zijn cargo plaatsen in geval van vervoer. Om met de sensor te verbinden zal er gebruik gemaakt worden van Bluetooth via een smartphone. Eenmaal een chauffeur zijn smartphone verbindt met een sensor zal dit in de desktop-app te zien zijn. Nadat de verbinding is gelukt kan de chauffeur het soort cargo kiezen via een dropdown lijst. De grenswaarden zullen automatisch geconfigureerd worden aan de hand van de eerdere instellingen in de desktop app. Tijdens vervoer controleert de sensor op een overschrijding van de grenswaarde. Als een grenswaarde overschreden wordt, zal de chauffeur verwittigd worden door middel van zijn smartphone. Als de grenswaarde terug stabiliseert zal de chauffeur ook een notificatie krijgen. Al deze notificaties zullen zichtbaar zijn in de desktop-app. Communicatie tussen chauffeur en management is ook mogelijk. Bij het deconnecteren met een sensor kan de chauffeur commentaar toevoegen die beschikbaar zal zijn via de desktop-app.

## Gedetailleerd
### Communicatie tussen smartphone-app en desktop-app
De uitwisseling van gegevens tussen de smartphone-app en de desktop-app zal gebeuren via een server gehost op Azure. Deze server bevat een database met alle nodige data. De data zal opgevraagd en bewerkt kunnen worden via een REST-api mits authenticatie door een Oauth-token. De desktop-app werkt niet real-time maar met een refresh knop. 

### Voorbeelden van data
- Locatie
- ID van de chauffeur
- Soort cargo
- ID van de sensor
- Ingestelde grenswaarden
- ...

### Elementen waarop de sensor kan controleren
- Lichtsterke
- Geluidssterkte
- Temperatuur
- Luchtvochtigheid
- Luchtdruk
- Magnetisme
- Beweging
- Acceleratie

## Extra
Er zal ook gecontroleerd worden of de lading goed is verdeeld. Dit gebeurt aan de hand van de gyroscoop die controleert of de vrachtwagen scheef staat. De smartphone-app heeft een continue internet verbinding nodig. Dit om de data door te kunnen sturen naar de server. Als de internet verbinding afgezet is, zal management hier een notificatie van krijgen. 
