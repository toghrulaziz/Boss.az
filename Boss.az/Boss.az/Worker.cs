using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    internal class Worker
    {
        public int Id { get; set; }
        public static int StaticId = 1;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public CV CV { get; set; }
        public string? Password { get; set; }



        public Worker()
        {
            Id = StaticId++;
        }


        public Worker(string? name,string? surname,string? city,string? phone,int age,string? password,CV? cv = null)
        {
            Id = StaticId++;
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
            CV = cv;
            Password = password;
        }

        public static Worker AddWorker()
        {
            string? name, surname, city, phone,password;
            int age;

            Console.WriteLine("Insert your Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Insert your Surname: ");
            surname = Console.ReadLine();

            Console.WriteLine("Insert your City: ");
            city = Console.ReadLine();

            Console.WriteLine("Insert your Phone: ");
            phone = Console.ReadLine();

            Console.WriteLine("Insert your Age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert your Password: ");
            password = Console.ReadLine();

            Worker worker = new(name,surname,city,phone,age,password);

            return worker;

        }


        public void Show()
        {
            Console.WriteLine($"Id: {Id} \nName: {Name} \nSurname: {Surname} \nCity: {City} \nPhone: {Phone} \nAge: {Age}\n");
            CV.Show();
        }

        public override string ToString()
        {
            return $"Id: {Id} \nName: {Name} \nSurname: {Surname} \nCity: {City} \nPhone: {Phone} \nAge: {Age}";
        }

    }
}
