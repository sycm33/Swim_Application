using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks;
/*  * 4. Event Holds the following information: a. Distance – distance of a swim (50, 100, 200, 400, 800, 1500) (use enum) b. Stroke – code for the stroke (butterfly, backstroke, breaststroke, freestyle, individual medley) (use enum)  */
namespace ClubLib {     [Serializable]      public class Event     {         public const string SWIMMER_NOT_ENTERED = "Swimmer has not entered event";
        private EventDistance distance;         private Stroke stroke;         private SwimMeet swimMeet;                  private Registrant[] registrants;         const int NUMOFREGISTRANTS = 100;         private int numOfRegistrants;         public Swim[] EventInfo;          public SwimMeet SwimMeet         {             set { swimMeet = value; }             get { return swimMeet; }         }         public EventDistance Distance         {             set { distance = value;}             get { return distance;}         }          public Stroke Stroke         {             set{  stroke = value; }             get { return stroke; }          }         public Registrant[] Registrants         {             set {  registrants = value; }             get { return registrants; }         }          public int NumOfRegistrants         {             get { return numOfRegistrants; }             set { numOfRegistrants = value; }         }          public Event()         {             registrants = new Registrant[NUMOFREGISTRANTS];             for (int i = 0; i < NUMOFREGISTRANTS; i++)
            {
                Registrants[i] = new Registrant();
            }

            EventInfo = new Swim[NUMOFREGISTRANTS];             for (int i = 0; i < NUMOFREGISTRANTS; i++)
            {
                EventInfo[i] = new Swim();
            }

        }         public Event(EventDistance distance, Stroke stroke) : this()         {             Distance = distance;             Stroke = stroke;         }         public void AddSwimmer(Registrant swimmer)         {
            //if (Registrants[numOfRegistrants].RegistrationNumer == swimmer.RegistrationNumer)
            //{
            //    throw new Exception("Swimmer " + Registrants[numOfRegistrants].Name + " " + Registrants[numOfRegistrants].RegistrationNumer + "is already entered");
            //}
            //else
            //{
            //    registrants[numOfRegistrants++] = swimmer;

            //}
            if (Registrants.Contains(swimmer))
            {
                throw new Exception("Swimmer " + swimmer.Name + ", " + swimmer.RegistrationNumber + ", is already entered");
            }
            else
            {
                registrants[numOfRegistrants++] = swimmer;
            }
        }         public void Seed(Registrant swimmer, int noOfHeat, int noOfLane)         {             for (int i = 0; i < NumOfRegistrants; i++)             {                 if (Registrants[i].RegistrationNumber == swimmer.RegistrationNumber)
                {                     EventInfo[i].Heat = noOfHeat;
                    EventInfo[i].Lane = noOfLane;                 }             }         }         public void EnterSwimmersTime(Swimmer swimmer, string time)         {
            for (int i = 0; i < numOfRegistrants; i++)
            {
                if (Registrants[i].RegistrationNumber == swimmer.RegistrationNumber)
                {
                    EventInfo[i].TimeSwam = time;
                    swimmer.AddAsBestTime(swimMeet.type, stroke, distance, TimeSpan.ParseExact(time, @"mm\:ss\.ff", System.Globalization.CultureInfo.InvariantCulture));
                }
                else if (!Registrants.Contains(swimmer))
                {
                    throw new Exception("Swimmer has not entered event");
                }
            }
           
        }
        public override string ToString()
        {
            string info = "";             info += string.Format($"\n{ Distance} \n{ Stroke}");             for (int i = 0; i < NumOfRegistrants; i++)             {                 info += string.Format("\n\t{0}", Registrants[i].Name);             }             return info;         }     } }