using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Almacen_Farmacorp
{
    public partial class frmEmpleado : MetroFramework.Forms.MetroForm
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        Capanegocio.Csucursal ISu = new Capanegocio.Csucursal();
        Capanegocio.Cempleado Cem = new Capanegocio.Cempleado();
        Capacontrol.CControl CC = new Capacontrol.CControl();

        public bool datoseliminarusuario()
        {
            var tr = CC.iniTR();
            if (eliminarusuario(tr))
            {
                CC.finTR(tr);
                return true;
            }
            return false;

        }
        
        public bool datoactualizarempleado()
        {
            var tr = CC.iniTR();
            if (actualizarempleado(tr))
            {
                CC.finTR(tr);
                return true;
            }
            return false;

        }

        public bool DatosUsuario() {
            var tr = CC.iniTR();
            if (insertarusuario(tr)) {
                CC.finTR(tr);
                return true;
            }
            return false;
        
        }
        public bool DatosEmpleado()
        {
            var tr = CC.iniTR();
            if (insertarEmpleado(tr))
            {
                CC.finTR(tr);
                return true;
            }
            return false;

        }
        string idusuario;
        public void generarCodigoUsuario()
        {
            List<DataRow> l = new List<DataRow>();
            DataTable d = new DataTable();
            d = Cem.generaridusuario();

            foreach (DataRow item in d.Rows)
            {
                l.Add((DataRow)item);
            }
            l = d.AsEnumerable().ToList();
            try
            {
                if (l[0][0].ToString() != "")
                {

                    idusuario = l[0][0].ToString();
                }

                else
                {

                    idusuario = "1";
                }
            }
            catch
            {
                idusuario = "1";
            }

        }
        public void GenerarCodigo()
        {
            List<DataRow> l = new List<DataRow>();
            DataTable d = new DataTable();
            d = Cem.generaridEmpleado();

            foreach (DataRow item in d.Rows)
            {
                l.Add((DataRow)item);
            }
            l = d.AsEnumerable().ToList();
            try
            {
                if (l[0][0].ToString() != "")
                {

                    txtid.Text = l[0][0].ToString();
                }

                else
                {

                    txtid.Text = "1";
                }
            }
            catch
            {

                txtid.Text = "1";
            }

        }
        public void traerempleado() {
            DataTable d = new DataTable();
            d = Cem.traerempleado();
            cbxtraeridempleado.DataSource = d;
            cbxtraeridempleado.DisplayMember = "nombre_empleado";
            cbxtraeridempleado.ValueMember = "idempleado";
        
        }
        public void infosucural() {
            DataTable s = new DataTable();
            s = ISu.infoSucursal();
            cbxSucursal.DataSource = s;
            cbxSucursal.DisplayMember = "nombre_sucursal";
            cbxSucursal.ValueMember = "idsucursal";
        }
      
       
        public bool insertarEmpleado(object tr) {


            Cem.v[0] = txtid.Text;
            Cem.v[1] = txtnombre.Text;
            Cem.v[2] = txtApp.Text;
            Cem.v[3] = txtapm.Text;
            Cem.v[4] = cbxSucursal.SelectedValue.ToString();
            Cem.v[5] = cbxestado.SelectedIndex.ToString();
            if(Cem.insertarEmpleado(tr)==0){
                CC.deshacerTR(tr);

                MessageBox.Show("error en los datos de empleado");
                return false;
            }
            return true;
        }

        public bool insertarusuario(object tr) {
            generarCodigoUsuario();
            Cem.v[6] = idusuario;
            Cem.v[7] = txtlogin.Text;
            Cem.v[8] = txtpass.Text;
            Cem.v[9] = txtid.Text;
            Cem.v[10] = cbxrango.SelectedIndex.ToString();
            if (Cem.insertarusuarioEmpleado(tr) == 0)
            {
                CC.deshacerTR(tr);

                MessageBox.Show("error en los datos de usuario");
                return false;
            }
            return true;

        
        }
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            traerempleado();
            GenerarCodigo();
            infosucural();
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.ToString() == "0" || comboBox1.SelectedIndex.ToString() == "-1")
            {
                if (DatosEmpleado())
                {

                    DatosUsuario();
                }
            }
            else if (comboBox1.SelectedIndex.ToString() == "1")
            {
                datoactualizarempleado();
                if (cbxestado.SelectedIndex.ToString() == "0")
                {
                    datoseliminarusuario();
                }
            
            }
        }

        private void cbxestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxestado.SelectedIndex.ToString() == "0")
            {
                txtlogin.Enabled = false;
                txtpass.Enabled = false;
            }
            else {
                txtlogin.Enabled = true;
                txtpass.Enabled = true;
            }
            }
        public void comboboxid() {
            string combo = comboBox1.SelectedIndex.ToString();
            if (combo == "0" || combo == "-1")
            {
                txtid.Visible = true;
                cbxtraeridempleado.Visible = false;
            }
            else if (combo == "1")
            {
                txtid.Visible = false;
                cbxtraeridempleado.Visible = true;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxid();

        
        }


        public void generardatosEmpleado() {
            string idprincipal = cbxtraeridempleado.SelectedValue.ToString(); ;

            List<DataRow> l = new List<DataRow>();
            DataTable d = new DataTable();

            d = Cem.traerDatosEmpleadoUsuario(idprincipal);

            foreach (DataRow item in d.Rows)
            {
                l.Add((DataRow)item);
            }
            l = d.AsEnumerable().ToList();

            txtnombre.Text = l[0][0].ToString();
           txtApp.Text = l[0][1].ToString();
            txtapm.Text=l[0][2].ToString();
            txtlogin.Text = l[0][3].ToString();
     txtpass.Text= l[0][4].ToString();

            }

        public bool actualizarempleado(object tr) {

            Cem.v2[5]=cbxtraeridempleado.SelectedValue.ToString();

            Cem.v2[0] = txtnombre.Text;
            Cem.v2[1] = txtApp.Text;
            Cem.v2[2] = txtapm.Text;
            Cem.v2[3] = cbxSucursal.SelectedValue.ToString();
            Cem.v2[4] = cbxestado.SelectedIndex.ToString();
            if (Cem.ActualizarEmpleado(tr) == 0)
            {
                CC.deshacerTR(tr);

                MessageBox.Show("error en los datos de empleado");
                return false;
            }
            return true;

        


        }
        public bool eliminarusuario(object tr) {
            Cem.v3[0] = cbxtraeridempleado.SelectedValue.ToString();


            if (Cem.eliminarUsuario(tr) == 0)
            {
                CC.deshacerTR(tr);

                MessageBox.Show("error en los datos de empleado");
                return false;
            }
            return true;

        
        }
        private void cbxtraeridempleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            generardatosEmpleado();

        }

       

   



       
   
    }
}
