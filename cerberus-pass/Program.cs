// Main UI-Flow
using cerberus_pass;
using Microsoft.VisualBasic;


var manager = new PasswordManager();
var userInterface = new ConsoleUI();
var masterPasswordSet = false;
var programIsRunning = true;

do
{
  userInterface.InitializeMasterPassword();
  var newMasterPassword = userInterface.GetParameter("das Master-Passwort");
  if (newMasterPassword == "") { userInterface.EmptyStringError(); Console.ReadLine(); continue; }
  userInterface.PromptConfirmPassword();
  if (!manager.CheckPasswordConfirmation(newMasterPassword, userInterface.GetParameter("das Password erneut"))) { userInterface.WrongPasswordError(); Console.ReadLine(); continue; }
  manager.SetMasterPassword(newMasterPassword);
  masterPasswordSet = true;
} while (masterPasswordSet == false);


Console.Clear();
userInterface.Greeting();

do
{

  userInterface.MainMenu();

  var userInput = Console.ReadLine();
  int menuChoice;
  if (!int.TryParse(userInput, out menuChoice))
    continue;

  switch ((MenuOptions)menuChoice)
  {
    case MenuOptions.ListVault:
      if (manager.GetVault().Count == 0) { userInterface.NoEntriesError(); break; }
      var allEntries = manager.GetVault();
      foreach (var entry in allEntries)
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine(entry);
        Console.ResetColor();
      }
      break;


    case MenuOptions.DisplayOneEntry:
      if (!manager.CheckMasterPassword(userInterface.GetParameter("das Master-Passwort"))) { userInterface.WrongPasswordError(); break; }
      if (manager.GetVault().Count == 0) { userInterface.NoEntriesError(); break; }
      var requestedTitle = userInterface.GetParameter("den Titel");
      if (!manager.TitleExists(requestedTitle)) { userInterface.TitleError("nicht"); break; }
      Console.ForegroundColor = ConsoleColor.Cyan;
      System.Console.WriteLine(manager.DisplayEntry(requestedTitle));
      Console.ResetColor();
      break;


    case MenuOptions.CreateNewEntry:
      var newTitle = userInterface.GetParameter("den Titel");
      if (newTitle == "" || manager.IsTitleTooShort(newTitle)) { userInterface.TitleLengthError(); break; }
      else if (manager.TitleExists(newTitle)) { userInterface.TitleError("bereits"); break; }
      var newLogin = userInterface.GetParameter("den Login");
      if (newLogin == "") { userInterface.EmptyStringError(); break; }
      var newPassword = userInterface.GetParameter("das Password");
      if (newPassword == "") { userInterface.EmptyStringError(); break; }
      userInterface.PromptConfirmPassword();
      if (!manager.CheckPasswordConfirmation(newPassword, userInterface.GetParameter("das Password erneut"))) { userInterface.WrongPasswordError(); break; }
      var newWebsite = userInterface.GetParameter("die Website");
      var newNote = userInterface.GetParameter("die Notiz");
      manager.CreateEntry(newTitle, newLogin, newPassword, newWebsite, newNote);
      userInterface.OperationSuccessfull("Eintrag erstellen");
      break;


    case MenuOptions.UpdateEntry:
      if (!manager.CheckMasterPassword(userInterface.GetParameter("das Master-Passwort"))) { userInterface.WrongPasswordError(); break; }
      if (manager.GetVault().Count == 0) { userInterface.NoEntriesError(); break; }
      var titleToChange = userInterface.GetParameter("den Titel");
      if (titleToChange == "") { userInterface.EmptyStringError(); break; }
      else if (!manager.TitleExists(titleToChange)) { userInterface.TitleError("nicht"); break; }

      var updatedTitle = userInterface.GetParameter("den neuen Titel");
      var updatedLogin = userInterface.GetParameter("den neuen Login");
      var updatedPassword = userInterface.GetParameter("das neue Password");
      userInterface.PromptConfirmPassword();
      if (!manager.CheckPasswordConfirmation(updatedPassword, userInterface.GetParameter("das Password erneut"))) { userInterface.WrongPasswordError(); break; }
      var updatedWebsite = userInterface.GetParameter("die neue Website");
      var updatedNote = userInterface.GetParameter("die neue Notiz");

      manager.UpdateEntry(titleToChange, updatedTitle, updatedLogin, updatedPassword, updatedWebsite, updatedNote);

      userInterface.OperationSuccessfull("Eintrag aktualisieren");
      break;


    case MenuOptions.DeleteEntry:
      if (!manager.CheckMasterPassword(userInterface.GetParameter("das Master-Passwort"))) { userInterface.WrongPasswordError(); break; }
      if (manager.GetVault().Count == 0) { userInterface.NoEntriesError(); break; }
      var titleToDelete = userInterface.GetParameter("den Titel");
      if (!manager.TitleExists(titleToDelete)) { userInterface.TitleError("nicht"); break; }
      manager.DeleteEntry(titleToDelete);
      userInterface.OperationSuccessfull("Eintrag löschen");
      break;

    default:
      System.Console.WriteLine("Falsche Eingabe! Valide Optionen: 1-5");
      break;

    case MenuOptions.ExitProgram:
      var choice = userInterface.ConfirmExitProgram();
      switch (choice)
      {
        case "j":
          programIsRunning = false;
          break;
        case "n":
          break;
        default:
          System.Console.WriteLine("Falsche Eingabe! Valide Optionen: j/n");
          break;
      }
      break;
  }
  Console.ReadKey();
  Console.Clear();
} while (programIsRunning);