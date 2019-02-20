using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace ClubLib
{
    public class ClubsManager:IClubsRepository
    {
        public const int MAX_NUM_OF_CLUBS = 100;
        public Club[] clubs= new Club[MAX_NUM_OF_CLUBS];
        public int number=0;

        public Club[] Clubs
        {
            set { clubs = value; }
            get { return clubs; }
        }
        public int Number
        {
            set { number = value; }
            get { return number; }
        }


        public ClubsManager()
        {
            
        }
        public ClubsManager(int maxnoOfClubs):this()
        {
            Number= maxnoOfClubs;

        }

        public void Add(Club club)
        {
            if (GetClubByRegNum(club.ClubNumber) == null)
            {
                clubs[number++] = club;
            }
            else
            {
                Console.WriteLine("already added");
            }
        }

        public Club GetClubByRegNum(int clubNumber)
        {
            for (int i = 0; i < number; i++)
            {
                if (Clubs[i] != null)
                {
                    if (Clubs[i].ClubNumber == clubNumber)
                    {
                        return Clubs[i];
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }


        public void Load(string fileName, string delimiter)
        {
            int result;
            long num;
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            string[] fields;
            while (line != null)
            {
                try
                {
                     fields = line.Split(Convert.ToChar(delimiter));
                    if (!int.TryParse(fields[0],out result))
                        {
                        throw new Exception("Invalid club record Club number is not valid:  \n\t" + line);
                        }
                    else if(!long.TryParse(fields[6], out num))
                        {
                        throw new Exception("Invalid club record. Phone number wrong format: \n\t" +line);
                        }
                    else if (GetClubByRegNum(Convert.ToInt32(fields[0])) != null)
                        {
                        throw new Exception("Invalid club record. Club with the registration number already exists: \n\t" + line);
                        }
                    else
                    {
                        Address address = new Address(fields[2], fields[3], fields[4], fields[5]);
                        Add(new Club(Convert.ToInt32(fields[0]), fields[1], address, Convert.ToUInt32(fields[6])));
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally 
                {
                    if (Clubs[number] != null)
                    {
                        ++number;
                        reader.Close();
                    } 
                }
                line = reader.ReadLine();
            }
        }
        public void Save(string fileName,string delimeter)
        { 
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            binaryFormatter.Serialize(fileOut, Clubs);
            fileOut.Close();
        }
        //public void Load(string fileName)
        //{
        //    int i = 0;
        //    BinaryFormatter binFormat = new BinaryFormatter();
        //    FileStream fileIn = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    clubs = (Club[])binFormat.Deserialize(fileIn);
        //    //this.numberOfClubs = clubs.Count;
        //    while(clubs[i]!=null){
        //       numberOfClubs = ++i;
        //    }
        //    fileIn.Close();
        //}

    }
}
