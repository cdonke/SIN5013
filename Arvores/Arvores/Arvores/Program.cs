using System;

namespace Arvores
{
    class Program
    {
        static void Main(string[] args)
        {
            //CriarArvoreBinariaDeBusca();
            CriarArvoreAVL();
        }

        private static void CriarArvoreAVL()
        {
            var arvore = new ArvoreAVL();
            arvore.AdicionarNo(15);
            arvore.AdicionarNo(8);
            arvore.AdicionarNo(23);
            arvore.AdicionarNo(2);
            arvore.AdicionarNo(20);
            arvore.AdicionarNo(12);
            arvore.AdicionarNo(18);


        }

        private static void CriarArvoreBinariaDeBusca()
        {
            var arvore = new ArvoreBinariaDeBusca();
            arvore.AdicionarNo(15);
            arvore.AdicionarNo(8);
            arvore.AdicionarNo(2);
            arvore.AdicionarNo(12);
            arvore.AdicionarNo(23);
            arvore.AdicionarNo(30);
            arvore.AdicionarNo(20);


            var busca1 = arvore.BuscarNo(12);
            Console.WriteLine($"Busca pelo elemento 12: {busca1 != null}");
            var busca2 = arvore.BuscarNo(60);
            Console.WriteLine($"Busca pelo elemento 60: {busca2 != null}");

            Console.WriteLine(new String('-', 40));
            Console.WriteLine();

            var qtdeNos = arvore.Contagem();
            Console.WriteLine($"Quantidade de nós: {qtdeNos}");
            Console.WriteLine();

            Console.WriteLine(new String('-', 40));
            Console.WriteLine();

            Console.Write("Leitura In Order:\t");
            arvore.InOrder();
            Console.WriteLine();

            Console.Write("Leitura Pre Order:\t");
            arvore.PreOrder();
            Console.WriteLine();

            Console.Write("Leitura Pos Order:\t");
            arvore.PosOrder();

            Console.WriteLine();
            Console.WriteLine(new String('-', 40));

            arvore.AdicionarNo(1);
            arvore.AdicionarNo(6);
            arvore.AdicionarNo(4);
            arvore.AdicionarNo(7);

            arvore.RemoverNo(8);
            arvore.InOrder();
            Console.WriteLine();

            Console.WriteLine(new String('-', 40));
            Console.WriteLine();
        }
    }
}

