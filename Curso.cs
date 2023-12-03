using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAB_AED_2023.EstruturaDados;

namespace TRAB_AED_2023
{

    internal class Curso
    {
        public string nome { get; set; }
        public int qtdVagas { get; set; }
        public List<Candidato> listaDeEspera = new List<Candidato>();
        public Fila selecionados;
        public double notaDeCorte { get; set; }

        public Curso(int qtdVagas)
        {
            selecionados = new Fila(qtdVagas);
        }
        public void OrdenacaoListaDeEspera()
        {

            // CRIA UM MÉTODO DE ORDENACAO
            listaDeEspera.Sort((c1, c2) => c2.getMedia().CompareTo(c1.getMedia()));


        }



    }



}
