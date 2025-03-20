# APISRBCOMERCIAL

## Sobre o Projeto

**APISRBCOMERCIAL** é uma API desenvolvida com .NET 8.0 para fornecer serviços de gestão comercial. A API permite o cadastro, atualização, exclusão e consulta de produtos, clientes e pedidos.

## Tecnologias Utilizadas
- .NET 8.0
- C#
- MySQL (banco de dados)
- Entity Framework Core (ORM)
- JWT para autenticação
- Swagger para documentação

## Requisitos
- .NET 8.0 SDK
- Banco de dados MySQL configurado

## Instalação e Execução

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/APISRBCOMERCIAL.git
   cd APISRBCOMERCIAL
   ```

2. Configure as variáveis de ambiente no arquivo `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=srbcomercial;User=root;Password=sua_senha;"
     },
     "Jwt": {
       "Key": "sua_chave_secreta",
       "Issuer": "seu_issuer",
       "Audience": "sua_audience"
     }
   }
   ```

3. Execute as migrações do banco de dados:
   ```sh
   dotnet ef database update
   ```

4. Inicie a API:
   ```sh
   dotnet run
   ```

5. Acesse a documentação da API (Swagger) em:
   ```
   http://localhost:5000/swagger
   ```

## Endpoints Principais
- **GET** `/products` - Listagem de produtos
- **POST** `/products` - Cadastro de um novo produto
- **PUT** `/products/:id` - Atualização de um produto
- **DELETE** `/products/:id` - Exclusão de um produto
- **GET** `/clients` - Listagem de clientes
- **POST** `/clients` - Cadastro de um novo cliente
- **GET** `/orders` - Listagem de pedidos
- **POST** `/orders` - Cadastro de um novo pedido

## Contribuição
Contribuições são bem-vindas! Para contribuir:
1. Fork o repositório
2. Crie uma branch (`git checkout -b feature/nova-funcionalidade`)
3. Commit suas alterações (`git commit -m 'Adicionando nova funcionalidade'`)
4. Envie para o repositório remoto (`git push origin feature/nova-funcionalidade`)
5. Abra um Pull Request

## Licença
Direitos da api por SRB-COMERCIAL

---
Desenvolvido por Samuel R Batista

