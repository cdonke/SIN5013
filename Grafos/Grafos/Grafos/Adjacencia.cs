using System;
namespace Grafos
{
	public class Adjacencia
	{
        public int Vertice { get; set; }
        public int Peso { get; set; }
        public Adjacencia Proximo { get; set; }

        public Adjacencia(int vertice, int peso)
        {
            Vertice = vertice;
            Peso = peso;
            Proximo = null;
        }
    }
}

