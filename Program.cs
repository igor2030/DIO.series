using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
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
                        InserirSerie();
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
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
               
                
            }

            Console.WriteLine("obrigado por utilizar nossos  serviços");
            Console.ReadLine();
            
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#Id {0}: - {1} - {2}", serie.RetornaId(), serie.retornaTitulo(), (excluido ? "*excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Serie");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da serie: ");
            string entradaDescrição = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoID(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescrição );
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre  as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite O tITULO Da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da serie: ");
            string entradaDescrição = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repositorio.ProximoID(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescrição );

            repositorio.Atualizar(indiceSerie, atualizaSerie);
           

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualisarSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
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
