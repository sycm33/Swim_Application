using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubLib
{
    [Serializable]
    public class Swimmer:Registrant
    {
        Coach coach;
        int numberOfRegistrants;
        int i;
        TimeSpan[] bestTimes = new TimeSpan[10];
        //string[] filters = new string[10];
        List<string> filters = new List<string>();
        SwimMeet swimMeet = new SwimMeet();
        public TimeSpan[] BestTimes
        {
            get { return bestTimes; }
            set { bestTimes = value; }
        }
        public Coach Coach
        {
            get { return coach; } 
            set
            {
               coach = value;
                //if (coach.Club == null)
                ////{
                ////if (coach.Club.ClubNumber == this.Club.ClubNumber)
                //{
                //    this.Coach = value;
                //}
                ////}
                //else
                //{
                //    throw new Exception("coach is not assigned to the club " + coach.Name);
                //}

            }
        }
        public Swimmer(): base()
        {
            for (int i = 0; i < bestTimes.Length; i++)
            {
                bestTimes[i] = new TimeSpan();
            }
            
        }
        public Swimmer(string name, DateTime dateOfBirth, Address address, ulong phoneNumber) :base(name, dateOfBirth, address, phoneNumber)
        {

        }
        public TimeSpan GetBestTime(PoolType poolType,Stroke stroke,EventDistance eventDistance)
        {
           TimeSpan bTime;
            string listOfFilter = Convert.ToString(poolType) + Convert.ToString(stroke) + Convert.ToString(eventDistance);
            if (filters.Contains(listOfFilter))
            {
                bTime = BestTimes[filters.IndexOf(listOfFilter)];
            }
            else
            {
               bTime= new TimeSpan(0);
            }
          
            return bTime;
        }
        public void AddAsBestTime(PoolType poolType, Stroke stroke, EventDistance eventDistance,TimeSpan time)
        {
            string listOfFilter = Convert.ToString(poolType) + Convert.ToString(stroke) + Convert.ToString(eventDistance) ;
            
            if (filters.Contains(listOfFilter))
            {
                if(BestTimes[filters.IndexOf(listOfFilter)] > time)
                {
                    BestTimes[filters.IndexOf(listOfFilter)] = time;
                }
            }
            else
            {
                filters.Add(listOfFilter);
                BestTimes[i++] = time;
            }
           
        }
        public void AddCoach(Coach coach)
        {
           if(coach.Club == null)
            {
                throw new Exception("Coach is not assigned to the club");
            }
           else if(coach.Club.ClubNumber != coach.Swimmers[numberOfRegistrants++].Club.ClubNumber)
            {
                throw new Exception("Coach and swimmer are not in the same club");
            }
            else
            {
                this.coach = coach;
            }

        }
        public override string ToString()
        {
            return base.ToString()+string.Format("\nCoach: {0}", Coach == null ? "not assigned" : Coach.Name);
        }
    }
}
