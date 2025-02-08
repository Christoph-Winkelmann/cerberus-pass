// Main UI-Flow
using cerberus_pass;


var manager = new PasswordManager();
var userInterface = new ConsoleUI();

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("Willkommen zu Cerberus-Pass!");
Console.ResetColor();

do
{
  Console.WriteLine("Wähle was du tun willst:");

  Console.WriteLine("""
  1. Passwort-Liste ausgeben
  2. Passwort mit ID ausgeben
  3. Neues Passwort erstellen
  4. Vorhandenes Passwort bearbeiten
  5. Passwort löschen
""");

  var userInput = Console.ReadLine();

  int menuChoice;

  if (!int.TryParse(userInput, out menuChoice))
    continue;

  switch ((MenuOptions)menuChoice)
  {
    case MenuOptions.ListVault:
      var vault = manager.GetAll();
      foreach (var item in vault)
      {
        Console.WriteLine(item);
      }
      break;


    case MenuOptions.DisplayOneEntry:
      var requestedTitle = userInterface.GetParameter("den Titel");
      if (!manager.TitleExists(requestedTitle))
      {
        userInterface.TitleError("nicht");
        break;
      }
      manager.DisplayEntry(requestedTitle);
      break;


    case MenuOptions.CreateNewEntry:
      var newTitle = userInterface.GetParameter("den Titel");
      if (manager.TitleExists(newTitle))
      {
        userInterface.TitleError("bereits");
        break;
      }
      var newLogin = userInterface.GetParameter("den Login");
      var newPassword = userInterface.GetParameter("das Password");

      manager.CreateEntry(newTitle, newLogin, newPassword);
      userInterface.OperationSuccessfull("Eintrag erstellen");
      break;


    case MenuOptions.UpdateEntry:
      var titleToChange = userInterface.GetParameter("den Titel");
      if (!manager.TitleExists(titleToChange))
      {
        userInterface.TitleError("bereits");
        break;
      }


      break;
    // Console.WriteLine("Welchen Eintrag willst du ändern? (Title):");
    // var title_to_change = Console.ReadLine();
    // Console.WriteLine(
    //   "Gebe einen neuen Titel für den Eintrag an (Leer um nichts zu ändern):");
    // var new_title = Console.ReadLine();
    // Console.WriteLine(
    //   "Gebe einen neuen Login für den Eintrag an (Leer um nichts zu ändern):");
    // var new_login = Console.ReadLine();
    // Console.WriteLine(
    //   "Gebe ein neues Passwort für den Eintrag an (Leer um nichts zu ändern):");
    // var new_password = Console.ReadLine();
    // var oldEntry = manager.GetEntry(title_to_change);
    // var updatedEntry = manager.UpdateEntry(title_to_change, new PasswordEntry(
    //   String.IsNullOrEmpty(new_title) ? oldEntry.Title : new_title,
    //   String.IsNullOrEmpty(new_login) ? oldEntry.Login : new_login,
    //   String.IsNullOrEmpty(new_password) ? oldEntry.Password : new_password
    // ));
    // Console.WriteLine($"Eintrag {updatedEntry.Title} wurde erfolgreich aktuallisiert.");
    // break;

    case MenuOptions.DeleteEntry:
      Console.WriteLine("Welchen Eintrag willst du Löschen? (Title):");
      var titleToDelete = Console.ReadLine();
      if (manager.DeleteEntry(titleToDelete))
        Console.WriteLine($"Eintrag {titleToDelete} wurde erfolgreich entfernt");
      else
        Console.WriteLine(
          $"Fehler beim löschen des Eintrags: {titleToDelete} wurde nicht gefunden!");
      break;

    default:
      // Fehler anzeigen -> Eingabe-Hint (1-5)
      // Eingabe wiederholen
      System.Console.WriteLine("Falsche Eingabe! Valide Optionen: 1-5");
      break;
  }
  Console.ReadKey();
  Console.Clear();
} while (true);