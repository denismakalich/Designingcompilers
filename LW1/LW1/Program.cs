using System.Text.RegularExpressions;

string path = "text.txt";
string text = String.Empty;
Dictionary<string, int> register = new Dictionary<string, int>();

text = ReadFile(path);
register = AddRegister(text);
Console.WriteLine();

static string ReadFile(string path)
{
    string text = string.Empty;
    try
    {
        using (StreamReader reader = new StreamReader(path))
        {
            text = reader.ReadToEnd();
            Console.WriteLine(text);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
    }

    return text;
}

static Dictionary<string, int> AddRegister(string text)
{
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    Regex regexValue = new Regex(@"^ld\s(r\d{1,2}),\s?#(\d{1,3})", RegexOptions.IgnoreCase | RegexOptions.Multiline);
    MatchCollection mathes = regexValue.Matches(text);

    foreach (Match match in mathes)
    {
        dictionary.Add(match.Groups[1].Value, Convert.ToInt32(match.Groups[2].Value));
    }

    return dictionary;
}