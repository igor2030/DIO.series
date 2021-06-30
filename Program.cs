using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserireSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualisarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        return;

                }
               
                
            }
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#Id {0}: - {1}", serie.retorna_id(), serie.retornaTitulo());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a Seu dispor!!!");

            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir nova Serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir Serie");
            Console.WriteLine("5- Visualisar Serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario =Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
          
    }
}
