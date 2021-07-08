using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fluje.Model;

namespace Fluje
{
    public partial class Form1 : Form
    {
        public FNEModel fneModel { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            float inversion= float.Parse(txtInversion.Text);
            int plazo = Int32.Parse(txtPlazo.Text);
            float tasa = float.Parse(txtTasa.Text);
            float[] Ingresos = new float[plazo];
            float[] Egresos = new float[plazo];
            float inflacion = float.Parse(txtInflacion.Text);
            float[] Depreciacion1 = new float[plazo];
            float[] VS = new float[plazo];
            float[] UAI = new float[plazo];
            float[] Ir = new float[plazo];
            float[] UDI = new float[plazo];
            float[] Depreciacion2 = new float[plazo];
            float[] Fne = new float[plazo + 1];

            float primer_ingreso = float.Parse(txtPrimerIngreso.Text);
            float primer_egreso = float.Parse(txtPrimerEgreso.Text);
            float valorSalvamento = float.Parse(txtVS.Text);
           
            

            AddHeaders(plazo);

            dgvFlujo.Rows[0].Cells[1].Value = inversion;
            
            calculoIngresos(primer_ingreso, inflacion, plazo, Ingresos);
            MostrarIngresos(Ingresos);

            calculoEgresos(primer_egreso, inflacion, plazo, Egresos);
            MostrarEgresos(Egresos);

            calculoDepreciacion(inversion,valorSalvamento, plazo, Depreciacion1);


            MostrarValorSalvamento(VS, valorSalvamento);
            calculoUAI();
            

        }

        private void MostrarEgresos(float[] egresos)
        {
            for (int i = 0; i < egresos.Length; i++)
            {
                dgvFlujo.Rows[2].Cells[i + 2].Value = egresos[i];
            }
        }

        private void calculoEgresos(float primer_egreso, float inflacion, int plazo, float[] egresos)
        {
            for (int i = 0; i <egresos.Length; i++)
            {
                if (i == 0)
                {
                    egresos[i] = primer_egreso;
                }
                else
                {
                    egresos[i] = egresos[i - 1] + (egresos[i - 1] * (inflacion / 100));
                }
            }
        }

        private void MostrarValorSalvamento(float[] vS, float valorSalvamento)
        {
            for (int i = 0; i < vS.Length; i++)
            {
                vS[i] = valorSalvamento;
                dgvFlujo.Rows[4].Cells[i + 2].Value = valorSalvamento;
            }
        }

        private void MostrarIngresos(float[] ingresos)
        {
            for (int i = 0; i < ingresos.Length; i++)
            {
                dgvFlujo.Rows[1].Cells[i + 2].Value = ingresos[i];
            }
        }

        private void calculoUAI()
        {
            for (int  i = 2;  i < dgvFlujo.ColumnCount;  i++)
            {
                float ingresos = float.Parse(dgvFlujo.Rows[1].Cells[i].Value.ToString());
                float egresos = float.Parse(dgvFlujo.Rows[2].Cells[i].Value.ToString());
                float depreciacion = float.Parse(dgvFlujo.Rows[3].Cells[i].Value.ToString());
                float vs = float.Parse(dgvFlujo.Rows[4].Cells[i].Value.ToString());
                dgvFlujo.Rows[5].Cells[i].Value = ingresos- egresos - depreciacion + vs;
            }
        }

        private void calculoDepreciacion(float inversion,float valorSalvamento, int plazo, float[] depreciacion1)
        {
            float depreciar = inversion - valorSalvamento;

            for (int i = 2; i < dgvFlujo.ColumnCount; i++)
            {
                dgvFlujo.Rows[3].Cells[i].Value = depreciar / plazo;
            }

            for (int i = 0; i < depreciacion1.Length; i++)
            {
                depreciacion1[i] = depreciar / plazo;
            }
        }

        private void calculoIngresos(float primer_ingreso, float inflacion, int plazo, float[] Ingresos)
        {
            for (int i = 0; i < Ingresos.Length; i++)
            {
                if (i == 0)
                {
                    Ingresos[i] = primer_ingreso;
                }
                else
                {
                    Ingresos[i] = Ingresos[i - 1] + (Ingresos[i - 1] * (inflacion / 100));
                }
            }
        }

        public void AddHeaders(int plazo) {
            dgvFlujo.ColumnCount = plazo + 2;

            for (int i = 0; i < plazo + 2; i++)
            {
                if (i == 0)
                {
                    dgvFlujo.Columns[0].Name = "";


                    continue;
                }
                dgvFlujo.Columns[i].Name = " " + (i - 1);
            }

            dgvFlujo.RowCount = 10;
            dgvFlujo.Rows[0].Cells[0].Value = "Inversión";
            dgvFlujo.Rows[1].Cells[0].Value = "Ingresos";
            dgvFlujo.Rows[2].Cells[0].Value = "Egresos";
            dgvFlujo.Rows[3].Cells[0].Value = "Depreciación";
            dgvFlujo.Rows[4].Cells[0].Value = "V.S";
            dgvFlujo.Rows[5].Cells[0].Value = "UAI";
            dgvFlujo.Rows[6].Cells[0].Value = "IR";
            dgvFlujo.Rows[7].Cells[0].Value = "UDI";
            dgvFlujo.Rows[8].Cells[0].Value = "Depreciación";
            dgvFlujo.Rows[9].Cells[0].Value = "FNE";
        }
            
    }
}
