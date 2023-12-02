using System.Collections;

namespace TRAB_AED_2023
{
    internal class Program
    {
        public static Dictionary<int, Curso> cursos = new Dictionary<int, Curso>();
        public static List<Candidato> candidatos = new List<Candidato>();
        static void Main(string[] args)
        {
            new CagaTXT().leArquivoTxt();

        }
    }
}
