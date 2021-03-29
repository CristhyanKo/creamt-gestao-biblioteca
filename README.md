# CREA - MT | Gestão de Biblioteca - Livre para Todos

Avaliação prática solicitada pela empresa CREA - MT.

Está aplicação foi desenvolvida inteiramente em .NET, com implementação da arquitetura DDD (Domain Driver Design) para o backend, trazendo o máximo de abstrações para fácil manutenção e crescimento do código, já o FrontEnd foi feito utilizando Wep App MVC.

#### Gif apresentando todo fluxo da aplicação.
![](app.gif)
#### Recursos utilizados
- C#, HMTL, CSS, JQuery, Bootstrap
- SQL Server, EF - Entity Framework
- DDD, MVC 5

#### Resumo do desenvolvimento
O projeto foi separado em 5 camadas, sendo elas:

- **Entities** - Camada responsável por representar os modelos das tabelas do banco de dados.
- **Domain** - Camada responsável por guardar toda a regra de negócio do projeto.
- **Infra** - Camada responsável pelo acesso, comunicação e execução de comandos no banco de dados.
- **Application** - Camada responsável por fazer a ponte entre o domínio da aplicação e a apresentação final, definindo quais métodos o projeto de apresentação poderá utilizar.
- **Presentation** - Camada responsável em entregar uma interface para que o usuário final possa executar suas interações.

Design simples feito a mão, utilizando modelo de layout em Flexbox para facil disposição dos componentes em tela.

Views geradas a partir do scaffolding da propiá IDE (Visual Studio Community), tendo as devidas modificações para funcionamento das mesmas na estrutura adotada.

## Como usar

Pré requisitos

- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Visual Studio 2019 ou Visual Studio Code](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=16)
- [DotNet Core](https://dotnet.microsoft.com/download)

Faça o download deste repositório e acesse a pasta de onde foi baixado o seu projeto, após o download execute o arquivo **GestaoMais.sln**

Ao executar a solução dirija-se até o seguinte arquivo no Visual Studio:
```
Infra > GestaoMais.Infrastructure > Configuration > ContextBase.cs
```

Altere as informações de conexão ao banco de dados para a sua preferência

```cs
private string GetStrConn()
        {
            var dataSource = "DESKTOP\\SQL";
            var database = "creamt-gestao-biblioteca";
            var user = "sa";
            var password = "123456";

            return $"Data Source={dataSource};Initial Catalog={database};Integrated Security=False;User ID={user};Password={password};Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
```

Defina o projeto GestaoMais.Web como o de inicialização.
```
Presentation > GestaoMais.Web
```

Após estas configurações basta iniciar o projeto, a geração do banco é automática com o seed de algumas informações básicas.

