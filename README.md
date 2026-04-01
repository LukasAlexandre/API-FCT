# API-FCT
API REST em .NET 10 e C# 14 para gerenciamento e entrega de planos de testes de fábrica (FCT) para dispositivos móveis, validando hardware, firmware e calibração.
# 🏭 API-BASE-FCT (Factory Test Plan API)

Uma API RESTful robusta desenvolvida em **.NET 10** e **C# 14** para fornecer planos de testes rigorosos para dispositivos (como tablets e smartphones) em um ambiente de fábrica ou laboratório. 

Esta API é responsável por entregar aos dispositivos móveis todas as diretrizes de execução, critérios de aprovação de hardware/software, configurações de conectividade (Wi-Fi, Bluetooth, GPS) e tolerâncias de calibração (Áudio, Câmera, Sensores) com base em seu `fingerprint` (assinatura de software/firmware).

## 🚀 Tecnologias Integradas
- **Framework:** .NET 10 / ASP.NET Core
- **Linguagem:** C# 14
- **Serialização/JSON:** `System.Text.Json` (Com serialização adaptada camelCase global)
- **Documentação da API:** Swagger / OpenAPI

## 🏗️ Arquitetura e Engenharia Base (S09 & S10)
Este projeto foi construído pensando em resiliência, escalabilidade e conformidade técnica comercial:

- **Separação de Preocupações (SoC):** Camadas bem divididas entre `Models/DTOs`, `Controllers`, `Middlewares` e `Repositories`.
- **Repository Pattern & DI:** `TestPlanController` não acessa dados; ele recebe uma injeção isolada de `ITestPlanRepository`, possibilitando transição ágil de Mocks em memória para Bancos de Dados SQL/NoSQL no futuro.
- **Middleware Global de Erros (`GlobalExceptionMiddleware`):** Proíbe o vazamento de exceções técnicas (ex: erro ao ler o mock, erro de processamento de JSON) e assegura que qualquer erro inesperado retorne um formato padronizado (`ErrorResponseDto`) com StatusCode 500, protegendo a estabilidade do app FCT cliente.
- **Observabilidade (Healthcheck):** Incorporação nativa do .NET para a Rota `/health`, permitindo que orquestradores (Kubernetes, Load Balancers) atestem a disponibilidade de servidor a todo instante.
- **Padronização de Contratos:** Models escritos no C# sob convenção `PascalCase`, acoplados a uma política global `JsonNamingPolicy.CamelCase` na porta da API. Assim, o backend fica limpo e o aplicativo front-end assimila em seu padrão esperado.

## 🛣️ Endpoints Disponíveis

A API possui documentação auto-gerada com o **Swagger**, permitindo testes interativos via interface gráfica. Localmente, abra via link configurado no `launchSettings.json`.

### `GET /testplan`
Recupera um plano de testes funcional em cascata compatível com o produto alvo.

- **Parâmetros (Query string):**
  - `fingerprint` (Obrigatório): Identificador de compilação/firmware do dispositivo no ambiente (ex: `MULTI/TAB10_DEMO/TAB10:13`).
- **Retornos Possíveis:**
  - `200 OK`: Retorna o JSON completo do Plano de Testes (Capabilities, Processos ordenados por ID, Thresholds, etc).
  - `400 Bad Request`: Caso o parâmetro `fingerprint` seja omitido.
  - `404 Not Found`: Caso não exista nenhum plano de testes que cruze o fingerprint cadastrado.

### `GET /health`
Validar integridade do serviço.
- **Retorno:** Status de execução da API (Ex: `Healthy`), pronto para monitoramento Cloud.

## 🛠️ Como Executar o Projeto Localmente

1. Certifique-se de que a máquina possui o **.NET 10 SDK** instalado.
2. Clone o repositório na sua máquina via Git.
3. Certifique-se que o banco de dados simulado está preenchido e presente em `Mocks/Testplan.json` (Raiz do API-FCT).
4. Via terminal (na raiz do projeto `API-FCT`), rode:

```bash
dotnet restore
dotnet run
```
5. A aplicação iniciará na porta configurada (ex: `https://localhost:7105`) abrindo automaticamente a documentação do **Swagger/OpenAPI** em seu navegador padrão.
