using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    internal class Vacancy
    {
        public int Id { get; set; }
        public static int StaticId = 1;
        public Employer? FromEmployer { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }
        public int MaxAge { get; set; }
        public string? WorkType { get; set; }


        public Vacancy()
        {
            Id = StaticId++;
        }


        public Vacancy(string? title,string? name,double salary,int experience,int maxage,string? worktype)
        {
            Id = StaticId++;
            Title = title;
            Name = name;
            Salary = salary;
            Experience = experience;
            MaxAge = maxage;
            WorkType = worktype;
            FromEmployer = null;
        }


        public static Vacancy CreateVacancy()
        {
            string? title, name, worktype;
            double salary;
            int experience,maxage;

            Console.WriteLine("Insert Title: ");
            title = Console.ReadLine();

            Console.WriteLine("Insert Job name: ");
            name = Console.ReadLine();

            Console.WriteLine("Insert Job Work Type: ");
            worktype = Console.ReadLine();

            Console.WriteLine("Insert Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insert Min Experience: ");
            experience = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert Max Age: ");
            maxage = Convert.ToInt32(Console.ReadLine());

            return new(title,name,salary,experience,maxage,worktype);
        }


        public override string ToString()
        {
            return $"Id: {Id} \nFrom Employer: {FromEmployer} \nTitle: {Title} \nName: {Name} \nSalary: {Salary} \nExperience: {Experience} \nMax Age: {MaxAge} \nWork Type: {WorkType}\n";
        }
    }
}
