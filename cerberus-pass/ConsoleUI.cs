using System;
using System.Security.Cryptography.X509Certificates;

namespace cerberus_pass;

public class ConsoleUI
{
    public string? GetParameter(string parameter)
    {
        Console.Clear();
        System.Console.Write($"Gebe {parameter} ein: ");
        var output = Console.ReadLine();
        return output;
    }

    public string[] GetParameter(string[] parameters)
    {
        var outParams = new string[parameters.Length];
        for (int i = 0; i > parameters.Length; i++)
        {
            Console.Clear();
            System.Console.Write($"Gebe {parameters[i]} ein: ");
            outParams[i] = Console.ReadLine() ?? String.Empty;
        }
        return outParams;
    }



    // Messages
    public void OperationSuccessfull(string operation)
    {
        Console.WriteLine($"{operation} war erfolgreich.");
    }

    public void TitleError(string modus)
    {
        System.Console.WriteLine($"Ein Eintrag mit diesem Titel ist {modus} vorhanden. Wähle bitte einen anderen Titel.");
    }

}
