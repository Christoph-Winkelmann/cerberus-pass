using System;
using System.Security.Cryptography.X509Certificates;

namespace cerberus_pass;

public class ConsoleUI
{
    // Get User Input
    public string? GetParameter(string parameter)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();
        System.Console.Write($"Gebe {parameter} ein: ");
        var output = Console.ReadLine();
        Console.ResetColor();
        return output;
    }

    // public string[] GetParameter(string[] parameters)
    // {
    //     var outParams = new string[parameters.Length];
    //     for (int i = 0; i > parameters.Length; i++)
    //     {
    //         Console.Clear();
    //         System.Console.Write($"Gebe {parameters[i]} ein: ");
    //         outParams[i] = Console.ReadLine() ?? String.Empty;
    //     }
    //     return outParams;
    // }


    // Messages
    public void InitializeMasterPassword()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("Bitte lege ein Master-Passwort fest:");
        Console.ResetColor();
    }


    public void Greeting()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("Willkommen zu Cerberus-Pass!");
        Console.ResetColor();
    }


    public void MainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("\tWähle was du tun willst:\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("\t1. Alle Einträge anzeigen\n" +
        "\t2. Einen bestimmten Eintrag anzeigen\n" +
        "\t3. Einen neuen Eintrag erstellen\n" +
        "\t4. Einen vorhandenen Eintrag bearbeiten\n" +
        "\t5. Einen vorhandenen Eintrag löschen\n" +
        "\t6. Programm beenden");
        Console.ResetColor();
    }

    public void OperationSuccessfull(string operation)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{operation} war erfolgreich.");
        Console.ResetColor();
    }

    public void PromptConfirmPassword()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("Bitte bestätige das Passwort:");
        Console.ResetColor();
    }

    public string ConfirmExitProgram()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("Willst du das Programm wirklich beenden? (j/n)");
        var output = Console.ReadLine();
        Console.ResetColor();
        return output;
    }


    // Error Messages
    public void TitleError(string modus)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"Ein Eintrag mit diesem Titel ist {modus} vorhanden. Wähle bitte einen anderen Titel.");
        Console.ResetColor();
    }

    public void TitleLengthError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Der Titel ist zu kurz. Wähle einen Title mit mindestens 3 Buchstaben.");
        Console.ResetColor();
    }

    public void EmptyStringError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Die Eingabe darf nicht leer sein.");
        Console.ResetColor();
    }

    public void NoEntriesError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Es sind keine Einträge vorhanden...");
        Console.ResetColor();
    }

    public void WrongPasswordError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Falsches Passwort!");
        Console.ResetColor();
    }
}
