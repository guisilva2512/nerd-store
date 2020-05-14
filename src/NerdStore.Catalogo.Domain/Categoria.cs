using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        // EF Relation
        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeDiferente(Id, Guid.Empty, "O Id não pode ser vazio!");
            Validacoes.ValidarSeVazio(Nome, "O Nome da categoria não pode estar vazio!");
            Validacoes.ValidarSeIgual(Codigo, 0, "O Código não pode ser 0!");
        }

    }
}
