using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubLib
{
    [Serializable]
    public static class RegNoGenerator
    {
        static int registrationCounter = 0;

        public static int GetRegNo()
        {
            ++registrationCounter;
            return registrationCounter;
        }
    }
}
