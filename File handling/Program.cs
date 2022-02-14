using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
interface IStudent
{
    int ID
    {
        get;
        set;
    }
    string Name
    {
        get;
        set;
    }

    string Email
    {
        get;
        set;
    }

    string Age
    {
        get;
        set;
    }
    string StudentNumber
    {
        get;
        set;
    }

    string Department
    {
        get;
        set;
    }
    string Address
    {
        get;
        set;
    }

    long PhoneNumber
    {
        get;
        set;
    }

    void Display();
}
class Student : IStudent

{
    public string path = @"studentrecord.txt";
    string department;
    public string Department
    {
        get
        {
            return department;
        }

        set
        {
            department = value;
        }
    }

    string email;
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    string name;
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    string studentnumber;
    public string StudentNumber
    {
        get
        {
            return studentnumber;
        }
        set
        {
            studentnumber = value;
        }
    }

    int id;
    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    long phonenumber;
    public long PhoneNumber
    {
        get
        {
            return phonenumber;
        }

        set
        {
            phonenumber = value;
        }
    }

    string age;
    public string Age
    {
        get
        {
            return age;
        }

        set
        {
            age = value;
        }
    }

    string address;
    public string Address
    {
        get
        {
            return address;
        }

        set
        {
            address = value;
        }
    }
    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("StudentNumber: " +
        StudentNumber);
        Console.WriteLine("Department: " + Department);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Address: " + Address);
        Console.WriteLine("PhoneNumber : " +
        PhoneNumber);
        File.WriteAllText(path, Name + "   " +
       StudentNumber + "   " + Department + "   " + Age +
       "   " + Email + "   " + Address + "   " +
       PhoneNumber);
    }
    internal void Remove()
    {
        throw new NotImplementedException();
    }
}
class Program
{
    static Dictionary<int, Student> listDictionary =
    new Dictionary<int, Student>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("------STUDENTS DETAILS------");
            Console.WriteLine("1. Insert new Student       ");
            Console.WriteLine("2. View list of Students    ");
            Console.WriteLine("3. Search Students          ");
            Console.WriteLine("4. Delete Students         ");
            Console.WriteLine("5. Exit                     ");
            Console.WriteLine("----------------------------");
            Console.Write("Your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    InsertStudent();
                    break;
                case 2:
                    ViewList();
                    break;
                case 3:
                    Search();
                    break;
                case 4:
                    Delete();
                    break;

                case 5:
                    return;
            }
        }
    }

    private static void Search()
    {
        bool found = false;
        Console.Write("Enter Department to search: ");
        String search = Console.ReadLine();
        Console.WriteLine("All student of department " + search);
        foreach (Student student in listDictionary.Values)
        {
            if (student.Department.Equals(search))
            {
                Console.WriteLine("----------------------------");
                student.Display();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No students were found!");
        }
    }
    private static void Delete()
    {
        bool found = false;
        Console.Write("Enter StudentNumber to delete: ");
        String delete = Console.ReadLine();
        Console.WriteLine("Deleting the nuumber " + delete);
        foreach (Student ss in listDictionary.Values)
        {
            if (ss.Department.Equals(delete))
            {
                Console.WriteLine("----------------------------");
                ss.Remove();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Deleted sucessfully!");
        }

    }

    private static void ViewList()
    {
        foreach (Student i in listDictionary.Values)
        {
            Console.WriteLine("----------------------------");
            i.Display();
        }
    }

    private static void InsertStudent()
    {
        Student student = new Student();
        student.ID = listDictionary.Count + 1;
        Console.Write("Enter name: ");
        student.Name = Console.ReadLine();
        Console.Write("Enter StudentNumber: ");
        student.StudentNumber = Console.ReadLine();
        Console.Write("Enter Department: ");
        student.Department = Console.ReadLine();
        Console.Write("Enter Age: ");
        student.Age = Console.ReadLine();
        Console.Write("Enter Email: ");
        student.Email = Console.ReadLine();
        Console.Write("Enter Address: ");
        student.Address = Console.ReadLine();
        while (true)
        {
            Console.Write("Enter PhoneNumber: ");
            try
            {
                student.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The number is not in the correct format!");
                Console.WriteLine(ex.Message);
            }
        }

        listDictionary.Add(student.ID, student);
        Console.WriteLine("Successfully inserted a student!");
    }
}




