using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

namespace Capacontrol
{
    public class CControl:Capadatos.Datos
    {

      
            public OleDbTransaction iniTR()
            {
                return iniciarTransaccion();
            }
            public void finTR(OleDbTransaction tr)
            {
                tr.Commit();
            }
            public void deshacerTR(object tr)
            {
                ((OleDbTransaction)(tr)).Rollback();
            }
        }
    }

