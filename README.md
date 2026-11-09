# FishingShop

Sklep ze sprzętem wędkarskim w ASP.NET Core MVC. Strona główna pod adresem `/` jest obsługiwana przez `HomeController` i wyświetla widok Razor `Views/Home/Index.cshtml`.

Wspólny szablon `Views/Shared/_Layout.cshtml` zawiera nagłówek, nawigację i stopkę. Widoki korzystają z niego przez `Views/_ViewStart.cshtml` i dostarczają własny tytuł oraz treść.

Wygląd strony określa `wwwroot/css/site.css`. Układ nagłówka i odstępy dostosowują się do szerokości ekranu.

Przykładowy produkt jest obiektem klasy `Product`, tworzonym w `HomeController`. Widok odczytuje jego nazwę, opis i cenę przez `@Model`. Cena używa typu `decimal` i jest wyświetlana w złotych z polskim formatowaniem.

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
