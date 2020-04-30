using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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
                new MySqlCommand("SELECT * FROM usuario where DNI = @DNI", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {

                    string passwordConHash = resultado.GetString(3);
                    if (BCrypt.Net.BCrypt.Verify(CONTRASEÑA, passwordConHash))
                    {

                        return true;

                    }
                    return false;
                }



                conexion.Close();
                return false;
            }

            catch (MySqlException e)
            {
                return false;
            }


        }

        public String insertaUsuario(String DNI, String NOMBRE, String CONTRASEÑA)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO usuario (ID, DNI, NOMBRE, CONTRASEÑA) VALUES (NULL, @DNI, @NOMBRE, @CONTRASEÑA)", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@NOMBRE", NOMBRE);
                consulta.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "USUARIO CREADO";
            }
            catch (MySqlException e)
            {
                return "error";
            }

        }

        public String insertaCliente(String DNI, String NOMBRE, String APELLIDOS, String TELEFONO1,
            String TELEFONO2, String EMAIL, String DIRECCION, String LOCALIDAD)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO cliente (ID, DNI, NOMBRE, APELLIDOS, TELEFONO1,TELEFONO2, EMAIL, DIRECCION, LOCALIDAD) " +
                "VALUES (NULL, @DNI, @NOMBRE, @APELLIDOS, @TELEFONO1, @TELEFONO2, @EMAIL, @DIRECCION, @LOCALIDAD)", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@NOMBRE", NOMBRE);
                consulta.Parameters.AddWithValue("@APELLIDOS", APELLIDOS);
                consulta.Parameters.AddWithValue("@TELEFONO1", TELEFONO1);
                consulta.Parameters.AddWithValue("@TELEFONO2", TELEFONO2);
                consulta.Parameters.AddWithValue("@EMAIL", EMAIL);
                consulta.Parameters.AddWithValue("@DIRECCION", DIRECCION);
                consulta.Parameters.AddWithValue("@LOCALIDAD", LOCALIDAD);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "CLIENTE REGISTRADO";
            }
            catch (MySqlException e)
            {

                return "error cliente";
            }

        }

        public String insertaMascota(String NOMBRE, String DUEÑO, String IDEM, String ANIMAL, String RAZA, String VETERINARIO,
            String EDAD)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                new MySqlCommand("INSERT INTO mascota (ID, NOMBRE, DUEÑO, IDEM, ANIMAL, RAZA, VETERINARIO, EDAD) " +
                "VALUES (NULL, @NOMBRE, @DUEÑO, @IDEM, @ANIMAL, @RAZA, @VETERINARIO, @EDAD)", conexion);
                consulta.Parameters.AddWithValue("@NOMBRE", NOMBRE);
                consulta.Parameters.AddWithValue("@DUEÑO", DUEÑO);
                consulta.Parameters.AddWithValue("@IDEM", IDEM);
                consulta.Parameters.AddWithValue("@ANIMAL", ANIMAL);
                consulta.Parameters.AddWithValue("@RAZA", RAZA);
                consulta.Parameters.AddWithValue("@VETERINARIO", VETERINARIO);
                consulta.Parameters.AddWithValue("@EDAD", EDAD);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "MASCOTA REGISTRADO";
            }
            catch (MySqlException e)
            {

                return "error cliente";
            }
        }

        public DataTable getMascota(string NOMBRE)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM mascota where NOMBRE ='" + NOMBRE + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable veterinary = new DataTable();
                veterinary.Load(resultado);
                conexion.Close();
                return veterinary;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public DataTable getCliente(string NOMBRE)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM cliente where NOMBRE ='" + NOMBRE + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable veterinary = new DataTable();
                veterinary.Load(resultado);
                conexion.Close();
                return veterinary;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public DataTable getTodasMascotas()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM mascota", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable veterinary = new DataTable();
                veterinary.Load(resultado);
                conexion.Close();
                return veterinary;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public DataTable getTodosClientes()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM cliente", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable veterinary = new DataTable();
                veterinary.Load(resultado);
                conexion.Close();
                return veterinary;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }


}

