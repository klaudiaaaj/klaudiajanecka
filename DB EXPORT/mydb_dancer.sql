CREATE DATABASE  IF NOT EXISTS `mydb` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `mydb`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `dancer`
--

DROP TABLE IF EXISTS `dancer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dancer` (
  `dancer_id` int NOT NULL,
  `function_id` int NOT NULL,
  `name` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `status` varchar(35) NOT NULL,
  PRIMARY KEY (`dancer_id`),
  KEY `fk_Dancer_Function1_idx` (`function_id`),
  CONSTRAINT `fk_Dancer_Function1` FOREIGN KEY (`function_id`) REFERENCES `function` (`function_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dancer`
--

LOCK TABLES `dancer` WRITE;
/*!40000 ALTER TABLE `dancer` DISABLE KEYS */;
INSERT INTO `dancer` VALUES (1,2,'Klaudia','Janecka','A'),(2,2,'Radoslaw','Kocwin','A'),(3,2,'Alicja','Kozien','A'),(4,2,'Adrianna','Szatan','A'),(5,1,'Przemysla','Mazur','A'),(6,2,'Sandra','Polec','A'),(10,1,'Kamil','Zurawlow','A'),(11,1,'Beata','Badowska','P'),(12,1,'Julia','Sarota','A'),(13,1,'Magdalena','Zajączkowska','A'),(14,1,'Natalia','Lipka','A'),(15,1,'Klaudia','ToShowAnExample','P'),(16,1,'Ola','Cyron','A'),(17,1,'Roksana','Domańska','A'),(18,1,'Wiktoria','Gabrys','A'),(19,1,'Ola','Lasia','A'),(20,1,'Dominika','Bednarska','A'),(30,1,'Marek','Marecki','A');
/*!40000 ALTER TABLE `dancer` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-16 16:48:10
