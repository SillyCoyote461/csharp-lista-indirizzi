using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class User
{
    public User(string name, string surname, string street, string city, string province, int? zip)
    {
        Name = name;
        Surname = surname;
        Street = street;
        City = city;
        Province = province;
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
}

