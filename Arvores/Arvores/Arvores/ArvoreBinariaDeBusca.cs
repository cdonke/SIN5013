using System;
namespace Arvores
{
	public class ArvoreBinariaDeBusca: BaseArvore
	{
        protected override No AdicionarNo(No raiz, No no)
        {
			if (no.Chave < raiz.Chave)
            {
				if (raiz.Esquerda == null)
					raiz.Esquerda = no;
				else
					AdicionarNo(raiz.Esquerda, no);
            }
			else if (no.Chave > raiz.Chave)
			{
				if (raiz.Direita == null)
					raiz.Direita = no;
				else
					AdicionarNo(raiz.Direita, no);
            }
			else
            {
				throw new Exception("Valor já existe");
            }

			return raiz;
        }

		public override void RemoverNo(int valor)
		{
			No no = Raiz;
			No pai = null;
			No noParaPromover = null;

			// Busca o Nó e seu pai
			while (no != null)
			{
				if (no.Chave == valor)
					break;

				pai = no;
				if (valor < no.Chave)
					no = no.Esquerda;
				else
					no = no.Direita;
			}


			if (no.Esquerda == null || no.Direita == null)
			{
				// Se só tenho 1 descendente, descobro qual deles
				if (no.Esquerda == null)
					noParaPromover = no.Direita;
				else
					noParaPromover = no.Esquerda;
			}
			else
			{
				var subPai = no;
				noParaPromover = no.Esquerda;
				while(noParaPromover.Direita != null)
                {
					subPai = noParaPromover;
					noParaPromover = noParaPromover.Direita;
                }

				if (subPai != no)
                {
					subPai.Direita = noParaPromover.Esquerda;
					noParaPromover.Esquerda = no.Esquerda;
                }
				noParaPromover.Direita = no.Direita;
			}

			if (pai == null)
				return;

			if (no.Chave < pai.Chave)
				pai.Esquerda = noParaPromover;
			else
				pai.Direita = noParaPromover;

		}

      
	}
}

