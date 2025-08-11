
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Transactions;
using MySqlConnector;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
///<summary>
///A method to output "Hello"!
///</summary>
///<return></return>

#region
class FirstClass
{
    public int x1;
    public int x2;
    public int x3;
    public int x4;
    public int x5;
    public int x6;

    public void Method1() { }
    public void Method2() { }
    public void Method3() { }
    public void Method4() { }
    public void Method5() { }

}
#endregion

#region
class SecondClass
{
    public int x1;
    public int x2;
    public int x3;
    public int x4;
    public int x5;
    public int x6;

    public void Method1() { }
    public void Method2() { }
    public void Method3() { }
    public void Method4() { }
    public void Method5() { }

}
#endregion

//public class Connection : IDisposable
//{
//    protected string conLine { get; set; }
//    public SqlConnection con { get; set; }

//    public Connection()
//    {
//        //conLine = "SERVER =127.0.0.1 ; port = 3306; datasource = localhost; username = root; database = account_project;";
//        //conLine = "Server=localhost;Port=3306;Database=project;Uid=root;Pwd=;";
//        conLine = "Server=localhost\\SQLEXPRESS;Database=MyFirstDB;Trusted_Connection=True;TrustServerCertificate=True;";
//        con = new SqlConnection(conLine);
//    }

//    public void OpenConnection()
//    {
//        if (con.State != System.Data.ConnectionState.Open)
//        {
//            con.Open();
//        }
//    }

//    public void CloseConnection()
//    {
//        if (con.State != System.Data.ConnectionState.Closed)
//        {
//            con.Close();
//        }
//    }

//    public void Dispose()
//    {
//        //throw new NotImplementedException();
//        if (con.State != System.Data.ConnectionState.Closed)
//        {
//            con.Close();
//        }
//    }
//}

public class Student
{
    public int idStudent { get; set; }

    public string? firstName { get; set; }
    public string? secondName { get; set; }

    public int age { get; set; }

    public List<StudentCourse>? sc_S { get; set; } = new();

}

public class Course
{ 
    public int idCourse { get; set; }
    public string? nameCourse { get; set; }
    public string? teacherName { get; set; }
    public bool mark { get; set; }
    public List<StudentCourse>? sc_C { get; set; } = new();

}

public class StudentCourse
{
    public Student? stdnts { get; set; } = new();
    public Course? crs { get; set; } = new();

    public int sc_idS { get; set; }
    public int sc_idC { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Student> students { get; set; }
    public DbSet<Course> courses { get; set; }
    public DbSet<StudentCourse> studentsCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=MyFirstDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(x => x.idStudent);
        modelBuilder.Entity<Course>().HasKey(x => x.idCourse);

        modelBuilder.Entity<StudentCourse>().HasKey(x => new {x.sc_idC, x.sc_idS});

        modelBuilder.Entity<StudentCourse>()
            .HasOne(x => x.crs)
            .WithMany(x => x.sc_C)
            .HasForeignKey(x => x.sc_idC)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourse>()
            .HasOne(x => x.stdnts)
            .WithMany(x => x.sc_S)
            .HasForeignKey(x => x.sc_idS)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
class Human
{
    public int age { get; set; }
    public string? name { get; set; }
    public char ch { get; set; }
    public bool truth { get; set; }
}
internal class Program
{
    static string Check<T>(T a) where T : class =>
        $"result: {a.GetType()}";
    //delegate, function, event, funcs in linq


    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            //context.studentsCourses.Add(new StudentCourse()
            //{
            //    crs = new Course()
            //    {
            //        nameCourse = "Physics",
            //        teacherName = "James Burkie",
            //        mark = false
            //    },

            //    stdnts = new Student()
            //    {
            //        firstName = "Clark",
            //        secondName = "Davies",
            //        age = 21,
            //    }
            //});

            //context.students.Add(new Student()
            //{
            //    firstName = "Michael",
            //    secondName = "Stephenson",
            //    age = 21,
            //    sc_S = new List<StudentCourse>()
            //    {
            //        new StudentCourse()
            //        {
            //            crs = new Course()
            //            {
            //                nameCourse = "Math",
            //                teacherName = "Matthiew Broadth",
            //                mark = true
            //            },
            //        },

            //        new StudentCourse()
            //        {
            //            crs = new Course()
            //            {
            //                nameCourse = "IT",
            //                teacherName = "Lydia Kostushko",
            //                mark = false
            //            },
            //        },

            //        new StudentCourse()
            //        {
            //            crs = new Course()
            //            {
            //                nameCourse = "PE",
            //                teacherName = "Charles Matt",
            //                mark = false
            //            },
            //        }
            //    }
            //});


            //context.courses.Add(new Course()
            //{
            //    nameCourse = "Chemistry",
            //    teacherName = "Jacob Malone",
            //    mark = true,
            //    sc_C = new List<StudentCourse>()
            //    {
            //        new StudentCourse()
            //        {
            //            stdnts = new Student()
            //            {
            //                firstName = "Mark",
            //                secondName = "Jamestown",
            //                age = 24
            //            }
            //        },

            //        new StudentCourse()
            //        {
            //            stdnts = new Student()
            //            {
            //                firstName = "Daniel",
            //                secondName = "Spark",
            //                age = 33
            //            }
            //        },

            //        new StudentCourse()
            //        {
            //            stdnts = new Student()
            //            {
            //                firstName = "Karlie",
            //                secondName = "Suddie",
            //                age = 21
            //            }
            //        }
            //    },
            //});


            //context.SaveChanges();

            //if(context.studentsCourses.Any()) Console.WriteLine("Success!");
        }

        Console.WriteLine("Happy birthday!");
        Human hn = new Human()
        {
            name = "Nicolas",
            age = 22,
            ch = 'a',
            truth = false
        };

        Console.WriteLine($"{hn.name}, {hn.age}, {hn.ch}, {hn.truth}, is all about {hn.name}");
        Console.ReadLine();
    }
}