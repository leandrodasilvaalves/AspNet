CREATE TABLE cargo(
   id  SERIAL PRIMARY KEY,
   descricao varchar(100) NOT NULL
);

CREATE TABLE funcionario(
   id  SERIAL PRIMARY KEY,
   nome varchar(100) NOT NULL,
   email varchar(150) NOT NULL,
   cargoId integer
);