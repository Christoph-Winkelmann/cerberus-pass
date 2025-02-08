using System.Security.Cryptography.X509Certificates;

namespace cerberus_pass;

public class PasswordManager
{
  private List<PasswordEntry> vault;

  public PasswordManager()
  {
    // vault = new List<PasswordEntry>();
    // vault = new();
    // vault = [];
    vault = [];
  }

  public List<PasswordEntry> GetAll() => vault;


  public void CreateEntry(
    string title,
    string login,
    string password,
    string website = "",
    string note = "")
  {

    var newEntry = new PasswordEntry(
      title,
      login,
      password,
      website,
      note
    );
    vault.Add(newEntry);
  }

  // GetEntry
  public PasswordEntry GetEntry(string title) =>
    vault.Find(x => x.Title == title);


  public string DisplayEntry(string title)
  {
    var requestedEntry = vault.Find(x => x.Title == title);
    return $"{requestedEntry.Title}\t{requestedEntry.Login}\t{requestedEntry.Password}";
  }

  // UpdateEntry
  public PasswordEntry UpdateEntry(string titleToChange, PasswordEntry newEntry)
  {
    var indexToUpdate = vault.FindIndex(
      x => x.Title == titleToChange);
    vault[indexToUpdate] = newEntry;
    return vault[indexToUpdate];

    // var entryToChange = vault.Find(x => x.Title == titleToChange);
    // entryToChange = newEntry;
  }

  // DeleteEntry
  public bool DeleteEntry(string titleToDelete) =>
    vault.RemoveAll(x => x.Title == titleToDelete) > 0;




  // Check if a given Title already exists in the Vault
  public bool TitleExists(string title) => vault.Any(x => x.Title == title);

}
