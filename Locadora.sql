CREATE DATABASE Locadora_db;
USE Locadora_db;

CREATE TABLE IF NOT EXISTS filmes(
id smallint primary key auto_increment not null,
titulo varchar(100) not null,
ano_lancamento datetime,
diretor varchar(100) not null,
imdb float
);

Insert into filmes values (null, "Jogos Vorazes", "2012-09-12", "Francis Lawrence, Gary Ross", 7.2),
(null, "Carros", "2006-10-02", "John Lasseter", 8),
(null, "Ainda estou aqui", "2024-01-28", "Walter Salles", 8.3);

select * from filmes;