using Boss.az;
using System.Text.Json;

List<Worker> workers = new();

List<Employer> employers = new() {};

List<Vacancy> vacancies = new();


//////////////////////////////////////////////////////////////

// Liste elave edir (Employer)
void AddToEmployerList(string? name, string? surname, string? city, string? phone, int age,string? password)
{
    Employer e = new() { Name = name, Surname = surname, City = city, Phone = phone, Age = age, Password = password};
    employers.Add(e);
}

// Listden file-a yazir (Employer)
void WriteToFileFromListForEmployer(List<Employer> employers)
{
    var json = JsonSerializer.Serialize(employers);
    File.WriteAllText("Employers.json", json);
}

// File-dan oxuyub liste yazir ve return edir (Employer)
List<Employer> ReadFromFileToListForEmployer()
{
    var json = File.ReadAllText("Employers.json");
    employers = JsonSerializer.Deserialize<List<Employer>>(json);

    return employers;
}


AddToEmployerList("Elon", "Musk", "Baku", "778889988", 45,"1234");
AddToEmployerList("Bill", "Gates", "Baku", "556667788", 54,"1234");

WriteToFileFromListForEmployer(employers);




/////////////////////////////////////////////////////////////////////////


// Liste elave edir (Worker)
void AddToWorkerList(string? name, string? surname, string? city, string? phone, int age,string? password)
{
    Worker w = new() { Name = name, Surname = surname, City = city, Phone = phone, Age = age ,Password = password};
    workers.Add(w);
}

// Listden file-a yazir (Worker)
void WriteToFileFromListForWorker(List<Worker> workers)
{
    var json = JsonSerializer.Serialize(workers);
    File.WriteAllText("Workers.json", json);
}


// File-dan oxuyub liste yazir ve return edir (Worker)
List<Worker> ReadFromFileToListForWorker()
{
    var json = File.ReadAllText("Workers.json");
    workers = JsonSerializer.Deserialize<List<Worker>>(json);

    return workers;
}

AddToWorkerList("Toghrul", "Azizli", "Baku", "773780123", 18,"1234");
AddToWorkerList("Hakuna", "Matata", "Baku", "554443322", 42,"1234");

WriteToFileFromListForWorker(workers);




////////////////////////////////////////////////////////////////////////////////


// Liste elave edir (Vacancies)
void AddToVacanciesList(string? title, string? name, double salary, int experiance, int maxAge,string? worktype)
{
    Vacancy v = new() { Title = title,Name = name,Salary = salary,Experience = experiance,MaxAge = maxAge,WorkType = worktype };
    vacancies.Add(v);
}


// Listden file-a yazir (Worker)
void WriteToFileFromListForVacancy(List<Vacancy> vacancies)
{
    var json = JsonSerializer.Serialize(vacancies);
    File.WriteAllText("Vacancies.json", json);
}



// File-dan oxuyub liste yazir ve return edir (Worker)
List<Vacancy> ReadFromFileToListForVacancies()
{
    var json = File.ReadAllText("Vacancies.json");
    vacancies = JsonSerializer.Deserialize<List<Vacancy>>(json);

    return vacancies;
}



AddToVacanciesList("title1", "vacancy1", 1500, 3, 50, "Freelance");
AddToVacanciesList("title2", "vacancy2", 2000, 4, 55, "Remoute");
AddToVacanciesList("title3", "vacancy3", 3000, 5, 40, "Part Time");
AddToVacanciesList("title4", "vacancy4", 3500, 6, 45, "Full Time");

WriteToFileFromListForVacancy(vacancies);



///////////////////////////////////////////////////////////////////


Employer GetEmployerFromList(string? empname, string? emppassword)
{
    foreach (var item in employers)
    {
        if (item.Name == empname && item.Password == emppassword)
        {
            return item;
        }
    }
    return null;
}

Worker GetWorkerFromList(string? workername, string? workerpassword)
{
    foreach (var item in workers)
    {
        if (item.Name == workername && item.Password == workerpassword)
        {
            return item;
        }
    }
    return null;
}

///////////////////////////////////////////////////////////////////


bool EmployerIsExistInList(string? empname, string? emppassword)
{
    foreach (var item in employers)
    {
        if (item.Name == empname && item.Password == emppassword)
        {
            return true;
        }
    }
    return false;
}

bool WorkersIsExistInList(string? workername, string? workerpassword)
{
    foreach (var item in workers)
    {
        if (item.Name == workername && item.Password == workerpassword)
        {
            return true;
        }
    }
    return false;
}

///////////////////////////////////////////////////////////////////////

int IDgetter()
{
    Console.WriteLine("Insert Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    return id;
}




void ShowAnyVacancyList(List<Vacancy> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}


void FilterVacancies()
{
    List<Vacancy> vacanciesForFilter = vacancies;

    bool exit = false;

    while (!exit)
    {
        try
        {
            int choice;
            Console.WriteLine("1.FilterVacancieByAge \n2.FilterVacancieByName \n3.FilterVacancieByExperience \n4.FilterVacancieBySalary \n5.FilterVacancieByWorkType \n6.Exit\n");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    sbyte maxAge;
                    Console.WriteLine("Insert maximum age: ");
                    maxAge = Convert.ToSByte(Console.ReadLine());
                    vacanciesForFilter = Filter.FilterVacancieByAge(vacanciesForFilter, maxAge);
                    Console.Clear();
                    break;
                case 2:
                    string? jobName;
                    Console.WriteLine("Insert Job name: ");
                    jobName = Console.ReadLine();
                    vacanciesForFilter = Filter.FilterVacancieByName(vacanciesForFilter, jobName);
                    break;
                case 3:
                    sbyte experience;
                    Console.WriteLine("Insert minumum experience: ");
                    experience = Convert.ToSByte(Console.ReadLine());
                    vacanciesForFilter = Filter.FilterVacancieByExperience(vacanciesForFilter, experience);
                    break;
                case 4:
                    double minSalary;
                    Console.WriteLine("Insert minumum Salary: ");
                    minSalary = Convert.ToDouble(Console.ReadLine());
                    vacanciesForFilter = Filter.FilterVacancieBySalary(vacanciesForFilter, minSalary);
                    break;

                case 5:
                    string worktype;
                    Console.WriteLine("Insert Work Type: ");
                    worktype = Console.ReadLine();
                    vacanciesForFilter = Filter.FilterVacancieByWorkType(vacanciesForFilter, worktype);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Choose one of them!");
                    Thread.Sleep(1000);
                    continue;
            }

            Console.Clear();
            Console.WriteLine();
            ShowAnyVacancyList(vacanciesForFilter);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            continue;
        }
    }
}



void EditNotifications(Employer Item)
{
    int ch2;
    while (true)
    {
        Console.Clear();
        Item.ShowAllNotifications();
        Console.WriteLine("1.Delete Notification(ID) \n2.Accept Notification(ID) \n3.Reject Notification(ID) \n4.Exit\n");
        ch2 = Convert.ToInt32(Console.ReadLine());

        if (ch2 == 1)
        {
            Console.Clear();
            Item.ShowAllNotifications();
            Item.DeleteNotification(IDgetter());
            Console.ReadKey();
            Console.Clear();
        }
        else if (ch2 == 2)
        {
            Console.Clear();
            Item.ShowAllNotifications();
            Item.AcceptNotification(IDgetter());
            Console.ReadKey();
            Console.Clear();
        }
        else if (ch2 == 3)
        {
            Console.Clear();
            Item.ShowAllNotifications();
            Item.RejectNotification(IDgetter());
            Console.ReadKey();
            Console.Clear();
        }
        else if (ch2 == 4) break;
        else
        {
            ElseFunction();
            continue;
        }
    }
}

void Apply(string? content, Worker worker)
{
    int id;
    Console.WriteLine("Id:");
    id = Convert.ToInt32(Console.ReadLine());

    foreach (var item in employers)
    {
        foreach (var vacancy in item.Vacancies)
        {
            if (vacancy.Id == id)
            {
                item.Notifications.Add(new Notification(content, worker, vacancy));
            }
        }
    }
}



List<CV> GetCVsFromAllNotification(Employer employer)
{
    List<CV> cvs = new();

    foreach (var item in employer.Notifications)
    {
        cvs.Add(item.Worker.CV);
    }
    return cvs;
}

void ElseFunction()
{
    Console.WriteLine("Choose one of them!");
    Console.ReadKey();
    Console.Clear();
}


//////////////////////////////////////////////////////////////////////////

while (true)
{
    int ch2;
    Console.WriteLine("1. Employer \n2. Worker \n3. Exit");
    ch2 = Convert.ToInt32(Console.ReadLine());

    //employer

    if (ch2 == 1)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("1. Sign up \n2. Sign in\n3. Exit\n");

            ch2 = Convert.ToInt32(Console.ReadLine());

            if (ch2 == 1)
            {
                employers.Add(Employer.CreateEmployer());
                continue;
            }

            else if (ch2 == 2)
            {
                string name, password;
                Console.WriteLine("Insert name: ");
                name = Console.ReadLine();

                Console.WriteLine("Insert password: ");
                password = Console.ReadLine();

                if (EmployerIsExistInList(name, password))
                {
                    Employer Item = GetEmployerFromList(name, password);
                    while (true)
                    {
                        Console.WriteLine("1.Show all vacancies\n 2.Show all Notifications \n3.Exit\n");
                        ch2 = Convert.ToInt32(Console.ReadLine());

                        if (ch2 == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("1.Add Vacancy\n 2.Delete Vacancy\n 3.Exit\n");
                            ch2 = Convert.ToInt32(Console.ReadLine());

                            if (ch2 == 1)
                            {
                                Console.Clear();
                                Item.AddVacancy(Vacancy.CreateVacancy());
                                Console.WriteLine("Vacancy added succesfully!");
                            }
                            else if (ch2 == 2)
                            {
                                Console.Clear();
                                int id;
                                Console.WriteLine("Insert id:");
                                id = Convert.ToInt32(Console.ReadLine());
                                Item.DeleteVacancy(id);
                                Console.WriteLine("Vacancy deleted succesfully!");
                                Console.ReadKey();
                            }
                            else if (ch2 == 3) break;
                            else
                            {
                                Console.WriteLine("Choose one of them!");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }

                        else if (ch2 == 2)
                        {
                            Console.Clear();
                            Item.ShowAllNotifications();
                            EditNotifications(Item);
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (ch2 == 3) break;

                        else
                        {
                            ElseFunction();
                            continue;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Employer isnt exist!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }

            else if (ch2 == 3) break;

            else
            {
                ElseFunction();
                continue;
            }
        }
    }

    //worker

    else if (ch2 == 2)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Sign up \n2. Sign in\n 3. Exit\n");
            ch2 = Convert.ToInt32(Console.ReadLine());

            if (ch2 == 1)
            {
                workers.Add(Worker.AddWorker());
                continue;
            }

            else if (ch2 == 2)
            {
                string name, password;
                Console.WriteLine("Insert name: ");
                name = Console.ReadLine();

                Console.WriteLine("Insert password: ");
                password = Console.ReadLine();

                if (WorkersIsExistInList(name, password))
                {
                    Worker worker = GetWorkerFromList(name, password);

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Create CV \n2. Show All Vacancies \n3. Filter vacancies\n 4. Apply Work\n 5. Exit:");
                        ch2 = Convert.ToInt32(Console.ReadLine());

                        if (ch2 == 1)
                        {
                            worker.CV = CV.CreateCv();
                            Console.WriteLine("CV created succesfully!");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (ch2 == 2)
                        {
                            foreach (var item in vacancies)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        else if (ch2 == 3)
                        {
                            FilterVacancies();
                            Console.ReadKey();
                            continue;
                        }

                        else if (ch2 == 4)
                        {
                            Console.WriteLine("Insert content:");
                            string? content = Console.ReadLine();
                            Apply(content, worker);
                            Console.WriteLine("Applied succesfully");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (ch2 == 5) break;

                        else
                        {
                            Console.WriteLine("Choose one of them!");
                            Console.ReadKey();
                            continue;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Worker cant found !");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
            }
            else if (ch2 == 3) break;

            else continue;
        }
    }
    //Exit

    else if (ch2 == 3) break;

    else
    {
        ElseFunction();
        continue;
    }
}
