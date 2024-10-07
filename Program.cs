using System;
using System.Data;
using System.Net;

// declaation of global variables
bool flagProg = true;
List<string> MathQuest = new List<string>();
Menu();
while (flagProg)
{
    var quest = Console.ReadLine();
    EndingClearProtocol(ref flagProg, ref MathQuest, quest);
    string resolve = $"{quest} = {ResolveQuestProblem(quest)}";
    MathQuest.Add(resolve);
    Console.Clear();
    foreach (var q in MathQuest)
    {
        Console.WriteLine(q);
    }
    System.Console.WriteLine("________________");
}

void Menu()
{
    System.Console.WriteLine($"################################");
    System.Console.WriteLine($"# wpisz działanie matematyczne #");
    System.Console.WriteLine($"# C - by wykasować historie    #");
    System.Console.WriteLine($"# E - by zakończyć             #");
    System.Console.WriteLine($"################################");
}
void EndingClearProtocol(ref bool flagProg, ref List<string> MathQuest, string quest)
{
    if (quest.Length == 1)
    {
        switch (quest.ToLowerInvariant())
        {
            case "c":
                MathQuest.Clear();
                break;
            case "e":
                flagProg = false;
                break;
            default:
                break;
        }
    }
}
string ResolveQuestProblem(string quest = "")
{
    if (quest.Length > 1)
    {
        var resolve = new DataTable().Compute(quest, null);
        return resolve.ToString();
    }
    else { return quest; }


}