using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubLib
{
    [Serializable]
    public class Coach:Registrant
    {
        string credentials;
        Registrant[] swimmers;
        //List<Registrant> swimmers; 
        int Max_Registrants = 20;
        int numberOfRegistrants;
        public string Credentials
        {
            get { return credentials; }
            set { credentials = value; }
        }
        //public List<Registrant> Swimmers
        //{
        //    get { return swimmers; }
        //    set { swimmers = value; }
        //}
        public Registrant[] Swimmers
        {
            get { return swimmers; }
            set { swimmers = value; }
        }

        public int NumberOfRegistrants
        { get{ return numberOfRegistrants; } set {  numberOfRegistrants = value; } }
        public Coach()
        {

        }
        public Coach(string name, DateTime dateOfBirth, Address address, ulong phoneNumber) :base(name,dateOfBirth, address, phoneNumber)
        {

            //Swimmers = new  List<Registrant>(Max_Registrants);
            Swimmers = new Registrant[Max_Registrants];
            //for (int i = 0; i < Swimmers.Length; i++)
            //{
            //    Swimmers[i] = new Registrant();
            //}
        }
        public void AddSwimmer(Swimmer swimmer)
        {
            //if (Swimmers.Count< Max_Registrants)
                if(numberOfRegistrants < Max_Registrants)
            {
                //if (Swimmers[Swimmers.Count].RegistrationNumber != swimmer.RegistrationNumber)
                //{
                //    //Swimmers[numberOfRegistrants++] = swimmer;
                //    Swimmers.Add(swimmer);
                //    swimmer.Coach = this;
                //}
                if (!Swimmers.Contains(swimmer))
                {
                    Swimmers[numberOfRegistrants++] = swimmer;
                    //Swimmers.Add(swimmer);
                    //if(swimmer.Club.ClubNumber==swimmer.Coach.Club.ClubNumber)
                   swimmer.Coach = this;
                    //else
                    //    Console.WriteLine("Club number is not same");
                  
                }
                else
                {
                    //throw new Exception("Swimmer already assigned to " + Swimmers[numberOfRegistrants++].Coach.Name);
                }
            }
            else
            {
                throw new Exception("Cannot register more than 20");
            }
        }
        public override string ToString()
        {
            string info = "";
            info += base.ToString() + string.Format("\nCredentials: {0} \nSwimmers: ", Credentials);
            for (int i = 0; i < numberOfRegistrants; i++)
               // for (int i = 0; i < Swimmers.Count; i++)
                {
                info += string.Format("\n\t{0}", Swimmers[i].Name);
            }
            return info;
        }


    }
}
