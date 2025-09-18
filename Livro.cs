using System;

namespace Biblioteca
{
    public class Livro
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int AnoPublicacao { get; private set; }
        public bool Disponivel { get; private set; }

        public Livro(string titulo, string autor, int anoPublicacao)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.", nameof(titulo));
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor não pode ser vazio.", nameof(autor));
            if (anoPublicacao <= 0)
                throw new ArgumentException("Ano de publicação inválido.", nameof(anoPublicacao));

            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Disponivel = true;
        }

        public bool Emprestar()
        {
            if (!Disponivel) return false;
            Disponivel = false;
            return true;
        }

        public bool Devolver()
        {
            if (Disponivel) return false;
            Disponivel = true;
            return true;
        }

        public override string ToString()
        {
            var status = Disponivel ? "Disponível" : "Emprestado";
            return $"{Titulo} - {Autor} ({AnoPublicacao}) [{status}]";
        }
    }
}
