﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DBHelper.Model;

namespace DBHelper.DataAccess
{
    public class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName) {
            System.Diagnostics.Debug.WriteLine("");
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<Pokemon> LoadData<T>() {
            List<Pokemon> PokemonList = new List<Pokemon>();
            SqlConnection con = new SqlConnection(GetConnectionString("GameFreakDB"));
            con.Open();
            string cmdstr = "select * from Pokemon";
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            cmd.ExecuteNonQuery();
            using (SqlDataReader dr = cmd.ExecuteReader()) {
                while (dr.HasRows) {
                    while (dr.Read())
                    {
                        PokemonList.Add(
                            new Pokemon(){
                                PName = dr.GetString(2),
                                PType = dr.GetString(4),
                                PLevel = dr.GetInt32(5),
                                PGender = dr.GetString(6)
                            }
                            );
                        System.Diagnostics.Debug.WriteLine("Pokemon: " + dr.GetString(2));
                    }
                    dr.NextResult();
                }
                dr.Close();
            }
            con.Close();
            return PokemonList;
        }
    }
}
