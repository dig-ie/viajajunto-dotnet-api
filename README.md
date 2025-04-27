
# 🔧 Viaja Junto Backend

Este é o backend da plataforma **Viaja Junto**, uma aplicação web (com possibilidade de evolução para algo mobile) colaborativa para planejamento e compartilhamento de itinerários de viagem. Construído com **ASP.NET Core Web API**, este backend fornece autenticação, lógica de negócio, integração com serviços de geocodificação e roteamento, e mensageria em tempo real.

## 🧰 Tecnologias Utilizadas

- **ASP.NET Core Web API** – Backend robusto e performático
- **Entity Framework Core** – ORM para acesso a dados
- **RabbitMQ** – Mensageria para notificações em tempo real
- **MySQL** – Banco de dados relacional
- **Swagger** – Documentação interativa da API
- **AutoMapper** – Mapeamento de objetos DTOs e Models

## Viajajunto Modelagem Banco de Dados:
https://github.com/dig-ie/viajajunto_banco_de_dados

## 📦 Funcionalidades

- 🔐 **Autenticação e Autorização**
- 🧾 **CRUD de itinerários com múltiplas paradas**
- 📍 **Geocodificação de endereços (via APIs externas)**
- 🚗 **Cálculo de rotas com múltiplos waypoints**
- 📤 **Publicação de eventos de interação via RabbitMQ**
- 🧑‍🤝‍🧑 **Interações da comunidade: curtidas e comentários**

## 🌐 Integrações Externas

- **PositionStack** – Geocodificação de endereços
- **OpenRouteService** – Cálculo de rotas
- **Mapbox / TomTom / MapQuest** – Renderização de mapas e rotas

## 📦 Commit Semântico (Padrão de mensagens)

| Tipo       | Uso                                                       |
|------------|-----------------------------------------------------------|
| `feat`     | Nova funcionalidade                                       |
| `fix`      | Correção de bug                                           |
| `refactor` | Refatoração de código (sem mudança de comportamento)      |
| `style`    | Ajustes visuais ou de formatação (sem lógica envolvida)   |
| `docs`     | Documentação adicionada ou atualizada                     |
| `test`     | Adição ou modificação de testes                           |
| `chore`    | Tarefas auxiliares (configs, dependências, etc.)          |

## Arquitetura em camadas:
![image](https://github.com/user-attachments/assets/1790d126-08c1-46f1-95ee-bb7f96c64153)

## 🛠 Como rodar localmente

```bash
# Clonar o repositório
git clone https://github.com/dig-ie/viajajunto-backend-dotnet.git

# Entrar na pasta do projeto
cd viajajunto-backend-dotnet

# Configurar appsettings.json com as chaves de API e string de conexão

# Rodar a aplicação (exemplo com .NET CLI)
dotnet run
```

A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

## 📌 Próximos Passos

- [ ] Finalizar modelo de dados
- [ ] Conectar frontend Next.js ao backend
- [ ] Implementar testes automatizados
- [ ] Deploy em ambiente de staging

---

> Backend do projeto **Viaja Junto** – conectando pessoas por meio de jornadas colaborativas.
