using System;
using System.Collections.Generic;
using System.Threading;

namespace HomeWorkL15;

class Program
{
    static void Main()
    {
        #region Preporation

        List<ReceptionTime> receptionTimes = new List<ReceptionTime>()
        {
            new ReceptionTime("09:00-11:00"),
            new ReceptionTime("12:00-14:00"),
            new ReceptionTime("15:00-17:00")

        };

        List<Doctor> pediatricsDoctors = new List<Doctor>()
        {
            new Doctor("Vernon","Ray",new List<ReceptionTime>(receptionTimes),10),
            new Doctor("Dennis","Perez",new List<ReceptionTime>(receptionTimes),5),
            new Doctor("Julie","Miller",new List<ReceptionTime>(receptionTimes),2),
            new Doctor("Edward","Morgan",new List<ReceptionTime>(receptionTimes),27),
        };

        List<Doctor> traumatologyDoctors = new List<Doctor>()
        {
            new Doctor("Cody","Lambert",new List<ReceptionTime>(receptionTimes),3),
            new Doctor("Timothy","Wright",new List<ReceptionTime>(receptionTimes),31)
        };


        List<Doctor> dentistryDoctors = new List<Doctor>()
        {
            new Doctor("Rebecca","Lewis",new List<ReceptionTime>(receptionTimes),9),
            new Doctor("David","Allen",new List<ReceptionTime>(receptionTimes),4),
            new Doctor("Gordon","Watson",new List<ReceptionTime>(receptionTimes),13)
        };


        #endregion

        Doctor currentDoctor;
        string doctorFullname;
        string time;
        bool isReserved = false;
        bool hasFreeTime = false;

        while (true)
        {
            Console.Clear();

            currentDoctor = null!;

            Console.WriteLine("Welcome to KepaClinics");
            Thread.Sleep(1500);

            Console.WriteLine("Please enter your data");

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Surname: ");
            string surname = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Phone number: ");
            string phone = Console.ReadLine()!;

            User user;

            try
            {
                user = new(name, surname, email, phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey(false);
                continue;
            }

            Console.WriteLine(@"Which specialist do you need?
1) Pediatrics
2) Traumotology
3) Dentistry");

            if (!int.TryParse(Console.ReadLine(), out int command))
            {
                Console.WriteLine("Unknown command");
                Console.ReadKey(false);
                continue;
            }

            List<Doctor> doctors = null!;

            switch (command)
            {
                case 1:

                    doctors = pediatricsDoctors;
                    break;

                case 2:
                    doctors = traumatologyDoctors;

                    break;

                case 3:

                    doctors = dentistryDoctors;


                    break;

                default:
                    Console.WriteLine("Unknown command");
                    Console.ReadKey(false);
                    continue;
            }


            while (true)
            {
                Console.Clear();
                foreach (var doctor in doctors)
                    Console.WriteLine(doctor);

                Console.WriteLine("Choose the doctor and enter his/her fullname");
                doctorFullname = Console.ReadLine()!;

                foreach (var doctor in doctors)
                {
                    if (doctor?.Name?.ToLower() == doctorFullname.Split()[0].ToLower() && doctor?.Surname?.ToLower() == doctorFullname.Split()[1].ToLower())
                    {
                        currentDoctor = doctor;
                        break;
                    }
                }

                if (currentDoctor is null)
                {
                    Console.WriteLine("Such doctor not found please enter correct information");
                    Console.ReadKey(false);
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentDoctor);

                foreach (var receptionTime in currentDoctor.ReceptionTimes)
                {
                    if(receptionTime.Reserver is null)
                        hasFreeTime = true;
                }

                if(!hasFreeTime)
                {
                    Console.WriteLine("Doctor has not free time please choose another one");
                    Console.ReadKey(false);
                    break;
                }

                foreach (var receptionTime in currentDoctor.ReceptionTimes)
                    Console.WriteLine(receptionTime);

                Console.WriteLine("Choose the reception time");
                time = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(time) || time.Length != 11)
                {
                    Console.WriteLine("Entered wrong information");
                    Console.ReadKey(false);
                    continue;
                }



                for (int i = 0; i < currentDoctor.ReceptionTimes.Count; i++)
                {
                    if (currentDoctor.ReceptionTimes[i].Time == time)
                    {
                        if (currentDoctor.ReceptionTimes[i].Reserver is null)
                        {
                            ReceptionTime temp = currentDoctor.ReceptionTimes[i];
                            temp.Reserver = user;
                            currentDoctor.ReceptionTimes[i] = temp;
                            isReserved = true;
                            Console.WriteLine("Reserved succesfully");
                            Console.ReadKey(false);
                        }
                        else
                        {
                            Console.WriteLine("This time is reserved please choose another one");
                            Console.ReadKey(false);
                        }
                        break;
                    }
                }

                if (isReserved)
                    break;
            }
        }
    }
}