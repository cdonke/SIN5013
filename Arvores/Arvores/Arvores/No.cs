using System;
namespace Arvores
{
    [System.Diagnostics.DebuggerDisplay("Chave={Chave}, Esquerda={Esquerda==null}, Direita={Direita==null}, Altura={Altura}")]
	public class No
	{
        public int Chave { get; set; }
        public No Esquerda { get; set; }
        public No Direita { get; set; }

        // Especifico para AVL
        public int Altura { get; set; }
    }
}

