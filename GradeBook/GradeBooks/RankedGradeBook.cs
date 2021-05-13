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
        public RankedGradeBook(string name) : base(name)
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
    }
}