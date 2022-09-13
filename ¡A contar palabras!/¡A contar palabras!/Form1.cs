using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _A_contar_palabras_
{
    public partial class frmContPalabra : Form
    {
        private Dictionary<string, int> diccionario;
        private List<string> palabrasLista;
        private List<KeyValuePair<string, int>> palabras;
        public frmContPalabra()
        {
            diccionario = new Dictionary<string, int>();
            palabrasLista = new List<string>();
            palabras = new List<KeyValuePair<string, int>>();
            InitializeComponent();
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            diccionario.Clear();
            palabrasLista.Clear();
            ContarPalabras(rtbTexto.Text);
            MessageBox.Show(Mostrar());
        }

        public void ContarPalabras(string texto)
        {
            string palabraToLower;
            char[] separacion = new char[] { ' ', ',', '.', ':', '\t', '\n' };
            palabrasLista.AddRange(texto.Split(separacion));

            foreach (string palabra in palabrasLista)
            {
                palabraToLower = palabra.ToLower();
                if (!diccionario.ContainsKey(palabraToLower) && palabraToLower != " ")
                {
                    diccionario.Add(palabraToLower, 1);
                }
                else
                {
                    diccionario[palabraToLower] += 1;
                }
            }

        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;

            palabras= diccionario.ToList();
            palabras.Sort(OrdenarLista);
            palabras.Reverse();
            diccionario.Clear();
            diccionario = palabras.ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> elemento in diccionario)
            {
               if (i != 3)
                { 
                    i += 1;
                }
                else
                {
                    break;
                }
                sb.Append($"{elemento.Key} - {elemento.Value} \n");
            }
            return sb.ToString();
        }

        private int OrdenarLista(KeyValuePair<string, int> elemento1, KeyValuePair<string, int> elemento2)
        {
            return elemento1.Value - elemento2.Value;
        }


    }
}
