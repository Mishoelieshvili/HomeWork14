using static Week14.Controllers.SurveyController;
using System;

namespace Week14.Model
{
    public class Respondent
    { 
            public DateTime CreateDate { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string JobPosition { get; set; }
            public double Salary { get; set; }
            public double WorkExperience { get; set; }
            public Address PersonAddress { get; set; }
            public int Id { get; set; }
    }
}
