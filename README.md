# ContactListAPI

Aplikacja napisana jest w .Net 5 z wykorzystaniem MSSQL. 
Podstawowe dane testowe są automatycznie generowane przy pierwszym uruchomieniu aplikacji po podłączeniu lokalnie do bazy danych. 
Aby uzyskać dostęp do endpointów wymagających autoryzacji należy utworzyć konto. 
Bez zalogowania działa tylko endpoint: https://localhost:5001/api/contact.
Po zalogowaniu wygenerowany JWT działa 15min. 


Opis klas i metod
ContactDbContext.cs - klasa konfiguracji bazy danych</br>
ContactController.cs - klasa obsługująca endpointy dla CRUD
ContactServices.cs - klasa serwis, zawierająca logikę dla endpointów
AccountControler.cs - klasa, kontroler, obsługująca endpointy logowania i rejestracji
AccountService.cs - klasa serwis, zawierająca logikę dla endpointów
ContactSeeder.cs - klasa tworząca pierwsze podstawowe dane, zawiera funkcję Seed(), która sprawdza połączenie z BD i jej zawartość. 
                    W przypadku pustej BD tworzy w niej nowe dane.


Wykorzystane biblioteki:
Entity Framework Core
Entity Framework Core.SqlSerwer
Entity Framework Core.Tools
Swashbuckle.AspNetCore (Swagger)
Authentication.JwtBearer
AutoMapper

Sposób uruchomienia aplikacji:
Obsługa endpointów za pomocą programu Postman
https://localhost:5001/swagger
