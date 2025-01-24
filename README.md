# GerenciamentoDePedidos.API

1.CRUD (Create, Read, Update, Delete) para gerenciar pedidos.
2. Cada pedido deve conter:
o Identificador único (ID).
o Nome do cliente.
o Data do pedido.
o Itens do pedido (nome do item, quantidade, valor unitário).
o Valor total do pedido (calculado com base nos itens).
3. Permitir filtrar os pedidos por data e/ou nome do cliente

Requisitos Técnicos:
1. Utilize .NET 6 ou superior.
2. Armazene os dados em memória (usando uma lista).
3. Exponha uma API REST com os seguintes endpoints:
o POST /orders: Criar um pedido.
o GET /orders: Listar todos os pedidos.
o GET /orders/{id}: Obter um pedido por ID.
o PUT /orders/{id}: Atualizar um pedido.
o DELETE /orders/{id}: Excluir um pedido.
