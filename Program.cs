using var file = File.OpenText("..\\..\\..\\addresses.csv");
string? line = file.ReadLine();

//take out first stream from the loop
Console.WriteLine(line);

List<User> users = new List<User>();

while (true)
{
    //reading and writing
    line = file.ReadLine();
    if (line == null) break;

    var array = line.Split(',');
    string name;
    string surname;
    string street;
    string city;
    string province;
    int? zip;

    //try and catch every string
    try { name = array[0];}
    catch { name = "undefined"; }

    try { surname = array[1]; }
    catch { surname = "undefined"; }

    try { street = array[2]; }
    catch { street = "undefined"; }

    try { city = array[3]; }
    catch { city = "undefined"; }

    try { province = array[4]; }
    catch { province = "undefined"; }

    try { zip = Convert.ToInt32(array[5]); }
    catch { zip = null; }

    //new User and add to list
    var user = new User(name, surname, street, city, province, zip);
    users.Add(user);
}

foreach (var user in users)
{
    Console.WriteLine(user.ToString());
}
