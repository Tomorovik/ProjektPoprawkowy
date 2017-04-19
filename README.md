Projekt poprawkowy na zaliczenie dla znajomego.

Stworzony w technologii ASP.NET jako aplikacja webowa WEB FORMS. 
Baza danych jest za pomocą CodeFirst EntityFramework.
System walidacji i rejestracji zaimplementowany za pomocą Identity 2.0

Aplikacja pozwala na:
- Rejestracje kont użytkownika.                                                 
- Logowanie do konta użytkownika oraz administratora.
- Dodawanie, usuwanie, modyfikacje utworu do BD przez administratora
- Definiowanie list utworów poprzez:
    * Losowosc
    * Wg czasu zalozonego przez uzytkownika
    * Artyste(losowy, lub okreslona kolejnosc(losowa,tytul, rok powstania))
- Okreslenie rozpoczecia czasu rozpoczecia odtwarzania
- Statystyki odtwarzania utworów

Konto administratora:

login - admin@com.pl
hasło - Admin!23

Konto użytkownika

login - user1@wp.pl
hasło - Haslo!23

Instrukcja obsługi:
- Domyślnie baza jest zmockowana na posiadanie 12 utworów.
    * Pozwala to na pokazanie poprawności działania dodawania, edytowania, usuwania utworów.
    * Pozwala także na tworzenie playlisty
- W razie komplikacji:
    * Projekt wyczyścić (Build -> Clean solution)
    * Usunąć fizyczną baze danych (folder App_Data plik Baza.mdf) 
    * Wykonać Update-Database w Package Manager Console ( Ctrl + Q i wpisać Package Manager Console. Następnie wewnątrz nowootwartego panelu wpisać Update-Database)
    * W razie modyfikacji modeli, należy wykonać Migracje za pomocą PMC. Komenda " Add-Migration "Tytuł migracji". Nastepnie wykonac Update-Database
- Interfejs na najwyższym poziomie. 
- Oprawa wizualna jeszcze wyżej.
    
