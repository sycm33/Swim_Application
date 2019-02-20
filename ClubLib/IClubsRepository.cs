using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubLib
{
    public interface IClubsRepository
    {
        void Add(Club club);
        void Save(string fileName, string delimiter);
        void Load(string fileName, string delimiter);
        int Number { get; set; }

    }
}
