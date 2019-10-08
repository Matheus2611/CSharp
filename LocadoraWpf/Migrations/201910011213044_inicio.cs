namespace LocadoraWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CARRO",
                c => new
                    {
                        IdVeiculo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Cor = c.String(),
                        Ano = c.Int(nullable: false),
                        Placa = c.String(),
                        ValorPorDia = c.Double(nullable: false),
                        ValorPorHora = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.IdVeiculo);
            
            CreateTable(
                "dbo.DEVOLUCAO",
                c => new
                    {
                        IdDevolucao = c.Int(nullable: false, identity: true),
                        Carro_IdVeiculo = c.Int(),
                        Cliente_IdCliente = c.Int(),
                        Moto_IdVeiculo = c.Int(),
                        Reserva_IdReserva = c.Int(),
                    })
                .PrimaryKey(t => t.IdDevolucao)
                .ForeignKey("dbo.CARRO", t => t.Carro_IdVeiculo)
                .ForeignKey("dbo.CLIENTE", t => t.Cliente_IdCliente)
                .ForeignKey("dbo.MOTO", t => t.Moto_IdVeiculo)
                .ForeignKey("dbo.RESERVA", t => t.Reserva_IdReserva)
                .Index(t => t.Carro_IdVeiculo)
                .Index(t => t.Cliente_IdCliente)
                .Index(t => t.Moto_IdVeiculo)
                .Index(t => t.Reserva_IdReserva);
            
            CreateTable(
                "dbo.CLIENTE",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Rg = c.String(),
                        Cpf = c.String(),
                        Senha = c.String(),
                        Cnh = c.String(),
                        cep = c.String(),
                        Telefone = c.String(),
                        PossuiReserva = c.String(),
                        Endereco_Rua = c.String(),
                        Endereco_Bairro = c.String(),
                        Endereco_Cidade = c.String(),
                        Endereco_Estado = c.String(),
                        Endereco_Numero = c.Int(),
                        CategoriaCnh = c.String(),
                        Status = c.String(),
                        MotoId = c.Int(nullable: false),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.PAGAMENTO",
                c => new
                    {
                        IdPagamento = c.Int(nullable: false, identity: true),
                        Credito = c.Boolean(),
                        Debito = c.Boolean(),
                        Dinheiro = c.Boolean(),
                        NroCartao = c.String(),
                        DataHoraPagamento = c.DateTime(nullable: false),
                        Status = c.String(),
                        ValorTotalReserva = c.Double(nullable: false),
                        ValorPagamento = c.Double(nullable: false),
                        ValorTroco = c.Double(nullable: false),
                        Cliente_IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.IdPagamento)
                .ForeignKey("dbo.CLIENTE", t => t.Cliente_IdCliente)
                .Index(t => t.Cliente_IdCliente);
            
            CreateTable(
                "dbo.RESERVA",
                c => new
                    {
                        IdReserva = c.Int(nullable: false, identity: true),
                        DataReserva = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(nullable: false),
                        ValorTotalReserva = c.Double(nullable: false),
                        Status = c.String(),
                        ClienteId = c.Int(nullable: false),
                        CarroId = c.Int(nullable: false),
                        MotoId = c.Int(nullable: false),
                        Carro_IdVeiculo = c.Int(),
                        Cliente_IdCliente = c.Int(),
                        Moto_IdVeiculo = c.Int(),
                    })
                .PrimaryKey(t => t.IdReserva)
                .ForeignKey("dbo.CARRO", t => t.Carro_IdVeiculo)
                .ForeignKey("dbo.CLIENTE", t => t.Cliente_IdCliente)
                .ForeignKey("dbo.MOTO", t => t.Moto_IdVeiculo)
                .Index(t => t.Carro_IdVeiculo)
                .Index(t => t.Cliente_IdCliente)
                .Index(t => t.Moto_IdVeiculo);
            
            CreateTable(
                "dbo.MOTO",
                c => new
                    {
                        IdVeiculo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Cor = c.String(),
                        Ano = c.Int(nullable: false),
                        Placa = c.String(),
                        ValorPorDia = c.Double(nullable: false),
                        ValorPorHora = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.IdVeiculo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DEVOLUCAO", "Reserva_IdReserva", "dbo.RESERVA");
            DropForeignKey("dbo.RESERVA", "Moto_IdVeiculo", "dbo.MOTO");
            DropForeignKey("dbo.DEVOLUCAO", "Moto_IdVeiculo", "dbo.MOTO");
            DropForeignKey("dbo.RESERVA", "Cliente_IdCliente", "dbo.CLIENTE");
            DropForeignKey("dbo.RESERVA", "Carro_IdVeiculo", "dbo.CARRO");
            DropForeignKey("dbo.PAGAMENTO", "Cliente_IdCliente", "dbo.CLIENTE");
            DropForeignKey("dbo.DEVOLUCAO", "Cliente_IdCliente", "dbo.CLIENTE");
            DropForeignKey("dbo.DEVOLUCAO", "Carro_IdVeiculo", "dbo.CARRO");
            DropIndex("dbo.RESERVA", new[] { "Moto_IdVeiculo" });
            DropIndex("dbo.RESERVA", new[] { "Cliente_IdCliente" });
            DropIndex("dbo.RESERVA", new[] { "Carro_IdVeiculo" });
            DropIndex("dbo.PAGAMENTO", new[] { "Cliente_IdCliente" });
            DropIndex("dbo.DEVOLUCAO", new[] { "Reserva_IdReserva" });
            DropIndex("dbo.DEVOLUCAO", new[] { "Moto_IdVeiculo" });
            DropIndex("dbo.DEVOLUCAO", new[] { "Cliente_IdCliente" });
            DropIndex("dbo.DEVOLUCAO", new[] { "Carro_IdVeiculo" });
            DropTable("dbo.MOTO");
            DropTable("dbo.RESERVA");
            DropTable("dbo.PAGAMENTO");
            DropTable("dbo.CLIENTE");
            DropTable("dbo.DEVOLUCAO");
            DropTable("dbo.CARRO");
        }
    }
}
