using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAB_AED_2023
{
    internal class CagaTXT
    {
        public void leArquivoTxt()
        {
            const string PATH = "../../../Docs\\entrada.txt";
            try
            {
                StreamReader sw = new StreamReader(
                    Path.Combine(Environment.CurrentDirectory, PATH),
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

                        Program.cursos.Add(codCurso, new Curso{ nome = nomeCurso, qtdVagas = vagasCurso }); // Adiciona ao dicionário um (Chave: (int)codigo, Curso: (object)valor)
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
    }
}
