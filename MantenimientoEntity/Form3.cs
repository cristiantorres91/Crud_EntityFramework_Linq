using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAcces;

namespace MantenimientoEntity
{
    public partial class Form3 : Form
    {
        private int id;
        public Form3(int idempleado)
        {
            InitializeComponent();
            id = idempleado;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // se carga el registro que se quiere editar
             cbbprofesion.SelectedIndex = 0;
             Personas persona = Datos.ObtenerId(id);
             id = persona.Id;
             txtnombre.Text = persona.Nombre;
             txtapellido.Text = persona.Apellido;
             txtedad.Text = persona.Edad.ToString();           
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            Datos.Editar(id,txtnombre.Text,txtapellido.Text,Convert.ToInt32(txtedad.Text),cbbprofesion.SelectedItem.ToString());
            MessageBox.Show("Registro Actualizado...", "Actualizar Registro");
            this.Close();
        }
    }
}
