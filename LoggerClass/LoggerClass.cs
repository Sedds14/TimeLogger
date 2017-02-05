using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace LoggerClass
{
    public class Xml
    {
        public static void save(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        public static object[] read(Object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(Type.GetType(obj));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            XmlReader reader = XmlReader.Create(fs);
            obj ObjectArray = 
            writer.Close();

            return ObjectArray[];
        }
    }
    public class DataBaseFunctions
    {

    }

    public class Project
    {
        public Project(string number, string description, int status)
        {
            //Error handling - Status does not exist
            //Should this be an 'Enumerator'??
            if (Status > 2)
            {
                //Console.WriteLine("Status provided is {0}. Only integers 0 - 2 are valid");
                //Console.WriteLine("Press ENTER to exit.");
                //return;

                throw new ArgumentException("Parameter cannot be greater than 2", "status");
            }

            Number = number;
            Description = description;
            Status = status;
            // need to write a method that uses the XML library to find the next serial number

            //write to XML file - probably not a great idea

        }

        public string Number { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } //prospect, active, complete
        public int ProjectSerial { get; set; } // need to add project serial

        public class WorkOrder
        {
            public WorkOrder(int projectSerial, string wONumber, string description, decimal budget, decimal multiplier, bool useStandardGrades, int customGradeSerial)
            {   
                ProjectSerial = projectSerial;
                WONumber = wONumber;
                Description = description;
                Budget = budget;
                Multiplier = multiplier;
                UseStandardGrades = useStandardGrades;
                // if you are not using a standard grade then the multiplier defaults to 1
                if (UseStandardGrades == false)
                {
                    Multiplier = 1;
                }
                Status = 0;//when you create it it must be active, right?!
                CustomGradeSerial = customGradeSerial;
                // WOSerial needs a method
            }
            public int ProjectSerial { get; set; }
            public string WONumber { get; set; }
            public string Description { get; set; }
            public decimal Budget { get; set; }
            public decimal Multiplier { get; set; } // Changes later?
            //write method to calculate spend to date
            public bool UseStandardGrades { get; set; }
            public int Status { get; set; } //active, inactive
            public int CustomGradeSerial { get; set; }

            public class TaskOrder
            {
                public TaskOrder(
                    int wOSerial,
                    string tORef,                                
                    string description,
                    int status,
                    string statusComment,
                    bool myTask,
                    DateTime deadline,
                    decimal budget)
                {            
                    WOSerial = wOSerial;
                    TORef = tORef;
                    Description = description;
                    Status = status;
                    StatusComment = statusComment;
                    MyTask = myTask;
                    Deadline = deadline;
                    Budget = budget;
                    //write method to get TOSerial
                }

                public int WOSerial { get; set; }
                public string TORef { get; set; }
                public string Description { get; set; }
                public int Status { get; set; } //Not Started, In Progress, On Hold, Complete
                public string StatusComment { get; set; }
                //Task order is for user?
                public bool MyTask { get; set; }
                public DateTime Deadline { get; set; }
                public decimal Budget { get; set; }

                //write a method to output hours remanining at a given grade
                //write a method to output budget spent using times and rates
                //write a method to output time before deadline
                //write a method to output allocated budget

            }
        }

        public class Xml
        {
            public static void saveProjects(Project[] MyProjects, string filename)
            {
                XmlSerializer sr = new XmlSerializer(MyProjects.GetType());
            }
        }

        /* Well, that doesnt work!
        public void WriteJSON(Project[] MyProjects)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer(JavaScriptTypeResolver);
            string outputJSON = ser.Serialize(MyProjects);
            File.WriteAllText("Projects.json", MyProjects);
        }
        */

    }

    public class TimeLog
    {
        public TimeLog(int tOSerial, int GradeSerial, DateTime timeStart, DateTime timeFinish)
        {
            //PLACEHOLDER
        }

        public int TOSerial { get; set; }
        public int GradeSerial { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
        public int TimeLogSerial { get; set; }
        // create TimeLogNumber

    }

    public class NonUserTime
    {
        public int TOSerial { get; set; }
        public decimal hours { get; set; }
        public decimal rate { get; set; }

        //create NonUserTimeNumber
    }

    public class Expese
    {

    }

    public class StandardGrades
    {
        //manipulate Excel to give me rates!
        public double rate { get; set; }
    }

    public class CustomGrade
    {
        //contains custom grades
        public int CGSerial { get; set; }
        public string FrameworkDescription { get; set; }
        public string GradeDescription { get; set; }
        public decimal Rate { get; set; }
    }

    public class OverheadTimeCodes
    {

    }
}
