using System;
using System.Collections.Generic;

namespace Grafos
{
	public class GrafoPorListaLigada:IGrafo
	{
        private int _qtdeVertices;
        private int _qtdeArestas;
        private Vertice[] _vertices;

        public GrafoPorListaLigada(int qtdeVertices)
        {
            _qtdeVertices = qtdeVertices;
            Limpar();
        }

        public void Limpar()
        {
            _qtdeArestas = 0;
            _vertices = new Vertice[_qtdeVertices];

            for (int i = 0; i < _qtdeVertices; i++)
            {
                _vertices[i] = new Vertice();
            }
        }

        public void BuscaPorProfundidade()
        {
            ECor[] cor = new ECor[_qtdeVertices];

            for (int i = 0; i < _qtdeVertices; i++)
            {
                if (cor[i] == ECor.BRANCO)
                {
                    VisitaPorProfundidade(i, cor);
                }
                Console.WriteLine();
            }
        }

        

        private void VisitaPorProfundidade(int i, ECor[] cor)
        {
            cor[i] = ECor.AMARELO;
            Console.Write($"{i} > ");

            var adj = _vertices[i].cabeca;
            while (adj != null)
            {
                if (cor[adj.Vertice] == ECor.BRANCO)
                {
                    VisitaPorProfundidade(adj.Vertice, cor);
                }
                adj = adj.Proximo;
            }
            cor[i] = ECor.VERMELHO;
        }

        public bool CriaAresta(int verticeInicial, int verticeFinal) => CriaAresta(verticeInicial, verticeFinal, 0);
        public bool CriaAresta(int verticeInicial, int verticeFinal, int Peso)
        {
            Adjacencia novo = new Adjacencia(verticeFinal, Peso);
            novo.Proximo = _vertices[verticeInicial].cabeca;

            _vertices[verticeInicial].cabeca = novo;
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

                var adj = _vertices[i].cabeca;
                while (adj!= null)
                {
                    Console.Write($"v{adj.Vertice}({adj.Peso}) ");
                    adj = adj.Proximo;
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
                {
                    VisitaEmLargura(i, explorados);
                    Console.WriteLine();
                }
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

                var vertice = _vertices[i].cabeca;
                while (vertice != null)
                {
                    Console.Write($"\t{vertice.Vertice} > ");
                    if (!explorados[vertice.Vertice])
                    {
                        explorados[vertice.Vertice] = true;
                        i = vertice.Vertice;
                        visitados.Enqueue(i);
                    }

                    vertice = vertice.Proximo;
                }
                Console.WriteLine();
            }
        }

        public void Dijkstra()
        {
            var distancia = new int[_qtdeVertices];
            var predecessor = new int[_qtdeVertices];
            var aberto = new bool[_qtdeVertices];

            for (int i = 0; i < _qtdeVertices; i++)
            {
                distancia[i] = Int32.MaxValue / 2;
                predecessor[i] = -1;
                aberto[i] = true;
            }
            distancia[0] = 0;


            while (ExisteAberto(aberto))
            {
                int u = MenorDistancia(aberto, distancia);
                aberto[u] = false;

                var adjacencia = _vertices[u].cabeca;
                while(adjacencia != null)
                {
                    Relaxar(distancia, predecessor, u, adjacencia.Vertice);
                    adjacencia = adjacencia.Proximo;
                }
            }

            var ultimoVertice = _qtdeArestas;
            for (int i = _qtdeArestas-1; i >=0 ; i--)
            {
                if (predecessor[i] > -1)
                {
                    ultimoVertice = i;
                    break;
                }
            }

            Console.Write($"Distancia: {distancia[ultimoVertice]}\tRota: ");
            var rota = new Stack<int>();
            rota.Push(ultimoVertice);
            while(ultimoVertice > 0)
            {
                ultimoVertice = predecessor[ultimoVertice];
                rota.Push(ultimoVertice);
            }

            while(rota.Count > 0)
            {
                var v = rota.Pop();
                Console.Write($"{v}, ");
            }
            Console.WriteLine();
        }
        private void Relaxar(int[] distancia, int[] precedessor, int verticeAtual, int verticeBuscado)
        {
            var adjacencia = _vertices[verticeAtual].cabeca;
            while (adjacencia != null && adjacencia.Vertice != verticeBuscado)
                adjacencia = adjacencia.Proximo;

            if (adjacencia != null)
            {
                if (distancia[adjacencia.Vertice] > distancia[verticeAtual] + adjacencia.Peso)
                {
                    distancia[adjacencia.Vertice] = distancia[verticeAtual] + adjacencia.Peso;
                    precedessor[verticeBuscado] = verticeAtual;
                }
            }
        }
        private bool ExisteAberto(bool[] aberto)
        {
            for (int i = 0; i < _qtdeVertices; i++)
            {
                if (aberto[i])
                    return true;
            }

            return false;

            //aberto.Any(q => q == true);
        }
        private int MenorDistancia(bool[] aberto, int[] distancias)
        {
            int i;
            for (i = 0; i < _qtdeVertices; i++)
                if (aberto[i])
                    break;

            if (i == _qtdeVertices)
                return -1;

            int menor = i;
            for (i=menor+1; i<_qtdeVertices; i++)
            {
                if (aberto[i] && distancias[menor] > distancias[i])
                    menor = i;
            }

            return menor;
        }
    }
}

