SET IDENTITY_INSERT [dbo].[CLIENTE] ON
INSERT INTO [dbo].[CLIENTE] ([IdCliente], [Nome], [Rg], [Cpf], [Senha], [Cnh], [Telefone], [Endereco_Rua], [Endereco_Bairro], [Endereco_Cidade], [Endereco_Estado], [Endereco_Numero], [CategoriaCnh], [Reserva_IdReserva], [Devolucao_IdDevolucao]) VALUES (10, N'testee', N'teste', N'teste', N'teste', N'teste', N'teste', N'teste', N'teste', N'teste', N'teste', 121, N'AB', NULL, NULL)
INSERT INTO [dbo].[CLIENTE] ([IdCliente], [Nome], [Rg], [Cpf], [Senha], [Cnh], [Telefone], [Endereco_Rua], [Endereco_Bairro], [Endereco_Cidade], [Endereco_Estado], [Endereco_Numero], [CategoriaCnh], [Reserva_IdReserva], [Devolucao_IdDevolucao]) VALUES (12, N'231321', N'123', N'123', N'123', N'123', N'123', N'123', N'123', N'123', N'123', 123, N'A', NULL, NULL)
INSERT INTO [dbo].[CLIENTE] ([IdCliente], [Nome], [Rg], [Cpf], [Senha], [Cnh], [Telefone], [Endereco_Rua], [Endereco_Bairro], [Endereco_Cidade], [Endereco_Estado], [Endereco_Numero], [CategoriaCnh], [Reserva_IdReserva], [Devolucao_IdDevolucao]) VALUES (13, N'TESTE', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'a', N'a', 5, N'AB', 24, NULL)
INSERT INTO [dbo].[CLIENTE] ([IdCliente], [Nome], [Rg], [Cpf], [Senha], [Cnh], [Telefone], [Endereco_Rua], [Endereco_Bairro], [Endereco_Cidade], [Endereco_Estado], [Endereco_Numero], [CategoriaCnh], [Reserva_IdReserva], [Devolucao_IdDevolucao]) VALUES (14, N's', N's', N's', N's', N's', N's', N's', N's', N's', N's', 2, N'AB', 25, NULL)
SET IDENTITY_INSERT [dbo].[CLIENTE] OFF


SELECT C.Nome, C.IdCliente, CR.IdCarro, R.[Status], R.DataDevolucao, R.DataReserva,R.IdReserva,R.ValorTotalReserva FROM RESERVA R
INNER JOIN CLIENTE C ON R.IdReserva  = C.Reserva_IdReserva 
INNER JOIN CARRO CR ON R.IdReserva = CR.reserva_IdReserva
WHERE R.[Status] = 'APROVADO'