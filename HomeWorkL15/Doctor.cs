using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkL15;

class Doctor
{
    public List<ReceptionTime> ReceptionTimes;

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

    private byte workExperience;

    public byte WorkExperience
    {
        get { return workExperience; }
        set
        {
            if (value < workExperience)
                throw new ArgumentException("Incorrect Information");

            workExperience = value;
        }
    }


    public Doctor(string? name, string? surname, List<ReceptionTime> receptionTimes, byte workExperience = 0)
    {
        Name = name;
        Surname = surname;
        WorkExperience = workExperience;
        ReceptionTimes = receptionTimes;
    }



    public override string ToString()
        =>
        $@"Name: {Name}
Surname: {Surname}
Work Experience: {WorkExperience} years
";
}
