using System.Text.RegularExpressions;

string str1 = "sfadsfadsfasdf555555444444 333 333333";
Console.WriteLine(Ex1(str1));

string str2 = "name name name";
Console.WriteLine(Ex2(str2));

string str3 = ":---( ;-]";
Console.WriteLine(Ex3(str3));

string str4 = "Текст с номером +373(778)00199 и еще одним +373(775)63154.";
Console.WriteLine(Ex4(str4));

string str5 = "Это Т123НЕ пример С001АА текста\"";
IEnumerable<string> carNumbers = Ex5(str5);

foreach (var number in carNumbers)
{
    Console.WriteLine(number);
}

string str6 = "Текст с IP-адресами: 192.168.1.1, 255.0.0.0, Invalid IP: 300.200.100.50";
IEnumerable<string> ipAddresses = Ex6(str6);

foreach (var ipAddress in ipAddresses)
{
    Console.WriteLine(ipAddress);
}

/*
 * (Count) Написать функцию, которая определяет количество
 * входящих в заданную строку почтовых индексов
 * (почтовый индекс состоит из 6 цифр).
 */
static int Ex1(string str)
{
    Regex regex = new Regex(@"\d{6}");
    MatchCollection matchCollection = regex.Matches(str);

    return matchCollection.Count;
}

/*
 * (Regex.Replace) Дана строка — предложение на русском языке.
 * Поменять местами первую и последнюю буквы каждого слова. 
*/
static string Ex2(string str)
{
    Regex regex = new Regex(@"\b(\w)(\w*?)(\w)\b");

    string replacement(Match match)
    {
        char first = match.Groups[1].Value[0];
        char last = match.Groups[3].Value[0];

        return last + match.Groups[2].Value + first;
    }

    string result = regex.Replace(str, replacement);
    
    return result;
}

/*
Дана строка. Посчитать, сколько смайликов в ней содержится. Смайликом будем считать последовательность символов, удовлетворяющую условиям:
первым символом является либо ; (точка с запятой) либо : (двоеточие) ровно один раз
далее может идти символ - (минус) сколько угодно раз (в том числе символ минус может идти ноль раз)
в конце обязательно идет некоторое количество (не меньше одной) одинаковых скобок из следующего набора: (, ), [, ].
внутри смайлика не может встречаться никаких других символов.
*/
static int Ex3(string str)
{
    Regex regex = new Regex(@"[;:]-*[\(\)\[\]]+");
    MatchCollection matchCollection = regex.Matches(str);

    return matchCollection.Count;
}

/*
(Regex.Replace) Дана строка, содержащая помимо прочей информации номера телефонов 
в федеральном формате. Скрыть все цифры городской части номера кроме 
самой первой под символами x. Например, если в тексте имелся номер +7 (863) 297-51-11, 
то после преобразования он должен выглядеть как +7 (863) 2xx-xx-xx. 
Считать, что код города может содержать от трёх до пяти цифр, а городской номер — от 7 до 5 цифр соответственно.
*/
static string Ex4(string str)
{
    Regex regex = new Regex(@"\b373\(\d{3}\)\d{5}\b");
    
    string replacement(Match match)
    {
        var value = match.Value;
        return value.Remove(value.Length - 4) + "xxxx";
    }

    string result = regex.Replace(str, replacement);

    return result;
}

/*
Выяснить, какими могут быть российские автомобильные номера (с кодом региона), 
составить соответствующее регулярное выражение и 
написать функцию, которая находит в строке все автомобильные номера и возвращает их в виде последовательности.
*/
static IEnumerable<string> Ex5(string str)
{
    Regex regex = new Regex(@"[АВЕНКРСТ]\d{3}[АВЕНКРСТ]{2}", RegexOptions.IgnoreCase);
    MatchCollection match = regex.Matches(str);
    List<string> carNumbers = new List<string>();

    foreach (Match item in match)
    {
        carNumbers.Add(item.Value);
    }

    return carNumbers;
}

/*
Дана строка.
Сохранить в новую строку все содержащиеся в нём IPv4-адреса
в десятичной записи с точками через разделитель.
*/
static IEnumerable<string> Ex6(string str)
{
    Regex regex = new Regex(@"\b(\d{1,3}\.){3}\d{1,3}\b");
    MatchCollection match = regex.Matches(str);
    List<string> ipv4 = new List<string>();

    foreach (Match item in match)
    {
        ipv4.Add(item.Value);
    }

    return ipv4;
}