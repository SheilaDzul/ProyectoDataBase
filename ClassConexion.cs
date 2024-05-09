using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Cinema
{
    internal class ClassConexion
    {
        public string vServidor { get; set; }
        public string vUsuario { get; set; }
        public string vPassword { get; set; }
        public string vBaseDeDatos { get; set; }


        public static MySqlConnection SQLConnection = new MySqlConnection();
        string vServerString = "";
        string vEstatus_Conexion = "";


        public int ABRIR_CONEXION_DB_MYSQL(ClassConexion vObjConexion)
        {
            
            globales.vBaseDeDatosConnect_Global = vObjConexion.vBaseDeDatos;
            globales.vPassUsuarioINIConnect_Global = vObjConexion.vPassword;
            globales.vUsuarioINIConnect_Global = vObjConexion.vUsuario;
            globales.vServidorConnect_Global = vObjConexion.vServidor;

        


            int vResultado = 1;
            vServerString = ("Server="
                        + (vObjConexion.vServidor + (";" + ("user Id="
                        + (vObjConexion.vUsuario + (";" + ("Password="
                        + (vObjConexion.vPassword + (";" + ("Database=" + vObjConexion.vBaseDeDatos))))))))));
            SQLConnection.Close();
            SQLConnection.ConnectionString = vServerString;
            try
            {
                //Si la cadenna esta cerrada 
                if ((SQLConnection.State == ConnectionState.Closed))
                {

                    SQLConnection.Open();
                    vResultado = 0;
                    vEstatus_Conexion = "OPEN";
                    return vResultado;
                }
                else
                {
                    SQLConnection.Close();
                    vResultado = 1;
                    vEstatus_Conexion = "CLOSE";
                    return vResultado;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

            return vResultado;
        }

    }
}
