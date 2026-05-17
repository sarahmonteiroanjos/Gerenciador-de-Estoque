# 📦 Controle de Estoque 

Este projeto foi desenvolvido como parte de um desafio de bootcamp para resolver uma dor real de microempreendedores. 

## 🌟 Entrega Intermediária (Nova Funcionalidade)
Nesta etapa, o projeto evoluiu para se conectar ao mundo exterior:
- **API Consumida:** [ViaCEP](https://viacep.com.br/) para autocompletar endereços de fornecedores.
- **Qualidade:** Adicionado um **Teste de Integração** automatizado que valida o consumo correto da API.
- **Rastreabilidade:** Tarefa gerenciada via GitHub Issues e integrada através de Pull Request.
- **Deploy/Publicação:** Executável pronto para uso disponível na branch principal.

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
2. Clone este repositório:
   ```bash
   git clone https://github.com/sarahmonteiroanjos/Gerenciador-de-Estoque.git
3. Acesse a pasta do projeto:
cd Gerenciador-de-Estoque
4. Execute o comando para restaurar as dependências:
dotnet restore  

## ⚙️ Instruções de Execução

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone o repositório.
3. Para rodar a aplicação interativa:
   ```bash
   dotnet run --project src/MeuProjetoEstoque.csproj

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
