create database locadora_db;
use locadora_db;

create table filmes(
id int primary key not null auto_increment,
nome varchar(255) not null,
genero varchar(255) not null,

ano_lancamento datetime
);

select * from filmes;

insert into filmes values (null, 'Velozes e Furiosos', 'Ação', '2012-01-01'),
(null, 'O Segredo da Montanha Brokeback', 'Drama', '2003-05-12');