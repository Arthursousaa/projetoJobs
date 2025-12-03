CREATE DATABASE ProjetoJobs;
go
 
USE ProjetoJobs;
go
 
CREATE TABLE Empresa(
    id INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(120) NOT NULL,
    CNPJ VARCHAR(14) NOT NULL,
    Email VARCHAR(70) NOT NULL,
    Senha VARCHAR(30) NOT NULL,
    Telefone VARCHAR(11),
    Cidade VARCHAR(100),
    Estado VARCHAR(50),
    Descricao VARCHAR(MAX)
);
go
 
CREATE TABLE Candidato (
    id INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(11) UNIQUE NOT NULL,
    DataNascimento DATE,
    Email VARCHAR(70),
    Senha VARCHAR(30),
    Telefone VARCHAR(11),
    Cidade VARCHAR(100),
    Estado VARCHAR(50),
    ResumoPerfil VARCHAR(MAX)
);
go
 
CREATE TABLE Vaga (
    id INT PRIMARY KEY IDENTITY,
    NomeVaga VARCHAR(100) NOT NULL,
    Cidade VARCHAR(100),
    Estado VARCHAR(50),
    HoraInicio TIME NOT NULL,
    HoraFim TIME NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,
    TipoContrato VARCHAR(50),
    NivelExperiencia VARCHAR(50),
    DescricaoVaga VARCHAR(MAX),
 
    Empresas_id INT NOT NULL,
    FOREIGN KEY (Empresas_id) REFERENCES Empresa(id)
);
go
 
CREATE TABLE Curriculo(
    id INT PRIMARY KEY IDENTITY,
    nome_arquivo VARCHAR(255),
    caminho_arquivo VARCHAR(500),
    data_envio DATETIME DEFAULT GETDATE(),
 
    Candidatos_id INT NOT NULL,
    FOREIGN KEY (Candidatos_id) REFERENCES Candidato(id),
 
    Vagas_id INT NOT NULL,
    FOREIGN KEY (Vagas_id) REFERENCES Vaga(id)
);
go
 
INSERT INTO Empresa (Nome, CNPJ, Email, Senha, Telefone, Cidade, Estado, Descricao)
VALUES
('Tech Solutions', '11111111000101', 'contato@tech.com', '123', '11999990001', 'São Paulo', 'SP', 'Empresa de tecnologia'),
('Web Sistemas', '22222222000102', 'web@sis.com', '123', '21999990002', 'Rio de Janeiro', 'RJ', 'Sistemas web'),
('InfoTech Brasil', '33333333000103', 'info@info.com', '123', '31999990003', 'Belo Horizonte', 'MG', 'Consultoria em TI'),
('Data Code', '44444444000104', 'data@code.com', '123', '41999990004', 'Curitiba', 'PR', 'Análise de dados'),
('Start Digital', '55555555000105', 'start@digital.com', '123', '71999990005', 'Salvador', 'BA', 'Startup de software');
 
go
-- CANDIDATOS
INSERT INTO Candidato (Nome, CPF, DataNascimento, Email, Senha, Telefone, Cidade, Estado, ResumoPerfil)
VALUES
('Ana Silva', '12345678901', '1999-05-12', 'ana@gmail.com', '123', '11988880001', 'São Paulo', 'SP', 'Estudante de tecnologia'),
('Bruno Santos', '23456789012', '1996-08-20', 'bruno@gmail.com', '123', '21988880002', 'Rio de Janeiro', 'RJ', 'Analista de suporte'),
('Carla Oliveira', '34567890123', '2000-02-10', 'carla@gmail.com', '123', '31988880003', 'Belo Horizonte', 'MG', 'Desenvolvedora iniciante'),
('Diego Pereira', '45678901234', '1997-11-03', 'diego@gmail.com', '123', '41988880004', 'Curitiba', 'PR', 'Programador backend'),
('Eduarda Costa', '56789012345', '2002-09-18', 'eduarda@gmail.com', '123', '71988880005', 'Salvador', 'BA', 'Estudante de ADS');
 
go
-- VAGAS
INSERT INTO Vaga (NomeVaga, Cidade, Estado, HoraInicio, HoraFim, Salario, TipoContrato, NivelExperiencia, DescricaoVaga, Empresas_id)
VALUES
('Desenvolvedor Web', 'São Paulo', 'SP', '08:00', '17:00', 3000.00, 'CLT', 'Júnior', 'Criação de sites', 1),
('Suporte Técnico', 'Rio de Janeiro', 'RJ', '09:00', '18:00', 2500.00, 'CLT', 'Pleno', 'Atendimento ao cliente', 2),
('Programador Java', 'Belo Horizonte', 'MG', '08:00', '17:00', 3500.00, 'PJ', 'Júnior', 'Desenvolvimento em Java', 3),
('Analista de Dados', 'Curitiba', 'PR', '09:00', '18:00', 4500.00, 'CLT', 'Pleno', 'Análise empresarial', 4),
('Estagiário de TI', 'Salvador', 'BA', '13:00', '18:00', 1200.00, 'Estágio', 'Estudante', 'Auxílio em TI', 5);
 
go
-- CURRÍCULOS
INSERT INTO Curriculo (nome_arquivo, caminho_arquivo, Candidatos_id, Vagas_id)
VALUES
('ana.pdf', '/curriculos/ana.pdf', 1, 1),
('bruno.pdf', '/curriculos/bruno.pdf', 2, 2),
('carla.pdf', '/curriculos/carla.pdf', 3, 3),
('diego.pdf', '/curriculos/diego.pdf', 4, 4),
('eduarda.pdf', '/curriculos/eduarda.pdf', 5, 5);