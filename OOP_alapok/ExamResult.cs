using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_alapok
{
    public class ExamResult
    {
        string neptunId;
        public string NeptunId
        {
            get => neptunId;
            set
            {
                if(value.Length.Equals(6))
                    neptunId = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        int percent;
        public int Percent
        {
            get => percent;
            set
            {
                if (value >= 0 && value <= 100)
                    percent = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public bool Passed
        {
            get
            {
                if (Percent >= 50)
                    return true;
                else
                    return false;
            }
        }
        public enum Grades
        {
            Jeles,
            Jó,
            Közepes,
            Elégséges,
            Elégtelen
        }
        public Grades Grade(int[] gradelimits)
        {
            if (Percent >= gradelimits[4])
                return Grades.Jeles;
            else if (Percent >= gradelimits[3])
                return Grades.Jó;
            else if (Percent >= gradelimits[2])
                return Grades.Közepes;
            else if (Percent >= gradelimits[1])
                return Grades.Elégséges;
            else
                return Grades.Elégtelen;
        }
        
        public ExamResult(string NeptunId, int Percent)
        {
            this.NeptunId = NeptunId;
            this.Percent = Percent;
        }
        public ExamResult()
        {
            string temp = "";
            char tobeadded;
            while (temp.Length != 6)
            {
                tobeadded = (char)new Random().Next(48, 90 + 1);
                if (char.IsLetter(tobeadded) || char.IsDigit(tobeadded))
                {
                    temp += tobeadded;
                }
            }
            this.NeptunId = temp;
            this.Percent = new Random().Next(0, 101);
        }
    }
}
