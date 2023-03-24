using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class User
{
    public User(string name, string surname, string street, string city, string province, int? zip)
    {
        Name = UndefinedString(name);
        Surname = UndefinedString(surname);
        Street = UndefinedString(street);
        City = UndefinedString(city);
        Province = UndefinedString(province);
        Zip = zip;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public int? Zip { get; set; }

    public override string ToString()
    {
        return $"{(Name != null ? Name : "N/D")}, {(Surname != null ? Surname : "N/D")}, {(Street != null ? Street : "N/D")}, {(City != null ? City : "N/D")}, {(Province != null ? Province : "N/D")}, {(Zip != null ? Zip : "N/D")}";
    }
    
    protected string UndefinedString(string str)
    {
        string noSpaces = str.Replace(" ", "");
        if (String.IsNullOrEmpty(str) || noSpaces.Length == 0) return null;
        else return str ;
    }
}

