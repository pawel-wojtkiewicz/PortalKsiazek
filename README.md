# Portal Książkowy

Portal Książkowy to aplikacja ASP.NET Core, która umożliwia użytkownikom przeglądanie książek, ocenianie ich oraz otrzymywanie rekomendacji na podstawie swoich ocen.

## Funkcjonalności

- Przeglądanie dostępnych książek
- Dodawanie nowych książek oraz usuwanie książek (dostępne dla administratorów)
- Ocena książek
- Rekomendacje książek na podstawie ocenionych książek

## Wymagania

- .NET 8.0 SDK lub wyższy
- SQL Server (lub inna baza danych wspierająca EF Core)

## Jak zaimportować projekt

1. Pobierz pliki projektu z repozytorium
2. Wypakuj pliki w dowolnym miejscu
3. Uruchom Visual Studio
4. Zaimportuj projekt za pomocą opcji otwórz projekt lub rozwiązanie, wskaż w projekcie plik PortalKsiazkowy.sln
5. Otwórz Narzędzia -> Menedżer pakietów NuGet -> Konsola menedżera pakietów
6. Uruchom polecenia<br>
dotnet tool install --global dotnet-ef <br>

dotnet ef migrations add InitialCreate <br>

dotnet ef database update <br>

8. Uruchom projekt
