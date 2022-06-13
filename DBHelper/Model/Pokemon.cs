using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int TID { get; set; }
        public string PName { get; set; }
        public string PNickname { get; set; }
        public string PType { get; set; }
        public int PLevel { get; set; }
        public string PGender { get; set; }
        public int PShiny { get; set; }
        public int PBox { get; set; }
    }
}
