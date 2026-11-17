# Lokalna baza FishingShop

Docker Compose uruchamia SQL Server 2022 Developer. Skopiuj `.env.example` do `.env` i wpisz własne silne hasło pod `FISHINGSHOP_SQL_PASSWORD`. Plik `.env` jest ignorowany przez Git.

W katalogu projektu uruchom kontener i poczekaj na komunikat `SQL Server is now ready for client connections`. Naciśnij `Ctrl+C`, aby zakończyć podgląd logów.

```console
docker compose up -d sql
docker compose logs -f sql
```

Polecenie dla `sqlcmd` w wersji ODBC poprosi o hasło, utworzy bazę `FishingShop`, jeśli jeszcze jej nie ma, i wypisze nazwę bazy. Możesz je wykonać ponownie.

```console
sqlcmd -S tcp:127.0.0.1,14334 -U sa -N -C -b -i sql/create-database.sql
```

Możesz też użyć SSMS. Wybierz serwer `127.0.0.1,14334`, uwierzytelnianie SQL Server i login `sa`. Dla tego lokalnego kontenera zaznacz **Trust server certificate**. Otwórz `sql/create-database.sql` i uruchom skrypt. Po utworzeniu bazy możesz sprawdzić połączenie poleceniem `SELECT DB_NAME();` w kontekście `FishingShop`.

Port jest dostępny lokalnie, a wolumen `fishingshop_sql-data` przechowuje pliki SQL Servera. `docker compose stop sql` zatrzymuje kontener z zachowaniem danych. Hasło konta `sa` jest zapisywane podczas inicjalizacji. Późniejsza zmiana wpisu w `.env` wymaga także zmiany hasła w SQL Serverze.

## Migracje EF Core

W Visual Studio kliknij prawym przyciskiem projekt `FishingShop.Web` i wybierz **Manage User Secrets**. Ustaw połączenie z lokalnym SQL Serverem. W miejsce `<hasło>` wpisz wartość `FISHINGSHOP_SQL_PASSWORD` z lokalnego `.env`.

```json
{
  "ConnectionStrings": {
    "FishingShop": "Server=127.0.0.1,14334;Database=FishingShop;User ID=sa;Password=\"<hasło>\";Encrypt=True;TrustServerCertificate=True"
  }
}
```

Z katalogu repozytorium przywróć narzędzie i zastosuj migracje.

```console
dotnet tool restore
dotnet ef database update --project src/FishingShop.Web -- --environment Development
```

`CatalogDbContext` opisuje tabele i relacje. Migracja `CreateCatalog` tworzy schemat bazy. EF Core zapisuje wykonane migracje w `__EFMigrationsHistory`, więc ponowne uruchomienie polecenia stosuje tylko brakujące migracje.

## Relacje katalogu

```mermaid
erDiagram
    Category ||--o{ Product : groups
    Brand ||--o{ Product : makes
    Product ||--o| RodSpecification : has
```

| Tabela | Dane i klucze |
| --- | --- |
| `Categories` | `Id`, `Name`. Jedna kategoria grupuje wiele produktów. |
| `Brands` | `Id`, `Name`. Jedna marka ma wiele produktów. |
| `Products` | `Id`, `Name`, `Description`, nieujemna cena `Price` jako `decimal(18,2)`. `CategoryId` i `BrandId` to wymagane klucze obce. |
| `RodSpecifications` | `ProductId` to klucz główny i obcy do `Products`, więc produkt może mieć najwyżej jedną specyfikację. Parametry to `LengthCm`, `CastWeightMinG`, `CastWeightMaxG` oraz typ `Spinning` lub `Casting`. |

Długość zapisujemy jako całkowitą liczbę centymetrów, a ciężary jako gramy z dokładnością do dwóch miejsc po przecinku. Długość i dolna granica ciężaru muszą być dodatnie, a dolna granica nie może przekraczać górnej. Filtr dokładny `7-21 g` sprawdza obie granice. Filtr dla przynęty `14 g` sprawdza, czy `14` mieści się w przedziale wędki. Te warunki można łączyć z długością, marką i typem.

Strona korzysta nadal z przykładowej listy w C#. Kolejny krok to dodanie przykładowych danych do tabel i podłączenie ich odczytu.
