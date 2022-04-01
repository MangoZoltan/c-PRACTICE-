using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Munkavallalo
    {
        public string vezNev;
        public string kerNev;
        public DateTime szul;
        public string munkakor;
        public Munkavallalo(string vezNev, string kerNev, DateTime szul, string munkakor)
        {
            this.vezNev = vezNev;
            this.kerNev = kerNev;
            this.szul   = szul;
            this.munkakor = munkakor;
        }
    }
}
