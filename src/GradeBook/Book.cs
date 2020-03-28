using System;
using System.Collections.Generic;

namespace GradeBook
{
    [Serializable]
    class InvalideGradeException:Exception{
        public InvalideGradeException(){

        }

        public InvalideGradeException(string var_name, string grade)
        :base(String.Format($"{var_name}: {grade} IS OUT OF RANGE. ALLOWED RANGE: (1-100)"))
        {

        }
    }
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }
        public void AddGrade(double grade)
        {
            if(grade>=0 && grade<=100)
            {
                grades.Add(grade);
            }
            else{
                throw new InvalideGradeException(nameof(grade), grade.ToString());
            }
        }

        public (double, double, double, char) ComputeGrades()
        {
            
            var sum=0.0;
            double average;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;
            foreach(var number in this.grades)
            {
                sum+=number;
                lowestGrade = Math.Min(number, lowestGrade);
                highestGrade = Math.Max(number, highestGrade);

            }
            average = sum/this.grades.Count;
            char letter = ' ';
            switch(average)
            {
                case var d when d >=90.0:
                    letter = 'A';
                    break;
                case var d when d >=80.0:
                    letter = 'B';
                    break;
                case var d when d >=70.0:
                    letter = 'C';
                    break;
                case var d when d >=60.0:
                    letter = 'D';
                    break;
                default:
                    letter = 'F';
                    break;

            }
            return (average, lowestGrade, highestGrade, letter);
        }

        public void DisplayStatistics()
        {
            var (average, lowest, highest, letter)= this.ComputeGrades();
            System.Console.WriteLine($"The average grade is {average:N1}");
            System.Console.WriteLine($"The lowest grade is {lowest:N1}");
            System.Console.WriteLine($"The highest grade is {highest:N1}");
            System.Console.WriteLine($"The Letter grade is {letter}");
        }
    }
}