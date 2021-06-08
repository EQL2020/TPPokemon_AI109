CREATE DATABASE  IF NOT EXISTS `pokemon_bdd` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `pokemon_bdd`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: pokemon_bdd
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `categorie`
--

DROP TABLE IF EXISTS `categorie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorie`
--

LOCK TABLES `categorie` WRITE;
/*!40000 ALTER TABLE `categorie` DISABLE KEYS */;
INSERT INTO `categorie` VALUES (1,'Feu'),(2,'Foudre'),(3,'Terre'),(4,'Eau');
/*!40000 ALTER TABLE `categorie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dresseur`
--

DROP TABLE IF EXISTS `dresseur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dresseur` (
  `id` int(11) NOT NULL,
  `nom` varchar(45) DEFAULT NULL,
  `prenom` varchar(45) DEFAULT NULL,
  `date_naissance` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dresseur`
--

LOCK TABLES `dresseur` WRITE;
/*!40000 ALTER TABLE `dresseur` DISABLE KEYS */;
INSERT INTO `dresseur` VALUES (1,'Marley','Bob','1970-01-01 00:00:00'),(2,'Morisson','Jim','1955-02-03 00:00:00');
/*!40000 ALTER TABLE `dresseur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pokemon`
--

DROP TABLE IF EXISTS `pokemon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pokemon` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `taille` float DEFAULT '0',
  `date_creation` datetime DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `id_dresseur` int(11) DEFAULT NULL,
  `id_categorie` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom_UNIQUE` (`nom`),
  KEY `FK_pokemon_dresseur_idx` (`id_dresseur`),
  KEY `FK_pokemon_categorie_idx` (`id_categorie`),
  CONSTRAINT `FK_pokemon_categorie` FOREIGN KEY (`id_categorie`) REFERENCES `categorie` (`id`),
  CONSTRAINT `FK_pokemon_dresseur` FOREIGN KEY (`id_dresseur`) REFERENCES `dresseur` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pokemon`
--

LOCK TABLES `pokemon` WRITE;
/*!40000 ALTER TABLE `pokemon` DISABLE KEYS */;
INSERT INTO `pokemon` VALUES (1,'Pikachu',0.83,'2021-05-27 00:00:00',NULL,1,1),(2,'Dracofeu',0.74,'2021-05-27 16:07:58',NULL,1,2),(3,'Bulbizarre',0.98,NULL,NULL,1,3),(5,'Carapuce',0.32,'2021-06-02 00:00:00',NULL,2,4),(6,'Ronflex',0.55,'2021-05-28 00:00:00',NULL,2,2),(8,'Machinoux',0.33,'2021-06-07 00:00:00',NULL,NULL,1),(9,'sdgsdgerqh',1.42,'2021-06-15 00:00:00',NULL,NULL,1),(10,'abc',0.53,NULL,NULL,NULL,3),(11,'Benoit',0.84,'2021-06-08 00:00:00',NULL,NULL,2);
/*!40000 ALTER TABLE `pokemon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pouvoir`
--

DROP TABLE IF EXISTS `pouvoir`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pouvoir` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pouvoir`
--

LOCK TABLES `pouvoir` WRITE;
/*!40000 ALTER TABLE `pouvoir` DISABLE KEYS */;
INSERT INTO `pouvoir` VALUES (1,'Boule de feu'),(2,'Eclair'),(3,'Jet d\'eau'),(4,'Postillon'),(5,'Griffe'),(6,'Souffle glacial');
/*!40000 ALTER TABLE `pouvoir` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pouvoir_pokemon`
--

DROP TABLE IF EXISTS `pouvoir_pokemon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pouvoir_pokemon` (
  `id_pouvoir` int(11) NOT NULL,
  `id_pokemon` int(11) NOT NULL,
  KEY `FK_pouvoir_pokemon_pouvoir_idx` (`id_pouvoir`),
  KEY `FK_pouvoir_pokemon_pokemon_idx` (`id_pokemon`),
  CONSTRAINT `FK_pouvoir_pokemon_pokemon` FOREIGN KEY (`id_pokemon`) REFERENCES `pokemon` (`id`),
  CONSTRAINT `FK_pouvoir_pokemon_pouvoir` FOREIGN KEY (`id_pouvoir`) REFERENCES `pouvoir` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pouvoir_pokemon`
--

LOCK TABLES `pouvoir_pokemon` WRITE;
/*!40000 ALTER TABLE `pouvoir_pokemon` DISABLE KEYS */;
/*!40000 ALTER TABLE `pouvoir_pokemon` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-08 10:50:50
