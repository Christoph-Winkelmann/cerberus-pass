namespace cerberus_pass;

public class PasswordManager
{
  private List<PasswordEntry> vault;
  private string masterPassword;

  public PasswordManager()
  {
    masterPassword = "";
    vault = [];
  }

  // Password Stuff
  public void SetMasterPassword(string password)
  {
    masterPassword = password;
  }

  public bool CheckMasterPassword(string password) => password == masterPassword;

  public bool CheckPasswordConfirmation(string password1, string password2) => password1 == password2;


  // Vault Entry Stuff
  public List<string> GetVault()
  {
    var allEntries = new List<string>();
    for (int i = 0; i < vault.Count; i++)
    {
      PasswordEntry? entry = vault[i];
      allEntries.Add($"Titel: {entry.Title} | Login: {entry.Login}");
    }
    return allEntries;
  }

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
      string.IsNullOrEmpty(website) ? "leer" : website,
      string.IsNullOrEmpty(note) ? "leer" : note
    );
    vault.Add(newEntry);
  }

  public PasswordEntry GetEntry(string title)
  {
    var requestedEntry = vault.Find(x => x.Title == title);
    return requestedEntry;
  }

  public string DisplayEntry(string title)
  {
    var requestedEntry = vault.Find(x => x.Title == title);
    return $"Titel: {requestedEntry.Title} | Login: {requestedEntry.Login} | Password: {requestedEntry.Password} | Website: {requestedEntry.Website} | Notiz: {requestedEntry.Note}";
  }

  public void UpdateEntry(
    string oldTitle,
    string title,
    string login,
    string password,
    string website,
    string note)
  {
    var indexToUpdate = vault.FindIndex(
      x => x.Title == oldTitle);

    var oldEntry = vault[indexToUpdate];

    var updatedEntry = new PasswordEntry(
      string.IsNullOrEmpty(title) ? oldEntry.Title : title,
      string.IsNullOrEmpty(login) ? oldEntry.Login : login,
      string.IsNullOrEmpty(password) ? oldEntry.Password : password,
      string.IsNullOrEmpty(website) ? oldEntry.Website : website,
      string.IsNullOrEmpty(note) ? oldEntry.Note : note
    );

    vault[indexToUpdate] = updatedEntry;
  }

  public bool DeleteEntry(string titleToDelete) =>
    vault.RemoveAll(x => x.Title == titleToDelete) > 0;


  // Validation Stuff, maybe move Input-related checks to ConsoleUI
  public bool TitleExists(string title) => vault.Any(x => x.Title == title);

  public bool IsTitleTooShort(string title) => title.Length < 3 ? true : false;

  public bool IsStringEmpty(string input) => input == "" ? true : false;
}
