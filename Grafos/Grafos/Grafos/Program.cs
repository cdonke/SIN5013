using System;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarGrafos(new GrafoPorListaLigada(8), "Grafos Por lista Ligada:");
            //CriarGrafos(new GrafosPorMatriz(8), "Grafos Por Matriz de Adjacencias:");
        }

        private static void CriarGrafos(IGrafo grafo, string titulo)
        {
            Console.WriteLine(titulo);

            CriaArestas(grafo);
            grafo.Imprimir();
            
            Console.WriteLine(new String('-', 20));

            grafo.BuscaPorProfundidade();
            Console.WriteLine(new String('-', 20));
            grafo.Limpar();

            CriaArestas_BFS(grafo);
            grafo.BuscaEmLargura();
            Console.WriteLine(new String('-', 20));
            grafo.Limpar();

            CriaArestas_Dijsktra(grafo);
            grafo.Dijkstra();
    
            Console.WriteLine(new String('-', 40));
        }
        private static void CriaArestas(IGrafo grafo)
        {
            grafo.CriaAresta(0, 1, 2);
            grafo.CriaAresta(1, 2, 4);
            grafo.CriaAresta(2, 0, 12);
            grafo.CriaAresta(3, 1, 3);
            grafo.CriaAresta(2, 4, 40);
            grafo.CriaAresta(4, 3, 8);
        }
        private static void CriaArestas_BFS(IGrafo grafo)
        {
            grafo.CriaAresta(0, 1);
            grafo.CriaAresta(0, 2);
            grafo.CriaAresta(1, 3);
            grafo.CriaAresta(2, 3);
            grafo.CriaAresta(2, 4);
            grafo.CriaAresta(3, 4);
            grafo.CriaAresta(3, 5);
            grafo.CriaAresta(4, 5);
            grafo.CriaAresta(6, 2);
            grafo.CriaAresta(6, 7);
        }
        private static void CriaArestas_Dijsktra(IGrafo grafo)
        {
            grafo.CriaAresta(0, 1, 10);
            grafo.CriaAresta(0, 2, 5);
            grafo.CriaAresta(2, 1, 3);
            grafo.CriaAresta(2, 3, 8);
            grafo.CriaAresta(1, 3, 1);
            grafo.CriaAresta(3, 4, 4);
            grafo.CriaAresta(3, 5, 4);
            grafo.CriaAresta(4, 5, 6);
        }
    }
}

