using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.az
{
    internal class Filter
    {
        //For Workers

        public static List<Vacancy> FilterVacancieByAge(List<Vacancy> vacancies, sbyte maxAge)
        {
            List<Vacancy> filteeredList = new();
            filteeredList.AddRange(vacancies.FindAll(v => v.MaxAge <= maxAge));
            return filteeredList;
        }

        public static List<Vacancy> FilterVacancieByName(List<Vacancy> vacancies, string jobName)
        {
            List<Vacancy> filteeredList = new();
            filteeredList.AddRange(vacancies.FindAll(v => v.Name == jobName));
            return filteeredList;
        }

        public static List<Vacancy> FilterVacancieByExperience(List<Vacancy> vacancies, sbyte experience)
        {
            List<Vacancy> filteeredList = new();
            filteeredList.AddRange(vacancies.FindAll(v => v.Experience <= experience));
            return filteeredList;
        }

        public static List<Vacancy> FilterVacancieBySalary(List<Vacancy> vacancies, double minSalary)
        {
            List<Vacancy> filteeredList = new();
            filteeredList.AddRange(vacancies.FindAll(v => v.Salary >= minSalary));
            return filteeredList;
        }

        public static List<Vacancy> FilterVacancieByWorkType(List<Vacancy> vacancies, string wt)
        {
            List<Vacancy> filteeredList = new();
            filteeredList.AddRange(vacancies.FindAll(v => v.WorkType == wt));
            return filteeredList;
        }

        //For Employers

      
        public static List<CV> FilterCVLiStByProffesion(List<CV> cvs, string specialty)
        {
            List<CV> filteredList = new();
            filteredList.AddRange(cvs.FindAll(c => c.Specialty == specialty));
            return filteredList;
        }
    }
}
