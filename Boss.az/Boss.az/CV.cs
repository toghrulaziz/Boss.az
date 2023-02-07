using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    internal class CV
    {
        public string? Specialty { get; set; }
        public string? University { get; set; }
        public double UniScore { get; set; }
        public string[]? Skills { get; set; }
        public string[]? Companies { get; set; }
        public List<Language>? Languages { get; set; }
        public bool HonorsDiploma { get; set; }
        public string? GitLink { get; set; }
        public string? Linkedln { get; set; }


        public CV(string? specialty,string? university,double uniscore, string[]? skills, string[]? companies,List<Language> languages,bool honorsdiploma,string? gitlink,string? linkedln)
        {
            Specialty = specialty;
            University = university;
            UniScore = uniscore;
            Skills = skills;
            Companies = companies;
            Languages = languages;
            HonorsDiploma = honorsdiploma;
            GitLink = gitlink;
            Linkedln = linkedln;
        }


        public static CV CreateCv()
        {
            string? specialty, university, gitlink, linkedln;
            double uniscore;
            string[]? skills, companies;
            bool honorsdiploma;
            List<Language> languages = default;

            Console.WriteLine("Insert your specialty: ");
            specialty = Console.ReadLine();

            Console.WriteLine("Insert your university: ");
            university = Console.ReadLine();

            Console.WriteLine("Insert your Git Link: ");
            gitlink = Console.ReadLine();

            Console.WriteLine("Insert your Linkedln: ");
            linkedln = Console.ReadLine();

            Console.WriteLine("Insert your University score: ");
            uniscore = Convert.ToDouble(Console.ReadLine());

            Console.Write("Do you have Honors diploma from university(yes=1 no=0) ?");
            honorsdiploma = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Insert your skills (use | for split):");
            skills = Console.ReadLine().Split('|');


            Console.WriteLine("Insert your worked companies (use | for split):");
            companies = Console.ReadLine().Split('|');


            int languagecount = default;

            Console.Write("Insert amount of languages:");
            languagecount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < languagecount; i++)
            {
                Language l = Language.CreateLanguage();
                languages.Add(l);
            }


            return new(specialty, university, uniscore, skills, companies, languages, honorsdiploma, gitlink, linkedln);
        }


        public void Show()
        {
            Console.WriteLine("******** CV ********");
            Console.WriteLine($"Specialty: {Specialty} \nUniversity: {University} \nUniversity Score: {UniScore} \nHonors Diploma: {HonorsDiploma} \nGit Link: {GitLink} \nLinkedln: {Linkedln}\n");

            Console.WriteLine("Skills:");
            foreach (var item in Skills)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Companies:");
            foreach (var item in Companies)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Languages:");
            foreach (var item in Languages)
            {
                Console.WriteLine(item);
            }
        }


    }

    class Language
    {
        public string? Name { get; set; }
        public string? Level { get; set; }

        public Language(string? name, string? level)
        {
            Name = name;
            Level = level;
        }

        public static Language CreateLanguage()
        {
            string? name, level;

            Console.WriteLine("Insert Language Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Insert Language Level: ");
            level = Console.ReadLine();

            return new(name, level);
        }

        public override string ToString()
        {
            return $"Language Name: {Name} \nLanguage Level: {Level}\n";
        }
    }

}
