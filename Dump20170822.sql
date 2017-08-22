-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: wxhy
-- ------------------------------------------------------
-- Server version	5.7.17-log

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
-- Table structure for table `lybusiness`
--

DROP TABLE IF EXISTS `lybusiness`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lybusiness` (
  `businessId` int(11) NOT NULL,
  `businessname` varchar(45) DEFAULT NULL,
  `logincode` varchar(45) DEFAULT NULL,
  `loginpassword` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`businessId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lybusiness`
--

LOCK TABLES `lybusiness` WRITE;
/*!40000 ALTER TABLE `lybusiness` DISABLE KEYS */;
/*!40000 ALTER TABLE `lybusiness` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lycustomer`
--

DROP TABLE IF EXISTS `lycustomer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lycustomer` (
  `cstId` int(11) NOT NULL AUTO_INCREMENT,
  `businessId` int(11) DEFAULT NULL,
  `openid` varchar(100) DEFAULT NULL,
  `nickname` varchar(45) DEFAULT NULL,
  `sex` int(11) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `country` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `language` varchar(45) DEFAULT NULL,
  `headimgurl` varchar(500) DEFAULT NULL,
  `subscribetime` varchar(45) DEFAULT NULL,
  `unionid` varchar(100) DEFAULT NULL,
  `remark` varchar(45) DEFAULT NULL,
  `groupid` varchar(45) DEFAULT NULL,
  `tagidlist` varchar(45) DEFAULT NULL,
  `csttype` int(11) DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `store` int(11) DEFAULT NULL,
  `interestproduct` varchar(5000) DEFAULT NULL,
  `referees` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`cstId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lycustomer`
--

LOCK TABLES `lycustomer` WRITE;
/*!40000 ALTER TABLE `lycustomer` DISABLE KEYS */;
/*!40000 ALTER TABLE `lycustomer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lyproduct`
--

DROP TABLE IF EXISTS `lyproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lyproduct` (
  `proId` int(11) NOT NULL AUTO_INCREMENT,
  `businessId` int(11) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `remark` varchar(5000) DEFAULT NULL,
  PRIMARY KEY (`proId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lyproduct`
--

LOCK TABLES `lyproduct` WRITE;
/*!40000 ALTER TABLE `lyproduct` DISABLE KEYS */;
/*!40000 ALTER TABLE `lyproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lystore`
--

DROP TABLE IF EXISTS `lystore`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lystore` (
  `storeId` int(11) NOT NULL AUTO_INCREMENT,
  `businessId` int(11) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `remark` varchar(5000) DEFAULT NULL,
  PRIMARY KEY (`storeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lystore`
--

LOCK TABLES `lystore` WRITE;
/*!40000 ALTER TABLE `lystore` DISABLE KEYS */;
/*!40000 ALTER TABLE `lystore` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-08-22 15:09:55
