using Online_Platform.Models.BusinessLogic;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Online_Platform.ViewModels
{
    class StudentVM: INotifyPropertyChanged
    {
        public StudentBusinessLogic studentBL { get; set; }
        public List<string> MarksList { get; set; }
        public List<string> AbsenteesList { get; set; }
        public List<string> FinalMarkList { get; set; }
        public List<string> SubjectMaterialsList { get; set; }

        public StudentVM()
        {
            studentBL = new StudentBusinessLogic();
            MarksList = new List<string>();
            foreach(var list in studentBL.subject_marks.Values.ToList())
            {
                string grades_subject = null;
                foreach (var elem in list)
                    grades_subject += elem.Grade +", ";
               MarksList.Add(grades_subject);
            }
            AbsenteesList = new List<string>();
            foreach(var list in studentBL.subject_absentees.Values.ToList())
            {
                var absentees = new List<string>();
                foreach (var elem in list)
                {
                    string[] date = elem.Absentee_Date.ToString().Split(' ');
                    absentees.Add(elem.Is_Motivated ? date[0] + 'M' : date[0] + 'N');
                }
                AbsenteesList.Add(string.Join(", ", absentees));
            }
            FinalMarkList = new List<string>();
            foreach(var elem in studentBL.subject_final_mark.Values.ToList())
            {
                FinalMarkList.Add(elem.ToString());
            }
            SubjectMaterialsList = new List<string>();
            foreach(var elem in studentBL.subjects.ToList())
            {
                SubjectMaterialsList.Add(elem.Materials.ToString());
            }
            studentBL.general_mark = studentBL.subject_final_mark.Values.Sum() / FinalMarkList.Count;

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
