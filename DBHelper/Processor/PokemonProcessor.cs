using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Model;
using DBHelper.DataAccess;


namespace DBHelper.Processor
{
    public class PokemonProcessor
    {
        public static void LoadPokemons() {
            SqlDataAccess.LoadData<Pokemon>();
        }
    }
}
