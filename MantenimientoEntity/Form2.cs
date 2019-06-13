using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MantenimientoEntity
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbbprofesion.SelectedIndex = 0;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            DataAcces.Datos.Agregar(txtnombre.Text,txtapellido.Text,Convert.ToInt32(txtedad.Text),cbbprofesion.SelectedItem.ToString());
            MessageBox.Show("Registro Agregado...","Agregar Registro");
            this.Close();
        }
    }
}
