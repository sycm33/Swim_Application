using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubLib
{
    public interface ISwimmersRepository
    {
        void Add(Registrant swimmers);
        void Save(string fileName, string delimiter);
        void Load(string fileName, string delimiter);
         int Number { get; set; }
    }
}
