using System;
using System.Collections.Generic;

class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }

    public Livro(string titulo, string autor, int ano)
    {
        Titulo = titulo;
        Autor = autor;
        Ano = ano;
    }

    public void ExibirInfo()
    {
        Console.WriteLine($"Título: {Titulo} | Autor: {Autor} | Ano: {Ano}");
    }
}

class Biblioteca
{
    private List<Livro> livros = new List<Livro>();

    public void AdicionarLivro(Livro livro)
    {
        livros.Add(livro);
        Console.WriteLine("Livro adicionado com sucesso!");
    }

    public void ExibirLivros()
    {
        if (livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
        else
        {
            Console.WriteLine("Livros na biblioteca:");
            foreach (Livro livro in livros)
            {
                livro.ExibirInfo();
            }
        }
    }

    public void PesquisarLivro(string titulo)
    {
        bool encontrado = false;
        foreach (Livro livro in livros)
        {
            if (livro.Titulo.ToLower().Contains(titulo.ToLower()))
            {
                livro.ExibirInfo();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
}

class Program
{
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\nSistema de Biblioteca");
            Console.WriteLine("1. Adicionar Livro");
            Console.WriteLine("2. Exibir Todos os Livros");
            Console.WriteLine("3. Pesquisar Livro por Título");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o título do livro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Digite o autor do livro: ");
                    string autor = Console.ReadLine();
                    Console.Write("Digite o ano de publicação: ");
                    int ano = Convert.ToInt32(Console.ReadLine());

                    Livro novoLivro = new Livro(titulo, autor, ano);
                    biblioteca.AdicionarLivro(novoLivro);
                    break;

                case 2:
                    biblioteca.ExibirLivros();
                    break;

                case 3:
                    Console.Write("Digite o título para pesquisa: ");
                    string pesquisaTitulo = Console.ReadLine();
                    biblioteca.PesquisarLivro(pesquisaTitulo);
                    break;

                case 4:
                    executando = false;
                    Console.WriteLine("Encerrando o sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}
