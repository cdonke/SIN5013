using System;
using System.Collections.Generic;

namespace Grafos
{
    public class GrafosPorMatriz : IGrafo
    {
        int _qtdeVertices;
        int _qtdeArestas;
        bool[,] _matrizDeAdjacencias;
        int[,] _matrizDePesos;

        public GrafosPorMatriz(int qtdeVertices)
        {
            _qtdeVertices = qtdeVertices;
            Limpar();
        }

        public void Limpar()
        {
            _matrizDeAdjacencias = new bool[_qtdeVertices, _qtdeVertices];
            _matrizDePesos = new int[_qtdeVertices, _qtdeVertices];
        }

        public void BuscaPorProfundidade()
        {
            ECor[] cor = new ECor[_qtdeVertices];

            for (int i = 0; i < _qtdeVertices; i++)
            {
                if (cor[i] == ECor.BRANCO)
                    VisitaPorProfundidade(i, cor);
            }
        }

        private void VisitaPorProfundidade(int i, ECor[] cor)
        {
            cor[i] = ECor.AMARELO;
            Console.Write($"{i} > ");

            for (int x = 0; x < _qtdeVertices; x++)
            {
                if (cor[x] == ECor.BRANCO)
                {
                    VisitaPorProfundidade(x, cor);
                }
            }
            cor[i] = ECor.VERMELHO;
        }

        public bool CriaAresta(int verticeInicial, int verticeFinal) => CriaAresta(verticeInicial, verticeFinal, 0);
        public bool CriaAresta(int verticeInicial, int verticeFinal, int peso)
        {
            _matrizDeAdjacencias[verticeInicial, verticeFinal] = true;
            _matrizDePesos[verticeInicial, verticeFinal] = peso;
            _qtdeArestas++;

            return true;
        }

        public void Imprimir()
        {
            Console.WriteLine($"Vertices: {_qtdeVertices}\tArestas: {_qtdeArestas}");
            Console.WriteLine();

            for (int i = 0; i < _qtdeVertices; i++)
            {
                Console.Write($"v{i}:\t");

                for (int x = 0; x < _qtdeVertices; x++)
                {
                    if (_matrizDeAdjacencias[i, x])
                    {
                        Console.Write($"v{x}({_matrizDePesos[i, x]}) ");
                    }
                }

                Console.WriteLine();
            }
        }

        public void BuscaEmLargura()
        {
            bool[] explorados = new bool[_qtdeVertices];

            for (int i = 0; i < _qtdeVertices; i++)
            {
                if (!explorados[i])
                    VisitaEmLargura(i, explorados);
            }
        }

        private void VisitaEmLargura(int i, bool[] explorados)
        {
            var visitados = new Queue<int>();
            explorados[i] = true;

            visitados.Enqueue(i);
            while (visitados.Count > 0)
            {
                i = visitados.Dequeue();
                Console.Write($"{i} > ");


                for (int x = 0; x < _qtdeVertices; x++)
                {
                    var vertice = _matrizDeAdjacencias[i, x];
                    while (vertice)
                    {
                        Console.Write($"\t{x} > ");
                        if (!explorados[x])
                        {
                            explorados[x] = true;
                            visitados.Enqueue(x);
                        }
                        if (x + 1 == _qtdeVertices)
                            break;

                        vertice = _matrizDeAdjacencias[i, ++x];
                        Console.WriteLine();
                    }
                }
            }
        }

        public void Dijkstra()
        {
            throw new NotImplementedException();
        }
    }
}

