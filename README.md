# ContactListAPI</br>

Aplikacja napisana jest w .Net 5 z wykorzystaniem MSSQL. 
Podstawowe dane testowe są automatycznie generowane przy pierwszym uruchomieniu aplikacji po podłączeniu lokalnie do bazy danych. 
Aby uzyskać dostęp do endpointów wymagających autoryzacji należy utworzyć konto. 
Bez zalogowania działa tylko endpoint: https://localhost:5001/api/contact.
Po zalogowaniu wygenerowany JWT działa 15min. </br></br>


Opis klas i metod</br>
ContactDbContext.cs - klasa konfiguracji bazy danych</br>
ContactController.cs - klasa obsługująca endpointy dla CRUD</br>
ContactServices.cs - klasa serwis, zawierająca logikę dla endpointów</br>
AccountControler.cs - klasa, kontroler, obsługująca endpointy logowania i rejestracji</br>
AccountService.cs - klasa serwis, zawierająca logikę dla endpointów</br>
ContactSeeder.cs - klasa tworząca pierwsze podstawowe dane, zawiera funkcję Seed(), która sprawdza połączenie z BD i jej zawartość. 
                    W przypadku pustej BD tworzy w niej nowe dane.</br></br>


Wykorzystane biblioteki:</br>
Entity Framework Core</br>
Entity Framework Core.SqlSerwer</br>
Entity Framework Core.Tools</br>
Swashbuckle.AspNetCore (Swagger)</br>
Authentication.JwtBearer</br>
AutoMapper</br></br>

Sposób uruchomienia aplikacji:</br>
Obsługa endpointów za pomocą programu Postman</br>
https://localhost:5001/swagger</br>
