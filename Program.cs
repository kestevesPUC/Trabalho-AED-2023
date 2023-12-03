using System.Collections;
using TRAB_AED_2023.EstruturaDados;

namespace TRAB_AED_2023
{
    internal class Program
    {
        public static Dictionary<int, Curso> cursos = new Dictionary<int, Curso>();
        public static List<Candidato> candidatos = new List<Candidato>();

        static void CriandoListadeEspera()
        {

            for (int i = 0; i < candidatos.Count; i++)
            {
                Candidato candidato = candidatos[i];

                int indiceCurso1 = candidato.opcCurso_1; // 1 (Matematica)
                int indiceCurso2 = candidato.opcCurso_2; // 2 (GEOGRAFIA)
                Curso curso1 = cursos[indiceCurso1];
                Curso curso2 = cursos[indiceCurso2];

                curso1.listaDeEspera.Add(candidato);
                curso2.listaDeEspera.Add(candidato);

                curso1.OrdenacaoListaDeEspera();

            }


        }

        static void PreenchendoFiladeSelecionados()
        {


            //Acessando o curso.
            foreach(var c in  cursos) 
            {
                Curso curso = c.Value;

                //Acessando a Fila de Selecionados dentro de cada curso.                
                for (int j = 0; j < curso.selecionados.array.Length; j++)
                {
                    Candidato candidato = curso.listaDeEspera[j];
                    curso.selecionados.inserir(candidato);

                    if(c.Key == candidato.opcCurso_1)
                    {
                        // Remove o candidato da lista
                    } else if(c.Key == candidato.opcCurso_2)
                    {
                        // Permanece com a opção 1 na lista de espera mas tira a 2
                    } 

                }

            }

        }


        static void ProcessaAprovados()
        {
            try
            {
                foreach(Candidato candidato in candidatos)
                {
                    // Cursos escolhidos pelo candidato
                    Curso curso1 = cursos[candidato.opcCurso_1];
                    Curso curso2 = cursos[candidato.opcCurso_2];

                    // Verifica se a fila de selecionados está
                    bool filaCheia1 = curso1.selecionados.FilaCheia();
                    bool filaCheia2 = curso2.selecionados.FilaCheia();

                    if (filaCheia1 && filaCheia2) // Não passou em nenhum dos cursos
                    {
                        //Entra na lista de espera
                        curso1.listaDeEspera.Add(candidato);
                        curso2.listaDeEspera.Add(candidato);

                    } else {
                        if(!filaCheia1) // Passou na primeira opção de curso
                        {
                            // Insere o candidato na lista de aprovados/selecionados
                            curso1.selecionados.inserir(candidato);

                            // Atualiza nota de corte do curso
                            curso1.notaDeCorte = candidato.getMedia();
                            
                            // Remove o candidato da lista de espera 1 e 2
                            if(curso1.listaDeEspera.Contains(candidato)) {
                                curso1.listaDeEspera.Remove(candidato);
                            }

                            if(curso2.listaDeEspera.Contains(candidato)) {
                                curso2.listaDeEspera.Remove(candidato);
                            }
                        } else if(!filaCheia2) {
                            // Verifica se o candidato não entrou na opção de curso 1
                            if(!curso1.selecionados.Pesquisar(candidato))
                            {
                                // Insere o candidato na lista de aprovados/selecionados
                                curso2.selecionados.inserir(candidato);

                                // Atualiza nota de corte do curso
                                curso2.notaDeCorte = candidato.getMedia();

                                // Adiciona o candidato na lista de espera do curso 1
                                curso1.listaDeEspera.Add(candidato);

                                // Remove o candidato da lista de espera 2
                                if(curso2.listaDeEspera.Contains(candidato)) {
                                    curso2.listaDeEspera.Remove(candidato);
                                }
                            }
                            
                        }
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        static void Main(string[] args)
        {
            Arquivo arquivo = new Arquivo();
            arquivo.LeArquivoTxt();

            candidatos.Sort((c1, c2) => c2.getMedia().CompareTo(c1.getMedia()));

            ProcessaAprovados();

            string textoSaida = "";
            foreach (Curso curso in cursos.Values)
            {
                textoSaida += $"{curso.nome} {curso.notaDeCorte}\n Selecionados\n";
                

            }

            Console.WriteLine(textoSaida);

            Console.ReadKey();
            //CriandoListadeEspera();

            //PreenchendoFiladeSelecionados();
        }
    }
}
