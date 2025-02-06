// Main UI-Flow
using cerberus_pass;

PasswordEntry pass1 = new PasswordEntry(
    "Steam",
    "WaldmeisterSD",
    "P@ssword");

Console.ForegroundColor = ConsoleColor.Magenta;

System.Console.WriteLine("Willkommen zu Cerberus-Pass!");
System.Console.WriteLine("Wähle, was du tun willst:");

Console.ResetColor();

System.Console.WriteLine(@"
  1. Passwort-Liste ausgeben
  2. Passwort mit ID ausgeben
  3. Neues Passwort erstellen
  4. Vorhandenes Passwort bearbeiten
  5. Passwort löschen
");
