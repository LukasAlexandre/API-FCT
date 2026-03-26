# API-FCT
API REST em .NET 10 e C# 14 para gerenciamento e entrega de planos de testes de fábrica (FCT) para dispositivos móveis, validando hardware, firmware e calibração.
# 🏭 API-BASE-FCT (Factory Test Plan API)

Uma API RESTful robusta desenvolvida em **.NET 10** e **C# 14** para fornecer planos de testes rigorosos para dispositivos (como tablets e smartphones) em um ambiente de fábrica ou laboratório. 

Esta API é responsável por entregar aos dispositivos todas as diretrizes de execução, critérios de aprovação de hardware/software, configurações de conectividade (Wi-Fi, Bluetooth, GPS) e tolerâncias de calibração (Áudio, Câmera, Sensores) com base em seu `fingerprint` (assinatura de software/firmware).

## 🚀 Tecnologias Integradas
- **Framework:** .NET 10 / ASP.NET Core
- **Linguagem:** C# 14
- **Serialização/JSON:** `System.Text.Json`
- **Documentação da API:** Swagger / OpenAPI

## 🏗️ Arquitetura e Padrões de Projeto
Este projeto foi construído pensando em escalabilidade e manutenibilidade, utilizando as melhores práticas do mercado:
- **Separação de Preocupações (SoC):** Divisão clara entre `Models`, `Controllers` e `Repositories`.
- **Repository Pattern (Padrão Repositório):** Abstração da camada de acesso a dados permitindo que a API não dependa diretamente do meio de armazenamento.
- **Injeção de Dependências (DI):** Gerenciamento do ciclo de vida dos repositórios nativamente estruturado no `Program.cs`.
- **Mock de Dados (In-Memory Data):** Implementação atual (`InMemoryTestPlanRepository`) consome um arquivo JSON físico para simular o banco de dados e possibilitar o desenvolvimento ágil.

## ⚙️ Principais Funcionalidades Modeladas
O domínio (`TestPlanModel`) lida com um nível extremo de detalhamento de testes, suportando:
*   **Políticas de Execução & Estação:** Regras de parada crítica, limites de tempo, login de operador e requisitos de palete.
*   **Gestão de Hardware (Capabilities):** Mapeamento de quais componentes o aparelho possui (Telefonia, SIM, Câmeras, SD Card, etc.).
*   **Limites de Calibração (Threshold Profiles):** Frequência (Hz), ruído de fundo (dB) para caixas e microfones; Desfoque, brilho e similaridade de imagem (SSIM) para câmeras.

## 🛣️ Endpoints Disponíveis

A API possui documentação interativa via **Swagger**. Ao rodar o projeto localmente, acesse a rota raiz ou `/swagger` no navegador.

### `GET /api/v1/testplan`
Recupera um plano de testes específico para o dispositivo que está solicitando.
- **Parâmetros de Consulta (Query):**
  - `fingerprint` (Obrigatório): String com a assinatura de compilação/firmware do dispositivo.
- **Respostas:**
  - `200 OK`: Retorna o JSON completo do Plano de Testes.
  - `400 Bad Request`: Caso o parâmetro `fingerprint` esteja vazio.
  - `404 Not Found`: Caso não exista nenhum plano de testes ativo para o firmware informado.

## 🛠️ Como executar localmente
1. Certifique-se de ter o **.NET 10 SDK** instalado no seu ambiente.
2. Clone este repositório.
3. Garanta que o arquivo contendo o banco de dados simulado (`Mocks/Testplan.json`) existe na raiz do projeto.
4. Restaure as dependências e execute via terminal:
