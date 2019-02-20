using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClubLib
{
    public class SwimmersManager : ISwimmersRepository
    {
        public const int MAX_NUM_OF_SWIMMERS = 20;
        public Registrant[] swimmers = new Registrant[MAX_NUM_OF_SWIMMERS];
        //public List<Registrant> swimmers = new List<Registrant>();
        public int number;
        private ClubsManager clbMngr;

        public Registrant[] Swimmers
        {
            set { swimmers = value; }
            get { return swimmers; }
        }
        //public List<Registrant> Swimmers
        //{
        //    set { swimmers = value; }
        //    get { return swimmers; }
        //}

        public int Number
        {
            set { number = value; }
            get { return number; }
        }

        public SwimmersManager(int maxnoOfSwimmers)
        {
            number = maxnoOfSwimmers;
        }

        public SwimmersManager(ClubsManager clbMngr)
        {
            this.clbMngr = clbMngr;
        }

        public void Add(Registrant swimmer)
        {
            if (GetByRegNum(swimmer.RegistrationNumber) == null)
            {
                swimmers[number++] = swimmer;
                //Swimmers.Add(swimmer);
            }
            else
            {
                Console.WriteLine("already added " + swimmer.RegistrationNumber);
            }

        }
        public Registrant GetByRegNum(int RegNumber)
        {
            for (int i = 0; i < number; i++)
            {
                if (Swimmers[i] != null)
                {
                    if (Swimmers[i].RegistrationNumber == RegNumber)
                    {
                        return Swimmers[i];
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
            int regNo;
            DateTime date;
            long phone;
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            string[] fields;
            while (line != null)
            {
                try
                {
                    fields = line.Split(Convert.ToChar(delimiter));
                    for (int i = 0; i < number; i++)
                    {
                        if (fields[1] == "")
                        {
                            throw new Exception("Invalid swimmer record. Invalid swimmer name:  \n\t" + line);
                        }
                        else
                        if (!DateTime.TryParse(fields[2], out date))
                        {
                            throw new Exception("Invalid swimmer record. Birth date is inalid: \n\t" + line);
                        }
                        else if (!long.TryParse(fields[7], out phone))
                        {
                            throw new Exception("Invalid swimmer record. Phone number wrong format: \n\t" + line);
                        }
                        else if (!int.TryParse(fields[0], out regNo))
                        {
                            throw new Exception("Invalid swimmer record. Invalid registration number: \n\t" + line);
                        }
                        else if (GetByRegNum(Convert.ToInt32(fields[0])) != null)
                        {
                            if (Swimmers.Contains(GetByRegNum(Convert.ToInt32(fields[0]))))

                            {
                                throw new Exception("Invalid swimmer record. Swimmer with the registration number already exists: \n\t" + line);
                            }
                            else
                            {
                                Address address = new Address(fields[3], fields[4], fields[5], fields[6]);
                                Registrant newSwimmer = new Registrant(Convert.ToInt32(fields[0]), fields[1], Convert.ToDateTime(fields[2]), address, Convert.ToUInt32(fields[7]));
                                Add(newSwimmer);
                            }
                        }
                    }
                    Address address1 = new Address(fields[3], fields[4], fields[5], fields[6]);
                    Registrant newSwimmer1 = new Registrant(Convert.ToInt32(fields[0]), fields[1], Convert.ToDateTime(fields[2]), address1, Convert.ToUInt32(fields[7]));
                    Add(newSwimmer1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (Swimmers[number] != null)
                    {
                        ++number;
                        reader.Close();
                    }
                }
                line = reader.ReadLine();
            }
        }

        public void Save(string fileName, string delimeter)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            binaryFormatter.Serialize(fileOut, Swimmers);
            fileOut.Close();
        }
    }
}
