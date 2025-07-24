using System.Net;
using System.Runtime.CompilerServices;
using InterfaceAnimes.Classes;

class Program
{
    static AnimeRepositorio serieRepositorio = new AnimeRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarAnimes();
                    break;
                case "2":
                    InserirAnimes();
                    break;
                case "3":
                    AtualizarAnimes();
                    break;
                case "4":
                    ExcluirAnimes();
                    break;
                case "5":
                    VisualizarAnimes();
                    break;
                case "6":
                    ListarAnimes();
                    break;
                case "7":
                    Assistido();
                    break;
                case "8":
                    BuscarAnime();
                    break;
                case "9":
                    ExportarAnimes();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
    }
    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("DIO Animes a seu dispor!!!");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1- Listar animes");
        Console.WriteLine("2- Inserir novo anime");
        Console.WriteLine("3- Atualizar anime");
        Console.WriteLine("4- Excluir anime");
        Console.WriteLine("5- Visualizar anime");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("6- Listar animes");
        Console.WriteLine("7- Marcar anime como assistido");
        Console.WriteLine("8- Buscar anime por título ou gênero");
        Console.WriteLine("9- Exportar lista de animes para arquivo");
        Console.WriteLine("X- Sair");

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
    private static void ListarAnimes()
    {
        Console.WriteLine("Listar animes");

        var lista = serieRepositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum anime cadastrado.");
            return;
        }

        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornarId(), serie.RetornarTitulo(), (excluido ? "*Excluído*" : ""));
        }
    }
    private static void InserirAnimes()
    {
        Console.WriteLine("Inserir novo anime");

        Console.Write("Digite o título do anime: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de lançamento do anime: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite o gênero do anime: ");
        string entradaGenero = Console.ReadLine();

        Console.Write("Digite a descrição do anime: ");
        string entradaDescricao = Console.ReadLine();

        Console.Write("O anime foi assistido? (S/N): ");
        bool entradaAssistido = Console.ReadLine().ToUpper() == "S";

        Anime novoAnime = new Anime(id: serieRepositorio.ProximoId(),
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    anoLancamento: entradaAno,
                                    genero: entradaGenero,
                                    assistido: entradaAssistido);

        serieRepositorio.Insere(novoAnime);
    }
    private static void AtualizarAnimes()
    {
        Console.Write("Digite o ID do anime: ");
        int indiceAnime = int.Parse(Console.ReadLine());

        Console.Write("Digite o título do anime: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de lançamento do anime: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite o gênero do anime: ");
        string entradaGenero = Console.ReadLine();

        Console.Write("Digite a descrição do anime: ");
        string entradaDescricao = Console.ReadLine();

        Console.Write("O anime foi assistido? (S/N): ");
        bool entradaAssistido = Console.ReadLine().ToUpper() == "S";

        Anime atualizaAnime = new Anime(id: indiceAnime,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        anoLancamento: entradaAno,
                                        genero: entradaGenero,
                                        assistido: entradaAssistido);

        serieRepositorio.Atualiza(indiceAnime, atualizaAnime);
    }
    private static void ExcluirAnimes()
    {
        Console.Write("Digite o ID do anime: ");
        int indiceAnime = int.Parse(Console.ReadLine());

        serieRepositorio.Exclui(indiceAnime);
    }
    private static List<string> RetornaDadosAnime()
    {
        List<string> dadosAnime = new List<string>();

        Console.Write("Digite o título do anime: ");
        dadosAnime.Add(Console.ReadLine());

        Console.Write("Digite o ano de lançamento do anime: ");
        dadosAnime.Add(Console.ReadLine());

        Console.Write("Digite o gênero do anime: ");
        dadosAnime.Add(Console.ReadLine());

        Console.Write("Digite a descrição do anime: ");
        dadosAnime.Add(Console.ReadLine());

        Console.Write("O anime foi assistido? (S/N): ");
        dadosAnime.Add(Console.ReadLine().ToUpper() == "S" ? "Sim" : "Não");

        return dadosAnime;
    }
    private static void VisualizarAnimes()
    {
        Console.Write("Digite o ID do anime: ");
        int indiceAnime = int.Parse(Console.ReadLine());

        var anime = serieRepositorio.RetornaPorId(indiceAnime);

        if (anime == null)
        {
            Console.WriteLine("Anime não encontrado.");
            return;
        }

        Console.WriteLine(anime);
    }
    private static void Assistido()
    {
        Console.Write("Digite o ID do anime que deseja marcar como assistido: ");
        int indiceAnime = int.Parse(Console.ReadLine());

        var anime = serieRepositorio.RetornaPorId(indiceAnime);

        if (anime == null)
        {
            Console.WriteLine("Anime não encontrado.");
            return;
        }

        anime.Assistido = true;
        serieRepositorio.Atualiza(indiceAnime, anime);
        Console.WriteLine($"O anime '{anime.Titulo}' foi marcado como assistido.");
    }
    private static void BuscarAnime()
    {
        Console.Write("Digite o título ou gênero para buscar: ");
        string termo = Console.ReadLine().ToLower();

        var resultados = serieRepositorio.Lista()
            .Where(a => a.Titulo.ToLower().Contains(termo) || a.Genero.ToLower().Contains(termo))
            .ToList();

        if (resultados.Count == 0)
            Console.WriteLine("Nenhum anime encontrado.");
        else
            foreach (var anime in resultados)
                Console.WriteLine(anime);
    }
    private static void ExportarAnimes()
{
    var lista = serieRepositorio.Lista();

    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhum anime cadastrado para exportar.");
        return;
    }

    using (var writer = new StreamWriter("animes.txt"))
    {
        writer.WriteLine("ID;Título;Ano;Gênero;Assistido;Descrição");
        foreach (var anime in lista)
        {
            writer.WriteLine($"{anime.RetornarId()};{anime.Titulo};{anime.AnoLancamento};{anime.Genero};{(anime.Assistido ? "Sim" : "Não")};{anime.Descricao}");
        }
    }

    Console.WriteLine("Lista de animes exportada para 'animes.txt' na pasta do programa.");
} 

}
