using System;
using System.Collections.Generic;

    public class Produto
    {
        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public int Id { get; private set; }

        /// <summary>
        /// Construtor da classe Produto.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="valor">Valor do produto.</param>
        /// <param name="id">Identificador único do produto.</param>        
        public Produto(string nome, double valor, int id)
        {
            Nome = nome;
            Valor = valor;
            Id = id;
        }
    }
}
