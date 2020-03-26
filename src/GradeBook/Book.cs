using System;
using System.Collections.Generic;

namespace GradeBook
{
    [Serializable]
    class InvalideGradeException:Exception{
        public InvalideGradeException(){

        }

        public InvalideGradeException(string grade)
        :base(String.Format($"GRADE: {grade} IS OUT OF RANGE (1-100)"))
        {

        }
    }
    class Book
    {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade>0 && grade <100){
                grades.Add(grade);
            }
            else{
                throw new InvalideGradeException(grade.ToString());
            }
        }

        public (double, double, double) ComputeGrades(){
            
            var sum=0.0;
            double average;
            var highestGrade = double.MaxValue;
            var lowestGrade = double.MinValue;
            foreach(var number in this.grades)
            {
                sum+=number;
                lowestGrade = Math.Max(number, lowestGrade);
                highestGrade = Math.Min(number, highestGrade);

            }
            average = sum/this.grades.Count;

            return (average, lowestGrade, highestGrade);
        }

        public void DisplayStatistics()
        {
            var (average, lowest, highest)= this.ComputeGrades();
            System.Console.WriteLine($"The average grade is {average:N1}");
            System.Console.WriteLine($"The lowest grade is {lowest:N1}");
            System.Console.WriteLine($"The highest grade is {highest:N1}");
        }
    }
}