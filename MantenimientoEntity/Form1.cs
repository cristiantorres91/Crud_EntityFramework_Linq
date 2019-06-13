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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void cargar()
        {
            dataGridView1.DataSource = Datos.CargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Datos.Buscar(txtnombre.Text);
        }


        //cargar datos al cerrar form agregarregistro y actualizar
        private void obj_FormClosed(object sender, FormClosedEventArgs e)
        {
            cargar();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            //abrir el otro formulario y actualizar datagrid al cerrarlo
            obj.FormClosed += new System.Windows.Forms.FormClosedEventHandler(obj_FormClosed);
            obj.Show();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            int id = Convert.ToInt32(row.Cells[0].Value);

            Form3 obj = new Form3(id);
            obj.FormClosed += new System.Windows.Forms.FormClosedEventHandler(obj_FormClosed);
            obj.Show();

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Seguro que quiere eliminar el Registro?", "Eliminar Registro", MessageBoxButtons.YesNo);
            if (resul == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                int idpersona = Convert.ToInt32(row.Cells[0].Value);
                Datos.Eliminar(idpersona);
                MessageBox.Show("Se Elimino el Registro Con Numero ID: " + idpersona, "Eliminar Registro");
                cargar();
            }
        }
    }
}
