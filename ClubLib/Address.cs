
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClubLib
{
    [Serializable]
    public struct Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Zip { get; set; }
        public Address(string street, string city, string province, string zip)
        {

            Street = street;
            City = city;
            Province = province;
            Zip = zip;
        }


    }
}
