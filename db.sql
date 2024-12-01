CREATE DATABASE  IF NOT EXISTS `lmsdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `lmsdb`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: lmsdb
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblauthors`
--

LOCK TABLES `tblauthors` WRITE;
/*!40000 ALTER TABLE `tblauthors` DISABLE KEYS */;
INSERT INTO `tblauthors` VALUES (1,'sample','aaaa','Male','2024-12-01 17:47:14');
/*!40000 ALTER TABLE `tblauthors` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=105 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblgenres`
--

LOCK TABLES `tblgenres` WRITE;
/*!40000 ALTER TABLE `tblgenres` DISABLE KEYS */;
INSERT INTO `tblgenres` VALUES (1,'Novel',NULL,'2024-11-30 18:22:36'),(2,'Fiction',NULL,'2024-11-30 18:23:06'),(3,'Non-Fiction',NULL,'2024-11-30 18:24:11'),(4,'History',NULL,'2024-11-30 18:27:15'),(5,'Novel',NULL,'2024-11-30 19:12:23'),(8,'Sample',NULL,'2024-11-30 19:15:51'),(9,'Novel',NULL,'2024-11-30 19:18:42'),(10,'Novel',NULL,'2024-11-30 19:24:38'),(11,'Novelellll',NULL,'2024-11-30 19:24:48'),(12,'Novel',NULL,'2024-11-30 19:24:54'),(13,'fawf',NULL,'2024-11-30 19:25:07'),(14,'fwafawf',NULL,'2024-11-30 19:25:11'),(15,'fawfa',NULL,'2024-11-30 19:25:15'),(16,'fawfaw',NULL,'2024-11-30 19:25:20'),(17,'wafawf',NULL,'2024-11-30 19:25:27'),(18,'fawfa',NULL,'2024-11-30 19:25:32'),(19,'fawfawf',NULL,'2024-11-30 19:25:41'),(20,'fawfawfa',NULL,'2024-11-30 19:25:47'),(27,'wadawvfvbdfb',NULL,'2024-11-30 19:28:48'),(31,'gwergwergergre',NULL,'2024-11-30 19:29:07'),(32,'rewgergwerg',NULL,'2024-11-30 19:29:13'),(33,'gwergwregerg',NULL,'2024-11-30 19:29:19'),(34,'gergwergergerg',NULL,'2024-11-30 19:29:24'),(35,'gewrgregregerg',NULL,'2024-11-30 19:29:29'),(36,'gewrgregreg',NULL,'2024-11-30 19:29:33'),(37,'rewgergreger',NULL,'2024-11-30 19:29:38'),(39,'awegseg',NULL,'2024-12-01 10:44:36'),(40,'gsegs',NULL,'2024-12-01 10:44:40'),(41,'gsegsges',NULL,'2024-12-01 10:44:46'),(42,'esgesgs',NULL,'2024-12-01 10:44:49'),(43,'gesgseg',NULL,'2024-12-01 10:44:53'),(44,'esgseg','gsegsg','2024-12-01 10:44:57'),(45,'segseg',NULL,'2024-12-01 10:45:01'),(46,'segsegse',NULL,'2024-12-01 10:45:05'),(47,'esgsgseg',NULL,'2024-12-01 10:45:09'),(48,'segsegseg',NULL,'2024-12-01 10:45:14'),(49,'segesgsegse',NULL,'2024-12-01 10:45:18'),(50,'segsegsegsegse',NULL,'2024-12-01 10:45:25'),(51,'gsegsegseggs',NULL,'2024-12-01 10:45:30'),(52,'gsegsegse','segsegse','2024-12-01 10:45:36'),(53,'gsegsegseg','gsegseg','2024-12-01 10:45:40'),(54,'gsegsgs','segsegsegse','2024-12-01 10:45:45'),(55,'esgse','segsegsegsegs','2024-12-01 10:45:50'),(56,'segsegsgsegs','segsegseg','2024-12-01 10:46:03'),(57,'gsegsegsegsegse',NULL,'2024-12-01 10:46:07'),(58,'esgsegsegse','segsegsegse','2024-12-01 10:46:12'),(59,'esgsegsegsegseg','egsegsegse','2024-12-01 10:46:17'),(60,'gsegsegsegsegsesegs',NULL,'2024-12-01 10:46:32'),(61,'segsgsgsegs','sgsegsegse','2024-12-01 10:46:38'),(62,'sgegsegseg','segsegsegse','2024-12-01 10:46:43'),(63,'gsegsegs','segsgsegseg','2024-12-01 10:46:48'),(64,'segsegs','segsegseg','2024-12-01 10:46:53'),(65,'segsegsegsgsegs','esgsegsegsegsgse','2024-12-01 10:47:00'),(66,'sgesegsegsegs',NULL,'2024-12-01 10:47:06'),(67,'gsegsegsegesgsg','gsegse','2024-12-01 10:47:11'),(68,'AAABBBS',NULL,'2024-12-01 10:47:15'),(69,'aaaaaS',NULL,'2024-12-01 10:47:21'),(70,'AABB',NULL,'2024-12-01 10:47:25'),(71,'3123123123',NULL,'2024-12-01 10:47:30'),(72,'423423423',NULL,'2024-12-01 10:47:35'),(73,'23423423423423',NULL,'2024-12-01 10:47:40'),(74,'2342342342342',NULL,'2024-12-01 10:47:45'),(75,'234234234','awdawda','2024-12-01 10:47:54'),(76,'awrawraw',NULL,'2024-12-01 10:49:52'),(77,'awrawrar',NULL,'2024-12-01 10:49:58'),(78,'rawrawrar',NULL,'2024-12-01 10:50:03'),(79,'awrawrawr',NULL,'2024-12-01 10:50:06'),(80,'rawrawraw',NULL,'2024-12-01 10:50:10'),(81,'rawrawrawraw',NULL,'2024-12-01 10:50:14'),(82,'rawrarawra',NULL,'2024-12-01 10:50:17'),(83,'awrawrawrawr',NULL,'2024-12-01 10:50:21'),(84,'warawrawr',NULL,'2024-12-01 10:50:26'),(86,'rawrawrawr',NULL,'2024-12-01 10:50:35'),(87,'rwarawrawr',NULL,'2024-12-01 10:50:39'),(88,'rawraraw',NULL,'2024-12-01 10:50:42'),(89,'warawrawrawr',NULL,'2024-12-01 10:50:45'),(90,'rwarawrawraw',NULL,'2024-12-01 10:50:49'),(91,'rwararawrawrar',NULL,'2024-12-01 10:50:55'),(92,'awrawrawrawrwar',NULL,'2024-12-01 10:51:00'),(93,'awrawrawrrawr',NULL,'2024-12-01 10:51:06'),(94,'rawrawrawrawra',NULL,'2024-12-01 10:51:10'),(95,'rwarawraw',NULL,'2024-12-01 10:51:14'),(96,'arwrawrawr',NULL,'2024-12-01 10:51:18'),(97,'rwarawrawrara',NULL,'2024-12-01 10:51:22'),(98,'awrawrawrawraw',NULL,'2024-12-01 10:51:27'),(99,'rawrawrawrawawrawr',NULL,'2024-12-01 10:51:34'),(100,'hdhdrhdr',NULL,'2024-12-01 10:51:39'),(101,'hdrhdrhdrhrdhrdhdrh',NULL,'2024-12-01 10:51:44'),(102,'hrdhdrhrdhdrhdr',NULL,'2024-12-01 10:51:48'),(103,'esgsegs','gsegsg','2024-12-01 11:24:31'),(104,'AWRAWR',NULL,'2024-12-01 11:40:48');
/*!40000 ALTER TABLE `tblgenres` ENABLE KEYS */;
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

-- Dump completed on 2024-12-01 18:55:39
