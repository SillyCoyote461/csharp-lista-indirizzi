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
    try {
        if (String.IsNullOrEmpty(array[0])) array[0] = "undefined";
        name = array[0];
    }
    catch { name = "undefined"; }

    try {
        if (String.IsNullOrEmpty(array[1])) array[1] = "undefined";
        surname = array[1]; 
    }
    catch { surname = "undefined"; }

    try {
        if (String.IsNullOrEmpty(array[2])) array[2] = "undefined";

        street = array[2]; 
    }
    catch { street = "undefined"; }

    try {
        if (String.IsNullOrEmpty(array[3])) array[3] = "undefined";

        city = array[3]; 
    }
    catch { city = "undefined"; }

    try {
        if (String.IsNullOrEmpty(array[4])) array[4] = "undefined";

        province = array[4]; 
    }
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
