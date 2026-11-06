# FishingShop

Sklep ze sprzętem wędkarskim w ASP.NET Core. Pierwszy etap zawiera pustą aplikację zwracającą tekst pod adresem `/`.

## Visual Studio

Otwórz `FishingShop.sln` w Visual Studio 2026 z obsługą ASP.NET. Profil `FishingShop.Web` uruchamia aplikację pod adresem [localhost:5186](http://localhost:5186) i otwiera przeglądarkę.

- `F5` uruchamia aplikację z debuggerem.
- `Ctrl+F5` uruchamia aplikację bez debuggera.
- Zatrzymanie debugowania: `Shift+F5`.

## Terminal

Wymagany .NET SDK 10. Z katalogu projektu:

```console
dotnet run --project src/FishingShop.Web
```

Otwórz [localhost:5186](http://localhost:5186). Zatrzymanie aplikacji: `Ctrl+C` w terminalu.
