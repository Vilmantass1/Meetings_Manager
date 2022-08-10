using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Meetings_Manager.Classes;
using Newtonsoft.Json;
using Meetings_Manager.Enums;

namespace Meetings_Manager
{
    public class Executor : IExecutor
    {
        private readonly string filePath = @"C:\Users\Vilmantas\source\repos\Meetings_Manager\Meetings_Manager\FileFolder\";
        private readonly string fileName = "MeetingData.json";

      
        public async Task Run()

        {
            //await CreateFile();
            //await RemoveLine();
            // await AddPerson();
            //await RemovePerson();
            await MainMeniu();
          //  await ListMeetings();
            //await FilterByDates();

        }

        public async Task MainMeniu()
        {
            while (true)
            {
                
                Console.Clear();
                Console.WriteLine("********************************************");
                Console.WriteLine("*                 Meniu                    *");
                Console.WriteLine("********************************************");
                Console.WriteLine("********************************************");
                Console.WriteLine("*    Create a new meeting - C              *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*    Delete a meeting. - D                 *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*    Add a person to the meeting. - A      *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*    Remove a person from the meeting. - R *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*    List all the meetings. - L            *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*              Close - U                   *");
                Console.WriteLine("********************************************");
                Console.WriteLine("\nYour Choice ?");
                var meniuChoice = Console.ReadLine();

                if (meniuChoice.Trim().ToLower() == "u")
                {
                    Environment.Exit(0);
                }
                else if (meniuChoice.Trim().ToLower() == "c")
                {
                    await CreateFile();
                }
                else if (meniuChoice.Trim().ToLower() == "d")
                {
                    await RemoveLine();
                }
                else if (meniuChoice.Trim().ToLower() == "a")
                {
                    await AddPerson();
                }
                else if (meniuChoice.Trim().ToLower() == "r")
                {
                    await RemovePerson();
                }
                else if (meniuChoice.Trim().ToLower() == "l")
                {
                    await ListMeetingsMeniu();
                }
              
            }
        }

   
        public async Task CreateFile()
        {
            Console.Clear();
            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
            Console.WriteLine("Please Indicate number of people that will participate in the meeting ");

            

            var solved = false;

            while (!solved)
            {
                
                var ParticipantsNo = Console.ReadLine().Trim();
                if (ParticipantsNo == "q") return;


                if (int.TryParse(ParticipantsNo, out var number))
                {
                    Participants[] ParticipantsList = new Participants[number];

                    for (int i = 0; i < ParticipantsList.Length; i++)
                    {
                        
                            
                            Console.Write("Please enter Participant's Name: ");
                            var name = Console.ReadLine().Trim().ToLower();
                            Console.Write("Please enter Participant's Surname: ");
                            var surname = Console.ReadLine().Trim().ToLower();
                            var time = DateTime.Now;

                        var ParticipantInput = new Participants(name, surname, time) { };

                        ParticipantsList[i]=ParticipantInput;
                    }


                    var newParticipantsList = ParticipantsList.ToList();
                    Console.Clear();
                    Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");

                    Console.Write("Please Indicate the Name of Responsible Person: ");
                    var responsiblePerson = Console.ReadLine().Trim().ToLower();
                    if (responsiblePerson == "q") return;

                    Console.Clear();
                    Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                    Console.Write("Please Indicate Description: ");
                    var description = Console.ReadLine().Trim().ToLower();
                    if (description == "q") return;
                    Console.Clear();
                    Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                    Console.WriteLine("Please input Meeting Category. Select form the following: c - CodeMonkey, h - Hub, s - Short, t - TeamBuilding");

                    var categoryInput = Console.ReadLine().Trim().ToLower();
                    if (categoryInput == "q") return;


                    Category categoryEnum;
                    if (categoryInput == "q") return;
                    if (categoryInput == "c")
                    {
                        categoryEnum = Category.CodeMonkey;
                    }

                    else if (categoryInput == "h")
                    {
                        categoryEnum = Category.Hub;
                    }
                    else if (categoryInput == "s")
                    {
                        categoryEnum = Category.Short;
                    }
                    else if (categoryInput == "t")
                    {
                        categoryEnum = Category.TeamBuilding;
                    }
                    else
                    {
                        categoryEnum = Category.Unknown;
                    }

                    Console.Clear();
                    Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                    Console.WriteLine("Please input Meeting Type. Select form the following: l - Live, i - InPerson");

                    var typeInput = Console.ReadLine().Trim().ToLower();



                    MeetingType meetingTypeEnum;
                    if (typeInput == "q") return;
                    if (typeInput == "l")
                    {
                        meetingTypeEnum = MeetingType.Live;
                    }

                    else if (typeInput == "i")
                    {
                        meetingTypeEnum = MeetingType.InPerson;
                    }

                    else
                    {
                        meetingTypeEnum = MeetingType.Unknown;
                    }
               

                    //Start Date validation
                    var error = string.Empty;
                    var dateNotSelected = true;
                    while (dateNotSelected)
                    {
                        Console.Clear();
                        if (!string.IsNullOrEmpty(error))
                        {

                            Console.WriteLine($"{error} \n");

                        }
                        
                        Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                        Console.Write("Please Indicate Start Year: ");
                        var yearStart = Console.ReadLine();
                        var monthStart = 0;
                        var dayStart = 0;
                        var hourStart = 0;
                        var minuteStart = 0;

                        if (yearStart == "q") return;

                        if (int.TryParse(yearStart, out var year))
                        {
                            if (year < DateTime.Now.Year)
                            {
                                error = $"Now it is year {DateTime.Now.Year} Metting cannot start on {year} becase it has already passed";
                                
                                continue;
                            }
                        }
                        else
                        {
                            error = $"Enter Start Year like: 2022, '{yearStart}' is not accepted";
                            
                            continue;
                        }

                        error = string.Empty;
                        var monthNotSelected = true;

                        while (monthNotSelected)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }

                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start Month (number): ");
                            var inputMonthStart = Console.ReadLine();

                            if (inputMonthStart == "q") return;

                            if (int.TryParse(inputMonthStart, out monthStart))
                            {
                                if (monthStart > 12 || monthStart < 1)
                                {
                                    error = $"enter month from 1 to 12... {monthStart} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    monthNotSelected = false;
                                }
                            }
                            else
                            {
                                error = $"enter month in numbers like: 9, '{monthStart}' is not accepted";
                                continue;
                            }
                        }

                        error = string.Empty;
                        var dayNotSelected = true;

                        while (dayNotSelected)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }
                            
                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start Day (number): ");
                            var inputDayStart = Console.ReadLine();

                            if (inputDayStart == "q") return;

                            if (int.TryParse(inputDayStart, out dayStart))
                            {
                                if (dayStart > DateTime.DaysInMonth(year, monthStart) || dayStart < 1)
                                {
                                    error = $"{year}-{monthStart} month has from 1 to {DateTime.DaysInMonth(year, monthStart)} days..., {dayStart} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    dayNotSelected = false;
                                    //startDateNotSelected = false;
                                }
                            }
                            else
                            {
                                error = $"Enter Day in number format, like: 20, '{dayStart}' is not accepted";
                                continue;
                            }
                        }

                        error = string.Empty;
                        var hourNotSelected = true;

                        while (hourNotSelected)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }
                           
                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start hour (number): ");
                            var inputhourStart = Console.ReadLine();

                            if (inputhourStart == "q") return;

                            if (int.TryParse(inputhourStart, out hourStart))
                            {
                                if (hourStart > 23 || hourStart < 0)
                                {
                                    error = $"enter hour from 0 to 23... {hourStart} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    hourNotSelected = false;
                                  
                                }
                            }
                            else
                            {
                                error = $"Enter hour in number format, like: 9, '{hourStart}' is not accepted";
                                continue;
                            }
                        }

                        error = string.Empty;
                        var minuteNotSelected = true;

                        while (minuteNotSelected)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }
                            
                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start minutes (number): ");
                            var inputminuteStart = Console.ReadLine();

                            if (inputminuteStart == "q") return;

                            if (int.TryParse(inputminuteStart, out minuteStart))
                            {
                                if (minuteStart > 59 || minuteStart < 0)
                                {
                                    error = $"enter minutes from 0 to 59... {minuteStart} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    minuteNotSelected = false;
                         

                                }
                            }
                            else
                            {
                                error = $"Enter minutes in number format, like: 9, '{minuteStart}' is not accepted";
                                continue;
                            }
                        }



                        //endDate validation

                        Console.Clear();
                        if (!string.IsNullOrEmpty(error))
                        {

                            Console.WriteLine($"{error} \n");

                        }

                        Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                        Console.Write("Please Indicate Meeting End Year: ");
                        var yearEnd = Console.ReadLine();
                        var monthEnd = 0;
                        var dayEnd = 0;
                        var hourEnd = 0;
                        var minuteEnd = 0;

                        if (yearEnd == "q") return;

                        if (int.TryParse(yearEnd, out var yearE))
                        {
                            if (yearE < year)
                            {
                                error = $"Meeting starts on year {year}, therefore meeting cannot end on {yearE}, as it's earlyer than meeting start year";

                                continue;
                            }
                        }
                        else
                        {
                            error = $"Enter Start Year like: 2022, '{yearEnd}' is not accepted";

                            continue;
                        }

                        error = string.Empty;
                        var monthNotSelectedEnd = true;

                        while (monthNotSelectedEnd)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }

                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter Meeting End Month (number): ");
                            var inputMonthEnd = Console.ReadLine();

                            if (inputMonthEnd == "q") return;

                            if (int.TryParse(inputMonthEnd, out monthEnd))
                            {
                                if (monthEnd > 12 || monthEnd < 1)
                                {
                                    error = $"enter month from 1 to 12... {monthEnd} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    monthNotSelectedEnd = false;
                                }
                            }
                            else
                            {
                                error = $"enter month in numbers like: 9, '{monthEnd}' is not accepted";
                                continue;
                            }
                        }

                        error = string.Empty;
                        var dayNotSelectedEnd = true;

                        while (dayNotSelectedEnd)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }

                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start Day (number): ");
                            var inputDayEnd = Console.ReadLine();

                            if (inputDayEnd == "q") return;

                            if (int.TryParse(inputDayEnd, out dayEnd))
                            {
                                if (dayEnd > DateTime.DaysInMonth(yearE, monthEnd) || dayEnd < 1)
                                {
                                    error = $"{yearE}-{monthEnd} month has from 1 to {DateTime.DaysInMonth(yearE, monthEnd)} days..., {dayEnd} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    dayNotSelectedEnd = false;
                                    //startDateNotSelected = false;
                                }
                            }
                            else
                            {
                                error = $"Enter Day in number format, like: 20, '{dayEnd}' is not accepted";
                                continue;
                            }
                        }

                        error = string.Empty;
                        var hourNotSelectedEnd = true;

                        while (hourNotSelectedEnd)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }

                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start hour (number): ");
                            var inputhourEnd = Console.ReadLine();

                            if (inputhourEnd == "q") return;

                            if (int.TryParse(inputhourEnd, out hourEnd))
                            {
                                if (hourEnd > 23 || hourEnd < 0)
                                {
                                    error = $"enter hour from 0 to 23... {hourEnd} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    hourNotSelectedEnd = false;

                                }
                            }
                            else
                            {
                                error = $"Enter hour in number format, like: 9, '{hourEnd}' is not accepted";
                                continue;
                            }
                        }

                        error = string.Empty;
                        var minuteNotSelectedEnd = true;

                        while (minuteNotSelectedEnd)
                        {
                            Console.Clear();

                            if (!string.IsNullOrEmpty(error))
                            {

                                Console.WriteLine($"{error} \n");

                            }

                            Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                            Console.Write("Enter meeting start minutes (number): ");
                            var inputminuteEnd = Console.ReadLine();

                            if (inputminuteEnd == "q") return;

                            if (int.TryParse(inputminuteEnd, out minuteEnd))
                            {
                                if (minuteEnd > 59 || minuteEnd < 0)
                                {
                                    error = $"enter minutes from 0 to 59... {minuteEnd} is not accepted";
                                    continue;
                                }
                                else
                                {
                                    minuteNotSelectedEnd = false;
                                    dateNotSelected = false;


                                }
                            }
                            else
                            {
                                error = $"Enter minutes in number format, like: 9, '{minuteEnd}' is not accepted";
                                continue;
                            }
                        }


                        var newMeeting = new MeetingModel(newParticipantsList, responsiblePerson, description, categoryEnum, meetingTypeEnum, new DateTime(year, monthStart, dayStart, hourStart, minuteStart,00), new DateTime(yearE, monthEnd, dayEnd, hourEnd, minuteEnd, 00));


                        //List<MeetingModel> meetingList = new List<MeetingModel>();
                        //meetingList.Add(newMeeting);

                        string stringtoJson = System.Text.Json.JsonSerializer.Serialize(newMeeting);
                        await File.AppendAllTextAsync($"{filePath}{fileName}", $"{stringtoJson}" + Environment.NewLine);

                        Console.WriteLine("Executed succesfully");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                        //solved = true;

                        if (Console.ReadLine().Trim().ToLower() == "q")
                        {
                            return;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Please enter numeric value and try again ");
                }


            }
            
        }


        public async Task RemoveLine()
        {
            Console.Clear();
            var solved = false;

            while (!solved)
            {
                // var meetingList = await File.ReadAllLinesAsync($"{filePath}{fileName}");
                Console.Clear();
                Console.WriteLine("Please indicate Meeting Number that you would like to Remove");
                Console.WriteLine("\n");
                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

                //For identifying responsible person
                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }
                //

                var counterMeeting = -1;

                foreach (var line in meetingLst)
                {
                counterMeeting++;
                Console.WriteLine($"line {counterMeeting}: {line}");


                }

           
                Console.WriteLine("\n");
                var indicatedMeetingNo = Console.ReadLine();
                if (int.TryParse(indicatedMeetingNo, out var number))
                {
                    Console.WriteLine("Please indicate your name. In order to delete the meeting Name should match with the name specified as Responsible Person within selected meeting");
                    var name = Console.ReadLine().Trim().ToLower();

                    if (newMeetingLstForSearch.Any(x => x.ResponsiblePerson.Contains(name)))
                    {


                        meetingLst.RemoveAt(number);
                        await File.WriteAllLinesAsync($"{filePath}{fileName}", meetingLst);

                        Console.WriteLine("Executed succesfully");

                        Console.WriteLine("\n");
                        Console.WriteLine("If you would like to quit enter \"q\" letter  (quit) \n");

                        if (Console.ReadLine().Trim().ToLower() == "q")
                        {
                            return;
                        }
                    }

                    else 
                    {
                        Console.WriteLine("Indicated person is not a Responsible person");
                    }
                }

                else 
                {

                    Console.WriteLine("Please enter numeric value");

                    Console.WriteLine("\n");
                    Console.WriteLine("If you would like to quit enter \"q\" letter  (quit) \n");

                    if (Console.ReadLine().Trim().ToLower() == "q")
                    {
                        return;
                    }

                }
            }
        }

        public async Task AddPerson()
        {
            Console.Clear();
            var solved = false;
            while (!solved)

            {

                Console.WriteLine("Please indicate Meeting Number in which you would like to Add a participiant");
                Console.WriteLine("\n");

                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
                var counter = -1;
                foreach (var line in meetingLst)
                {
                    counter++;
                    Console.WriteLine($"line {counter}: {line}");


                }
           
                var indicatedMeetingNo = Console.ReadLine();
                if (int.TryParse(indicatedMeetingNo, out var number ))
                {
           
                    //Deserialize from file to object:
                    var MeetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meetingLst.ElementAtOrDefault(number), MeetingModel);

                  
                    Console.Clear();

                    Console.WriteLine("Please provide details for a new meeting Participant:");

                    Console.WriteLine("enter Name");
                    var name = Console.ReadLine().Trim().ToLower();
                    Console.WriteLine("enter Surname");
                    var surname = Console.ReadLine().Trim().ToLower();
                    var time = DateTime.UtcNow;


                    var NewParticipant = new Participants(name, surname, time);
                    var containsParticipant = MeetingModel.Participant.Any(x => x.Name.Contains(name));
                    if (!containsParticipant)

                    {
                        MeetingModel.Participant.Add(NewParticipant);
                        Console.WriteLine($"participant: {NewParticipant.Name}, {NewParticipant.Surname}, added on: {NewParticipant.TimeWhenAdded} ");

                        // convert to JSON string
                        string stringtoJson = System.Text.Json.JsonSerializer.Serialize(MeetingModel);
                        meetingLst.Add(stringtoJson);
                        meetingLst.RemoveAt(number);
                        await File.WriteAllLinesAsync($"{filePath}{fileName}", meetingLst);

                        Console.WriteLine("Executed succesfully");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("If you would like to quit enter \"q\" letter  (quit) \n");
                        //solved = true;

                        if (Console.ReadLine().Trim().ToLower() == "q")
                        {
                            return;
                        }


                    }

                    else
                    {
                        Console.WriteLine($"Person: {NewParticipant.Name}, {NewParticipant.Surname}, is already in the meeting, therefore cannot be added again");

                        Console.WriteLine("\n");
                        Console.WriteLine("If you would like to quit enter \"q\" letter  (quit) \n");

                        if (Console.ReadLine().Trim().ToLower() == "q") 
                        {
                            return;
                        }
                    }
                }

                else 
                {
                    Console.WriteLine("Please enter numeric value and try again");
                }
            }

 
      

        }

        public async Task RemovePerson()

        {
            Console.Clear();
            var solved = false;

           while (!solved)
           {
             Console.WriteLine("If you would like to quit enter \"q\" letter  (quit) \n");
             Console.WriteLine("Please indicate a Meeting Number in which you would like to Remove a participiant");
             Console.WriteLine("\n");


            List<string> meetingLst =  File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            var counterMeeting = -1;
            foreach (var line in meetingLst)
            {
                counterMeeting++;
                Console.WriteLine($"line {counterMeeting}: {line}");


            }
            var indicatedMeetingNo = Console.ReadLine();

                

                if (indicatedMeetingNo == "q")
                {
                    return;
                }
                if (int.TryParse(indicatedMeetingNo, out var meetingNoInput))
                {
                    var MeetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meetingLst.ElementAtOrDefault(meetingNoInput), MeetingModel);
                    Console.Clear();
                    Console.WriteLine("Selected meeting inludes the following Participants. Please indicate participant Number to be removed");

                    var counterParticipant = -1;
                    foreach (var participant in MeetingModel.Participant)
                    {
                        counterParticipant++;
                        Console.WriteLine($"{counterParticipant} participant: {participant.Name}, {participant.Surname}, added on: {participant.TimeWhenAdded} ");

                    }



                    Console.WriteLine("\n");
                    var indicatedParticipantNo = Console.ReadLine().Trim().ToLower();

                    if (int.TryParse(indicatedMeetingNo, out var number))
                    {
                        //
                        if (!(MeetingModel.Participant[int.Parse(indicatedParticipantNo)].Name == MeetingModel.ResponsiblePerson))

                        {

                            MeetingModel.Participant.RemoveAt(int.Parse(indicatedParticipantNo));

                            string stringtoJson = System.Text.Json.JsonSerializer.Serialize(MeetingModel);
                            meetingLst.Add(stringtoJson);
                            meetingLst.RemoveAt(int.Parse(indicatedMeetingNo));
                            await File.WriteAllLinesAsync($"{filePath}{fileName}", meetingLst);

                            Console.WriteLine("Executed succesfully");

                            Console.WriteLine("\n");
                            Console.WriteLine("Jei norite iseiti iveskite \"q\" raide  (quit) \n");

                            if (Console.ReadLine().Trim().ToLower() == "q")
                            {
                                return;
                            }



                        }
                        else
                        {
                            Console.WriteLine("Action not Possible - Indicated participant is also a resposible Person");

                            Console.WriteLine("\n");
                            Console.WriteLine("Jei norite iseiti iveskite \"q\" raide  (quit) \n");

                            if (Console.ReadLine().Trim().ToLower() == "q")
                            {
                                return;
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Ivedete ne skaiciu, bandykite dar karta...");

                        Console.WriteLine("\n");
                        Console.WriteLine("Jei norite iseiti iveskite \"q\" raide  (quit) \n");

                        if (Console.ReadLine().Trim().ToLower() == "q")
                        {
                            return;
                        }
                    }
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("Please enter numeric value");
                }


         }


      }

        public async Task ListMeetings()
        {
            
            //base for all
            List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

            List<MeetingModel> newMeetingLstForSearch= new List<MeetingModel>();
         
            foreach (var meeting in meetingLst)
            {
                var meetingModel = new MeetingModel();
                JsonConvert.PopulateObject(meeting, meetingModel);

               newMeetingLstForSearch.Add(meetingModel);
            }
            //by description
            Console.WriteLine("Please indicate Meeting description");

            var input = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("\n");

            Console.WriteLine("The following meetings match yor search criteria");
            Console.WriteLine("\n");

            var containsDescription = newMeetingLstForSearch.Where(x => x.Description.Contains(input));

            foreach (var item in containsDescription)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }

            // by responsible person

            //
            //Console.WriteLine("Filter by Responsibl person");
            //var inputResponsiblePerson = Console.ReadLine().Trim().ToLower();

            //foreach (var meeting in newMeetingLstForSearch)
            //{

            //    if (meeting.ResponsiblePerson == inputResponsiblePerson)

            //    {
            //        Console.WriteLine(JsonConvert.SerializeObject(meeting));
            //    }

            //}



            // by Category
            //Console.WriteLine("Filter by Category");
            //var categoryInput = Console.ReadLine().Trim().ToLower();
            //Category categoryEnum;
            //if (categoryInput == "c")
            //{
            //    categoryEnum = Category.CodeMonkey;
            //}

            //else if (categoryInput == "h")
            //{
            //    categoryEnum = Category.Hub;
            //}
            //else if (categoryInput == "s")
            //{
            //    categoryEnum = Category.Short;
            //}
            //else if (categoryInput == "t")
            //{
            //    categoryEnum = Category.TeamBuilding;
            //}
            //else
            //{
            //    categoryEnum = Category.Unknown;
            //}


            //var filteredListForCategory = newMeetingLstForSearch.Where(x => x.Category.Equals(categoryEnum));

            //foreach (var item in filteredListForCategory) 
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //}


            ////type

            //Console.WriteLine("Filter by Type");
            //var typeInput = Console.ReadLine().Trim().ToLower();
            //MeetingType TypeEnum;
            //if (typeInput == "l")
            //{
            //    TypeEnum = MeetingType.Live;
            //}

            //else if (typeInput == "i")
            //{
            //    TypeEnum = MeetingType.InPerson;
            //}

            //else
            //{
            //    TypeEnum = MeetingType.Unknown;
            //}


            //var filteredListForType = newMeetingLstForSearch.Where(x => x.MeetingType.Equals(TypeEnum));

            //foreach (var item in filteredListForType)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //}


        }

        private async Task ListMeetingsMeniu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("********************************************");
                Console.WriteLine("*          List Meetings Meniu             *");
                Console.WriteLine("********************************************");
                Console.WriteLine("********************************************");
                Console.WriteLine("*        Filter By Description - d         *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*      Filter By Responsible Person - r    *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*         Filter By Category - c           *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*           Filter By Type - t             *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*           Filter By Dates - s            *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*      Filter By Number Of Attendees - a   *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*      Filter By Responsible Person - r    *");
                Console.WriteLine("********************************************");
                Console.WriteLine("*          Return to Main Meniu  - q       *");
                Console.WriteLine("********************************************");
                Console.WriteLine("\nYour Choice ?");
                var meniuChoice = Console.ReadLine();

                if (meniuChoice.Trim().ToLower() == "q")
                {
                    return;
                }
                else if (meniuChoice.Trim().ToLower() == "d")
                {
                   await FilterByDescription();
                }
                else if (meniuChoice.Trim().ToLower() == "r")
                {
                    await FilterByResponsiblePerson();
                }

                else if (meniuChoice.Trim().ToLower() == "c")
                {
                    await FilterByCategory();
                }

                else if (meniuChoice.Trim().ToLower() == "t")
                {
                    await FilterByType();
                }

                else if (meniuChoice.Trim().ToLower() == "s")
                {
                    await FilterByDates();
                }
                else if (meniuChoice.Trim().ToLower() == "a")
                {
                    await FilterByNumberOfAttendees();
                }

            }
        }

        public async Task FilterByDescription() 

        {
            Console.Clear();
            var solved = false;
            while (!solved)
            {

                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }
                //Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                Console.WriteLine("Please indicate Meeting description");


                var input = Console.ReadLine().Trim().ToLower();

                Console.WriteLine("\n");

                if (input == "q") return;

                var containsDescription = newMeetingLstForSearch.Where(x => x.Description.Contains(input));
                if (containsDescription.Count() >= 1)
                {
                    Console.WriteLine("The following meetings match yor search criteria");
                    Console.WriteLine("\n");

                    foreach (var item in containsDescription)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }

                else

                {
                    Console.WriteLine("based on your input we could not find anything");
                }
            }
        }

        public async Task FilterByResponsiblePerson() 
        {
            Console.Clear();
            var solved = false;
            while (!solved)
            {
                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }
                Console.WriteLine("\n");
                Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                Console.WriteLine("Please enter Responsible Person");
                var inputResponsiblePerson = Console.ReadLine().Trim().ToLower();

                Console.WriteLine("\n");

                if (inputResponsiblePerson == "q") return;

                var containsRespPErson = newMeetingLstForSearch.Where(x => x.ResponsiblePerson.Equals(inputResponsiblePerson));
                if (containsRespPErson.Count() >= 1)

                {

                    Console.WriteLine("The following meetings match yor search criteria");
                    Console.WriteLine("\n");
                    foreach (var meeting in newMeetingLstForSearch)
                    {

                        if (meeting.ResponsiblePerson == inputResponsiblePerson)

                        {
                            Console.WriteLine(JsonConvert.SerializeObject(meeting));
                        }

                    }
                }
                else 
                {
                    Console.WriteLine("based on your input we could not find anything");

                }
            }
        }

        public async Task FilterByCategory() 
        {
            Console.Clear();
            var solved = false;
            while (!solved)
            {
                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }
                Console.WriteLine("\n");
                Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                Console.WriteLine("Please enter Meeting Category. Select form the following: c - CodeMonkey, h - Hub, s - Short, t - TeamBuilding");

                var categoryInput = Console.ReadLine().Trim().ToLower();

                Console.WriteLine("\n");

                if (categoryInput == "q") return;

                Category categoryEnum;
                if (categoryInput == "c")
                {
                    categoryEnum = Category.CodeMonkey;
                }

                else if (categoryInput == "h")
                {
                    categoryEnum = Category.Hub;
                }
                else if (categoryInput == "s")
                {
                    categoryEnum = Category.Short;
                }
                else if (categoryInput == "t")
                {
                    categoryEnum = Category.TeamBuilding;
                }
                else
                {
                    categoryEnum = Category.Unknown;
                }


                var filteredListForCategory = newMeetingLstForSearch.Where(x => x.Category.Equals(categoryEnum));

                if (filteredListForCategory.Count() >= 1)

                {
                    Console.WriteLine("The following meetings match yor search criteria");
                    Console.WriteLine("\n");
                    foreach (var item in filteredListForCategory)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }
                else 
                {
                    Console.WriteLine("based on your input we could not find anything");
                }


            }
        }

        public async Task FilterByType() 
        {
            Console.Clear();
            var solved = false;
            while (!solved)
            {
                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }

                Console.WriteLine("\n");
                Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                Console.WriteLine("Please enter Meeting Type. Select form the following: l - Live, i - InPerson");

                var typeInput = Console.ReadLine().Trim().ToLower();

                Console.WriteLine("\n");

                if (typeInput == "q") return;

                MeetingType TypeEnum;
                if (typeInput == "l")
                {
                    TypeEnum = MeetingType.Live;
                }

                else if (typeInput == "i")
                {
                    TypeEnum = MeetingType.InPerson;
                }

                else
                {
                    TypeEnum = MeetingType.Unknown;
                }


                var filteredListForType = newMeetingLstForSearch.Where(x => x.MeetingType.Equals(TypeEnum));

                if (filteredListForType.Count() >= 1)

                {
                    Console.WriteLine("The following meetings match yor search criteria");
                    Console.WriteLine("\n");
                    foreach (var item in filteredListForType)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(item));
                    }
                }
                else 
                {
                    Console.WriteLine("based on your input we could not find anything");
                }
            }
        }

        public async Task FilterByDates ()
        {
            Console.Clear();
            var solved = false;
            while (!solved)
            {

                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();


                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }
                Console.WriteLine("\n");
                Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");

                Console.WriteLine("Please Enter from Date in a format yyyy.mm.dd");

                var inputStartDate = Console.ReadLine().Trim().ToLower();
                Console.WriteLine("\n");

                Console.WriteLine("Please Enter To Date in a format yyyy.mm.dd");
                var inputEndDate = Console.ReadLine().Trim().ToLower();
                Console.WriteLine("\n");
              

                if (inputStartDate == "q" || inputEndDate == "q") return;

                Console.WriteLine("The following meetings match yor search criteria");
                Console.WriteLine("\n");


                if (DateTime.TryParse(inputStartDate, out var InputStartDateCheck) || DateTime.TryParse(inputEndDate, out var InputEndDateCheck))
                {

                    Console.WriteLine("The following meetings match yor search criteria");
                    Console.WriteLine("\n");

                    foreach (var item in newMeetingLstForSearch)

                    {
                        if (item.StartDate >= DateTime.Parse(inputStartDate) && item.EndDate <= DateTime.Parse(inputEndDate))

                        {
                            Console.WriteLine(JsonConvert.SerializeObject(item));
                        }

                    }
                }
                else 
                {
                    Console.WriteLine("Please enter correct Date format and try again");
                }
      
            }

        }

        public async Task FilterByNumberOfAttendees()
        {
            Console.Clear();
            var solved = false;
            while (!solved)
            {
                List<string> meetingLst = File.ReadAllLines($"{filePath}{fileName}").Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();


                List<MeetingModel> newMeetingLstForSearch = new List<MeetingModel>();

                foreach (var meeting in meetingLst)
                {
                    var meetingModel = new MeetingModel();
                    JsonConvert.PopulateObject(meeting, meetingModel);

                    newMeetingLstForSearch.Add(meetingModel);
                }

                Console.WriteLine("\n");
                Console.WriteLine("If you woud like to quit Enter \"q\" letter  (quit) \n");
                Console.WriteLine("Please indicate number of Attendees to fillter meetings (numeric)");

                var inputAttendees = Console.ReadLine().Trim().ToLower();
                Console.WriteLine("\n");
                Console.WriteLine("\n");

                if (inputAttendees == "q") return;


                //var containsDescription = newMeetingLstForSearch.Where(x => x.StartDate.Equals(DateTime.Parse(inputStartDate)));
                if (int.TryParse(inputAttendees, out var input))
                {
                    Console.WriteLine("The following meetings match yor search criteria");
                    Console.WriteLine("\n");
                    foreach (var item in newMeetingLstForSearch)

                    {
                        if (item.Participant.Count() >= int.Parse(inputAttendees))

                        {
                            Console.WriteLine(JsonConvert.SerializeObject(item));
                        }

                        if (item.Participant.Count() < int.Parse(inputAttendees));
                        {
                            Console.WriteLine("There are no meetings with indicated number of Attendees");
                            break;
                        }
                    }
                    
                }
                else 
                {
                    Console.WriteLine("Please enter numeric value");
                }
            }

        }




    }
}
