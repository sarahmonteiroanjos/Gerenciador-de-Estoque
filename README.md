# 📦 Controle de Estoque

Este projeto foi desenvolvido como parte de um desafio de bootcamp para resolver uma dor real de microempreendedores.

## 🌟 Entrega Intermediária (Nova Funcionalidade)

Nesta etapa, o projeto evoluiu para se conectar ao mundo exterior:

* **API Consumida:** ViaCEP para consulta e validação de endereços através do CEP.
* **Testes Automatizados:** Implementação de testes de integração utilizando xUnit.
* **Qualidade:** Validação de cenários positivos e negativos relacionados à consulta de CEP.
* **Rastreabilidade:** Desenvolvimento realizado através de branch dedicada, Pull Request e GitHub Issues.
* **Deploy/Publicação:** Aplicação disponível na branch principal do projeto.

## 🚀 O Problema

Muitos microempreendedores (confeiteiros, artesãos e revendedores) gerenciam seu estoque manualmente, o que pode causar esquecimentos, falta de produtos e perda de vendas.

## 💡 Proposta da Solução

Uma aplicação de linha de comando (CLI) que permite o cadastro e gerenciamento de produtos, possibilitando o acompanhamento das quantidades em estoque e a definição de limites mínimos para reposição.

## 👥 Público-Alvo

Microempreendedores e pequenos comerciantes que necessitam de uma solução simples, gratuita e de fácil utilização para controle de estoque.

## ✨ Funcionalidades

* Cadastro de produtos.
* Definição de quantidade mínima para reposição.
* Consulta de produtos cadastrados.
* Pesquisa de produtos.
* Integração com a API ViaCEP.
* Consulta de endereços através do CEP.
* Validações de entrada para evitar dados inconsistentes.

## 🧪 Testes Implementados

Foram desenvolvidos testes de integração utilizando o framework xUnit para validar o comportamento do serviço ViaCEP.

### Cenários testados

* Consulta de CEP válido.
* Consulta de CEP contendo hífen.
* Consulta de CEP contendo espaços.
* CEP vazio.
* CEP com menos de 8 dígitos.
* CEP com mais de 8 dígitos.
* CEP inexistente.
* CEP contendo caracteres alfabéticos.

Resultado atual:

* Total de testes: 8
* Testes aprovados: 8
* Testes com falha: 0

## 🛠️ Tecnologias Utilizadas

* C#
* .NET 10
* PostgreSQL
* ViaCEP API
* xUnit
* GitHub Actions
* GitHub

## 📥 Instalação

1. Instale o .NET SDK:
   https://dotnet.microsoft.com/download

2. Clone o repositório:

```bash
git clone https://github.com/sarahmonteiroanjos/Gerenciador-de-Estoque.git
```

3. Acesse a pasta:

```bash
cd Gerenciador-de-Estoque
```

4. Restaure as dependências:

```bash
dotnet restore
```

## ⚙️ Execução

Execute a aplicação:

```bash
dotnet run --project src/MeuProjetoEstoque.csproj
```

## ▶️ Executando os Testes

```bash
dotnet test
```

## 🧹 Verificação de Qualidade

```bash
dotnet format --verify-no-changes
```

## 🔀 Fluxo de Desenvolvimento

Para implementação de novas funcionalidades, utilize branches específicas:

```bash
git checkout -b feature/nome-da-funcionalidade
```

Após concluir o desenvolvimento:

```bash
git add .
git commit -m "Descrição da alteração"
git push -u origin feature/nome-da-funcionalidade
```

Em seguida, abra um Pull Request para revisão e integração ao projeto.

## ✨ Versão

v1.0.0

## 👩‍💻 Autora

Sarah Monteiro dos Anjos

## 🔗 Repositório

https://github.com/sarahmonteiroanjos/Gerenciador-de-Estoque

