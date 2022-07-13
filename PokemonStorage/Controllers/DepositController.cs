using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokemonStorage.Models;
using DBHelper.DataAccess;

//https://www.c-sharpcorner.com/article/handle-multiple-buttons-in-same-form-in-mvc/

namespace PokemonStorage.Controllers
{
    public class DepositController : Controller
    {
        // GET: Add
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Pokemon pkm, string action)
        {
            if (action == "Deposit") {
                System.Diagnostics.Debug.WriteLine("Add try: " + pkm.PName);

                //pkm
                DBHelper.Model.Pokemon pkmList = new DBHelper.Model.Pokemon()
                {
                    TID = pkm.TID,
                    PName = pkm.PName,
                    PNickname = pkm.PNickname,
                    PLevel = pkm.PLevel,
                    PGender = pkm.PGender,
                    PType = pkm.PType,
                    PShiny = pkm.PShiny,
                    PBox = pkm.PBox
                };

                SqlDataAccess.DepositPokemon(pkmList);
            }
            else if (action == "Clear") {
                System.Diagnostics.Debug.WriteLine("clear");
            }
            
            return View();
        }
    }
}