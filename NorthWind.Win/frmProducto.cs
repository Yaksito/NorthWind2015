using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind.Win
{
    public partial class frmProducto : Form
    {

        public event EventHandler<TbProductoBE> OnProductoSeleccionado;
        
        public frmProducto()
        {
            InitializeComponent();
        }
        List<TbProductoBE> Lista = new List<TbProductoBE>();

        private void AgregarProductoFactura()
        {
            //agregar cliente al formulario documento
            int i = dataGridView1.CurrentRow.Index;
            int codigoproducto = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            //query en LINQ
            TbProductoBE oProducto = (from item in Lista.ToArray()
                                    where item.CodProducto == codigoproducto
                                    select item).Single();
            OnProductoSeleccionado(new object(), oProducto);
            this.Close();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            Lista = TbProductoBE.SelectAll();
            productobindingSource.DataSource = Lista;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProductoFactura();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                AgregarProductoFactura();
            }
        }
    }
}
