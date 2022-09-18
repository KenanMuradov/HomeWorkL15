using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkL15;

class User
{
    private string? name;
    public string? Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                throw new ArgumentException("Entered Name is incorrect");

            name = value;
        }
    }

    private string? surname;

    public string? Surname
    {
        get { return surname; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                throw new ArgumentException("Entered Surname is incorrect");

            surname = value;
        }
    }

    private string? email;

    public string? Email
    {
        get { return email; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 8 || !value.EndsWith("@gmail.com"))
                throw new ArgumentException("Entered Email is incorrect");

            email = value;
        }
    }

    private string? phone;
    public string? Phone
    {
        get { return phone; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 10 || !value.All(char.IsDigit))
                throw new ArgumentException("Entered Number is incorrect");

            phone = value;
        }
    }
    public User(string? name, string? surname, string? email, string? phone)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
    }

}
