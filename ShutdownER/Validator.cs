using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownER
{
    class Validator
    {
        public bool Check(string hour, string min, string sec)
        {
            if (Convert.ToInt32(hour) > 24) return false;
            if (Convert.ToInt32(hour) < 0) return false;
            if (Convert.ToInt32(min) > 60) return false;
            if (Convert.ToInt32(min) < 0) return false;
            if (Convert.ToInt32(sec) > 60) return false;
            if (Convert.ToInt32(sec) < 0) return false;
            return true;

        }
    }
}
