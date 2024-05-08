using System;
using System.Collections.Generic;

namespace Learning02
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
            Job job2 = new Job("Manager", "Apple", 2022, 2023);

            job1.Display();
            job2.Display();

            Resume myResume = new Resume("Allison Rose");

            myResume.AddJob(job1);
            myResume.AddJob(job2);

            myResume.Display();
        }
    }

    public class Job
    {
        private string _jobTitle;
        private string _company;
        private int _startYear;
        private int _endYear;

        public Job(string jobTitle, string company, int startYear, int endYear)
        {
            _jobTitle = jobTitle;
            _company = company;
            _startYear = startYear;
            _endYear = endYear;
        }

        public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }

    public class Resume
    {
        private string _personName;
        private List<Job> _jobs;

        public Resume(string personName)
        {
            _personName = personName;
            _jobs = new List<Job>();
        }

        public void AddJob(Job job)
        {
            _jobs.Add(job);
        }

        public void Display()
        {
            Console.WriteLine($"Name: {_personName}");
            Console.WriteLine("Jobs:");
            foreach (var job in _jobs)
            {
                job.Display();
            }
        }
    }
}
