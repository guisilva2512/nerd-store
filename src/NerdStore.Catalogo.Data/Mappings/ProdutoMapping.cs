using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Defindo a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // Mapeando o objeto de valor Dimensoes, na mesma tabela do produto
            // O mesmo não é uma entidade pra ser gerado em outra tabela
            builder.OwnsOne(p => p.Dimensoes, dimen =>
            {
                dimen.Property(d => d.Altura)
                    .HasColumnName("Altura")
                    .HasColumnType("int");

                dimen.Property(d => d.Largura)
                    .HasColumnName("Largura")
                    .HasColumnType("int");

                dimen.Property(d => d.Profundidade)
                    .HasColumnName("Profundidade")
                    .HasColumnType("int");
            });

            builder.ToTable("Produtos");
        }
    }
}
