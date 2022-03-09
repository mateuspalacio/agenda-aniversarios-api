# T�cnicas de integra��o de sistemas

## Equipe

* Mateus Pal�cio
* Pedro Gomes
* Tha�s Ara�jo

## Pr� requisitos para rodar

* .NET 6
* VS 2022
* MySQL

## Como rodar

Baixe o c�digo utilizando-se de `git clone <link do git>` no seu cmd/terminal, e em seguida, localmente abra o arquivo .sln, que ir� carregar o projeto no seu Visual Studio 2022.

Ap�s isso, v� at� Tools -> Nuget Package Manager -> Package Manager Console e abra um terminal do nuget.

Nele, voc� deve rodar `update-database`, que ir� colocar uma tabela do banco de Dados no seu MySQL local. 

Caso queira configurar configura��es como nome da Database, host, user e password, mude-as no `appsettings.json` em ConnectionStrings:AgendaContext.

Por favor garanta que o user e pw no appsettings � igual ao seu local do MySQL.

# Systems Integration Techniques

## Group

* Mateus Pal�cio
* Pedro Gomes
* Tha�s Ara�jo

## Software needed for running the project

* .NET 6
* VS 2022
* MySQL

## How to run

Download the code using the command `git clone <git link>` on your cmd/terminal, and then run the `.sln` file, which will load the project on your Visual Studio 2022.

After that, navigate to Tools -> Nuget Package Manager -> Package Manager Console and open a new nuget terminal.

On the new terminal, run the command `update-database`, which will add a table on your local MySQL DB.

If you which to change the default Database name, host, user or password, change them on the `appsettings.json` file, on the ConnectionStrings:AgendaContext section.

Please make sure that the user and pw on appsettings match your local MySQL settings.