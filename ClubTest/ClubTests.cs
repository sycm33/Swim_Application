using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubLib;

namespace ClubTests
{
    [TestClass]
    public class ClubTests
    {
        [TestMethod]
        public void Club_NameProperty_Same()
        {
            //Arrange
            Club club1 = new Club
            {
                PhoneNumber = 4164444444,
                Name = "New Club"
            };
            //Act
            string expectedClubName = "New Club";

            //Assert
            Assert.AreEqual(club1.Name, expectedClubName, "Club Name in not same!");
        }
        [TestMethod]
        public void Event_EnterSwimmerTime_Exception()
        {
            Event _400free = new Event();
            Swimmer swimmer1 = new Swimmer("Bob Smith", new DateTime(1970, 1, 1),
             new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            try
            {
                _400free.EnterSwimmersTime(swimmer1, "04:55.23");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, Event.SWIMMER_NOT_ENTERED);
            }
        }
        [TestMethod]
        public void Event_AddSwimmer_Exception()
        {
            Registrant[] swimmers = new Registrant[50];
            for (int i = 0; i < swimmers.Length; i++)
            {
                swimmers[i] = new Registrant();
            }

            Event _50free1 = new Event
            {
                Distance = EventDistance._50,
                Stroke = Stroke.Freestyle
            };
            Registrant swimmer1 = new Registrant("Bob Smith", new DateTime(1970, 1, 1),
            new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            Registrant swimmer2 = new Registrant
            {
                Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3"),
                Name = "John Lee",
                PhoneNumber = 4162222222,
                DateOfBirth = new DateTime(1950, 12, 1)
            };
            Registrant swimmer3 = new Registrant("Ann Smith", new DateTime(1975, 1, 1),
               new Address("5 Queen St", "Toronto", "ON", "M2M 4M4"), 4163333333);

            _50free1.AddSwimmer(swimmer1);
            _50free1.AddSwimmer(swimmer2);
            _50free1.AddSwimmer(swimmer3);
            try
            {
                _50free1.AddSwimmer(swimmer3);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Swimmer " + swimmer3.Name + ", " + swimmer3.RegistrationNumber + ", is already entered");
                //Assert.AreNotEqual(ex.Message, "Swimmer " + swimmer3.Name + ", " + swimmer3.RegistrationNumer + ", is already entered", " not same!");

                // return;
            }
            //Assert.Fail();
        }
        [TestMethod]
        public void Registrant_ClubProperty_Exception()
        {
            Registrant swimmer1 = new Registrant("Bob Smith", new DateTime(1970, 1, 1),
            new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            Registrant swimmer2 = new Registrant
            {
                Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3"),
                Name = "John Lee",
                PhoneNumber = 4162222222,
                DateOfBirth = new DateTime(1950, 12, 1)
            };
            Club club1 = new Club
            {
                PhoneNumber = 4164444444,
                Name = "NYAC"
            };
            Club club2 = new Club("CCAC", new Address("35 River St", "Toronto", "ON", "M2M 5M5"), 4165555555);
            club1.AddSwimmer(swimmer1);
            club2.AddSwimmer(swimmer2);
            try
            {
                swimmer2.Club = club1;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Swimmer is registered with a different club " + swimmer2.Club.Name);
                // Assert.AreNotEqual(ex.Message, "Swimmer is registered with a different club "+ swimmer2.Club.Name);
                // return;
            }
            //Assert.Fail();
        }
        [TestMethod]
        public void Registrant_AssigningClub_NoException()
        {
            Registrant swimmer1 = new Registrant("Bob Smith", new DateTime(1970, 1, 1),
            new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            Registrant swimmer2 = new Registrant
            {
                Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3"),
                Name = "John Lee",
                PhoneNumber = 4162222222,
                DateOfBirth = new DateTime(1950, 12, 1)
            };
            Registrant swimmer3 = new Registrant("Ann Smith", new DateTime(1975, 1, 1),
            new Address("5 Queen St", "Toronto", "ON", "M2M 4M4"), 4163333333);
            Club club1 = new Club
            {
                PhoneNumber = 4164444444,
                Name = "NYAC"
            };
            Club club2 = new Club("CCAC", new Address("35 River St", "Toronto", "ON", "M2M 5M5"), 4165555555);
            club1.AddSwimmer(swimmer1);
            club2.AddSwimmer(swimmer2);
            try
            {
                swimmer3.Club = club1;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Swimmer is registered with a different club " + swimmer3.Club.Name);
            }
        }
        [TestMethod]
        public void Club_ContsuctorWithArguments_Same()
        {
            Club newClub = new Club(122, "Toronto Club", new Address("Golf Club", "Scarborough", "On", "K1H 1G4"), 6541234567);

            string Expected_Club_Name = "Toronto Club";

            Assert.AreEqual(newClub.Name, Expected_Club_Name, "Club name is not same!");
        }
        //Work on This
        [TestMethod]
        public void Club_AddSwimmers_Exception()
        {
            //Arrange
            Club newClub = new Club();
            Registrant swimmer1 = new Registrant("Bob Smith", new DateTime(1970, 1, 1),
           new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            Registrant swimmer2 = new Registrant
            {
                Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3"),
                Name = "John Lee",
                PhoneNumber = 4162222222,
                DateOfBirth = new DateTime(1950, 12, 1)
            };
            Registrant swimmer3 = new Registrant("Ann Smith", new DateTime(1975, 1, 1),
            new Address("5 Queen St", "Toronto", "ON", "M2M 4M4"), 4163333333);


            newClub.AddSwimmer(swimmer1);
            newClub.AddSwimmer(swimmer2);
            newClub.AddSwimmer(swimmer3);
            try
            {
                newClub.AddSwimmer(swimmer3);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Swimmer is registered with a different club " + swimmer3.Club.Name);
            }

        }

        [TestMethod]
        public void SwimMeet_AllProperty_Same()
        {
            //Arrange
            SwimMeet newSwimMeet = new SwimMeet
            {
                Name = "New Swim Meet",
                StartDate = new DateTime(2017, 1, 10),
                EndDate = new DateTime(2017, 1, 12)
            };
            //Act
            string expectedSwimMeetName = "New Swim Meet";
            //assert
            Assert.AreEqual(newSwimMeet.Name, expectedSwimMeetName, "Meet Name in not same!");
        }

        [TestMethod]
        public void SwimMeet_ContsuctorWithArguments_Same()
        {
            //Arrange
            SwimMeet newSwimMeet = new SwimMeet("Toronto Meet", new DateTime(2017, 5, 21), new DateTime(2017, 5, 21), PoolType.LCM, 2);
            //Act
            string Expected_SwimMeet_Name = "Toronto Meet";
            //Assert
            Assert.AreEqual(newSwimMeet.Name, Expected_SwimMeet_Name, "Swim Meet name is not same!");
        }
        [TestMethod]
        public void Event_ContsuctorWithArguments_Same()
        {
            //Arrange
            Event newEvent = new Event(EventDistance._100, Stroke.Butterfly);
            Assert.AreEqual(newEvent.Distance, EventDistance._100);
        }
        [TestMethod]
        public void Swim_ContsuctorWithArguments_Same()
        {
            //Arrange
            Swim anSwim = new Swim("00:30.13", 1, 1);
            //Act
            string Expected_Swim_SwamTime = "00:30.13";
            //Assert
            Assert.AreEqual(anSwim.TimeSwam, Expected_Swim_SwamTime, "Swam time is not same!");
        }
        [TestMethod]
        public void Club_AddSwimmer_Same()
        {
            //arrange
            Club newClub = new Club();
            Registrant swimmer1 = new Registrant("Bob Smith", new DateTime(1970, 1, 1),
           new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            Registrant swimmer2 = new Registrant
            {
                Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3"),
                Name = "John Lee",
                PhoneNumber = 4162222222,
                DateOfBirth = new DateTime(1950, 12, 1)
            };
            Swimmer swimmer3 = new Swimmer("Ann Smith", new DateTime(1975, 1, 1),
            new Address("5 Queen St", "Toronto", "ON", "M2M 4M4"), 4163333333);
            //act
            newClub.AddSwimmer(swimmer1);
            string expectedSwimmerName = "Bob Smith";
            //assert
            //Assert.AreEqual(expectedSwimmerName, newClub.Swimmers[0].Name, "Swimmer is not same");
        }
        [TestMethod]
        public void Event_Seed_Same()
        {
            Event newEvent = new Event();
            Registrant swimmer1 = new Registrant("Bob Smith", new DateTime(1970, 1, 1),
           new Address("35 Elm St", "Toronto", "ON", "M2M 2M2"), 4161234567);
            Registrant swimmer2 = new Registrant
            {
                Address = new Address("1 King St", "Toronto", "ON", "M2M 3M3"),
                Name = "John Lee",
                PhoneNumber = 4162222222,
                DateOfBirth = new DateTime(1950, 12, 1)
            };

            newEvent.AddSwimmer(swimmer1);
            newEvent.AddSwimmer(swimmer2);

            newEvent.Seed(swimmer1, 1, 1);
            Assert.AreEqual(newEvent.EventInfo[0].Heat, 1);
        }
        [TestMethod]
        public void SwimMeet_AddEvent_Same()
        {
            SwimMeet swimMeet = new SwimMeet();
            Event[] events = new Event[10];
            Event _50free1 = new Event
            {
                Distance = EventDistance._50,
                Stroke = Stroke.Freestyle
            };
            //Act
            swimMeet.AddEvent(_50free1);
            EventDistance expectedDistance = EventDistance._50;
            //Assert
            Assert.AreEqual(expectedDistance, _50free1.Distance, "Distance is not Same");

        }
        [TestMethod]
        public void SwimMeet_CreateEvents_Same()
        {
            SwimMeet swimMeet = new SwimMeet();
            Event[] events = new Event[4];
            Event _50free1 = new Event
            {
                Distance = EventDistance._50,
                Stroke = Stroke.Freestyle
            };
            Event _100fly = new Event(EventDistance._100, Stroke.Butterfly);
            Event _200breast = new Event(EventDistance._200, Stroke.Breaststroke);
            Event _400free = new Event(EventDistance._400, Stroke.Freestyle);
            Event _1500free = new Event(EventDistance._1500, Stroke.Freestyle);

            //Act
            swimMeet.AddEvent(_50free1);
            swimMeet.AddEvent(_100fly);
            swimMeet.AddEvent(_200breast);
            swimMeet.AddEvent(_400free);
            swimMeet.AddEvent(_1500free);
            int expectedNumOfEvetns = 5;
            //Assert
            Assert.AreEqual(expectedNumOfEvetns, swimMeet.NumOfEvetns, "Number of Events are not Same");
        }
        [TestMethod]
        public void ClubsManager_Load_Same()
        {
            ClubsManager newClubsManager = new ClubsManager();

            newClubsManager.Load("Clubs.txt", ",");
            int ExpectedClubNumber = 3004;
            Assert.AreEqual(newClubsManager.Clubs[0].ClubNumber, ExpectedClubNumber, "Club number is not same");

        }
        [TestMethod]
        public void ClubsManager_Save_Same()
        {
            ClubsManager newClubsManager = new ClubsManager();
            for (int i = 0; i < newClubsManager.Number; i++)
            {
                Console.WriteLine(newClubsManager.Clubs[i].Name);
                Console.WriteLine("----");
            }

            Console.WriteLine("Clubs and registrants saved");
            string fileName = "NewClubs.txt";
            string delimiter = ",";
            newClubsManager.Save(fileName, delimiter);
            string ExpectedFileName = "NewClubs.txt";
            string ExpectedDelimiter = ",";
            Assert.AreEqual(ExpectedFileName, ExpectedDelimiter, fileName, delimiter, "File is not same");

        }
        //[TestMethod]
        //public void ClubsManager_Load_Same()
        //{
        //    ClubsManager newClbMng = new ClubsManager();
        //    //Console.WriteLine("Clubs and registrants loaded");
        //    string fileName = @"C:\A2\NewClubs.txt" ;
        //    string delimiter = ",";
        //    newClbMng.Load(fileName,delimiter);
        //    string ExpectedFileName = @"C:\A2\NewClubs.txt" ;
        //    string ExpectedDelimiter = ",";
        //    Assert.AreEqual(ExpectedFileName, ExpectedDelimiter, fileName, delimiter, "File is not same");
        //}

        [TestMethod]
        public void Event_ToString_Same()
        {
            Event TestEvent = new Event(EventDistance._100, Stroke.Butterfly);

            Assert.AreEqual(TestEvent.ToString(), $"\n{ TestEvent.Distance} \n{ TestEvent.Stroke}");

        }
        [TestMethod]
        public void Swim_ToString_Same()
        {
            Swim TestSwim = new Swim("00:30.13", 1, 1);

            Assert.AreEqual(TestSwim.ToString(), $"\n\t\t\t\t H{TestSwim.Heat}L{TestSwim.Lane}   time:{TestSwim.TimeSwam}");
        }

        [TestMethod]
        public void SwimMeet_ToString_Same()
        {
            SwimMeet TestSwimMeet = new SwimMeet("Toronto Meet", new DateTime(2017, 5, 21), new DateTime(2017, 5, 21), PoolType.LCM, 2);

            Assert.AreEqual(TestSwimMeet.ToString(), $"\nSweem meet name:{ TestSwimMeet.Name} \nFrom-to: { TestSwimMeet.StartDate:yyyy/MM/dd} to { TestSwimMeet.EndDate:yyyy/MM/dd}\nPool type: {TestSwimMeet.Type} \nNo lanes: {TestSwimMeet.NoOfLanes} \nEvent:");

        }
    }
}