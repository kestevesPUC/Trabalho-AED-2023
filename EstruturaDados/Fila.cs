using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAB_AED_2023.EstruturaDados
{
    internal class Fila
    {
        public Candidato[] array { get; set; }
        int primeiro, ultimo;

        public Fila(int tamanho)
        {

            // Reservando uma espaço a mais, ou seja, se desejar 5 na fila, vamos ter 6 espaços.
            // O Motivo se deve para diferenciar a fila cheia da vazia. 
            array = new Candidato[tamanho + 1];

            //Colocando os indicadores da Fila redonda para começar em 0, ou seja, sempre que começa em 0 está vazia.
            primeiro = 0;
            ultimo = 0;

        }


        public void inserir(Candidato x)
        {
            // Verificar se o a posicao do ultimo mais 1 é igual o resto da divisao do tamanho do array.
            // EX: posicao 2 + 1 = 3 --> 3 % por 5 = 3 --> Ou seja o resultado é a nova posicao. 
            if ((ultimo + 1) % array.Length == primeiro)
            {
                // Verificar se está cheia, entrou aqui vai dar erro.
                throw new Exception("Erro, Fila Cheia");
            }
            else
            {
                //Sempre colocar o número no final da Fila
                array[ultimo] = x;
                // Colocar a variavel ultimo pular uma casa. 
                ultimo = (ultimo + 1) % array.Length;
            }


        }

        public Candidato Remover()
        {
            // Verificar se a Fila está vazia.
            if (primeiro == ultimo)
            {
                throw new Exception("Erro, Fila Vazia!");
            }


            Candidato resp = array[primeiro];
            // Passar a variavel primeiro para a proxima posicao.
            primeiro = (primeiro + 1) % array.Length;
            return resp;

        }

        public bool FilaCheia()
        {
            if ((ultimo + 1) % array.Length == primeiro)
                return true;

            return false;
        }

        public void Mostrar()
        {
            //Vou criar o variavel I para não mudar meu primeiro
            int i = primeiro;
            if (primeiro == ultimo)
            {
                Console.WriteLine("Nenhum candidato na FILA!");
            }

            while (i != ultimo)
            {
                Console.WriteLine(array[i] + " ");

                //Mesma logica de adicionar, vai somando 1 até rodar a fila toda.
                i = (i + 1) % array.Length;
            }




        }

        public int ObterTamanho()
        {
            // Verificar se a Fila está vazia.
            if (primeiro == ultimo)
            {
                throw new Exception("Não tem nenhum aviao");
            }


            return Math.Abs(primeiro - ultimo);

        }

        public Candidato ObterPrimeiro()
        {
            // Verificar se a Fila está vazia.
            if (primeiro == ultimo)
            {
                throw new Exception("Erro, Fila Vazia!");
            }
            return array[primeiro];

        }

        public bool Pesquisar(Candidato candidatoProcurado)
        {
            // Percorrer a fila para verificar se o candidato está presente
            int i = primeiro;
            while (i != ultimo)
            {
                if (array[i].nome.Equals(candidatoProcurado.nome))
                {
                    return true; // Candidato encontrado na fila
                }

                i = (i + 1) % array.Length;
            }

            return false; // Candidato não encontrado na fila
        }


    }
}
