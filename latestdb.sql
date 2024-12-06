CREATE DATABASE  IF NOT EXISTS `lmsdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `lmsdb`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: lmsdb
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `tbladmins`
--

DROP TABLE IF EXISTS `tbladmins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbladmins` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(80) NOT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `gender` varchar(6) DEFAULT NULL,
  `address` varchar(80) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `role` varchar(20) DEFAULT NULL,
  `date_created` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbladmins`
--

LOCK TABLES `tbladmins` WRITE;
/*!40000 ALTER TABLE `tbladmins` DISABLE KEYS */;
INSERT INTO `tbladmins` VALUES (1,'sa','$2a$11$0G.QGRss2L616vZ4DHILF.z72mKk0SvgHx8WCL9PWupl3uBnn32j6',NULL,NULL,NULL,NULL,NULL,NULL,'Super Admin','2024-11-30 09:09:38');
/*!40000 ALTER TABLE `tbladmins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblauthors`
--

DROP TABLE IF EXISTS `tblauthors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblauthors` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `date_added` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblauthors`
--

LOCK TABLES `tblauthors` WRITE;
/*!40000 ALTER TABLE `tblauthors` DISABLE KEYS */;
INSERT INTO `tblauthors` VALUES (1,'sample','aaaa','Male','2024-12-01 17:47:14'),(2,'J.K','Rowling','Female','2024-12-01 21:40:14'),(4,'J.K','Rowling','Male','2024-12-03 14:01:27'),(5,'awdaw','awdaw','Male','2024-12-03 14:01:32'),(6,'dawdaw','awdaw','Male','2024-12-03 14:01:37'),(7,'dawd','wdawdaw','Male','2024-12-03 14:01:42'),(8,'J.K','Rowling','Female','2024-12-03 15:50:18');
/*!40000 ALTER TABLE `tblauthors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblclassifications`
--

DROP TABLE IF EXISTS `tblclassifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblclassifications` (
  `id` int NOT NULL AUTO_INCREMENT,
  `dewey_decimal` varchar(10) NOT NULL,
  `classification` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblclassifications`
--

LOCK TABLES `tblclassifications` WRITE;
/*!40000 ALTER TABLE `tblclassifications` DISABLE KEYS */;
INSERT INTO `tblclassifications` VALUES (1,'000','General Knowledge');
/*!40000 ALTER TABLE `tblclassifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbldonators`
--

DROP TABLE IF EXISTS `tbldonators`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbldonators` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `address` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbldonators`
--

LOCK TABLES `tbldonators` WRITE;
/*!40000 ALTER TABLE `tbldonators` DISABLE KEYS */;
INSERT INTO `tbldonators` VALUES (1,'aaa','aaa');
/*!40000 ALTER TABLE `tbldonators` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblgenres`
--

DROP TABLE IF EXISTS `tblgenres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblgenres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `date_created` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_tblgenres_name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblgenres`
--

LOCK TABLES `tblgenres` WRITE;
/*!40000 ALTER TABLE `tblgenres` DISABLE KEYS */;
INSERT INTO `tblgenres` VALUES (105,'Fiction',NULL,'2024-12-05 06:48:53');
/*!40000 ALTER TABLE `tblgenres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpublishers`
--

DROP TABLE IF EXISTS `tblpublishers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpublishers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `publisher_name` varchar(50) NOT NULL,
  `address` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpublishers`
--

LOCK TABLES `tblpublishers` WRITE;
/*!40000 ALTER TABLE `tblpublishers` DISABLE KEYS */;
INSERT INTO `tblpublishers` VALUES (1,'AWDAWD',NULL);
/*!40000 ALTER TABLE `tblpublishers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsuppliers`
--

DROP TABLE IF EXISTS `tblsuppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblsuppliers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `address` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsuppliers`
--

LOCK TABLES `tblsuppliers` WRITE;
/*!40000 ALTER TABLE `tblsuppliers` DISABLE KEYS */;
INSERT INTO `tblsuppliers` VALUES (1,'bb','bbb');
/*!40000 ALTER TABLE `tblsuppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'lmsdb'
--

--
-- Dumping routines for database 'lmsdb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-06  8:35:26
