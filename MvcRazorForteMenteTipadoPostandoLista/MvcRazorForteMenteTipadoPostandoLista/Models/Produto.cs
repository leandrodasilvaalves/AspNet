﻿namespace MvcRazorForteMenteTipadoPostandoLista.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public bool Ativo { get; set; }
    }
}