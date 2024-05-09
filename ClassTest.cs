using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace Cinema
{
    internal class ClassTest
    {
        //va a abrir una cadena 
        public DataTable ListarRegistros(string vSQL)
        {

            MySqlDataAdapter vAdaptador = new MySqlDataAdapter(vSQL, ClassConexion.SQLConnection);
            DataTable vTable = new DataTable();
            vAdaptador.Fill(vTable);

            ClassConexion.SQLConnection.Close();
            ClassConexion.SQLConnection.Dispose();

            return vTable;

        }


    }
}
