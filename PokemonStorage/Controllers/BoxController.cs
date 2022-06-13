using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokemonStorage.Models;
using DBHelper.DataAccess;

namespace PokemonStorage.Controllers
{
    public class BoxController : Controller
    {
        // GET: Box
        public ActionResult Box1()
        {
           
            List<Pokemon> pkm = new List<Pokemon>();
            foreach (var x in SqlDataAccess.LoadData<Pokemon>()) {
                pkm.Add(new Pokemon
                {
                    //TID = 2001,
                    PName = x.PName,
                    //PNickname = "Charizard",
                    PType = x.PType,
                    PLevel = x.PLevel,
                    PGender = x.PGender,
                    //PShiny = 0,
                    //PBox = 1
                });
            }
            
            
            System.Diagnostics.Debug.WriteLine("Before Load Data");
            
            return View(pkm);
        }
    }
}