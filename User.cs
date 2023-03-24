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
        return $"{Name}, {Surname}, {Street}, {City}, {Province}, {(Zip != null ? Zip : "undefined")}";
    }
    
    protected string UndefinedString(string str)
    {
        if (String.IsNullOrEmpty(str)) return "undefined";
        else return str ;
    }
}

