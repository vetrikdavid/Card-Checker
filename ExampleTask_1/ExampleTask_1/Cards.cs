using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTask_1
{
    class Cards
    {
        string pid; //kártya azonosító
        string byr; //születési év
        string cid; //születési ország
        string iyr; //kártya kiállításának éve)
        string eyr; //lejárati dátum
        string hgt; //magasság
        string hcl; //hajszín
        string ecl; //szemszín

        public string _pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public string _byr
        {
            get { return byr; }
            set { byr = value; }
        }

        public string _cid
        {
            get { return cid; }
            set { cid = value; }
        }

        public string _iyr
        {
            get { return iyr; }
            set { iyr = value; }
        }

        public string _eyr
        {
            get { return eyr; }
            set { eyr = value; }
        }
        public string _hgt
        {
            get { return hgt; }
            set { hgt = value; }
        }
        public string _hcl
        {
            get { return hcl; }
            set { hcl = value; }
        }
        public string _ecl
        {
            get { return ecl; }
            set { ecl = value; }
        }
    }
}
