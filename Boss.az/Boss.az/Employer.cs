using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    internal class Employer
    {
        public int Id { get; set; }
        public static int StaticId = 1;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public string? Password { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public List<Notification> Notifications { get; set; }


        public Employer()
        {
            Id = StaticId++;
        }

        public Employer(string? name, string? surname,string? city,string? phone,int age,string? password)
        {
            Id = StaticId++;
            Name = name;   
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
            Vacancies = new();
            Notifications = new();
            Password = password;
        }


        public static Employer CreateEmployer()
        {
            string? name,surname,city,phone, password;
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

            Console.WriteLine("Insert your password: ");
            password = Console.ReadLine();

            Employer employer = new(name,surname,city,phone,age,password);
            

            return employer;
        }


        public void Show()
        {
            Console.WriteLine($"Id: {Id} \nName: {Name} \nSurname: {Surname} \nCity: {City} \nPhone: {Phone} \nAge: {Age}\n");

            foreach (var item in Vacancies)
            {
                Console.WriteLine(item);
            }
        }


        // Notification
        public void AcceptNotification(int id)
        {
            foreach (var item in Notifications)
            {
                if (item.Id == id)
                {
                    item.AcceptOrNot = true;
                    Console.WriteLine("Worker accepted!");
                    Thread.Sleep(200);
                    Notifications.Remove(item);
                }
            }
        }


        public void RejectNotification(int id)
        {
            foreach (var item in Notifications)
            {
                if (item.Id == id)
                {
                    item.AcceptOrNot = false;
                    Console.WriteLine("Worker rejected!");
                    Thread.Sleep(200);
                    Notifications.Remove(item);
                }
            }
        }


        public void DeleteNotification(int id)
        {
            foreach (var item in Notifications)
            {
                if (item.Id == id)
                {
                    Notifications.Remove(item);
                    Console.WriteLine("Notification deleted Succesfully!");
                }
            }
        }


        public void ShowAllNotifications()
        {
            foreach (var item in Notifications)
            {
                Console.WriteLine(item);
            }
        }

        // Vacancies

        public void AddVacancy(Vacancy vacancy) { Vacancies.Add(vacancy); }


        public void DeleteVacancy(int id)
        {
            foreach (var item in Vacancies)
            {
                if (item.Id == id)
                {
                    Vacancies.Remove(item);
                }
            }
        }


        public void ShowVacancies()
        {
            foreach (var item in Vacancies)
            {
                Console.WriteLine(item);
            }
        }


        public override string ToString()
        {
            return $"{Name} {Surname} {City} {Phone} {Age}";
        }


    }
}
