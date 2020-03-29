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

    public delegate void GradeAddedDelegate(object sender, GradeAddedArgs args);

    public class GradeAddedArgs : EventArgs{
        public GradeAddedArgs(string s){
            message = s;
        }
        private string message;
        public string Message{
            get{return message;}
        }
    }

    public class NamedObject
    {
        public string Name
        {
            get;
            set;
        }
    }
    public class Book : NamedObject
    {
        private List<double> grades;
        readonly string category = "Science";

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
            category = "";
        }

        public Book(string name, string category)
        {
            grades = new List<double>();
            Name = name;
            this.category = category;
        }

        public event GradeAddedDelegate GradeAdded;

        public void AddGrade(double grade)
        {
            if(grade>=0 && grade<=100)
            {
                grades.Add(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new GradeAddedArgs(grade.ToString()));
                }
            }
            else{
                throw new InvalideGradeException(nameof(grade), grade.ToString());
            }
        }

        public (double, double, double, char, string) ComputeGrades()
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
            return (average, lowestGrade, highestGrade, letter, Name);
        }

        public void DisplayStatistics()
        {
           
            var (average, lowest, highest, letter, name)= this.ComputeGrades();
            Console.WriteLine($"For the Book {name}");
            Console.WriteLine($"The lowest grade is {lowest:N1}");
            Console.WriteLine($"The highest grade is {highest:N1}");
            Console.WriteLine($"The average grade is {average:N1}");
            Console.WriteLine($"The Letter grade is {letter}");
        }
    }
}