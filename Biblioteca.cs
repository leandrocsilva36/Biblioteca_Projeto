using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp
{
    public class Biblioteca
    {
        private List<Livro> livros = new List<Livro>();

        public void AdicionarLivro(Livro livro)
        {
            if (livro == null) throw new ArgumentNullException(nameof(livro));
            livros.Add(livro);
        }

        public bool RemoverLivro(string titulo)
        {
            var livro = livros.FirstOrDefault(l => string.Equals(l.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
            if (livro == null) return false;
            livros.Remove(livro);
            return true;
        }

        public List<Livro> Buscar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo)) return new List<Livro>(livros);
            termo = termo.Trim();
            return livros.Where(l =>
                l.Titulo.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                l.Autor.Contains(termo, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public bool EmprestarLivro(string titulo)
        {
            var livro = livros.FirstOrDefault(l => string.Equals(l.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
            if (livro == null) return false;
            return livro.Emprestar();
        }

        public bool DevolverLivro(string titulo)
        {
            var livro = livros.FirstOrDefault(l => string.Equals(l.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
            if (livro == null) return false;
            return livro.Devolver();
        }

        public void ListarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            Console.WriteLine("Catálogo de livros:");
            foreach (var livro in livros)
            {
                Console.WriteLine(livro);
            }
        }
    }
}
