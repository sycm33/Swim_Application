using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 5. Swim
Holds the following information:
a. Time swam – final time of a swim (example: 1:05.52)
b. Heat – number of the heat
c. Lane – number of the lane
 */
namespace ClubLib
{
    [Serializable]
    public class Swim
    {
        private string timeSwam;
        private int heat;
        private int lane;
        public string TimeSwam
        {
            set{  timeSwam = value;  }
            get { return timeSwam; }
        }
        public int Heat
        {
            set{ heat = value;}
            get{ return heat; }
        }
        public int Lane
        {
            set { lane = value;}
            get { return lane;}
        }
        public Swim()
        {

        }
        public Swim(string timeswam,int heat,int lane)
        {
            TimeSwam = timeswam;
            Heat = heat;
            Lane = lane;
        }
        public override string ToString()
        {
            return string.Format($"\n\t\t\t\t H{Heat}L{Lane}   time:{TimeSwam}");
        }
    }
}
