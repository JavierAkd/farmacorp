using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Capanegocio
{
   public class Csucursal:Capadatos.Datos
    {

       public DataTable infoSucursal() {

           string s = "select idsucursal,nombre_sucursal from Sucursal";

           return consultar(s);
       }
    }
}
