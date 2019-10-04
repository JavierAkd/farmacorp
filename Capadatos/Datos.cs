using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace Capadatos
{
    public class Datos
    {
        private OleDbConnection conectar()
        {
            string cc = (@"Provider=SQLOLEDB.1;Data Source=.;Initial Catalog=Farmacorp_;Integrated Security=SSPI");
            OleDbConnection conex = new OleDbConnection(cc);
            conex.Open();
            return conex;
        }
        protected OleDbTransaction iniciarTransaccion()
        {
            OleDbConnection conex = conectar();
            return conex.BeginTransaction();
        }
        protected DataTable consultar(string s)
        {
            OleDbTransaction tr = iniciarTransaccion();
            return consultar(s, tr);
            tr.Commit();
        }
        protected DataTable consultar(string s, object tr)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter(s, ((OleDbTransaction)(tr)).Connection);
            ada.SelectCommand.Transaction = (OleDbTransaction)(tr);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }
        protected int ejecutar(string s)
        {
            OleDbTransaction tr = iniciarTransaccion();
            int i = ejecutar(s, tr);
            tr.Commit();
            return i;
        }
        protected int ejecutar(string s, object tr)
        {
            try
            {
                OleDbCommand comando = new OleDbCommand(s, ((OleDbTransaction)(tr)).Connection);
                comando.Transaction = (OleDbTransaction)(tr);
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
