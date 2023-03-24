using System.IO;
using System.Xml.Linq;

using var file = File.OpenText("..\\..\\..\\addresses.csv");
string? line = file.ReadLine();

//take out first stream from the loop
Console.WriteLine(line);

List<User> users = new List<User>();



while (true)
{
    line = file.ReadLine();
    if (line == null) break;
    var array = line.Split(',');
    string[]? data = {"", "", "", ""};
    string? province = null;
    int? zip = null;
    int position = 0;

    foreach(var item in array)
    {
        string noSpacesStr = item.Replace(" ", "");
        //if zip code
        if (int.TryParse(item, out int number) && zip == null)
        {
            zip = number;
            break;
        }

        //if province

        else if (noSpacesStr.Length is 2 && province == null)
        {
            bool zipChecker = true;
            for (int i = 0; i < 2; i++)
            {
                if (!Char.IsUpper(noSpacesStr[i]))
                {
                    zipChecker = false; break;
                }
            }
            if (zipChecker)
            {
                province = noSpacesStr;
                continue;
            }
        }
        else
        {
            if(position < 4)
            {

                data[position] = item;
                position++;
            }
        }
    }
    var user = new User(data[0], data[1], data[2], data[3], province, zip);
    users.Add(user);
}

foreach (var user in users)
{
    Console.WriteLine(user.ToString());
}

