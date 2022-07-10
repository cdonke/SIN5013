namespace Grafos
{
    public interface IGrafo
    {
        bool CriaAresta(int verticeInicial, int verticeFinal);
        bool CriaAresta(int verticeInicial, int verticeFinal, int peso);
        void Limpar();
        void Imprimir();
        void BuscaPorProfundidade();
        void BuscaEmLargura();
        void Dijkstra();
    }
}