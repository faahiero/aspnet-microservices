**Projeto desenvolvido no curso -> https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/**

Visão geral das implementações de microserviços utilizando .NET 7 em um projeto real de microserviços de comércio eletrônico.

![microservices_remastered](https://user-images.githubusercontent.com/1147445/110304529-c5b70180-800c-11eb-832b-a2751b5bda76.png)

Os microserviços desenvolvidos são responsáveis por funcionalidades comumente encontradas em comércios eletrônicos, como por exemplo, **Catálogo**, **Cesta**, **Desconto** e **Pedido**, utilizando **bancos de dados NoSQL (MongoDB, Redis)** e **bancos de dados relacionais (PostgreSQL, SQL Server)**, com comunicação através do **RabbitMQ Event Driven Communication** e fazendo uso do **Ocelot API Gateway**.

## Principais recursos do projeto:

#### Microserviço de Catálogo: 
* Aplicação ASP.NET Web API 
* Princípios de API REST, operações CRUD
* Conexão e conteinerização do **banco de dados MongoDB**
* Implementação do Padrão Repositório
* Implementação do Swagger Open API

#### Microserviço de Cesta:
* Aplicação ASP.NET Web API 
* Princípios de API REST, operações CRUD
* Conexão e conteinerização do **banco de dados Redis**
* Consumo do **Serviço Grpc** de Desconto para comunicação inter-serviço e calculo de preço final do produto
* Publicação da Fila de Checkout da Cesta usando **MassTransit e RabbitMQ**
  
#### Microserviço de Desconto:
* Aplicação ASP.NET **Grpc Servidor**
* **Comunicação Grpc inter-serviço** altamente eficiente com o Microserviço de Cesta
* Exposição de Serviços Grpc com criação de **mensagens Protobuf**
* Uso do micro-ORM **Dapper** para simplificar o acesso aos dados e garantir alta performance
* Conexão e conteinerização do **banco de dados PostgreSQL**

#### Comunicação entre Microserviços:
* **Comunicação Grpc** síncrona inter-serviço
* Comunicação assíncrona entre Microserviços com o **serviço de Message-Broker RabbitMQ**
* Uso do mecanismo de **Publicação/Assinatura de tópicos do RabbitMQ**
* Uso do **MassTransit** para abstração do sistema de Message-Broker RabbitMQ
* Publicação da fila de eventos BasketCheckout a partir dos microserviços de Cesta e inscrição deste evento nos microserviços de Pedidos
* Criação da **biblioteca de classe RabbitMQ EventBus.Messages** e adição de referências aos Microserviços

#### Microserviço de Pedidos:

* Implementação de **DDD, CQRS e Arquitetura Limpa** seguindo as Melhores Práticas
* Desenvolvimento de **CQRS usando pacotes MediatR, FluentValidation e AutoMapper**
* Consumo da fila de eventos BasketCheckout do **RabbitMQ** usando a Configuração **MassTransit-RabbitMQ**
* Conexão e conteinerização do **banco de dados SqlServer**
* Uso do **ORM Entity Framework Core** com migração automática para SqlServer durante a inicialização da aplicação

#### API Gateway Ocelot:
* Implementação de **Gateways de API com Ocelot**
* Microserviços/contêineres de amostra para roteamento através dos Gateways de API
* Execução de vários tipos diferentes de containers de **API Gateway/BFF**
* Padrão de Agregação de Gateway em Shopping.Aggregator

#### Microserviço WebUI ShoppingApp:
* Aplicação Web ASP.NET com Bootstrap 4 e modelo Razor
* Chamadas às APIs do Ocelot com Refit

#### Contêineres Auxiliares: 
* Uso do **Portainer** para uma interface de gerenciamento leve de contêineres que permite gerenciar facilmente diferentes ambientes Docker
* Ferramentas **pgAdmin PostgreSQL**, uma plataforma rica em recursos e de código aberto para administração e desenvolvimento do PostgreSQL

#### Configuração Docker Compose com todos os microserviços em Docker:

* Containerização de microserviços
* Containerização de bancos de dados
* Substituição de variáveis de ambiente

## Execute o projeto:
Você precisará das seguintes ferramentas:

* [Visual Studio 2019 +](https://visualstudio.microsoft.com/downloads/) ou [Jetbrains Rider](https://www.jetbrains.com/rider/)
* [.NET 5 +](https://dotnet.microsoft.com/download/dotnet-core/5)
* [Docker Desktop](https://www.docker.com/products/docker-desktop) (No Windows)

### Instalação:
Siga estas etapas para configurar seu ambiente de desenvolvimento: (Antes de iniciar o Docker Desktop)

1. Clone o repositório
2. Depois de instalar o Docker para Windows, vá para **Configurações** > **Opções Avançadas**, no ícone do Docker na bandeja do sistema, para configurar a quantidade mínima de memória e CPU da seguinte forma:
* **Memória: 4 GB**
* CPU: 2
3. No diretório raiz, que inclui os arquivos **docker-compose.yml**, execute o seguinte comando:
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

4. Aguarde o docker compor todos os microserviços. Alguns deles podem precisar de tempo extra para funcionar, então aguarde se não funcionar na primeira tentativa

5. Você pode iniciar os microserviços nas seguintes URLs:

* **Catalog API -> http://host.docker.internal:8000/swagger/index.html**
* **Basket API -> http://host.docker.internal:8001/swagger/index.html**
* **Discount API -> http://host.docker.internal:8002/swagger/index.html**
* **Ordering API -> http://host.docker.internal:8004/swagger/index.html**
* **Shopping.Aggregator -> http://host.docker.internal:8005/swagger/index.html**
* **API Gateway -> http://host.docker.internal:8010/Catalog**
* **Rabbit Management Dashboard -> http://host.docker.internal:15672**   -- guest/guest
* **Portainer -> http://host.docker.internal:9000**   -- admin/admin1234
* **pgAdmin PostgreSQL -> http://host.docker.internal:5050**   -- admin@aspnetrun.com/admin1234
* **Web UI -> http://host.docker.internal:8006**

6. Inicie http://host.docker.internal:8006 no seu navegador para visualizar a Interface Web. Você pode usar o projeto Web para chamar os microserviços por meio do API Gateway. Ao finalizar a compra, você pode acompanhar o registro da fila no painel do RabbitMQ.

![mainscreen2](https://user-images.githubusercontent.com/1147445/81381837-08226000-9116-11ea-9489-82645b8dbfc4.png)
