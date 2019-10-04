using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Capanegocio
{
    public class Cempleado:Capadatos.Datos
    {
        public string [] v= new string[11];


        public int insertarEmpleado(object tr) {

            string s = "insert into Empleado values(#v1,'#v2','#v3','#v4',#v5,#v6)";

            s = s.Replace("#v1",v[0]);
            s = s.Replace("#v2",v[1]);
            s = s.Replace("#v3",v[2]);
            s = s.Replace("#v4",v[3]);
            s = s.Replace("#v5",v[4]);
            s = s.Replace("#v6", v[5]);

            return ejecutar(s,tr);
        }
        public int insertarusuarioEmpleado(object tr) {

            string s = "insert into Usuario values(#v1,'#v2','#v3',#v4,#v5)";

            s = s.Replace("#v1", v[6]);
            s = s.Replace("#v2", v[7]);
            s = s.Replace("#v3", v[8]);
            s = s.Replace("#v4", v[9]);
            s = s.Replace("#v5", v[10]);


            return ejecutar(s, tr);
        
        }

        public DataTable generaridEmpleado() {
            string s = "select max(idempleado)+1 from empleado";
         return   consultar (s);
        }

        public DataTable generaridusuario() {

            string s = "select max(idusuario)+1 from usuario";
            return consultar(s);
        }
        public DataTable traerempleado() {

            string s = "select idempleado, nombre_empleado from empleado";
            return consultar (s);
        }
    
        public DataTable traerDatosEmpleadoUsuario(string id) {
            string s = "select em.nombre_empleado,em.ap_paterno,em.ap_materno,us.login,us.contra from empleado em inner join Usuario us on us.idempleado=em.idempleado  where em.idempleado="+id;
            
            
            return consultar(s);
        }
        public string[] v2 = new string[7];

        public int ActualizarEmpleado(object tr)
        {

            string s = "update empleado set nombre_empleado='#v1', ap_paterno='#v2', ap_materno='#v3', idsucursal=#v4, estado=#v5 where idempleado=" +v2[5].ToString();

            s = s.Replace("#v1", v2[0]);
            s = s.Replace("#v2", v2[1]);
            s = s.Replace("#v3", v2[2]);
            s = s.Replace("#v4", v2[3]);
            s = s.Replace("#v5", v2[4]);

            return ejecutar(s, tr);
        }

        public string[] v3 = new string[1];
            public int eliminarUsuario(object tr)
        {

            string s = "delete from Usuario where idempleado=" + v3[0].ToString();

          

            return ejecutar(s, tr);
        }
        public int ActualizarUsuario(object tr)
        {

            string s = "insert into Usuario values(#v1,'#v2','#v3',#v4,#v5)";

            s = s.Replace("#v1", v2[6]);
            s = s.Replace("#v2", v2[7]);
            s = s.Replace("#v3", v2[8]);
            s = s.Replace("#v4", v2[9]);
            s = s.Replace("#v5", v2[10]);


            return ejecutar(s, tr);

        }



    }
}
