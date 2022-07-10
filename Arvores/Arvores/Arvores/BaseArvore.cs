using System;
namespace Arvores
{
	public abstract class BaseArvore
	{
		public No Raiz { get; set; }

		public void AdicionarNo(int valor)
		{
			var no = new No { Chave = valor };

			if (Raiz == null)
			{
				Raiz = no;
			}
			else
			{
				AdicionarNo(Raiz, no);
			}
		}
		protected abstract No AdicionarNo(No raiz, No no);
		public abstract void RemoverNo(int valor);



		public No BuscarNo(int valor) => BuscarNo(Raiz, valor);
		private No BuscarNo(No raiz, int valor)
		{
			if (raiz == null)
				return null;

			if (raiz.Chave == valor)
				return raiz;
			else if (valor < raiz.Chave)
				return BuscarNo(raiz.Esquerda, valor);
			else if (valor > raiz.Chave)
				return BuscarNo(raiz.Direita, valor);

			return null;
		}

		public int Contagem() => Contagem(Raiz);
		private int Contagem(No raiz)
		{
			int n = 0;

			if (raiz == null)
				return n;

			if (raiz.Direita != null)
				n += Contagem(raiz.Direita);

			if (raiz.Esquerda != null)
				n += Contagem(raiz.Esquerda);

			return n + 1;
		}

		public void InOrder() => InOrder(Raiz);
		private void InOrder(No raiz)
		{
			if (raiz == null)
				return;

			Console.Write(raiz.Chave);
			Console.Write("(");
			InOrder(raiz.Esquerda);
			InOrder(raiz.Direita);
			Console.Write(")");
		}


		public void PreOrder() => PreOrder(Raiz);
		private void PreOrder(No raiz)
		{
			if (raiz == null)
				return;

			Console.Write("(");
			PreOrder(raiz.Esquerda);
			Console.Write(raiz.Chave);
			PreOrder(raiz.Direita);
			Console.Write(")");
		}

		public void PosOrder() => PosOrder(Raiz);
		private void PosOrder(No raiz)
		{
			if (raiz == null)
				return;

			Console.Write("(");
			PosOrder(raiz.Esquerda);
			PosOrder(raiz.Direita);
			Console.Write(raiz.Chave);
			Console.Write(")");
		}
	}
}

