using System;
using System.Globalization;

namespace BibliotecaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();
            // Seed with sample books
            biblioteca.AdicionarLivro(new Livro("A CAÇA ", "CAÇADOR ", 1949));
            biblioteca.AdicionarLivro(new Livro("ANIMAIS", "CAVALO", 1899));
            biblioteca.AdicionarLivro(new Livro("O CIRCO ", "PALHAÇO", 1943));

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Biblioteca ===");
                Console.WriteLine("1. Listar livros");
                Console.WriteLine("2. Adicionar livro");
                Console.WriteLine("3. Remover livro");
                Console.WriteLine("4. Buscar por título/autor");
                Console.WriteLine("5. Emprestar livro");
                Console.WriteLine("6. Devolver livro");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                var key = Console.ReadLine();
                Console.WriteLine();

                switch (key)
                {
                    case "1":
                        biblioteca.ListarLivros();
                        break;
                    case "2":
                        AdicionarLivroInterativo(biblioteca);
                        break;
                    case "3":
                        RemoverLivroInterativo(biblioteca);
                        break;
                    case "4":
                        BuscarInterativo(biblioteca);
                        break;
                    case "5":
                        EmprestarInterativo(biblioteca);
                        break;
                    case "6":
                        DevolverInterativo(biblioteca);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarLivroInterativo(Biblioteca biblioteca)
        {
            Console.Write("Título: ");
            var titulo = Console.ReadLine() ?? "";
            Console.Write("Autor: ");
            var autor = Console.ReadLine() ?? "";
            Console.Write("Ano de publicação: ");
            if (!int.TryParse(Console.ReadLine(), out var ano))
            {
                Console.WriteLine("Ano inválido. Operação cancelada.");
                return;
            }

            var livro = new Livro(titulo, autor, ano);
            biblioteca.AdicionarLivro(livro);
            Console.WriteLine("Livro adicionado com sucesso.");
        }

        static void RemoverLivroInterativo(Biblioteca biblioteca)
        {
            Console.Write("Digite o título exato do livro a remover: ");
            var titulo = Console.ReadLine() ?? "";
            var removed = biblioteca.RemoverLivro(titulo);
            Console.WriteLine(removed ? "Livro removido." : "Livro não encontrado.");
        }

        static void BuscarInterativo(Biblioteca biblioteca)
        {
            Console.Write("Digite parte do título ou autor para buscar: ");
            var termo = Console.ReadLine() ?? "";
            var resultados = biblioteca.Buscar(termo);
            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum livro encontrado.");
                return;
            }
            Console.WriteLine("Resultados:");
            foreach (var l in resultados)
            {
                Console.WriteLine(l);
            }
        }

        static void EmprestarInterativo(Biblioteca biblioteca)
        {
            Console.Write("Título do livro a emprestar: ");
            var titulo = Console.ReadLine() ?? "";
            var ok = biblioteca.EmprestarLivro(titulo);
            Console.WriteLine(ok ? "Empréstimo realizado." : "Livro não disponível ou não encontrado.");
        }

        static void DevolverInterativo(Biblioteca biblioteca)
        {
            Console.Write("Título do livro a devolver: ");
            var titulo = Console.ReadLine() ?? "";
            var ok = biblioteca.DevolverLivro(titulo);
            Console.WriteLine(ok ? "Devolução registrada." : "Livro não encontrado ou já disponível.");
        }
    }
}
