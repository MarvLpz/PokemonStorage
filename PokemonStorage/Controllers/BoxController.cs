using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokemonStorage.Models;
using DBHelper.DataAccess;
//https://www.youtube.com/watch?v=SABg7RyjX-4 partial view
namespace PokemonStorage.Controllers
{
    public class BoxController : Controller
    {
        public List<Pokemon> GetPokemonList() {
            List<Pokemon> pkm = new List<Pokemon>();
            foreach (var x in SqlDataAccess.LoadData<Pokemon>())
            {
                pkm.Add(new Pokemon
                {
                    TID = x.TID,
                    PName = x.PName,
                    //PNickname = "Charizard",
                    PType = x.PType,
                    PLevel = x.PLevel,
                    PGender = x.PGender,
                    //PShiny = 0,
                    //PBox = 1
                });
            }
            return pkm;
        }

        public Pokemon GetPokemon(int TID, string PName)
        {
            SqlDataAccess.GetPokemon(TID, PName);
            Pokemon pkm = new Pokemon
                {
                    TID = SqlDataAccess.GetPokemon(TID, PName).TID,
                    PName = SqlDataAccess.GetPokemon(TID, PName).PName,
                    PType = SqlDataAccess.GetPokemon(TID, PName).PType,
                    PLevel = SqlDataAccess.GetPokemon(TID, PName).PLevel,
                    PGender = SqlDataAccess.GetPokemon(TID, PName).PGender,
                };
            return pkm;
        }
        // GET: Box
        public ActionResult Box1()
        {
            System.Diagnostics.Debug.WriteLine("Before Load Data"); 
            return View(GetPokemonList());
        }
        //NEXT use pass pkm model as argument to return partial view
        public ActionResult Popup( int TID, string name)
        {
            System.Diagnostics.Debug.WriteLine("PopupView Clicked " + SqlDataAccess.GetPokemon(TID, name).PName);
            return PartialView(GetPokemon(TID, name));
        }
    }
}