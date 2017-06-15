using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_Circulares_Atención_de_procesos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int contPAtendido, contCVacios, contProcsFormados;
        private void btnAtender_Click(object sender, EventArgs e)
        {
            Random ciclosNecesariosPorProceso = new Random();
            Random probabilidad = new Random();

            Lista_circular lcircular = new Lista_circular();

            for (int ciclo = 1; ciclo <= 200; ciclo++) //200
            {
                if (probabilidad.Next(1, 100) <= 25)//25
                {
                    Proceso nuevo = new Proceso();
                    nuevo.tiempo = ciclosNecesariosPorProceso.Next(4, 12);
                    lcircular.agregar(nuevo);
                    contProcsFormados++;
                }
                if (lcircular.meter() != null)
                {
                    lcircular.meter().tiempo--;
                    if (lcircular.meter().tiempo == 0)
                        contPAtendido++;
                }
                else
                    contCVacios++;
            }

            int PPendientes = contProcsFormados - contPAtendido;
            txtResultados.Text = "";
            txtResultados.Text = "Procesos formados = " + contProcsFormados + Environment.NewLine + "Procesos atendidos = " + contPAtendido + Environment.NewLine + "Ciclos vacios = " + contCVacios + Environment.NewLine + "Procesaos pendientes = " + PPendientes;// + Environment.NewLine+ "Faltaron " + ldoble.quedaban() + " ciclos";
        }
    }
}
