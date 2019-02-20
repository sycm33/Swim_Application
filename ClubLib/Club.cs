using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks;
/*  * 1. Club Holds the following information: a. club number – club’s registration number b. name –the name of the club c. address – address of the club (use structs) d. telephone number – 10-digit phone number  */
namespace ClubLib {     [Serializable]     public class Club     {         public const int MAX_NUM_OF_REGISTRANTS = 20;         private int clubNumber;         private string name;         private Address address;         private long phoneNumber;         public Registrant[] registrants;         public int numOfRegistrants;        Coach[] coaches;         private int numOfCoaches=0;         int maxCoaches = 10;         public Coach[] Coaches
        {
            get { return coaches; }
            set { coaches = value; }
        }         public int NumOfRegistrants         {             set {  numOfRegistrants = value; }             get  { return numOfRegistrants; }         }
        public int NumOfCoaches         {             set { numOfCoaches = value; }             get { return numOfCoaches; }         }          public int ClubNumber         {             get { return clubNumber; }         }         public string Name         {             set { name = value; }             get{ return name;}         }         public Address Address         {             set { address = value; }             get { return address; }         }          public long PhoneNumber         {             set { phoneNumber = value; }             get  { return phoneNumber; }         }         public Registrant[] Registrants         {             set { registrants = value; }             get  {  return registrants; }         }          public Club()         {
            clubNumber = RegNoGenerator.GetRegNo();
            registrants = new Registrant[MAX_NUM_OF_REGISTRANTS];             for (int i = 0; i < numOfRegistrants; i++)
            {
                Registrants[i] = new Registrant();
            }             coaches = new Coach[maxCoaches];             for (int i = 0; i < numOfCoaches; i++)
            {
                coaches[i] = new Coach();
            }         }         public Club(string name, Address address, long phoneNumber):this()
        { 
            Name = name;             Address = address;             PhoneNumber = phoneNumber;                     }         public Club(int number, string name, Address address, long phoneNumber)         {             this.clubNumber = number;             Name = name;             Address = address;             PhoneNumber = phoneNumber;
            registrants = new Registrant[MAX_NUM_OF_REGISTRANTS];             for (int i = 0; i < numOfRegistrants; i++)
            {
                Registrants[i] = new Registrant();
            }             coaches = new Coach[maxCoaches];             for (int i = 0; i < numOfCoaches; i++)
            {
                coaches[i] = new Coach();
            }

        }

        //public void AddSwimmer(Registrant swimmer)
        //{
        //    if (numOfRegistrants < MAX_NUM_OF_REGISTRANTS)
        //    {
        //        if ((swimmer.Club == null) || (Registrants[numOfRegistrants++].RegistrationNumer != swimmer.RegistrationNumer))
        //        {
        //            Registrants[numOfRegistrants++] = swimmer;
        //            swimmer.Club = this;
        //        }
        //        else if (Registrants[numOfRegistrants++].RegistrationNumer == swimmer.RegistrationNumer)
        //        {
        //            throw new Exception("already assigned to " + Registrants[numOfRegistrants++].Club.Name);
        //        }

        //    }
        //    else
        //    {
        //        throw new Exception("Cannot register more than 20");
        //    }
        //}
        public void AddSwimmer(Registrant swimmer)
        {
            if (numOfRegistrants < MAX_NUM_OF_REGISTRANTS)
            {
                //if (Registrants[numOfRegistrants++].RegistrationNumber != swimmer.RegistrationNumber)
                //{

                //    Registrants[numOfRegistrants++] = swimmer;
                //    swimmer.Club = this;
                //}
                if (!Registrants.Contains(swimmer))
                {
                    Registrants[numOfRegistrants++] = swimmer;
                    swimmer.Club = this;
                }
                else 
                {
                    throw new Exception("Swimmer already assigned to " + Registrants[numOfRegistrants++].Club.Name);
                }
            }
            else
            {
                throw new Exception("Cannot register more than 20");
            }
        }
        public void AddCoach(Coach coach)
        {

            if (numOfCoaches < maxCoaches)
            {
                Coaches[numOfCoaches++] = coach;
                    coach.Club = this;
            }
            else
            {
                throw new Exception("Cannot add anymore coaches!");
            }
        }


        public override string ToString()
        {
            string info = "";
            info += string.Format("Name: {0} \nAddress: \n\t{1} \n\t{2} \n\t{3} \n\t{4} \nPhone: {5} \nReg number: {6} \nSwimmers: {7} \nCoaches: {8}",
                Name, address.Street, address.City, address.Province, address.Zip, PhoneNumber, ClubNumber,GetSwimmers(),GetCoaches());
            return info;
        }
        private string GetSwimmers()
        {
            string info = "";
            for (int i = 0; i < numOfRegistrants; i++)
            {
                if (Registrants[i] != null)
                {
                    //if (Registrants[i].Club != null)
                    {
                        info += string.Format("\n\t{0}", Registrants[i].Name);
                    }
                }
            }
            return info;
        }
        private string GetCoaches()
        {
            string info="";
            for (int i = 0; i < numOfCoaches; i++)
            {
                if (Coaches[i] != null)
                {
                    if (Coaches[i].Club != null)
                    {
                        info += string.Format("\n\t{0}", Coaches[i].Name);
                    }

                }

            }
            return info;
        }
    } }
