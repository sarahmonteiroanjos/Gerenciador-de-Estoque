//produtos inventory Table 
create table produtos (
    id bigint generated always as identity primary key,
    nome text not null,
    quantidade integer not null,
    quantidade_minima integer not null,
    data_cadastro timestamp default now()
); 

SELECT * FROM produtos;

ALTER TABLE produtos
ADD COLUMN tipo_produto_id BIGINT;

ALTER TABLE produtos
ADD CONSTRAINT fk_produto_tipo
FOREIGN KEY (tipo_produto_id)
REFERENCES tipo_produto(id);


SELECT column_name
FROM information_schema.columns
WHERE table_name = 'produtos';

INSERT INTO produtos
(nome, quantidade, quantidade_minima, tipo_produto_id)
VALUES
('Arroz 5kg', 50, 10, 1),
('Feijao 1kg', 30, 5, 1),
('Refrigerante Cola 2L', 25, 5, 2),
('Agua Mineral 500ml', 100, 20, 2),
('Detergente', 40, 10, 3),
('Sabonete', 60, 15, 4);



//Tabela do tipo Produto 

CREATE TABLE tipo_produto (
    id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nome TEXT NOT NULL,
    descricao TEXT,
    data_cadastro TIMESTAMP DEFAULT NOW()
);


SELECT * FROM tipo_produto;

INSERT INTO tipo_produto (nome, descricao)
VALUES
('Alimentos', 'Produtos alimentícios'),
('Bebidas', 'Refrigerantes e sucos'),
('Limpeza', 'Produtos de limpeza'),
('Higiene', 'Produtos de higiene pessoal');



//Estoque Movimentação

CREATE TABLE movimentacao_estoque (
    id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    produto_id BIGINT NOT NULL,
    tipo_movimentacao TEXT NOT NULL,
    quantidade INTEGER NOT NULL,
    data_movimentacao TIMESTAMP DEFAULT NOW(),

    FOREIGN KEY (produto_id)
    REFERENCES produtos(id)
); 

SELECT * FROM movimentacao_estoque;

INSERT INTO movimentacao_estoque
(produto_id, tipo_movimentacao, quantidade)
VALUES
(1, 'Entrada', 50),
(2, 'Entrada', 30),
(3, 'Saida', 5);
