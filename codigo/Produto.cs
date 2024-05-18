using System;
using System.Collections.Generic;
{
    internal class Produto
    {
        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public int Id { get; private set; }
        public int Quantidade { get; private set; }

        /// <summary>
        /// Construtor da classe Produto.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="valor">Valor do produto.</param>
        /// <param name="id">Identificador único do produto.</param>
        /// <param name="quantidade">Quantidade do produto disponível.</param>
        public Produto(string nome, double valor, int id, int quantidade)
        {
            Nome = nome;
            Valor = valor;
            Id = id;
            Quantidade = quantidade;
        }
    }
}
