-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: 03-Dez-2020 às 19:20
-- Versão do servidor: 5.7.24
-- versão do PHP: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mathdb`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(85) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(85) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(85) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('00f1bbc7-b644-422e-a9f8-48f792aed891', 'Visitante', 'VISITANTE', 'd671161b-0784-4eb6-971d-616005c765fd'),
('a18be9c0-aa65-4af8-bd17-00bd9344e575', 'Administrador', 'ADMINISTRADOR', 'a9b1d6a5-f458-4d15-8d9b-da52987afa38');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(85) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(85) NOT NULL,
  `ProviderKey` varchar(85) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(85) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(85) NOT NULL,
  `RoleId` varchar(85) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('1244cf42-8bbe-459e-8680-b351ace2b319', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('1a129871-a9fe-4173-806e-cab644145da7', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('1c242d73-01bb-499a-b273-457e8dc3afea', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('224d5c99-e4fe-4040-9dc7-33bc814d3193', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('247c2290-b829-4c57-8150-4d6420f1143b', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('2dbc4a00-f36e-42d0-834b-f380d0ba5789', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('2e2cf4af-a85e-4d05-ac0a-6a2f0f90bce2', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('43435923-11e4-4d69-9080-353c418da917', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('5808e108-28ed-41ac-93c2-ae96a40538f8', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('cbd79594-eb04-4c6a-b722-e665a84ef984', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('da776c24-6c4c-438f-a329-16ef4d82fa0f', '00f1bbc7-b644-422e-a9f8-48f792aed891'),
('a18be9c0-aa65-4af8-bd17-00bd9344e575', 'a18be9c0-aa65-4af8-bd17-00bd9344e575');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(85) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(85) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(85) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Apelido` varchar(15) DEFAULT NULL,
  `DataNascimento` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Nome`, `Apelido`, `DataNascimento`) VALUES
('1244cf42-8bbe-459e-8680-b351ace2b319', 'breno.brito@gmail.com', 'BRENO.BRITO@GMAIL.COM', 'breno.brito@gmail.com', 'BRENO.BRITO@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEGx1sxu2Vj0O4kF1NTvdLgaOxZVrQxoEVV5Z0rA/1EWuhnWAmE5pC/0LQPVZB1oyIQ==', 'G3VVV6264CKTPR3A6IRY2PMNVBMAOJQA', 'c3d6aa65-556d-46fb-b357-bf68ddb028c1', NULL, b'0', b'0', NULL, b'1', 0, 'Breno Leandro Brito', 'Breno', '1998-08-06 00:00:00'),
('1a129871-a9fe-4173-806e-cab644145da7', 'eliane.jesus@gmail.com', 'ELIANE.JESUS@GMAIL.COM', 'eliane.jesus@gmail.com', 'ELIANE.JESUS@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAENXs0ajxCYdoXByRfWiSXg0JxHVsDLOaM1ZLp9h1tbTS0SkBr8CGSK9pBFR4BXOnlQ==', 'YC2IN6N7P3JSO5WKNL7T4WLY7NLOMIW5', '39bb6aa8-1f7c-4994-b870-ee18326de4fa', NULL, b'0', b'0', NULL, b'1', 0, 'Eliane Yasmin Jesus', 'Eliane', '1999-05-05 00:00:00'),
('1c242d73-01bb-499a-b273-457e8dc3afea', 'henry.silveira@gmail.com', 'HENRY.SILVEIRA@GMAIL.COM', 'henry.silveira@gmail.com', 'HENRY.SILVEIRA@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEJcgFUZzpGWEcle9OrJIQlfyAAdlVaZlBxy86PZPrV8Fl71el+I39mfQ1w7IZIAFYw==', 'PIWEZC556D7ZMCW53GPF4YRLD2KHA5PT', 'a93d4811-dbd5-45f3-a9b0-cef5bdedd2ed', NULL, b'0', b'0', NULL, b'1', 0, 'Henry Gustavo Silveira', 'Henry', '2006-06-19 00:00:00'),
('224d5c99-e4fe-4040-9dc7-33bc814d3193', 'sophie.monteiro@gmail.com', 'SOPHIE.MONTEIRO@GMAIL.COM', 'sophie.monteiro@gmail.com', 'SOPHIE.MONTEIRO@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEEGFZtpFMsgQuCKNs7wJUa87p1YXV5mKnL8H2/pGY6G60u15jRf26zgy7DspdLfFnQ==', 'MEY2UG4LEKI3YZX6OHLCFZYPX225MQ4U', 'aeeaf87b-8a00-40b1-b3b2-4bb50fe13c2b', NULL, b'0', b'0', NULL, b'1', 0, 'Sophie Olivia Monteiro', 'Sophie', '1993-05-20 00:00:00'),
('247c2290-b829-4c57-8150-4d6420f1143b', 'jorge.caldeira@gmail.com', 'JORGE.CALDEIRA@GMAIL.COM', 'jorge.caldeira@gmail.com', 'JORGE.CALDEIRA@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAENc6fdrnEGZ+D7wzryg+NdeHZWyF5QB8KONPWNv9bsN4Tyq9g+/PhE0n7LrFPp/www==', 'U4JV5AJGPMGEVB4KCDFQXIB2GLLKJWOO', '56b0304f-995c-4310-ab3f-8943ee2288d4', NULL, b'0', b'0', NULL, b'1', 0, 'Jorge Iago Caldeira', 'Jorge', '2003-04-14 00:00:00'),
('2dbc4a00-f36e-42d0-834b-f380d0ba5789', 'stefany.rezende@gmail.com', 'STEFANY.REZENDE@GMAIL.COM', 'stefany.rezende@gmail.com', 'STEFANY.REZENDE@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEJfTu5+JxjMI696h1LJAtIqJHmTKks4iKodoh9Ze/z8JFtq4zR24Ahg85Icr5uJrlA==', 'WNICNHFDCNE6EBIKOWWWOJQHKLQMI2P3', 'c5f0ba84-c7d6-446f-b9ba-6d0282f3e2c1', NULL, b'0', b'0', NULL, b'1', 0, 'Stefany Nina Rezende', 'Stefany', '2005-11-08 00:00:00'),
('2e2cf4af-a85e-4d05-ac0a-6a2f0f90bce2', 'heitor.teixeira@gmail.com', 'HEITOR.TEIXEIRA@GMAIL.COM', 'heitor.teixeira@gmail.com', 'HEITOR.TEIXEIRA@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEO6Cf0Q0o8dtMIv24G6a57RVxZ3hCSeyod9wKHwUTO340hvJkaMsN8hv+ENg80pPvQ==', 'RFWUBFJUJP4E32R4UCSA63GBQXXFFBEI', '14988896-b7db-4c5b-a0b3-ac51e93091f1', NULL, b'0', b'0', NULL, b'1', 0, 'Heitor Henry Teixeira', 'Heitor', '2002-01-09 00:00:00'),
('43435923-11e4-4d69-9080-353c418da917', 'benjamin.forgaca@gmail.com', 'BENJAMIN.FORGACA@GMAIL.COM', 'benjamin.forgaca@gmail.com', 'BENJAMIN.FORGACA@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEFaxoh8bli4Kk+mGfJM14pZewDWyJ+jyEOkELp8LXsUEFqvwhBuXaeGhsNoDDv4hVw==', 'DCW465IKTJCPMJMEE7HPJD4VTUENTDK2', '1754807b-779f-4cbe-82fc-c1b7759f691d', NULL, b'0', b'0', NULL, b'1', 0, 'Benjamin Hugo Fogaça', 'Benjamin', '2005-06-13 00:00:00'),
('5808e108-28ed-41ac-93c2-ae96a40538f8', 'sarah.ramos@gmail.com', 'SARAH.RAMOS@GMAIL.COM', 'sarah.ramos@gmail.com', 'SARAH.RAMOS@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEK5+mnGsZwURL7j8LZ0rAuu84M3v2EkNAtihTPkZHjfwEvmmMsCmZUf6VAPvwWa2WQ==', '3YN2ZXFQQ5OKOJBVGIXHAMOXI5MA5VZ3', 'ce4c274d-c915-4fff-97b8-6bacb727c5e9', NULL, b'0', b'0', NULL, b'1', 0, 'Sarah Lívia Ramos', 'Sarah', '2003-04-15 00:00:00'),
('a18be9c0-aa65-4af8-bd17-00bd9344e575', 'math4few@gmail.com', 'MATH4FEW@GMAIL.COM', 'math4few@gmail.com', 'MATH4FEW@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEHbgVaSfmovV8f7ZoxhzyMx0vLlmOJYtoILbqEoQTtEo/tTj/uMTprnvU4qIAYbEug==', '11133493', '8396feb3-5337-42de-9bf6-b06722ba6267', NULL, b'0', b'0', '2020-10-21 00:25:36', b'0', 0, 'Admin', 'Admin', '2001-01-01 00:00:00'),
('cbd79594-eb04-4c6a-b722-e665a84ef984', 'marcos.e.oliveira01@gmail.com', 'MARCOS.E.OLIVEIRA01@GMAIL.COM', 'marcos.e.oliveira01@gmail.com', 'MARCOS.E.OLIVEIRA01@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEA/AOBZQJ8OAjAPCv+Gl+kNURLSx2ZS615t3wl+oEugvhpTwphW+7OTnjrWi88QF8A==', 'MAM5J67PKZ4ABMZX6GBZNOZJWIZXUECN', '7303a319-7c74-468e-9484-762482634477', NULL, b'0', b'0', NULL, b'1', 0, 'Marcos Eduardo Oliveira Santos', 'Marcos', '2002-02-02 00:00:00'),
('da776c24-6c4c-438f-a329-16ef4d82fa0f', 'manuela.cunha@gmail.com', 'MANUELA.CUNHA@GMAIL.COM', 'manuela.cunha@gmail.com', 'MANUELA.CUNHA@GMAIL.COM', b'1', 'AQAAAAEAACcQAAAAEBknQmPE1BwkLhLlSf6FAkqkdPP63kHXcH1VS6LFF71zsEaU8Xw7VBFxXAc8AXY7Pw==', 'NRK3P7XIRBTX6GHXGVNEF7CMFWWPOLTU', 'e4fd9c7b-72f5-4d1a-ac28-a240cac91533', NULL, b'0', b'0', NULL, b'1', 0, 'Manuela Isabelle da Cunha', 'Manuela', '2002-03-06 00:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(85) NOT NULL,
  `LoginProvider` varchar(85) NOT NULL,
  `Name` varchar(85) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `conteudo`
--

DROP TABLE IF EXISTS `conteudo`;
CREATE TABLE IF NOT EXISTS `conteudo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(50) NOT NULL,
  `Descricao` varchar(1000) NOT NULL,
  `NivelId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Conteudo_NivelId` (`NivelId`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `conteudo`
--

INSERT INTO `conteudo` (`Id`, `Titulo`, `Descricao`, `NivelId`) VALUES
(1, 'Frações', 'Fração é a forma de dividir alguma coisa através da razão de dois números inteiros. Dessa forma, nada mais é do que uma divisão onde o dividendo é numerador e o divisor é o denominador.\r\nQuando dividimos uma pizza, por exemplo, estamos fracionando a pizza. Cada fatia representa uma parte da pizza, ou seja, uma fração. Geralmente ela é dividida em 8 pedaços, então cada pedaço de uma pizza representa 1/8 (um oitavo) de uma pizza.\r\nPodemos representar uma fração através da escrita em números ou de forma visual, através de desenhos para melhor o entendimento. Vamos mostrar as duas formas.\r\nImagine uma pizza dividida em oito pedaços iguais, e caso exista quatro pessoas para comer esta pizza. Se todos comerem dois pedaços, assim cada pessoa comeu 2/8 (dois oitavos) de pizza.\r\nAgora imagine que oito pessoas comeram um pedaço cada uma, dessa forma, cada pessoa comeu 1/8 (um oitavo) de pizza.', 4),
(2, 'Adição', 'A adição é uma das quatros operações fundamentais da aritmética. Consiste em adicionar dois ou mais números naturais, conhecido como parcelas, que produz em todos os casos um único resultado que chamamos de soma ou total.\r\nA adição é conhecida popularmente como soma. O ato de somar alguma coisa ocorre frequentemente no nosso cotidiano, como, por exemplo, somar o troco que recebemos de uma compra para confirmar se está correto.\r\nO sinal indicativo é o sinal mais (+). Este é o operador aritmético da adição.\r\nNa adição, os números antes do sinal de igual são chamados de parcelas, enquanto que o número depois da igualdade é a soma ou o total da adição.', 7),
(3, 'Equações do 1º grau', 'Equação do 1º grau (primeiro grau) é nada mais do que uma igualdade entre as expressões, que as transformam em uma identidade numérica, para um ou para mais valores atribuídos as suas variáveis.\r\nÉ toda sentença aberta, redutível e equivalente a ax + b = 0, com a ? R* e b ? R.\r\nOu seja, a e b são números que pertencem aos conjuntos dos números reais (R), com a diferente de zero e x representa uma variável que não conhecemos (incógnita).\r\nA incógnita é o valor que precisamos achar para encontrar a solução para a equação. A variável que não conhecemos (incógnita) costumamos representá-la na equação pelas letras x, y e z.\r\nNuma equação do primeiro grau, o expoente da incógnita é sempre 1.', 4),
(4, 'Inequações do 1º grau', 'Inequação do 1º grau é diferente de uma equação do primeiro grau. Enquanto uma equação expressa uma igualdade, a inequação expressa uma desigualdade.\r\nChamamos de inequação do 1º grau uma desigualdade na variável x que pode ser reduzida em uma das formas: ax + b > 0 ou ax + b = 0 ou ax + b < 0 ou ax + b = 0, em que a, b ? R e a ? 0.\r\nNa inequação utilizaremos os símbolos:\r\n> (Leia-se: Maior que);\r\n< (Leia-se: Menor que);\r\n= (Leia-se: Maior ou igual);\r\n= (Leia-se: Menor ou igual);\r\nEsses sinais servem para comparar. A própria definição de inequação é clara, devemos descobrir números que satisfazem essa comparação.', 4),
(5, 'Potenciação', 'Potenciação ou exponenciação é a forma de abreviar a multiplicação de uma sequência de fatores iguais.\r\nDessa forma, quando multiplicamos um número sucessivas vezes, podemos abreviar elevando-o a quantidade de vezes que o número é multiplicado.\r\nSeja um número real a e um número natural n, com n > 1, chamamos de potência de base a e expoente n o número an, isto é, o produto de n fatores iguais ao a.\r\n', 4),
(6, 'Radiciação', 'Radiciação é a forma de conhecermos a raiz de um determinado número. Sendo um tipo de representação de expoentes fracionários.\r\nPara entender radiciação é necessário entender também potenciação, que é ao inverso da radiciação.\r\nSeja a um número real não negativo e n um número natural, com n = 1, chamamos de raiz enésima de a se, e somente se, o número real x, não negativo, elevado ao expoente n, resulta em a, tal que xn = a.', 4),
(7, 'Razões', 'A razão entre dois números é dada pela sua divisão obedecendo a ordem na qual eles foram dados. Tal razão pode ser representada na forma fracionária, decimal e percentual. A relação entre duas ou mais razões é uma importante ferramenta para solucionar problemas práticos, essa igualdade é chamada de proporção.', 4),
(8, 'Proporções', 'A proporção é definida como a igualdade entre duas razões, caso essa igualdade seja verdadeira, então dizemos que os números que foram as razões na ordem dada são proporcionais.\r\nO estudo das proporções é essencial para o desenvolvimento matemático, pois elas possibilitam-nos relacionar grandezas, assim resolvendo problemas do nosso cotidiano. São exemplos de proporções: escala de um mapa, velocidade média de um móvel, e densidade de uma solução.', 4),
(9, 'Algarismos Romanos', 'Os números romanos foram durante muito tempo a principal forma de representação numérica na Europa. Os números eram representados a partir de letras do próprio alfabeto dos romanos. Esse sistema numérico associava uma letra a uma quantidade fixa.\r\nNa numeração romana, as letras são escritas uma ao lado da outra. Quando temos uma letra maior seguida de uma menor somamos os valores, quando temos uma letra menor seguida de uma maior, subtraímos o valor da maior pelo valor da menor.\r\nOs números romanos não são indicados nas questões relacionadas a cálculos matemáticos como adição, subtração, multiplicação e divisão. Atualmente eles são utilizados em nomes de papas e reis, representação de séculos, relógios, capítulos e páginas de livros entre outros.', 4),
(10, 'Grandezas', 'Definimos por grandeza tudo aquilo que pode ser contado e medido, como o tempo, a velocidade, comprimento, preço, idade, temperatura entre outros. As grandezas são classificadas em: diretamente proporcionais e inversamente proporcionais.\r\nUma grandeza diretamente proporcional são aquelas grandezas onde a variação de uma provoca a variação da outra numa mesma razão. Se uma dobra a outra dobra, se uma triplica a outra triplica, se uma é dividida em duas partes iguais a outra também é dividida à metade.\r\nUma grandeza é inversamente proporcional quando operações inversas são utilizadas nas grandezas. Por exemplo, se dobramos uma das grandezas temos que dividir a outra por dois, se triplicamos uma delas devemos dividir a outra por três e assim sucessivamente. A velocidade e o tempo são considerados grandezas inversas, pois aumentarmos a velocidade, o tempo é reduzido, e se diminuímos a velocidade, o tempo aumenta.', 4),
(11, 'Regra de Três', 'A regra de três simples é usada para encontrar um quarto valor que não conhecemos, desde que conheçamos apenas três dos valores no problema.\r\nChamamos de regra de três simples a comparação de duas grandezas proporcionais, relacionando dois valores de uma com dois valores na outra grandeza, sendo que em uma das grandezas um valor é desconhecido.\r\nExiste dois tipos de regra de três: diretamente proporcional ou inversamente proporcional.\r\nDiretamente proporcional: as grandezas são diretamente proporcionais quando aumentamos em uma das grandezas, a outra grandeza também aumenta proporcionalmente, e vice-versa;\r\nInversamente proporcional: temos grandezas inversamente proporcionais quando aumentamos ou diminuímos uma das grandezas, a outra ocorre o contrário, se uma aumenta a outra diminui, e vice-versa.', 4),
(12, 'Dízimas Periódicas', 'Dízimas periódicas são números infinitos e periódicos. Infinitos, pois eles não possuem fim, e periódicos, pois certas partes deles se repetem, isto é, possuem um período. Além disso, as dízimas periódicas podem ser representadas na forma fracionária, ou seja, podemos dizer que elas são números racionais.\r\nSe dividirmos o numerador de uma fração pelo denominador e encontrarmos uma dízima, então essa fração será chamada de fração geratriz. As dízimas podem ser classificadas como simples e compostas.\r\nA dízima periódica simples é caracterizada por não possuir antiperíodo, ou seja, o período (parte que se repete) vem logo depois da vírgula.\r\nA dízima periódica composta é aquela que possui antiperíodo, ou seja, entre a vírgula e o período existe um número que não se repete.', 4),
(13, 'Números Primos', 'Os números primos representam o conjunto dos números naturais, maiores que 1, que possuem apenas dois divisores (1 e ele próprio). Exemplo: 2, 5, 7, 11, etc. Já os números, maiores que 1, com mais de dois divisores são chamados de números compostos. \r\nTais números foram descobertos por volta de 530 a.C, na Escola Pitagórica - fundada pelo filósofo e matemático Pitágoras. No local, os participantes estudavam os números perfeito e já tinham uma noção de primalidade. \r\nNaquela época, os números primos eram conhecidos como lineares, por serem representados por pontos agrupado em uma linha. Enquanto os números não-primos (compostos) eram representados por pontos formando retângulos, dando a ideia de que eram formados a partir dos lineares.', 4),
(14, 'Geometria Plana', 'A geometria plana é a área da matemática que estuda as figuras bidimensionais, isto é, com duas dimensões.\r\nAs figuras planas são figuras que são dispostas no plano, possuindo duas medidas que são o comprimento e a largura.\r\nA geometria plana foi criada pelo matemático Euclides de Alexandria, que tem base nos axiomas e postulados propostos por ele. Por esse motivo, a geometria plana também é chamada de geometria euclidiana.', 4),
(15, 'Medidas de Superfície', 'As medidas de superfície estão diretamente ligadas ao nosso cotidiano, ao comprar um lote, pintar uma parede, ladrilhar um piso ou azulejar uma parede, o primeiro fato que precisamos saber é a medida da área das superfícies. Pelo SI (Sistema Internacional de Medidas), a unidade padrão usada para expressar uma medida de área é o metro quadrado (m²). A área de uma superfície é calculada através do produto entre o comprimento e a largura. Os múltiplos e submúltiplos do metro quadrado (m²) são:\r\nMúltiplos: quilômetro quadrado (km²), hectômetro quadrado (hm²), decâmetro quadrado (dam²).\r\nSubmúltiplos: decímetro quadrado (dm²), centímetro quadrado (cm²), milímetro quadrado (mm²).\r\nAs unidades de medidas de superfície podem aparecer em qualquer uma das unidades citadas, de modo que podem ser transformadas de uma unidade para outra.', 4),
(16, 'Medidas de Volume', 'As medidas de volume possuem grande importância nas situações envolvendo capacidades de sólidos. Podemos definir volume como o espaço ocupado por um corpo ou a capacidade que ele tem de comportar alguma substância. Da mesma forma que trabalhamos com o metro linear (comprimento) e com o metro quadrado (comprimento x largura), associamos o metro cúbico a três dimensões: altura x comprimento x largura.\r\nAs unidades de metro cúbico são: quilômetros cúbicos (km³), hectômetros cúbicos (hm³), decâmetros cúbicos (dam³), metros cúbicos (m³), decímetros cúbicos (dm³), centímetros cúbicos (cm³), milímetros cúbicos (mm³).\r\nDe acordo como Sistema Internacional de medidas (SI), o metro cúbico é a unidade padrão das medidas de volume. Um metro cúbico (1m³) corresponde a uma capacidade de 1000 litros. Essa relação pode ser exemplificada em conjunto com a Geometria, através de um cubo com arestas medindo 1 metro.', 4),
(17, 'Medidas de Capacidade', 'As medidas de capacidade são grandezas utilizadas para estimar uma quantidade que está inserida em um reservatório/recipiente, ou seja, são empregadas na medição de líquidos. Ainda pode-se dizer que tais medidas são usadas para definir o volume no interior de um recipiente.\r\nQuando falarmos em volume, estamos nos referindo ao espaço que um corpo é capaz de ocupar. Mas ao falar de capacidade, estamos nos referindo ao volume de líquido que pode ser acomodado dentro do recipiente. \r\nAs medidas de capacidade fazem parte do nosso cotidiano. Elas são utilizadas, por exemplo, quando queremos saber quantos litros de água estão dentro de um tanque ou, ainda, quantos litros de leite estão dentro da caixa.\r\nAs unidades de medida de capacidade são: Quilolitro (kl), Hectolitro (hl), Decalitro (dal), Litro (l), Decilitro (dl), Centilitro (cl), Mililitro (ml).  De acordo como Sistema Internacional de medidas (SI), o Litro é a unidade padrão das medidas de capacidade.', 4),
(18, 'Medidas de Massa', 'Existem diferentes medidas de massa, usadas para representar a medida dessa importante grandeza. As medidas mais comuns estão ligadas ao grama (g), sendo os seus múltiplos o hectograma (hg), o decagrama (dag) e o quilograma (kg), os quais são utilizados em objetos de massa maior. Também existem os submúltiplos, decigrama (dg), centigrama (cg) e miligrama (mg), para medir objetos que possuem massa menor. Além dessas medidas de massa, existem outras usadas no dia a dia de certos grupos, como a tonelada (t), a arroba (@) e o quilate (ct).', 4),
(19, 'Medidas de Tempo', 'As medidas de tempo são as unidades de medida usadas para marcar o tempo no geral. Essas medidas são formadas por padrões que podem ser encontrados facilmente no cotidiano. \r\nQuando usamos o relógio para marcar o período que precisamos nos arrumar, ou que vamos levar para chegar a um determinado compromisso, estamos medindo o tempo.  Os anos, meses, horas (h), minutos (min) e segundos (s) são formas de determiná-lo. \r\nO segundo (s) é adotado pelo Sistema Internacional de Medidas como parâmetro para as demais unidades. Ele serve para todo canto do mundo, fazendo com que o tempo seja marcado do mesmo jeito em qualquer lugar.', 4),
(20, 'Medidas de Comprimento', 'As unidades de medidas de comprimento surgem para suprir a necessidade do ser humano de medir vários tipos de distâncias. Existem várias unidades de medidas de comprimento, a utilizada no sistema internacional de unidades é o metro (m), e seus múltiplos (quilômetro (km), hectômetro (hm) e decâmetro (dam)) e submúltiplos (decímetro (dm), centímetro (cm) e milímetro (mm)).\r\nAlém das unidades de medidas de comprimento apresentadas, existem outras como as que utilizam o corpo como parâmetro: o palmo, o pé (ft), a polegada (in). Ainda, há aquelas que não são do sistema internacional, mas são utilizadas a depender da região, como a légua (\'), a jarda (yd), a milha (mi) e o ano-luz (ly).\r\nMedir a distância entre dois pontos de referência é uma tarefa executada pelos seres humanos desde as primeiras civilizações. Inicialmente utilizávamos objetos do dia a dia como referenciais, como cordas ou o próprio corpo humano.', 4),
(21, 'Equações do 2º grau', 'A equação do 2º grau é caracterizada por um polinômio de grau 2, ou seja, um polinômio do tipo ax² + bx + c, em que a, b e c são números reais. Ao resolvermos uma equação de grau 2, estamos interessados em encontrar valores para a incógnita x que torne o valor da expressão igual a 0, que são chamadas de raízes, isto é, ax² + bx + c = 0.\r\nA equação de 2º grau pode ser representada por ax²+bx+c=0, em que os coeficientes a, b e c são números reais, com a ? 0.\r\nA equação do 2º grau é classificada como completa quando todos os coeficientes são diferentes de 0, ou seja, a ? 0, b ? 0 e c ? 0.\r\nA equação do 2º grau é classificada como incompleta quando o valor dos coeficientes b ou c são iguais a 0, isto é, b = 0 ou c = 0.', 4),
(22, 'Inequação do 2º grau', 'Uma inequação do 2º grau é uma desigualdade parecida com uma equação do 2º grau, porém as inequações apresentam uma desigualdade, enquanto as equações uma igualdade entre os termos.\r\nChamamos de inequação do 2º grau uma desigualdade na variável x que apresenta um grau 2 e pode ser reduzida em uma das formas: ax² + bx + c > 0 ou ax² + bx + c = 0 ou ax² + bx + c < 0 ou ax² + bx + c = 0, com a, b, c ? R e a ? 0.', 4),
(23, 'Números Decimais', 'Os números decimais são os números que têm vírgula e números após essa vírgula. Os números após a vírgula são chamados de casas decimais. Os decimais estão contidos no conjunto dos números racionais (Q).\r\nUm número decimal pode ser negativo ou positivo. Além disso, eles podem ser finitos ou infinitos ou periódicos e infinitos. Podendo ser representado, também, na forma de uma fração.\r\nNos números decimais, os números que ficam após a vírgula são chamados de casas decimais.', 4),
(24, 'Médias', 'Médias são dados da Estatística usados para simplificar um conjunto de informações em único elemento, que são chamados de medidas de tendência central. Esses números permitem que certos valores quantitativos sejam representados por um dado central e encontrados através de conjuntos finitos e infinitos.\r\nExistem quatro tipos de média: Média aritmética simples, média aritmética ponderada, média geométrica e média harmônica.\r\nA média aritmética simples é obtida dividindo a soma de todos os valores que temos pela quantidade de valores.\r\nA média ponderada considera “pesos” para cada item, ou seja, em um conjunto de dados, cada item recebe uma importância. Cada item será multiplicado pelo seu peso. A média será dada pela divisão entre esta soma e a soma dos pesos considerados.\r\nA média geométrica entre um conjunto de n dados é a raiz enésima da multiplicação desses dados.\r\nA média harmônica de um conjunto de n dados é obtida dividindo a quantidade de dados pela soma dos inversos dos dados.', 4),
(25, 'Números Racionais', 'Números racionais são os números que podem ser representados por frações de números inteiros, contanto que o denominador seja qualquer número diferente de zero (0). Eles também são formados por elementos pertencentes aos conjuntos dos Números Reais (R), e Números Irracionais (I).\r\nO conjunto dos números racionais é a junção dos conjuntos numéricos de frações e dos decimais, já que esses algarismos podem ser escritos em formato de fração. A letra Q representa esse conjunto, pois o termo “quociente” começa com a letra q, e remete ao resultado de uma divisão.\r\nPor estarem diretamente ligados às frações, para entender os números racionais é preciso conhecer um pouco mais sobre elas.', 4),
(26, 'Razões Trigonométricas', 'As razões trigonométricas no triângulo retângulo são as relações estabelecidas entre os ângulos do triângulo. Essas relações são obtidas através da divisão entre os valores correspondentes aos lados do triângulo.\r\nO triângulo retângulo recebe esse nome porque possui um ângulo reto, isto é, um ângulo que mede 90°. A soma dos ângulos internos no triângulo retângulo for igual a 180°.\r\nO triângulo retângulo tem um ângulo reto e dois que são complementares entre si. Os lados b e c são chamados de catetos e a é a hipotenusa. Sendo que a hipotenusa é sempre oposta ao ângulo reto do triângulo e maior que os catetos, como mostra o Teorema de Pitágoras.', 4),
(27, 'Semelhança de Polígonos', 'Polígonos são regiões planas fechadas, constituídas de lados, vértices e ângulos. Dizemos que dois polígonos são semelhantes quando eles possuem o mesmo número de lados e se adéquam às seguintes condições: Ângulos iguais; Lados correspondentes proporcionais; Possuem razão de semelhança igual entre dois lados correspondentes.\r\nDurante a razão de semelhança podemos observar as seguintes situações: Ampliação: razão entre os lados correspondentes maior que 1; Redução: razão entre os lados correspondentes menor que 1.\r\nA semelhança entre figuras possui diversas aplicabilidades no cotidiano, como na elaboração de maquetes, ampliação de fotos, medições de distância (teorema de Tales) entre outras questões envolvendo proporcionalidade na Geometria.', 4),
(28, 'Ângulos', 'O ângulo é uma região delimitada por duas semirretas. Para medi-lo, há duas possíveis unidades: grau ou radiano. De acordo com a sua medida, ele pode ser classificado em agudo, reto, obtuso ou raso.\r\nQuando temos dois ângulos, podemos estabelecer relações entre eles. Caso eles possuam a mesma medida, eles são chamados de congruentes. Quando a soma entre eles é igual a 90º ou 180º ou 360º, eles são conhecidos, respectivamente, como ângulos complementares, suplementares e replementares.\r\nPara a realização de um desenho ou para a medição de um ângulo, na geometria plana utilizamos o compasso e o transferidor. Existem alguns outros instrumentos utilizados por profissionais da construção civil, como o teodolito.\r\nComo o ângulo corresponde à região que está entre duas semirretas, para realizar a medida em um transferidor, posicionamos uma das semirretas apontando para 0º e observamos o grau para o qual a outra semirreta está apontada.', 4),
(29, 'Análise Combinatória', 'A análise combinatória é um campo de estudo da matemática associado com as regras de contagem. No início do século XVIII, o estudo sobre jogos envolvendo dados e cartas fez com que as teorias de contagem tivessem grande desenvolvimento.\r\nO trabalho da análise combinatória possibilita a realização de contagens cada vez mais precisas. O princípio fundamental da contagem (PFC), o fatorial e os tipos de agrupamento são exemplos de conceitos estudados na análise combinatória, que, além de propiciar maior precisão, auxilia no desenvolvimento de outras áreas da matemática, como a probabilidade e o binômio de Newton.\r\nA análise combinatória está associada com o processo de contagem, ou seja, o estudo dessa área da matemática possibilita-nos desenvolver ferramentas que nos auxiliam na realização de contagens de maneira mais eficiente.', 5),
(30, 'Teoria dos Conjuntos', 'A compreensão de conjuntos é a principal base para o estudo da álgebra e de conceitos de grande importância na Matemática, como funções e inequações. A notação que usamos para conjuntos é sempre uma letra maiúscula do nosso alfabeto (por exemplo, conjunto A ou conjunto B).\r\nEm se tratando da representação dos conjuntos, ela pode ser feita pelo diagrama de Venn, pela simples descrição das características dos seus elementos, pela enumeração dos elementos ou pela descrição das suas propriedades. Ao trabalhar com problemas que envolvem conjuntos, existem situações que exigem a realização de operações entre os conjuntos, sendo elas a união, a intersecção e a diferença.', 5),
(31, 'Vetores', 'Em termos das ciências exatas, vetores são segmentos de reta orientados, responsáveis pela caraterização das grandezas definidas como vetoriais. É importante salientar que a palavra vetor assume significados diferentes dependendo do contexto em que é aplicada. Os agentes que disseminam doenças infectocontagiosas, por exemplo, também são chamados de vetores.\r\nTudo aquilo que pode ser medido é considerado como sendo uma grandeza. Massa, velocidade, aceleração, força e energia são algumas das inúmeras grandezas físicas. As grandezas são classificadas em dois grupos: escalares e vetoriais.\r\nEscalares é o tipo de grandeza que é definida apenas a partir da informação do seu valor numérico (módulo), seguido de uma unidade de medida. Massa, temperatura e energia são exemplos de grandezas escalares;\r\nVetoriais é o tipo de grandeza que possui, além do valor numérico (módulo), direção e sentido. Força, velocidade e aceleração são exemplos de grandezas vetoriais.', 5),
(32, 'Probabilidade', 'Probabilidade é um ramo da Matemática em que as chances de ocorrência de experimentos são calculadas. É por meio de uma probabilidade, por exemplo, que podemos saber desde a chance de obter cara ou coroa no lançamento de uma moeda até a chance de erro em pesquisas.\r\nPara compreender esse ramo, é extremamente importante conhecer suas definições mais básicas, como a fórmula para o cálculo de probabilidades em espaços amostrais equiprováveis, probabilidade da união de dois eventos, probabilidade do evento complementar etc.', 5),
(33, 'Logaritmos', 'Logaritmo é uma ferramenta muito importante não somente para a área da matemática, pois possui aplicação em diversos campos da ciência, como na geografia, química e computação.\r\nHistoricamente o logaritmo surge a fim de facilitar contas que apareciam com frequência em diversas áreas cientificas. John Napier foi pioneiro nos estudos sobre logaritmos, e conseguiu desenvolver a operação capaz de transformar produtos em soma, divisões em subtrações e potências em multiplicações.\r\nDefinindo essa operação, com o tempo, outros matemáticos formalizaram definições e propriedades, além disso, foi desenvolvida também a conhecida tábua de logaritmos.', 5),
(34, 'Matrizes', 'Matrizes são números reais estruturados em tabelas formadas por linhas horizontais e colunas verticais. Essa configuração facilita a execução de variados cálculos ao mesmo tempo. \r\nOs números, que são identificados como elementos, aparecem dentro de colchetes, parênteses, barras simples ou barras duplas. \r\nGeralmente as tabelas mxn (“m por n”) são definidas de matrizes. Cada elemento é determinado por aij, no qual o i corresponde a posição do número na linha e j a posição na coluna. As colunas são organizadas de cima para baixo, e as linhas da esquerda para a direita.\r\nAs matrizes apresentam duas diagonais: uma principal e outra secundária. A principal é formada pelos elementos de i = j e a secundária pelas somas de i com j.', 5),
(35, 'Determinantes', 'O determinante de uma matriz possui várias aplicações atualmente. Utilizamos o determinante para verificar se três pontos estão alinhados no plano cartesiano, para calcular áreas de triângulos, para resolução de sistemas lineares, entre outras aplicações na matemática. O estudo de determinantes não se limita à matemática, há algumas aplicações na física, como no estudo de campos elétricos.\r\nCalculamos determinantes somente de matrizes quadradas, ou seja, matrizes em que a quantidade de colunas e a quantidade de linhas são iguais. Para calcular o determinante de uma matriz, precisamos analisar a ordem dela, ou seja, se ela é 1x1, 2x2, 3x3 e assim sucessivamente, quanto maior a sua ordem, mais difícil será encontrar o determinante. No entanto, há métodos importantes realizar-se o exercício, como a regra de Sarrus, utilizada para calcular-se determinantes de matrizes 3x3.', 5),
(36, 'Números Complexos', 'Os números complexos surgem a partir da necessidade de resolução de equações que possuem raiz de números negativos, o que, até então, não era possível de resolver-se trabalhando com os números reais. Os números complexos podem ser representados de três formas: a forma algébrica (z = a + bi), composta por uma parte real a e uma parte imaginária b; a forma geométrica, representada no plano complexo conhecido também como plano de Argand-Gauss; e a sua forma trigonométrica, conhecida também como forma polar. Com base na sua representação, como estamos trabalhando com um conjunto numérico, os números complexos possuem operações bem definidas: adição, subtração, multiplicação, divisão e potenciação.', 5),
(37, 'Polinômios', 'Polinômios são expressões algébricas formadas pela adição de monômios. Ambos são constituídos por números conhecidos e números desconhecidos. Antes de partirmos para as operações matemáticas que envolvem os polinômios, precisamos entender melhor alguns conceitos.\r\nMonômios são constituídos pelo produto entre números conhecidos e incógnitas (números desconhecidos comumente representados por letras). Divisões por incógnitas não são consideradas monômios, mas são chamados de frações algébricas.', 5),
(38, 'Produtos Notáveis', 'Produtos Notáveis são expressões que existem para facilitar o cálculo de problemas que envolvem equações, por exemplo. Fórmulas, com regras básicas que facilitam enigmas matemáticos.  Existem diversos os momentos em que se pode usar os produtos notáveis, por isso ele recebe essa palavra “notável” em seu nome. Esse assunto envolve alguns conceitos e outros temas matemáticos, tais quais: potenciação (elevação a segunda potência (quadrado) e elevação a terceira potência (cubo)), produto (multiplicação) e diferença (subtração).', 5),
(39, 'Progressões', 'O termo “progressão” remete a um desenvolvimento gradual de um processo ou uma sucessão. Em matemática, dizemos que esta sucessão é uma sequência. Quando é estudado progressões no Ensino Médio, é ensinado dois tipos de progressão: aritmética (PA) e a geométrica (PG).\r\nProgressão aritmética (P.A.) é uma sequência numérica em que o próximo elemento da sequência é o número anterior somando a uma constante r. Este r é chamado de razão da P.A. Para sabermos qual a razão de uma P.A. basta subtrair um elemento qualquer pelo seu antecessor.\r\nProgressão geométrica (P.G.) é uma sequência numérica onde os termos a partir do segundo são obtidos multiplicados por uma constante q que chamamos de razão. Para encontrarmos a razão de uma PG basta dividirmos um número pelo seu antecessor.', 5),
(40, 'Trigonometria', 'A trigonometria é a área da matemática que estuda a relação entre a medida dos lados de um triângulo e seus ângulos. Temos como principais razões trigonométricas o seno, o cosseno e a tangente, estudados também nos ciclos trigonométricos.\r\nHá as identidades trigonométricas, que relacionam as razões trigonométricas entre si. O estudo da trigonometria, quando feito de forma mais aprofundada, ocorre com base nas funções trigonométricas — função seno e função cosseno.\r\nAinda que o triângulo seja o polígono mais simples, ele é amplamente estudado. A trigonometria é a área da matemática que estuda e analisa a relação entre os lados dos triângulos e os seus ângulos.\r\nAcontece que foi percebido que um triângulo com um ângulo medindo a sempre possui os lados proporcionais entre si, o que permitiu uma grande evolução no estudo de triângulos.', 5),
(41, 'Função Exponencial', 'A função exponencial ocorre quando, em sua lei de formação, a variável está no expoente, com domínio e contradomínio nos números reais. O domínio da função exponencial são os números reais, e o contradomínio são os números reais positivos diferentes de zero. A sua lei de formação pode ser descrita por f(x)=ax, em que a é um número real positivo diferente de 1.\r\nO gráfico de uma função exponencial sempre estará no primeiro e segundo quadrantes do plano cartesiano, podendo ser crescente, quando a for um número maior do que 1, ou decrescente, quando a for um número positivo menor do que 1. A função inversa da função exponencial é a função logarítmica, o que torna os gráficos dessas funções sempre simétricos.', 5),
(42, 'Função Logarítmica', 'A função logarítmica é a função do tipo f(x) = logax, em que a é a base do logaritmo da função, a é positivo e a ? 1.\r\nO logaritmo é usado para descobrir o valor do expoente de uma base qualquer. Assim, o logaritmo de um número b com base a, é o expoente x, que é potência da base e resulta em b. Para entender o logaritmo é necessário estudar e entender potenciação.\r\nO gráfico da função logarítmica é uma curva, construída em razão dos valores aplicados em x e os respectivos resultados calculados para f (x). \r\nAs coordenadas são colocadas dentro do plano cartesiano nos quadrantes I e II, pois essa função é caracterizada por x > 0. Além disso, a depender da base \"a\", são classificadas em crescente e decrescente.', 5),
(43, 'Função Modular', 'Função é uma lei ou regra que associa cada elemento de um conjunto A a um único elemento de um conjunto B. O conjunto A é chamado de domínio da função e o conjunto B de contradomínio. A função modular é uma função que apresenta o módulo na sua lei de formação.\r\nDe maneira mais formal, podemos definir função modular como: f(x) = |x| ou y = |x|. A função f(x) = |x| apresenta as seguintes características: f(x) = x, se x= 0 ou f(x) = – x, se x < 0; Essas características decorrem da definição de módulo.', 5),
(44, 'Conjuntos Numéricos', 'Conjuntos numéricos são coleções de números que possuem características semelhantes. Eles nasceram como resultado das necessidades da humanidade em determinado período histórico.\r\nO conjunto dos Números Naturais(N) foi o primeiro de que se teve notícia. Nasceu da simples necessidade de se fazer contagens, seus elementos são apenas os números inteiros e positivos.\r\nO conjunto dos números inteiros(Z), é formado pela união do conjunto dos números naturais com os números negativos. Em outras palavras, o conjunto dos números inteiros.\r\nO conjunto dos números racionais(Q), nasceu da necessidade de dividir quantidades. Portanto, esse é o conjunto dos números que podem ser escritos na forma de fração.\r\nO conjunto dos números irracionais(I), são os números que não pertencem ao conjunto dos racionais.\r\nO conjunto dos números reais(R), é formado por todos os números citados anteriormente. Sua definição é dada pela união entre o conjunto dos números racionais e o conjunto dos números irracionais.', 5),
(45, 'Binômio de Newton', 'O Binômio de Newton é a potência na forma (x + y)n. Nessa conotação, x e y são números reais e n um número natural.\r\nA matéria do Binômio de Newton abrange Coeficientes Binomiais com seus predicados, Triângulo de Pascal e suas propriedades, e a fórmula do desenvolvimento do Binômio de Newton.\r\nNa matemática, Binômio de Newton, é escrito na forma canônica (termo vem do latim régua ou linha de medida) com os polinômios correspondentes à potência de um binômio.\r\nO Binômio de Newton não foi o tema central dos estudos de Isaac Newton. Na verdade, o que Newton pesquisou e examinou foram as normas que valem para (a+b)n quando o expoente “n” é fracionário ou inteiro negativo, o que leva ao estudo de séries sem fim.\r\nO desenvolvimento do Binômio de Newton, em certos casos, não é complexo, pois pode ser efetuado através da multiplicação direta dos termos.\r\nEntretanto, o uso dessa fórmula nem sempre é permitida porque a depender do expoente os cálculos podem ficar mais complicados e extensos.', 5),
(46, 'Função do 1º grau', 'Uma função do primeiro grau é aquela cuja lei de formação pode ser escrita na seguinte forma: y = ax + b. Na qual, a e b pertencem ao conjunto dos números reais, e a é diferente de zero. Esse tipo de função também é chamado de função afim.\r\nÉ importante relembrar os principais conceitos a respeito das funções em geral para compreender bem as funções do primeiro grau.\r\nUma função é uma regra matemática que relaciona cada elemento x, de um conjunto A, a um único elemento y, de um conjunto B. Os conjuntos A e B são conhecidos, respectivamente, como domínio e contradomínio. Já x e y são conhecidos, respectivamente, como variável independente e variável dependente.\r\nAssim, as funções do primeiro grau são regras que relacionam cada elemento de um conjunto a um único elemento de outro cuja variável independente é uma potência de expoente 1. O grau de uma função sempre é dado pelo maior expoente da variável independente e, no caso das funções do primeiro grau, o maior expoente é 1.', 5),
(47, 'Função do 2º grau', 'A função quadrática é uma função polinomial do 2º grau. A função quadrática tem a seguinte lei de formação: f(x) = ax² + bx + c, com a, b e c números reais e a ? 0. Por causa do grau 2, a função possui um gráfico curvo que é chamado de parábola.\r\nUma função é uma regra matemática que relaciona cada elemento x, de um conjunto A, a um único elemento y, de um conjunto B. Os conjuntos A e B são conhecidos, respectivamente, como domínio e contradomínio. Já x e y são conhecidos, respectivamente, como variável independente e variável dependente.\r\nAssim, as funções do segundo grau são regras que relacionam cada elemento de um conjunto a um único elemento de outro cuja variável independente é uma potência de expoente 2. O grau de uma função sempre é dado pelo maior expoente da variável independente e, no caso das funções do segundo grau, o maior expoente é 2.', 5),
(48, 'Sistemas Lineares', 'Resolver sistemas lineares é uma tarefa bastante recorrente para estudos nas áreas das ciências da natureza e da matemática. A busca por valores desconhecidos fez com que fossem desenvolvidos métodos de resolução de sistemas lineares, como o método da adição, igualdade e substituição para sistemas que possuem duas equações e duas incógnitas, e a regra de Crammer e o escalonamento, que resolvem sistemas lineares de duas equações, mas que são mais convenientes para sistemas  com mais equações. Um sistema linear é um conjunto de duas ou mais equações com uma ou mais incógnitas.\r\nDepois de conhecer o conceito de equação linear, já é possível entender os sistemas lineares. Estes são conjuntos de equações lineares que possuem as mesmas variáveis. Para encontrar a solução de um sistema linear é necessário descobrir um resultado comum a todas as equações.', 5),
(49, 'Equações Trigonométricas', 'Para que exista uma equação qualquer é preciso que tenha pelo menos uma incógnita e uma igualdade.\r\nAgora, para ser uma equação trigonométrica é preciso que, além de ter essas características gerais, é preciso que a função trigonométrica seja a função de uma incógnita.\r\nGrande parte das equações trigonométricas é escrita na forma de equações trigonométricas elementares ou equações trigonométricas fundamentais, representadas da seguinte forma: sen x = sen a; cos x = cos a; tg x = tag a;\r\nCada uma dessas equações possui um tipo de solução, ou seja, de um conjunto de valores que a incógnita deverá assumir em cada equação.', 5),
(50, 'Inequações Trigonométricas', 'Inequações trigonométricas são desigualdades que possuem pelo menos uma razão trigonométrica envolvendo um ângulo desconhecido. Dessa maneira, a solução de uma inequação trigonométrica é um conjunto de ângulos, geralmente apresentados na forma de arco, em radianos. Para encontrar essa solução, é necessário usar alguns conhecimentos básicos a respeito de ciclo trigonométrico.\r\nO ciclo trigonométrico é uma circunferência de raio 1 un cujo centro é a origem de um plano cartesiano. Nessa construção, o eixo x é o eixo dos cossenos e o eixo y é o eixo dos senos.', 5),
(51, 'Geometria Espacial', 'A geometria espacial é responsável pelo estudo das figuras geométricas espaciais, também chamadas de sólidos geométricos, que ocupam lugar no espaço, devido sua característica de tridimensionalidade (altura, largura e comprimento). Cubos, prismas, pirâmides e cones são alguns sólidos explorados por essa subárea da geometria.\r\nA geometria espacial teve início na História Antiga, em especial com os egípcios há cerca de 1.850 a.C, por meio de estudos extraídos de papiros. Dentre os principais documentos antigos podem ser citados o “Papiro de Rhind” e o “Papiro de Moscou”.\r\nO Papiro de Moscou consiste em uma tira de 5,5 m de comprimento por 8 cm de largura, com 25 problemas, um desses resolvia o cálculo do volume do cilindro reto determinando o produto da área da base pelo comprimento da altura.', 5),
(52, 'Geometria Plana', 'A geometria plana ou euclidiana é a vertente da matemática que estuda as figuras geométricas que não possuem volume, como triângulos, retângulos, círculos, entre outros. \r\nCriado pelo matemático Euclides de Alexandria, a geometria plana vai explorar as propriedades e tamanho das formas, além de aplicar fórmulas matemáticas para descobrir seu perímetro e área. Esta área apresenta certas propriedades que nos ajudam a compreender as figuras mais complexas, como os conceitos de ponto, linha, plano e ângulo.\r\nA geometria plana é uma área de estudos que faz parte da geometria. Euclides de Alexandria ficou conhecido como \"pai de geometria\", devido a sua contribuição para os estudos dessa área. Já as figuras que possuem volume são estudadas pela geometria espacial.', 5),
(53, 'Geometria Analítica', 'A geometria analítica é a linha matemática ligada à álgebra. Através desse diferencial podemos entender as propriedades do ponto, reta e das figuras. Para isso, é necessário estudar o conceito de distância entre um ponto e outro da reta e a localização dentro do mesmo.\r\nÉ possível perceber a distância entre pontos na reta, plano e espaço. Os pontos situados no espaço são definidos por um conjunto de três números, conhecidos como ternos ordenados. Cada terno representa um ponto no espaço.\r\nCaso uma reta seja feita de pontos, acredita-se que ela possua uma dimensão. Por outro lado, caso o ponto seja parte do plano, o espaço vai apresentar duas dimensões. Sendo assim, a quantidade de coordenadas que um ponto possui é proporcional a quantidade de dimensões de onde está localizada.\r\nQualquer figura geométrica pode ser calculada através de fórmulas algébricas. Entre elas estão: matrizes, vetores, entre outros.', 5),
(54, 'Matemática Financeira', 'A matemática financeira é uma das áreas da matemática que estuda a variação do dinheiro ao longo do tempo. Ela é muito utilizada nas atividades financeiras do dia a dia, das mais simples às mais complexas.\r\nQuem deseja comprar um imóvel precisa escolher uma forma de pagamento, à vista ou parcelado. Por meio da matemática financeira será possível escolher a opção mais viável e que gere menos custos, calculando, por exemplo, os juros incididos nas prestações do financiamento ou o desconto na quitação no ato da compra. Dessa forma, a matemática financeira tem uma importância fundamental para a vida das pessoas.\r\nAs antigas civilizações já se utilizavam da matemática para as atividades comerciais da época. Os sumérios realizavam empréstimos de sementes e o pagamento era feito com uma parte da colheita, uma forma de pagamento de juros. Na época não existia outra moeda de troca. As informações financeiras eram escritas em tábuas com dados como escrituras de vendas e notas promissórias.', 5),
(55, 'Introdução ao Cálculo', 'A matéria introdutória traz os conceitos que você vai usar em toda a profissão. Conjuntos, números e funções são abordados nesta disciplina, bem como algumas operações simples. É a base da construção do seu entendimento!', 6),
(56, 'Pré-Cálculo', 'Não importa o que você aprendeu no Ensino Médio. Essa cadeira ajuda a nivelar seus conhecimentos matemáticos e a prepará-lo para o que virá.\r\nCom os conceitos aprendidos na disciplina anterior, você é apresentado às operações e aos teoremas que são a base de todo o Cálculo. Ao final, vai estar craque para lidar com os novos conhecimentos.', 6),
(57, 'Álgebra Linear e Vetorial', 'Nessa matéria, você será apresentado às matrizes e aos sistemas de equação. Além disso, também usará os vetores como representação matemática e as transformações lineares.', 6),
(58, 'História da Matemática', 'Conhecer os fundamentos da Matemática inclui desvendar a sua história. É por isso que é importante saber como ela se desenvolveu ao longo dos séculos, os principais nomes que a consolidaram e como ela impactou a humanidade.', 6),
(59, 'Geometria com Construções Geométricas', 'A Matemática também é usada para construir as formas que conhecemos. A geometria é um tema relevante, então você vai descobrir como são feitas as construções geométricas e o que elas representam.', 6),
(60, 'Geometria Analítica', 'Além de colocar a mão na massa, é essencial estudar a geometria por meio de cálculos, conhecimento de área, perímetro e assim por diante. A Geometria Analítica oferece exatamente essa proposta, com fórmulas e meios de estudo sobre cada forma.', 6),
(61, 'Lógica Matemática', 'Tem gente que acha que a ciência dos números é pura magia, mas não é nada disso. Ao estudar matemática, é indispensável conhecer sua lógica e como ela é aplicada nas diversas operações.\r\nAo entender como utilizar a lógica, inclusive, vai ficar muito mais fácil resolver os problemas nos estudos.', 6),
(62, 'Cálculo Diferencial e Integral I, II e III', 'Um bom curso de Matemática tem que se aprofundar no Cálculo Diferencial e Integral.\r\nNessas disciplinas, é possível aprender sobre limites, integrais, derivadas, equações de superfície, representação de planos e assim diante.\r\nÉ um verdadeiro mergulho no uso aplicado dos números!', 6),
(63, 'Estatística e Probabilidade', 'Os números também representam a chance de algo se concretizar. É por isso que aprender sobre análises combinatórias e estatísticas é essencial. É o modo de descobrir como usar os números para prever cenários com muita confiança.', 6),
(64, 'Cálculo Numérico', 'Para aplicar os números nas operações, essa disciplina inclui vários problemas que podem ser solucionados com as equações certas. É fundamental porque abrange conceitos aprendidos em outras disciplinas e, assim, consolida os temas.', 6),
(65, 'Estruturas Algébricas', 'Na parte de estruturas relacionadas à álgebra, você é apresentado a conceitos abstratos, como anéis e grupos diferentes, além de teoremas variados. É a evolução da Matemática!', 6),
(66, 'Subtração', 'A subtração é uma das quatros operações fundamentais da aritmética. Consiste em subtrair dois ou mais números tendo um outro número como resultado. O sinal indicativo da subtração é o “sinal de menos” (–).\r\nOs números antes do sinal de igual são chamados de minuendo e subtraendo. O valor após o sinal de igualdade é chamado de diferença ou resto. Na subtração, trocar a ordem em que os valores são subtraídos tem resultado diferente.\r\nA diferença de dois ou mais números reais tem como resultado um número real. Ou seja, se fazermos a diferença entre dois números do conjunto dos números reais, a diferença entre esses números também será um número do conjunto dos números reais.', 7),
(67, 'Multiplicação', 'Multiplicação é uma das quatro operações básicas da aritmética. Consiste em uma adição sucessivas de um mesmo número produzindo um resultado que chamamos de produto. \r\nO símbolo da multiplicação pode variar, no entanto tem o mesmo sentido: ( * ), ( x ) ou ( . ). \r\nSão formas de representar a multiplicação e você pode encontrá-las por aí. Dessa forma, quando encontrar uma representação da multiplicação assim já sabe do que se trata.\r\nNa matemática, muitas vezes utiliza-se o x para representar a multiplicação, mas, para não confundir com uma variável, é frequentemente substituído pelo (.) ponto.\r\nNuma operação utilizando a multiplicação, o multiplicador e o multiplicando são chamados de fatores, e o resultado é o produto resultante da multiplicação.', 7),
(68, 'Divisão', 'A divisão é uma das quatro operações fundamentais da aritmética. Consiste em dividir dois números, o dividendo e o divisor, que produz dois resultados chamados de quociente e resto.\r\nSeu símbolo é o “÷”. No entanto pode variar, por exemplo, no teclado do computador o símbolo adotado é a barra “/”, em outros casos, “:”.\r\nA divisão é o ato de dividir em partes iguais para todos. O número que está sendo dividido em partes iguais é chamado de dividendo; o número que indica em quantas vezes vamos dividir é chamado de divisor; o resultado é chamado de quociente; o que sobra é chamado de resto.', 7),
(70, 'Exponenciação', 'Exponenciação ou potenciação é a forma de abreviar a multiplicação de uma sequência de fatores iguais.\r\nDessa forma, quando multiplicamos um número sucessivas vezes, podemos abreviar elevando-o a quantidade de vezes que o número é multiplicado.\r\nSeja um número real a e um número natural n, com n > 1, chamamos de potência de base a e expoente n o número an, isto é, o produto de n fatores iguais ao a.', 7),
(71, 'Porcentagem', 'Porcentagem ou percentagem é usada para calcular descontos, acréscimo de preços, lucros, etc. É uma fração em que o denominador é igual a 100. O símbolo para representar uma porcentagem é % e vem precedido por um número.\r\nAo número p associamos a razão p/100, ou seja, tomamos p partes de um todo que foi dividido em 100 partes iguais.\r\nO nome tem origem do latim (per centum) e quer dizer por cento, ou seja, uma razão de base 100. É frequentemente utilizado para cálculos de transações comerciais, entre outros.\r\nEssas razões com denominadores 100 são chamadas de razões centesimais, taxas percentuais ou, simplesmente, porcentagens.', 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `dica`
--

DROP TABLE IF EXISTS `dica`;
CREATE TABLE IF NOT EXISTS `dica` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(50) NOT NULL,
  `Descricao` varchar(2500) NOT NULL,
  `LinkVideo` text NOT NULL,
  `ConteudoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Dica_ConteudoId` (`ConteudoId`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `dica`
--

INSERT INTO `dica` (`Id`, `Titulo`, `Descricao`, `LinkVideo`, `ConteudoId`) VALUES
(1, 'Multiplicar um número por 11', 'Quando o número for de 2 algarismos, basta somar esses 2 algarismos e colocar o resultado no meio deles. Por exemplo, vamos efetuar a seguinte multiplicação: 26x11. Temos o número 26, somando seus 2 algarismos temos 2+6=8. Pronto! Agora é só colocar esse 8 no meio deles: a resposta é 286. Portanto 26 x 11 = 286. Somamos os algarismos do número 37: 3+7=10 . Como deu um nº maior que 9, então não podemos colocar todo o número no meio deles. Colocamos apenas o algarismo das unidades (0) no meio deles, e o algarismo da dezena (1) é somado ao primeiro algarismo do número: 407. Portanto 37x11 = 407. Quando o número for de 3 algarismos, então esse número multiplicado por 11 resultará em um número de 4 algarismos. Por exemplo, vamos efetuar a seguinte multiplicação: 135 x 11.  Temos o número 135. Somando o 1º com o 2º algarismo desse número temos 1+3=4. Somando o 2º com o 3º algarismo desse número temos 3+5=8. Esses 2 resultados serão colocados no meio do número 135, tirando o seu algarismo do meio: 1485. Portanto 135 x 11 = 1485.', 'https://www.youtube.com/embed/KbHiA1Z986s', 67),
(2, 'Soma dos n primeiros números naturais ímpares', 'Para fazer a soma do n primeiros números naturais ímpares basta você multiplicar esse número por ele mesmo: n * n ou n². Por exemplo, vamos efetuar o seguinte cálculo: Soma dos 5 primeiros números naturais ímpares.\r\nOs 5 primeiros números ímpares são (1 + 3 + 5 + 7 + 9), para fazer a soma você pega o total de números que é 5 multiplica por 5: A soma é igual a 25. Outro exemplo é a soma dos 8 primeiros números naturais ímpares: 8² = 64.', 'https://www.youtube.com/embed/KbHiA1Z986s', 2),
(3, 'Multiplicar um número por 15', 'Para fazer a multiplicação de um número por 15 basta você somar esse número com a sua metade e no final multiplicar o resultado por 10. Por exemplo, vamos efetuar a seguinte multiplicação: 14x15.\r\nA metade de 14 é igual a 7 então devemos somar (14 + 7) que é igual a 21 e agora multiplicamos (21 * 10) que é igual a 210, e pronto 14x15 = 210. Outro exemplo é a multiplicação de 10,4×15, a metade de 10,4 = 5,2. Somando (10, 4 + 5,2) = 15,6. Multiplicando por 10 = 156. Portanto 10,4x15 = 156.', 'https://www.youtube.com/embed/KbHiA1Z986s', 67),
(4, 'Dividir qualquer número por 5', 'A divisão de qualquer número por 5 é muito simples você só tem que multiplicar esse número por dois e arrastar a virgula para a esquerda. Por exemplo, vamos efetuar a seguinte divisão: 345 / 5.\r\nMultiplicando (345 * 2) é igual a 690, agora arrastamos a virgula uma casa para a esquerda e temos: 69,0 ou 69, então 345 / 5 = 69. Outro exemplo é a divisão de 1526 / 5, multiplicando 1526 por 2 = 3052. Arrastando a virgula uma casa para a esquerda temos 305,2. Portanto 1526 / 5 = 305,2.', 'https://www.youtube.com/embed/KbHiA1Z986s', 68),
(5, 'Como descobrir o próximo quadrado?', 'Se você sabe o resultado de um número ao quadrado é quer descobrir qual o resultado do próximo número ao quadrado você precisa somar o quadrado que você tem com o número que você está tentado descobrir o quadrado multiplicado por 2, e depois diminua uma unidade. Por exemplo, vamos efetuar o seguinte cálculo: Sabendo que 3² = 9 quanto é 4²?\r\nAplicando a regra primeiro nós temos que pegar o quadrado que você já sabe que é o 9, depois pegar o número que está tentando descobrir o quadrado que é o 4 e multiplica-lo por 2 que é igual a 8, a seguir temos que somar os resultado 8 + 9 = 17, e por fim subtrair 1 que é igual a 16. Então, 4² = 16. Outro exemplo é descobrir quanto é 5² já que sabemos que 4² = 16 do exemplo anterior. Pegamos o 16 e somamos com (2 * 5) o resultado é igual a 26, subtrairmos 1 unidade teremos 25. Portanto 5² = 25.', 'https://www.youtube.com/embed/KbHiA1Z986s', 5),
(6, 'Soma de um grupo de dezenas', 'Para encontrar a soma de um grupo de dez dezenas (iniciando com a unidade de final 0), basta trocar o algarismo das unidades por 45. Por exemplo, vamos considerar o número 4260. A soma das dez dezenas iniciando por ele seria: (4260 + 4261 + 4262 + 4263 + 4264 + 4265 + 4266 + 4267 + 4268 + 4269) = 42645, utilizando a dica ficaria mais fácil, bastaria retirar o zero e acrescentar o 45.\r\nOutro exemplo é 13420 se retirarmos o zero e substituirmos por 45 ficaria 134245 que é o resultado da soma. Isso ocorre porque, se somássemos separadamente as unidades, teríamos 0 + 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45.', 'https://www.youtube.com/embed/KbHiA1Z986s', 2),
(7, 'Elevar números terminados em 5 ao quadrado', 'Para Elevar números terminados em 5 ao quadrado é super simples. Vamos pegar o número 35, por exemplo. Esqueça o algarismo da unidade, e some o algarismo da dezena com 1 e depois multiplique por ele mesmo. Depois, insira o número 25 como sufixo.\r\nNo exemplo 35² = 3 x (3 + 1) = 12 depois acrescente 25 como sufixo, ou seja, 1225. Isso vale para todos os múltiplos de 5. Veja com 105² = 10 x (10 + 1) = 110, mais o sufixo 25 igual a 11025.', 'https://www.youtube.com/embed/KbHiA1Z986s', 5),
(8, 'Calcular 15% de um número', 'Calcular 15% de um número é bem simples você precisa primeiro calcular 10% do número, ou seja, dividi-lo por 10, depois pegar o resultado e dividir por 2 que é o mesmo que 5% do valor, e por fim some os resultados das duas divisões. \r\nComo por exemplo 15% de 300, aplicando a regra pegamos 300 e dividimos por 10 o resultado é 30, depois pegamos o 30 e dividimos por dois teremos o 15 e por fim somando o resultado 30 + 15 = 45. Portanto 15% de 300 é igual a 45.', 'https://www.youtube.com/embed/KbHiA1Z986s', 71),
(9, 'Multiplicar um número por 9', 'Para fazer a multiplicação de um número por 9 você tem que pegar esse número e acrescentar um zero no final e depois subtrair o resultado pelo número inicial. Por exemplo, vamos efetuar a seguinte multiplicação: 44x9.\r\nAcrescentando um zero no final do número 44 ficamos com 440. Então subtraímos desse valor o valor inicial: 440 - 44 = 396. Então 44 x 9 = 396. Outro exemplo é a multiplicação de 27 x 9, adicionando o zero no final teremos 270 depois subtraindo o resultado pelo número inicial: 270 - 27 = 243. Portanto 27 x 9 = 243.', 'https://www.youtube.com/embed/KbHiA1Z986s', 67),
(10, 'Raiz quadrada de um número', 'Quando o número for de 2 algarismos, basta somar esses 2 algarismos e colocar o resultado no meio deles. Por exemplo, vamos efetuar a seguinte multiplicação: 26x11. Temos o número 26, somando seus 2 algarismos temos 2+6=8. Pronto! Agora é só colocar esse 8 no meio deles: a resposta é 286. Portanto 26 x 11 = 286. Somamos os algarismos do número 37: 3+7=10 . Como deu um nº maior que 9, então não podemos colocar todo o número no meio deles. Colocamos apenas o algarismo das unidades (0) no meio deles, e o algarismo da dezena (1) é somado ao primeiro algarismo do número: 407. Portanto 37x11 = 407. Quando o número for de 3 algarismos, então esse número multiplicado por 11 resultará em um número de 4 algarismos. Por exemplo, vamos efetuar a seguinte multiplicação: 135 x 11.  Temos o número 135. Somando o 1º com o 2º algarismo desse número temos 1+3=4. Somando o 2º com o 3º algarismo desse número temos 3+5=8. Esses 2 resultados serão colocados no meio do número 135, tirando o seu algarismo do meio: 1485. Portanto 135 x 11 = 1485.', 'https://www.youtube.com/embed/KbHiA1Z986s', 6),
(11, 'Elevar qualquer número ao quadrado', 'Quando o número for de 2 algarismos, basta somar esses 2 algarismos e colocar o resultado no meio deles. Por exemplo, vamos efetuar a seguinte multiplicação: 26x11. Temos o número 26, somando seus 2 algarismos temos 2+6=8. Pronto! Agora é só colocar esse 8 no meio deles: a resposta é 286. Portanto 26 x 11 = 286. Somamos os algarismos do número 37: 3+7=10 . Como deu um nº maior que 9, então não podemos colocar todo o número no meio deles. Colocamos apenas o algarismo das unidades (0) no meio deles, e o algarismo da dezena (1) é somado ao primeiro algarismo do número: 407. Portanto 37x11 = 407. Quando o número for de 3 algarismos, então esse número multiplicado por 11 resultará em um número de 4 algarismos. Por exemplo, vamos efetuar a seguinte multiplicação: 135 x 11.  Temos o número 135. Somando o 1º com o 2º algarismo desse número temos 1+3=4. Somando o 2º com o 3º algarismo desse número temos 3+5=8. Esses 2 resultados serão colocados no meio do número 135, tirando o seu algarismo do meio: 1485. Portanto 135 x 11 = 1485.', 'https://www.youtube.com/embed/KbHiA1Z986s', 5);

-- --------------------------------------------------------

--
-- Estrutura da tabela `nivel`
--

DROP TABLE IF EXISTS `nivel`;
CREATE TABLE IF NOT EXISTS `nivel` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `nivel`
--

INSERT INTO `nivel` (`Id`, `Nome`) VALUES
(4, 'Ensino Fundamental'),
(5, 'Ensino Médio'),
(6, 'Ensino Superior'),
(7, 'Outros');

-- --------------------------------------------------------

--
-- Estrutura da tabela `questao`
--

DROP TABLE IF EXISTS `questao`;
CREATE TABLE IF NOT EXISTS `questao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(50) NOT NULL,
  `Alternativa1` varchar(60) NOT NULL,
  `Alternativa2` varchar(60) NOT NULL,
  `Alternativa3` varchar(60) NOT NULL,
  `Alternativa4` varchar(60) NOT NULL,
  `Resposta` varchar(60) NOT NULL,
  `QuizId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Questao_QuizId` (`QuizId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `questao`
--

INSERT INTO `questao` (`Id`, `Titulo`, `Alternativa1`, `Alternativa2`, `Alternativa3`, `Alternativa4`, `Resposta`, `QuizId`) VALUES
(1, 'Quanto é 35 X 11?', '237', '375', '412', '385', '385', 1),
(2, 'Quanto é 42 X 11?', '565', '462', '489', '452', '462', 1),
(3, 'Quanto é 61 X 11?', '671', '707', '688', '652', '671', 1),
(4, 'Quanto é 87 X 11?', '812', '771', '957', '967', '957', 1),
(5, 'Quanto é 93 X 11?', '1023', '951', '1331', '1053', '1023', 1),
(6, 'Qual a soma dos 3 primeiros números ímpares?', '12', '9', '17', '8', '9', 2),
(7, 'Qual a soma dos 12 primeiros números ímpares?', '132', '190', '144', '215', '144', 2),
(8, 'Qual a soma dos 15 primeiros números ímpares?', '125', '264', '185', '225', '225', 2),
(9, 'Qual a soma dos 22 primeiros números ímpares?', '484', '579', '490', '381', '484', 2),
(10, 'Qual a soma dos 37 primeiros números ímpares?', '1319', '1414', '1371', '1369', '1369', 2),
(11, 'Quanto é 17 X 15?', '208', '323', '255', '389', '255', 3),
(12, 'Quanto é 22 X 15?', '315', '277', '382', '330', '330', 3),
(13, 'Quanto é 54 X 15?', '810', '957', '772', '634', '810', 3),
(14, 'Quanto é 78 X 15?', '1170', '1559', '1360', '968', '1170', 3),
(15, 'Quanto é 95 X 15?', '1586', '1455', '1425', '1634', '1425', 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `quiz`
--

DROP TABLE IF EXISTS `quiz`;
CREATE TABLE IF NOT EXISTS `quiz` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(50) NOT NULL,
  `ConteudoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Quiz_ConteudoId` (`ConteudoId`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `quiz`
--

INSERT INTO `quiz` (`Id`, `Titulo`, `ConteudoId`) VALUES
(1, 'Multiplicar um número por 11', 67),
(2, 'Soma dos n primeiros números naturais ímpares', 2),
(3, 'Multiplicar um número por 15', 67),
(4, 'Dividir qualquer número por 5', 68),
(5, 'Como descobrir o próximo quadrado?', 5),
(6, 'Soma de um grupo de dezenas', 2),
(7, 'Elevar números terminados em 5 ao quadrado', 5),
(8, 'Calcular 15% de um número', 71),
(9, 'Multiplicar um número por 9', 67),
(10, 'Raiz quadrada de um número', 6),
(11, 'Elevar qualquer número ao quadrado', 5);

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200914110349_inicio', '3.1.8');

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `conteudo`
--
ALTER TABLE `conteudo`
  ADD CONSTRAINT `FK_Conteudo_Nivel_NivelId` FOREIGN KEY (`NivelId`) REFERENCES `nivel` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `dica`
--
ALTER TABLE `dica`
  ADD CONSTRAINT `FK_Dica_Conteudo_ConteudoId` FOREIGN KEY (`ConteudoId`) REFERENCES `conteudo` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `questao`
--
ALTER TABLE `questao`
  ADD CONSTRAINT `FK_Questao_Quiz_QuizId` FOREIGN KEY (`QuizId`) REFERENCES `quiz` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `quiz`
--
ALTER TABLE `quiz`
  ADD CONSTRAINT `FK_Quiz_Conteudo_ConteudoId` FOREIGN KEY (`ConteudoId`) REFERENCES `conteudo` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
