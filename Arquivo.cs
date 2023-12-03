using System;   
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAB_AED_2023
{
    internal class Arquivo
    {
            const string PATH = "../../../Docs\\";
        public void LeArquivoTxt()
        {
            try
            {
                StreamReader sw = new StreamReader(
                    Path.Combine(Environment.CurrentDirectory, PATH + "entrada.txt"),
                    Encoding.GetEncoding("iso-8859-1")
                    );

                string linha1 = sw.ReadLine();
                int qtdCursos = int.Parse(linha1.Split(';')[0]);
                int qtdCandidatos = int.Parse(linha1.Split(';')[1]);

                for(int i = 0; i < (qtdCandidatos + qtdCursos); i++)
                {
                    string linha = sw.ReadLine();
                    string[] elementos = linha.Split(';');

                    if (i <= qtdCursos-1)
                    {
                        int codCurso = int.Parse(elementos[0]); 
                        string nomeCurso = elementos[1];
                        int vagasCurso = int.Parse(elementos[2]);

                        Curso curso = new Curso(vagasCurso);
                        curso.nome = nomeCurso;
                        Program.cursos.Add(codCurso, curso); // Adiciona ao dicionário um (Chave: (int)codigo, Curso: (object)valor)
                    } else
                    {
                        string nomeCandidato = elementos[0];
                        double notaRedacao= double.Parse(elementos[1]);
                        double notaMatematica = double.Parse(elementos[2]);
                        double notaLinguagens = double.Parse(elementos[3]);
                        int opcaoCurso_1 = int.Parse(elementos[4]);
                        int opcaoCurso_2 = int.Parse(elementos[5]);

                        Program.candidatos.Add(
                            new Candidato {
                                nome = nomeCandidato,
                                notaRedacao = notaRedacao,
                                notaMatematica = notaMatematica,
                                notaLinguagens = notaLinguagens,
                                opcCurso_1 = opcaoCurso_1,
                                opcCurso_2 = opcaoCurso_2 
                            }
                        );
                    }
                    
                }
                sw.Close();
                
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EscreverArquivo(string texto)
        {
            try
            {
                // Escrever o conteúdo no arquivo
                using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, PATH + "saida.txt")))
                {
                    writer.WriteLine(texto);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
