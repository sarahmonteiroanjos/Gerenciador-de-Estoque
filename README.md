# 📦 Controle de Estoque 

Este projeto foi desenvolvido como parte de um desafio de bootcamp para resolver uma dor real de microempreendedores.

## 🚀 O Problema
Muitos microempreendedores (confeiteiros, artesãos, revendedores) gerenciam seu estoque de forma manual, o que gera esquecimentos e perda de vendas por falta de mercadoria.

## 💡 Proposta da Solução
Uma aplicação de linha de comando (CLI) simples que permite o cadastro de produtos com limites mínimos, gerando alertas automáticos de reposição.

## 👥 Público-alvo
Microempreendedores e pequenos comerciantes que precisam de uma ferramenta leve e gratuita para controle de mercadorias.

## ✨ Funcionalidades Principais
- Cadastro de produtos com nome e quantidade.
- Definição de estoque mínimo para alertas.
- Visualização de relatório com cores de aviso (Vermelho para estoque baixo).

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** C# (.NET)
- **Framework de Testes:** xUnit
- **CI/CD:** GitHub Actions

## 📥 Instruções de Instalação
1. Instale o .NET SDK (versão 10.0 ou superior).(https://dotnet.microsoft.com/download).
2. Clone este repositório.
    git clone (https://github.com/sarahmonteiroanjos/Gerenciador-de-Estoque.git)
3. Vá até a diretorio  `src`.
4. Execute `dotnet restore` para baixar as dependências.  

## ⚙️ Instruções de Execução
Na pasta do projeto, digite:
    dotnet run

## ▶️ Como rodar os testes
Para validar se o sistema está calculando os alertas corretamente, use:
    dotnet test

## 🧹 Como rodar o lint
Para verificar a qualidade e o estilo do código, utilize:
     dotnet format --verify-no-changes

## ✨ Versão
Este projeto utiliza o padrão de versões v1.0.0.

## 👩‍💻 Autor:
Sarah Monteiro dos Anjos

## 🔗 Link do Repositório
   https://github.com/sarahmonteiroanjos/Gerenciador-de-Estoque.git 
