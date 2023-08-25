using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; 

namespace Gestion_de_Gastos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            StreamReader sr = new StreamReader("Conceptos.txt");
            string linea = "";
            while (sr.EndOfStream== false)
            {

                linea = sr.ReadLine();
                cboConcepto.Items.Add(linea);

            }

            sr.Close();
            sr.Dispose();
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal importe = Convert.ToDecimal(txtmporte.Text);
                if (importe > 0)
                {
                    StreamWriter sw = new StreamWriter("Gastos.txt", true);

                    sw.Write(dtpFecha.Text);
                    sw.Write(",", " ");
                    sw.Write(cboConcepto.Text);
                    sw.Write(",", " ");
                    sw.WriteLine(txtmporte.Text);

                    sw.Close();
                    sw.Dispose();
                    cboConcepto.SelectedIndex = 0;
                    txtmporte.Text = " ";

                }
                else 
                {
                    MessageBox.Show("Ingrese un valor mayor a 0", "AVISO");
                }


                

            } 
            catch (Exception ex)
            {
                MessageBox.Show("Verifique los datos ingresados","ERROR");
            }
            
        }
    }
}
