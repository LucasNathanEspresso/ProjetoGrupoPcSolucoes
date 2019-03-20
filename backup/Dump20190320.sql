CREATE DATABASE  IF NOT EXISTS `cadastro` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `cadastro`;
-- MySQL dump 10.13  Distrib 5.7.25, for Win64 (x86_64)
--
-- Host: localhost    Database: cadastro
-- ------------------------------------------------------
-- Server version	5.7.24

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `CodCliente` int(11) NOT NULL AUTO_INCREMENT,
  `NomFantasia` varchar(100) DEFAULT NULL,
  `RazaoSocial` varchar(100) DEFAULT NULL,
  `TipInscricao` enum('F','J') DEFAULT NULL,
  `Cpf` varchar(15) DEFAULT NULL,
  `Cnpj` varchar(19) DEFAULT NULL,
  `DtNacimento` date DEFAULT NULL,
  `DtAtividade` date DEFAULT NULL,
  `Endereço` varchar(120) DEFAULT NULL,
  `Numero` int(11) DEFAULT NULL,
  `Cep` varchar(10) DEFAULT NULL,
  `Fone` varchar(16) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`CodCliente`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Lucas Nathan','','F','234567890-','','1992-07-06',NULL,'alamenda João Borges',182,'4567890',NULL,'lucasnathan2012@hotmail.com'),(2,'Thais ','Thais teste','J','','345678908776',NULL,'1994-06-23','Presidente Olegario',87,'456789',NULL,'abcdefg'),(18,'','','F','1111111111','','2018-02-16',NULL,'',12,'','',''),(16,'teste','','F','1111111111111','','2018-01-01',NULL,'aaaaaaaaa',123,'456789','999999999999','aaaaaaaaa'),(15,'Welliton Simão','teste','J','','',NULL,'2019-01-12','Alameda João',182,'1234555','999999999999','aaaaaaaaaaaa'),(9,'teste 19/03 - 2','jhgfghjklkjhg','J','','76545678909876',NULL,'2019-02-12','cvbnm,,mn',67890,'987678','0987656789','kjhgfdcvbnm'),(10,'teste 2 Atualizado','','F','567890-','','2018-12-23',NULL,'dfghjklç',7788,'0987654','76655436778','lkjhgfd'),(17,'aaaaaaaaaaaa','kjhgfdfghj','J','','456789987654',NULL,'2019-01-12','cvbnm,lç',123,'4567890','9999999999','123jhgffgghh'),(12,'Lucas Nathan atualizar 4','','F','234567890-','','1992-07-06',NULL,'alamenda João Borges',182,'4567890','','lucasnathan2012@hotmail.com'),(14,'Lucas Nathan teste 2','','F','234567890-','','1992-07-06',NULL,'alamenda João Borges',182,'4567890','','lucasnathan2012@hotmail.com');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-20 10:35:43
