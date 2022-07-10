using System;
namespace Arvores
{
    public class ArvoreAVL : BaseArvore
    {
        public override void RemoverNo(int valor)
        {
            throw new NotImplementedException();
        }

        protected override No AdicionarNo(No raiz, No no)
        {
            if (raiz == null)
            {
                return no;
            }

            if (no.Chave < raiz.Chave)
            {
                //if (raiz.Esquerda == null)
                //    raiz.Esquerda = no;
                //else
                    raiz.Esquerda= AdicionarNo(raiz.Esquerda, no);

                if (CalcularAltura(raiz.Esquerda) - CalcularAltura(raiz.Direita) == 2)
                {
                    if (no.Chave < raiz.Esquerda.Chave)
                        raiz = RotacaoDireita(raiz);
                    else
                        raiz = RotacaoEsquerdaDireita(raiz);
                }

            }
            else
            {
                //if (raiz.Direita == null)
                //    raiz.Direita = no;
                //else
                   raiz.Direita= AdicionarNo(raiz.Direita, no);

                if (CalcularAltura(raiz.Direita) - CalcularAltura(raiz.Esquerda) == 2)
                {
                    if (no.Chave > raiz.Direita.Chave)
                        raiz = RotacaoEsquerda(raiz);
                    else
                        raiz = RotacaoDireitaEsquerda(raiz);
                }
            }

            raiz.Altura = Math.Max(CalcularAltura(raiz.Esquerda), CalcularAltura(raiz.Direita)) + 1;

            return raiz;
        }

        private No RotacaoDireita(No raiz)
        {
            var aux = raiz.Esquerda;
            raiz.Esquerda = aux.Direita;
            aux.Direita = raiz;

            raiz.Altura = Math.Max(CalcularAltura(raiz.Direita), CalcularAltura(raiz.Esquerda)) + 1;
            aux.Altura = Math.Max(CalcularAltura(aux.Esquerda), raiz.Altura) + 1;

            return aux;
        }
        private No RotacaoEsquerda(No raiz)
        {
            var aux = raiz.Direita;
            raiz.Direita = aux.Esquerda;
            aux.Esquerda = raiz;

            raiz.Altura = Math.Max(CalcularAltura(raiz.Direita), CalcularAltura(raiz.Esquerda)) + 1;
            aux.Altura = Math.Max(CalcularAltura(aux.Direita), raiz.Altura) + 1;

            return aux;
        }
        private No RotacaoEsquerdaDireita(No raiz)
        {
            raiz.Esquerda = RotacaoEsquerda(raiz.Esquerda);
            return RotacaoDireita(raiz);
        }
        private No RotacaoDireitaEsquerda(No raiz)
        {
            raiz.Direita = RotacaoDireita(raiz.Direita);
            return RotacaoEsquerda(raiz);
        }


        private int CalcularAltura(No raiz)
        {
            if (raiz == null)
                return -1;

            return 1 + Math.Max(CalcularAltura(raiz.Esquerda), CalcularAltura(raiz.Direita));
        }
    }
}

