using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool weight) : base(name,weight)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var number = Students.Count/5;
            var sortedGrade = Students.OrderByDescending(x=>x.AverageGrade).Select(x=>x.AverageGrade).ToList();
            if(averageGrade>=sortedGrade[ number-1 ])
            {
                return 'A';
            }
            if(averageGrade>=sortedGrade[ 2*number -1 ])
            {
                return 'B';
            }
            if(averageGrade>=sortedGrade[ 3*number -1 ])
            {
               return 'C';
            }
            if(averageGrade>=sortedGrade[ 4*number -1 ])
            {    
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");;
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }

}