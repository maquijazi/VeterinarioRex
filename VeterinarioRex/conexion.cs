using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeterinarioRex
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 192.168.138.148; Database = veterinario; Uid = root; Pwd =; Port = 3306");
        }

        public Boolean loginVeterinario(String DNI, String CONTRASEÑA)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                //new MySqlCommand("SELECT * FROM usuario where DNI ='" + DNI + "' AND CONTRASEÑA = '" + CONTRASEÑA + "'", conexion);
                new MySqlCommand("SELECT * FROM usuario where DNI = @DNI AND CONTRASEÑA = @CONTRASEÑA", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    return true; //resultado.GetString(0);
                }

                conexion.Close();

                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }

        }
    }
}

