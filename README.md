# DesafioKPMG

Para este projeto foi utilizado o framework .Net 6 e o ORM Entity Framework Core 6. Ambos são produtos desenvolvidos pela Microsoft e são amplamente utilizados e possuem ótima documentação. Eu considero ambas boas escolhas para o desenvolvimento da aplicações exigida. A escolha do banco de dados Sqlserver, que também é desenvolvida pela Microsoft, também acredito ser uma boa escolha visto ser amplamente documentado e com boa performance.

A conexão utiliza o seguinte endereço para o banco de dados: "Server=(localdb)\mssqllocaldb\" e o nome do database: "Database=DesafioKPMG".

Para migrar o banco de dados deve ser rodado o comando "update-database" no Package Manager Console do Visual Studio.

Todas as tarefas de implementação foram realizadas com sucesso.

Com relação aos endpoints exigidos:

----------------------------------------

Endpoint 1:

Esse endpoint fica no caminho (POST) "/api/GameResults" e recebe um JSON no formato
	
{
  "playerId": 1,
  "win": 123,
  "timestamp": "2022-04-22T09:40:03.3100424-03:00"
}

ou

{
  "playerId": 1,
  "win": 123
}

Onde este último atribui automaticamente um valor para "timestamp".

O dados enviados são armazenados em cache na memória do servidor e são enviados para o database periodicamente, conforme o tempo definido na variável "GameResultsSaveIntervalSeconds" (inicialmente em 40 segundos) definido em "appsettings.json"

----------------------------------------

Endpoint 2:

Esse endpoint fica no caminho (GET) "/api/Players/Leaderboard" e devolve um JSON no formato

[
  {
    "playerId": 1,
    "balance": 123,
    "lastUpdateDate": "2022-04-22T06:49:55.7431292-03:00"
  },
  {
    "playerId": 2,
    "balance": -123,
    "lastUpdateDate": "2022-04-22T06:50:14.120173-03:00"
  }
]

Os jogadores recebidos por esse endpoint correspondem a pontuação acumulada de forma decrescente até 100 jogadores a partir do maior pontuador. Retornando além do playerId, os valores de balanço (balance) e o timestamp do último GameResult cadastrado no banco de dados.

----------------------------------------

Alem desses são disponibilizados os seguintes endpoints:

(GET) "/api/GameResults/GetResult?Id=1" que retorna os dados de um GameResult por Id

(POST) "/api/Players" para cadastrar jogadores usando um JSON no formato

{
  "username": "user"
}

(GET) "/api/Players/GetPlayer?Id=1" que retorna os dados de um Player por Id

{
  "id": 1,
  "username": "user",
  "gameResults": [
    {
      "gameId": 1,
      "playerId": 1,
      "win": 123,
      "timestamp": "2022-04-22T09:40:03.3100424"
    },
    {
      "gameId": 2,
      "playerId": 1,
      "win": 123,
      "timestamp": "2022-04-22T09:42:56.1196621"
    },
    {
      "gameId": 3,
      "playerId": 1,
      "win": -123,
      "timestamp": "2022-04-22T09:49:55.7431292"
    }
  ],
  "balance": 123,
  "lastUpdateDate": "2022-04-22T09:49:55.7431292"
}
