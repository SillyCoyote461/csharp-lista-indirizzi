using System.IO;
using System.Xml.Linq;

using var file = File.OpenText("..\\..\\..\\addresses.csv");

//take out first stream from the loop
string? line = file.ReadLine();
Console.WriteLine($"{line}{Environment.NewLine}");

List<User> users = new List<User>();
List<object> scraps = new List<object>();
List<string[]> strScraps = new List<string[]>();


while (true)
{
    line = file.ReadLine();
    if (line == null) break;
    var array = line.Split(',');
    string[]? data = {"", "", "", ""};
    string? province = null;
    int? zip = null;
    byte position = 0;

    if (array.Length != 6)
    {
        //Console.WriteLine(
        //    $"-----------------{Environment.NewLine}" +
        //    $"This user has invalid data format: {Environment.NewLine}" +
        //    $"{line}{Environment.NewLine}" +
        //    $"-----------------"
        //    );
        strScraps.Add(array);
    }
    else
    {
        foreach (var item in array)
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

            //else this is something
            else
            {
                if (position < 4)
                {

                    data[position] = item;
                    position++;
                }
            }
        }

        var user = new User(data[0], data[1], data[2], data[3], province, zip);
        if(user.Name == null || user.Surname == null || user.Street == null || user.City == null || user.Province == null || user.Zip == null)
        {
            scraps.Add(user);
        }
        else
        {
            users.Add(user);
        }
    }

}

if(scraps.Count > 0 || strScraps.Count > 0)
{
    Console.WriteLine(
        $"-----------------{Environment.NewLine}" +
        $"These users cannot be stored duo to invalid format or missing data: {Environment.NewLine}");
    foreach (var scrap in scraps)
    {
        if (scrap is User)
        {
        Console.WriteLine(scrap.ToString());
        }
    }

    foreach (var scrap in strScraps)
    {
        for(int i = 0; i < scrap.Length; i++)
        {
            if(i < scrap.Length - 1)
            {
                Console.Write($"{scrap[i]}, ");
            }
            else
            {
                Console.Write(scrap[i]);
            }
        }
            Console.WriteLine();
    }
    Console.WriteLine($"-----------------{Environment.NewLine}");
}



foreach (var user in users)
{
    Console.WriteLine(user.ToString());
}

