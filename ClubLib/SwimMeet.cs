using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; /*  * 3. Swim meet Holds the following information: a. Start date – start date of the meet b. End date – end date of the meet c. Name of the meet – represent a name of the meet d. Course – pool type (SCM, SCY, LCM) (use enum)  */ namespace ClubLib {         [Serializable]     public class SwimMeet     {         private DateTime startDate;         private DateTime endDate;         private string name;         public PoolType type;         private int noOfLanes = 0;         private Swim swim;         private Event[] events;         private int numOfEvents;         private int Max_Events = 50;         public int NoOfLanes         {             set { noOfLanes = value; }             get { return noOfLanes; }         }
        public int NumOfEvetns         {             set { numOfEvents = value; }             get { return numOfEvents; }         }         public DateTime StartDate         {             set {  startDate = value; }             get { return startDate;}         }          public DateTime EndDate         {             set {  endDate = value; }             get { return endDate; }         }         public string Name         {             set{  name = value; }             get{ return name; }         }         public PoolType Type         {             set { type = value; }             get { return type; }          }         public Swim Swim         {             set { swim = value;}             get {return swim; }         }         public Event[] Events         {             set  { events = value;}             get {return events;}         }         public SwimMeet()         {             events = new Event[50];             type = 0;             noOfLanes = 8;         }          public SwimMeet(string name, DateTime startDate, DateTime endDate, PoolType poolType, int noOfLanes) : this()         {             StartDate = startDate;             EndDate = endDate;             Name = name;             type = poolType;             NoOfLanes = noOfLanes;         }          public void AddEvent(Event anEvent)         {             if(numOfEvents< Max_Events)
            {
                events[numOfEvents++] = anEvent;
                anEvent.SwimMeet = this;
            }
            else
            {
                throw new Exception("Limit has reached.Cannot add more events.");
            }

        }          public void Seed()         {             if (events != null)
            {
                for (int i = 0; i < Events.Length; i++)                 {                     int heat = 1;                     int lane = 1;                     if (events[i] != null)                     {                         for (int j = 0; j < Events[i].Registrants.Length; j++)                         {                             if (Events[i].Registrants[j] != null)                             {                                 Events[i].Seed(Events[i].Registrants[j], heat, lane++);                                 if (lane == NoOfLanes)                                 {                                     lane = 1;                                     heat++;                                 }                             }                         }                     }                 }
            }                          } 
        public override string ToString()
        {   
            string list = "";
            list += string.Format($"\nSweem meet name:{ Name} \nFrom-to: { StartDate:yyyy/MM/dd} to { EndDate:yyyy/MM/dd}\nPool type: {Type} \nNo lanes: { NoOfLanes} \nEvent:");
            for (int i = 0; i < events.Length; i++)
            {
                if (Events[i] != null)
                {
                    list += string.Format("\n\n\t {0} {1} \n\tSwimmers:", Events[i].Distance, Events[i].Stroke);
                    for (int j = 0; j < events[i].NumOfRegistrants; j++)
                    {
                        if (Events[i].Registrants[j] != null)
                        {
                            list += string.Format("\n\t {0}", Events[i].Registrants[j].Name );
                        }
                        if ((Events[i].EventInfo[j].Heat == 0) && (Events[i].EventInfo[j].Lane == 0) && (Events[i].EventInfo[j].TimeSwam == null))
                        {
                            list += string.Format("\n\t\tNot Seeded/no swim");
                        }
                        else if ((Events[i].EventInfo[j].Heat != 0) || (Events[i].EventInfo[j].Lane != 0))
                        {
                            list += string.Format("\t H{0}L{1} \ttime: {2}", Events[i].EventInfo[j].Heat, Events[i].EventInfo[j].Lane, Events[i].EventInfo[j].TimeSwam ?? "no time");
                        }
                    }
                }
            }
            return list;
        }       } }