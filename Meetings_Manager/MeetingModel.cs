using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meetings_Manager.Classes;
using Meetings_Manager.Enums;

namespace Meetings_Manager
{
    public class MeetingModel
    {
        public List<Participants> Participant { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public MeetingType MeetingType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public List<string> Meetings { get; set; }

        public MeetingModel() { }

        public MeetingModel(List<Participants> participant, string responsiblePerson, string description, Category category, MeetingType meetingType, DateTime startDate, DateTime endDate) 
        {
         Participant = participant;
            ResponsiblePerson = responsiblePerson;
            Description = description;
            Category = category;
            MeetingType = meetingType;
            StartDate = startDate;
            EndDate = endDate;

              
        } 

    }
}
