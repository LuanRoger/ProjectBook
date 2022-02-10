![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintSplashScreen.png?raw=true)
# Project Book
![](https://img.shields.io/github/v/release/LuanRoger/ProjectBook?include_prereleases)
![](https://img.shields.io/github/license/LuanRoger/ProjectBook)
![](https://img.shields.io/github/last-commit/LuanRoger/ProjectBook)

### Programa para gerenciamento de livros, clientes e aluguel.

## Features
* Acesso rápido para pesquisa e barra superior para acessar.
* Autoformatação para maiúsculo ao salvar.
* Impressão de qualquer pesquisa.
* Sistema de login.
* Atalhos nas teclas de função.

## Tecnologias e linguagem
- [.NET 6](https://dotnet.microsoft.com)
- [SQL Server Express 2019](https://www.microsoft.com/pt-br/sql-server)
- C#
- Entity Framework

## Capturas de tela
![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintInicio.png?raw=true)

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintLogin.png?raw=true)

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintNovoLivro.png?raw=true)

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintNovoCliente.png?raw=true)

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintNovoAluguel.png?raw=true)

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintConfiguracoes.png?raw=true)

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintPesquisaRapida.png?raw=true)

## Pré-requisitos
- [.NET Desktop Runtime 5x](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server Local DB 2019](https://download.microsoft.com/download/7/c/1/7c14e92e-bdcb-4f89-b7cf-93543e7112d1/SqlLocalDB.msi)
- [Microsoft Visual C++ Redistribuível](https://support.microsoft.com/pt-br/topic/os-downloads-do-visual-c-mais-recentes-com-suporte-2647da03-1eea-4433-9aff-95f26a218cc0).

## Configurando
Baixe os dois arquivos (DbModel.mdf e DbModel_log.ldf) em [DbModel](./DbModel) e coloque em qualquer pasta de seu computador.
Estes são os arquivos de banco de dados que o programa usará para guardar os livros.

Depois indique o caminho do arquivo .mdf nas configurações do programa.

Caso esteja com um servidor local apenas coloque a String de conexão do seu servidor, 
mas lembre que você deve anexar os dois arquivos de [DbModel](./DbModel).

Se preferir baixe o [arquivo SQL](./DbModel/ModeloSQL.sql) e execute em seu banco de dados para criar todas as tabelas de forma que o programa consiga interpretar sem problemas.

Se preferir baixe o [arquivo SQL](./DbModel/ModeloSQL.sql) e execute em seu banco de dados para criar todas as tabelas de forma que o programa consiga ler sem problemas.

## Links úteis
- [Problemas frequentes.](https://github.com/LuanRoger/ProjectBook/blob/master/PROBLEMS.md)

## Apoiador
<img src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png" height=170 width=170>

Obrigado à [JetBrains](https://jb.gg/OpenSource) por fornecer softwares para o desenvolvimento do projeto.

*Copyright © 2000-2021 JetBrains s.r.o. JetBrains and the JetBrains logo are registered trademarks of JetBrains s.r.o.*
