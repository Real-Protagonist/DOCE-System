-- Active: 1662535769897@@127.0.0.1@3306
CREATE DATABASE ATHENA_ROOM
    DEFAULT CHARACTER SET = 'utf8mb4'
    DEFAULT COLLATE utf8mb4_general_ci;

USE ATHENA_ROOM;

CREATE TABLE FUNCIONARIOS (
  ID_FUNC INT PRIMARY KEY AUTO_INCREMENT,
  PRIMEIRO_NOME VARCHAR(255) NOT NULL,
  ULTIMO_NOME VARCHAR(255) NOT NULL,
  SEXO VARCHAR(20) NOT NULL,
  DOCUMENTO VARCHAR(255),
  DATA_NASCIMENTO DATE,
  TEL1 NUMERIC NOT NULL,
  TEL2 NUMERIC,
  EMAIL VARCHAR(255),
  BAIRRO VARCHAR(255),
  RUA VARCHAR(255),
  CASA INT,
  FUNCAO VARCHAR(255),
  DATA_REGISTO DATE
)DEFAULT CHARSET=utf8mb4;

CREATE TABLE USUARIOS (
  ID_USER INT PRIMARY KEY AUTO_INCREMENT,
  NOME_USUARIO VARCHAR(255) NOT NULL,
  SENHA_USUARIO VARCHAR(255) NOT NULL,
  ACTIVE INT,
  STATUS INT,
  DATA_REGISTO DATE,
  DATA_ATUALIZACAO DATE,
  FUNCIONARIO INT,
  FOREIGN KEY(FUNCIONARIO) REFERENCES FUNCIONARIOS(ID_FUNC)
)DEFAULT CHARSET=utf8mb4;

CREATE TABLE CLIENTES (
  ID_CL INT PRIMARY KEY AUTO_INCREMENT,
  PRIMEIRO_NOME VARCHAR(255) NOT NULL,
  ULTIMO_NOME VARCHAR(255) NOT NULL,
  SEXO VARCHAR(20),
  DOCUMENTO VARCHAR(255),
  TEL1 NUMERIC NOT NULL,
  TEL2 NUMERIC,
  EMAIL VARCHAR(255),
  BAIRRO VARCHAR(255),
  RUA VARCHAR(255),
  CASA INT,
  DATA_REGISTO DATE
)DEFAULT CHARSET=utf8mb4;

CREATE TABLE CONTRATOS(
  ID_CONT INT PRIMARY KEY AUTO_INCREMENT,
  CONTRATO_NUMERO VARCHAR(255) NOT NULL,
  DATA DATE,
  CLIENTE INT,
  FOREIGN KEY(CLIENTE) REFERENCES CLIENTES(ID_CL)
);

CREATE TABLE PAGAMENTOS(
  ID_PAG INT PRIMARY KEY AUTO_INCREMENT,
  DESCRICAO VARCHAR(255) NOT NULL,
  MES VARCHAR(255),
  VALOR_PAGAR DECIMAL(12,2),
  MULTA DECIMAL(12,2),
  DESCONTO DECIMAL(12,2),
  VALOR_ENTREGUE DECIMAL(12,2),
  TROCO DECIMAL(12,2),
  OBSERVACAO TEXT,
  DATA_PAGAMENTO DATE,
  DATA_REGISTO DATE,
  CONTRATO INT,
  PAGOU VARCHAR(255) DEFAULT("Cliente"),
  FUNCIONARIO INT,
  FOREIGN KEY(FUNCIONARIO) REFERENCES FUNCIONARIOS(ID_FUNC),
  FOREIGN KEY(CONTRATO) REFERENCES CONTRATOS(ID_CONT)
)DEFAULT CHARSET=utf8mb4;
select * from pagamentos;
drop table pagamentos;

CREATE TABLE FACTURA(
  ID_FACT INT PRIMARY KEY AUTO_INCREMENT,
  NUMERO_FACT VARCHAR(255) NOT NULL,
  CONTRATO INT,
  DATA_EMISSAO DATE,
  HORA_EMISSA TIME(0),
  FUNCIONARIO INT,
  FOREIGN KEY(FUNCIONARIO) REFERENCES FUNCIONARIOS(ID_FUNC),
  FOREIGN KEY(CONTRATO) REFERENCES CONTRATOS(ID_CONT)
);

CREATE TABLE RECLAMACOES(
  ID_RC INT PRIMARY KEY AUTO_INCREMENT,
  ASSUNTO VARCHAR(255),
  DESCRICAO TEXT,
  CONTRATO INT,
  DATA_REGISTO DATE,
  FOREIGN KEY(CONTRATO) REFERENCES CONTRATOS(ID_CONT)
)DEFAULT CHARSET=utf8mb4;

CREATE TABLE EMPRESA(
  ID_EMP INT PRIMARY KEY AUTO_INCREMENT,
  NOME VARCHAR(255),
  NIF VARCHAR(255),
  ENDERCO VARCHAR(255),
  TEL1 NUMERIC NOT NULL,
  TEL2 NUMERIC
)DEFAULT CHARSET=utf8mb4;

CREATE TABLE SERVICOS_PAGAMENTO(
  ID_SERVICO INT PRIMARY KEY AUTO_INCREMENT,
  SERVICO VARCHAR(255) NOT NULL,
  VALOR DECIMAL(12,2)
)DEFAULT CHARSET=utf8mb4;
select * from servicos_pagamento;

create user doce@localhost IDENTIFIED by '5544332211';
grant all PRIVILEGES on *.* to 'doce'@'localhost' ;
flush PRIVILEGES;

mysql --user=username;