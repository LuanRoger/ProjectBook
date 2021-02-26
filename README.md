<h1 align="center">
  <img alt="SplashScreen" src="https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintSplashScreen.png"/>
</h1>

<p>
<img alt="GitHub release" src="https://img.shields.io/github/v/release/LuanRoger/ProjectBook?include_prereleases">
<img alt="GitHub License" src="https://img.shields.io/github/license/LuanRoger/ProjectBook">
<img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/LuanRoger/ProjectBook">
</p>

<h4 align="center"> Programa para gerenciamento de livros, clientes e alguel.</h4>
<h3 align="center">Projeto ainda em desenvolvimento...</h3>

### Features
* Acesso rápido para pesquisa e barra superior para acessar.
* Integração nativa com o OneDrive, oferece sincronização em tempo real para um banco de dados local.
* Autoformatação para maiúsculo ao salvar.
* Impressão de qualquer pesquisa com DGVPrinter.
* Sistema de login.
* Atalhos nas teclas de função.

### Tecnologias e linguagem
- [.NET Core 3.1](https://dotnet.microsoft.com)
- [SQL Server Express 2019](https://www.microsoft.com/pt-br/sql-server)
- SQL Local DB
- C#
### Capturas de tela
![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintInicio.png)
> Inicio.

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintLogin.png?raw=true)
> Login

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintNovoLivro.png)
> Cadastrar livro.

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintNovoCliente.png)
> Cadastrar cliente.

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintNovoAluguel.png)
> Registrar aluguel.

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintConfigura%C3%A7%C3%B5es.png)
> Configurações.

![](https://github.com/LuanRoger/ProjectBook/blob/master/ProjectBook/assets/screenshots/PrintPesquisaRapida.png)
> Pesquisa rápida.

## Pré-requisitos
Para conseguir abrir o programa será necessário instalar o .NET Core 3.1 Runtime,
e para conseguir rodar o banco de dados é preciso instalar o [SQL Server Local DB 2019](https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
e o  [Microsoft Visual C++ Redistribuível](https://support.microsoft.com/pt-br/topic/os-downloads-do-visual-c-mais-recentes-com-suporte-2647da03-1eea-4433-9aff-95f26a218cc0).
Depois é só executar o programa normalmente.

### Configurando
Logo quando abrir o programa verá um erro, pedindo para que inicie a String de conexão,
para isso baixe os dois arquivos em [DbModel](./DbModel) e coloque em qualquer pasta de seu computador e indique o caminho.
Caso esteja com um servidor local apenas coloque a String de conexão do seu servidor,
mas lembre que você deve anexar os dois arquivos de [DbModel](./DbModel) em sua instância do SQL Server.

Se preferir baixe o [arquivo SQL](./DbModel/ModeloSQL.sql) e execute em seu banco de dados para criar todas as tabelas de forma que o programa consiga ler sem problemas.

## OneDrive
<p>
<img alt="onedrive" src="https://img.shields.io/badge/sync-onedrive-blue">
</p>
A integração com OneDrive só funciona no Windows 10 que esteja com o OneDrive instalado e atualizado,
estando com todos os seus arquivos sincronizados. Deve também estar usando um banco de dados local
Para migrar seu banco para o OneDrive basta ir nas Configurações e marcar “OneDrive” e salvar,
irá aparecer um aviso, depois de ler, selecione “Sim” caso esteja de acordoe o programa
será reiniciado automaticamente já com o banco de dados no seu OneDrive.
