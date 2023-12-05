-- --------------------------------------------------------
-- Host:                         10.123.0.7
-- Server version:               8.0.35-0ubuntu0.23.04.1 - (Ubuntu)
-- Server OS:                    Linux
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for model_test_db
CREATE DATABASE IF NOT EXISTS `model_test_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `model_test_db`;

-- Dumping structure for table model_test_db.campuses
CREATE TABLE IF NOT EXISTS `campuses` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.campuses: ~2 rows (approximately)
INSERT INTO `campuses` (`id`, `code`, `description`, `address`, `status`) VALUES
	(1, 'MCNP', 'Medical Colleges of Northern Philippines', 'ALIMANAO, PENABLANCA, CAGAYAN', 'Active'),
	(3, 'ISAP', 'International School of Asia and the Pacific', 'ATULAYAN NORTE, TUGUEGARAO, CAGAYAN', 'Active');

-- Dumping structure for table model_test_db.courses
CREATE TABLE IF NOT EXISTS `courses` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `description` varchar(255) NOT NULL,
  `level` varchar(255) NOT NULL,
  `campus` varchar(255) NOT NULL,
  `department` varchar(255) NOT NULL,
  `max_units` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.courses: ~2 rows (approximately)
INSERT INTO `courses` (`id`, `code`, `description`, `level`, `campus`, `department`, `max_units`, `status`) VALUES
	(1, 'BSIT', 'BACHELOR OF SCIENCE IN IT', 'COLLEGE', 'ISAP', 'CITE', '30', 'ACTIVE'),
	(2, 'BSN', 'BACHELOR OF SCIENCE IN NURSING', 'COLLEGE', 'MCNP', 'CITE', '30', 'Active'),
	(3, 'BSCA', 'Bachelor of Science in Customs Administration', 'COLLEGE', 'ISAP', 'CBEM', '50', 'Active');

-- Dumping structure for table model_test_db.course_fees
CREATE TABLE IF NOT EXISTS `course_fees` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `course_code` varchar(50) NOT NULL,
  `course` varchar(50) NOT NULL,
  `year_level` varchar(50) NOT NULL,
  `fee_type` varchar(50) NOT NULL,
  `amount` decimal(20,3) NOT NULL DEFAULT '0.000',
  `remarks` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.course_fees: ~9 rows (approximately)
INSERT INTO `course_fees` (`id`, `course_code`, `course`, `year_level`, `fee_type`, `amount`, `remarks`) VALUES
	(7, 'BSIT-1', 'BSIT', '1', 'TUITION  FEE per unit', 329.700, ''),
	(8, 'BSIT-1', 'BSIT', '1', 'Chemistry Lab/unit', 949.500, ''),
	(9, 'BSIT-1', 'BSIT', '1', 'Library Fee', 422.060, ''),
	(10, 'BSIT-1', 'BSIT', '1', 'Medical/Dental Fee', 118.180, ''),
	(11, 'BSIT-1', 'BSIT', '1', 'Testing Materials Fee', 337.650, ''),
	(12, 'BSIT-1', 'BSIT', '1', 'Physics Lab/unit', 606.620, ''),
	(14, 'BSN-1', 'BSN', '1', 'Physics Lab/unit', 606.620, ''),
	(15, 'BSN-1', 'BSN', '1', 'Physics Lab/unit', 606.620, ''),
	(16, 'BSN-1', 'BSN', '1', 'AUDIO VISUAL FEE', 168.200, '');

-- Dumping structure for table model_test_db.curriculums
CREATE TABLE IF NOT EXISTS `curriculums` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `campus` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `course` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `effective` varchar(50) NOT NULL,
  `expires` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.curriculums: ~1 rows (approximately)
INSERT INTO `curriculums` (`id`, `code`, `description`, `campus`, `course`, `effective`, `expires`, `status`) VALUES
	(3, 'BSIT-2019-2020', 'BSIT CURRICULUM 2019-2020', 'MAIN', 'BSIT', '21-01-2019', '01-01-2024', 'Active'),
	(4, 'BSCA-2021-2022', 'Bachelor of Science in Customs Administration 2021-2022', 'ISAP', 'BSCA', '01-12-2021', '01-12-2022', 'Active');

-- Dumping structure for table model_test_db.curriculum_subjects
CREATE TABLE IF NOT EXISTS `curriculum_subjects` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `curriculumIdCode` varchar(50) NOT NULL,
  `curriculum` varchar(50) NOT NULL,
  `year_level` varchar(50) NOT NULL,
  `semester` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `descriptive_title` text NOT NULL,
  `total_units` varchar(50) NOT NULL,
  `lecture_units` varchar(50) NOT NULL,
  `lab_units` varchar(50) NOT NULL,
  `pre_requisite` varchar(50) NOT NULL,
  `total_hrs_per_week` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `curriculumIdCode` (`curriculumIdCode`)
) ENGINE=InnoDB AUTO_INCREMENT=181 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.curriculum_subjects: ~13 rows (approximately)
INSERT INTO `curriculum_subjects` (`id`, `curriculumIdCode`, `curriculum`, `year_level`, `semester`, `code`, `descriptive_title`, `total_units`, `lecture_units`, `lab_units`, `pre_requisite`, `total_hrs_per_week`) VALUES
	(8, 'BSIT-2019-2020CC 101', 'BSIT-2019-2020', '', '1', 'CC 101', 'INTRODUCTION TO COMPUTING', '5', '2', '3', 'NONE', '3'),
	(9, 'BSIT-2019-2020CC 102', 'BSIT-2019-2020', '', '1', 'CC 102', 'COMPUTER PROGRAMMING 1', '5', '2', '3', 'NONE', '3'),
	(10, 'BSIT-2019-2020MATH 11', 'BSIT-2019-2020', '', '1', 'MATH 11', 'MATHEMATICS IN THE MODERN WORLD', '3', '3', '0', 'NONE', '3'),
	(11, 'BSIT-2019-2020SOC SCI 11', 'BSIT-2019-2020', '', '1', 'SOC SCI 11', 'UNDERSTANDING THE SELF', '3', '3', '0', 'NONE', '3'),
	(12, 'BSIT-2019-2020ENG 11', 'BSIT-2019-2020', '', '1', 'ENG 11', 'PURPOSIVE COMMUNICATION', '3', '3', '0', 'NONE', '3'),
	(13, 'BSIT-2019-2020FIL 11', 'BSIT-2019-2020', '', '1', 'FIL 11', 'Kontekswalisadong Komunikasyon sa Filipino ', '3', '3', '0', 'NONE', '3'),
	(14, 'BSIT-2019-2020SOC SCI 13', 'BSIT-2019-2020', '', '1', 'SOC SCI 13', 'READINGS IN PHILIPPINE HISTORY', '3', '3', '0', 'NONE', '3'),
	(15, 'BSIT-2019-2020PE 11', 'BSIT-2019-2020', '', '1', 'PE 11', 'MOVEMENT ENHANCEMENT', '3', '3', '0', 'NONE', '3'),
	(16, 'BSIT-2019-2020NSTP 11', 'BSIT-2019-2020', '', '1', 'NSTP 11', 'CIVIC WELFARE TRAINING SERVICE 1', '3', '3', '0', 'NONE', '3'),
	(17, 'BSIT-2019-2020NSTP 12', 'BSIT-2019-2020', '', '1', 'NSTP 12', 'RESERVED OFFICERS TRAINING CORPS', '3', '3', '0', 'NONE', '3'),
	(18, 'BSIT-2019-2020CC 103', 'BSIT-2019-2020', '', '2', 'CC 103', 'INTRODUCTION TO COMPUTER INTERACTION', '3', '3', '0', 'CC 101', '3'),
	(19, 'BSIT-2019-2020CC 104', 'BSIT-2019-2020', '', '2', 'CC 104', 'COMPUTER PROGRAMMING 2', '5', '2', '3', 'CC 102', '3'),
	(20, 'BSIT-2019-2020CC 105', 'BSIT-2019-2020', '', '2', 'CC 105', 'FUNDAMENTALS OF DATABASE SYSTEMS', '5', '2', '3', 'CC 101', '3'),
	(121, 'BSCA-2021-2022GEC 1', 'BSCA-2021-2022', '1', '1', 'GEC 1', 'Understanding the Self', '3', '3', '0', 'None', '3'),
	(122, 'BSCA-2021-2022GEC 2', 'BSCA-2021-2022', '1', '1', 'GEC 2', 'Readings in the Philippine History', '3', '3', '0', 'None', '3'),
	(123, 'BSCA-2021-2022GEC 3', 'BSCA-2021-2022', '1', '1', 'GEC 3', 'The Contemporary World', '3', '3', '0', 'None', '3'),
	(124, 'BSCA-2021-2022GEC 4', 'BSCA-2021-2022', '1', '1', 'GEC 4', 'Mathematics in the Modern World', '3', '3', '0', 'None', '3'),
	(125, 'BSCA-2021-2022SBEC 100', 'BSCA-2021-2022', '1', '1', 'SBEC 100', 'International Trade', '3', '3', '0', 'None', '3'),
	(126, 'BSCA-2021-2022GEC 5', 'BSCA-2021-2022', '1', '1', 'GEC 5', 'Purposive Communication', '3', '3', '0', 'None', '3'),
	(127, 'BSCA-2021-2022PE 101', 'BSCA-2021-2022', '1', '1', 'PE 101', 'Physical Education 1 (Physical Fitness)', '2', '2', '0', 'None', '2'),
	(128, 'BSCA-2021-2022NSTP 1', 'BSCA-2021-2022', '1', '1', 'NSTP 1', 'National Service Training Program 1', '3', '3', '0', 'None', '3'),
	(129, 'BSCA-2021-2022ETHICS 100', 'BSCA-2021-2022', '1', '1', 'ETHICS 100', 'ISAPian Education with Values Formation', '1.5', '1.5', '0', 'None', '1.5'),
	(130, 'BSCA-2021-2022MSCED 201', 'BSCA-2021-2022', '1', '1', 'MSCED 201', 'Advisorship Time', '0', '1', '0', 'None', '1'),
	(131, 'BSCA-2021-2022GEC 6', 'BSCA-2021-2022', '1', '2', 'GEC 6', 'Art Apreciation', '3', '3', '0', 'None', '3'),
	(132, 'BSCA-2021-2022GEC 7', 'BSCA-2021-2022', '1', '2', 'GEC 7', 'Science, Technology and Society', '3', '3', '0', 'None', '3'),
	(133, 'BSCA-2021-2022SCM 101', 'BSCA-2021-2022', '1', '2', 'SCM 101', 'Introduction to Supply Chain Management', '3', '3', '0', 'SBEC 100', '3'),
	(134, 'BSCA-2021-2022CM 101', 'BSCA-2021-2022', '1', '2', 'CM 101', 'Border Control and Security', '3', '3', '0', 'SBEC 100', '3'),
	(135, 'BSCA-2021-2022TM 101', 'BSCA-2021-2022', '1', '2', 'TM 101', 'Fundamentals of Customs and Tariff Management', '3', '3', '0', 'SBEC 100', '3'),
	(136, 'BSCA-2021-2022GEC 8', 'BSCA-2021-2022', '1', '2', 'GEC 8', 'Ethics', '3', '3', '0', 'None', '3'),
	(137, 'BSCA-2021-2022ECON 101', 'BSCA-2021-2022', '1', '2', 'ECON 101', 'International Economics', '3', '3', '0', 'SBEC 100', '3'),
	(138, 'BSCA-2021-2022PE 102', 'BSCA-2021-2022', '1', '2', 'PE 102', 'Physical Education 2 (Gymnastics)', '2', '2', '0', 'PE 1', '2'),
	(139, 'BSCA-2021-2022NSTP 2', 'BSCA-2021-2022', '1', '2', 'NSTP 2', 'National Service Training Program 2', '3', '3', '0', 'NSTP 1', '3'),
	(140, 'BSCA-2021-2022MSCED 202', 'BSCA-2021-2022', '1', '2', 'MSCED 202', 'Advisorship Time', '0', '1', '0', 'MSCED 201', '1'),
	(141, 'BSCA-2021-2022GEC 9', 'BSCA-2021-2022', '2', '1', 'GEC 9', 'Rizal\'s Life and Works', '3', '3', '0', 'None', '3'),
	(142, 'BSCA-2021-2022LIT 101', 'BSCA-2021-2022', '2', '1', 'LIT 101', 'Panitikang Pilipino ', '3', '3', '0', 'None', '3'),
	(143, 'BSCA-2021-2022SBEC 101', 'BSCA-2021-2022', '2', '1', 'SBEC 101', 'Income and Business Taxation', '3', '3', '0', 'SBEC 100', '3'),
	(144, 'BSCA-2021-2022SCM102', 'BSCA-2021-2022', '2', '1', 'SCM102', 'Warehoues Operations Management', '3', '3', '0', 'SCM 100', '3'),
	(145, 'BSCA-2021-2022SBEC 102', 'BSCA-2021-2022', '2', '1', 'SBEC 102', 'Business Law', '3', '3', '0', 'SBEC 100', '3'),
	(146, 'BSCA-2021-2022CM 102', 'BSCA-2021-2022', '2', '1', 'CM 102', 'Customs Operations and Cargo Handling with Educ. Tour', '3', '3', '0', 'CM 101', '3'),
	(147, 'BSCA-2021-2022CM 103', 'BSCA-2021-2022', '2', '1', 'CM 103', 'Customs Warehousing', '5', '5', '0', 'CM 101', '5'),
	(148, 'BSCA-2021-2022TM 102', 'BSCA-2021-2022', '2', '1', 'TM 102', 'Commodity Classification System', '3', '3', '0', 'TM 101', '3'),
	(149, 'BSCA-2021-2022PE 103', 'BSCA-2021-2022', '2', '1', 'PE 103', 'Physical Education  3 (Swimming)', '2', '2', '0', 'PE 102', '2'),
	(150, 'BSCA-2021-2022MSCED 203', 'BSCA-2021-2022', '2', '1', 'MSCED 203', 'Advisorship Time', '0', '1', '0', 'MSCED 202', '1'),
	(151, 'BSCA-2021-2022GEE 101', 'BSCA-2021-2022', '2', '2', 'GEE 101', 'Philippine Popular Culture', '3', '3', '0', 'None', '3'),
	(152, 'BSCA-2021-2022CBMEC 101', 'BSCA-2021-2022', '2', '2', 'CBMEC 101', 'Strategic Management', '3', '3', '0', 'None', '3'),
	(153, 'BSCA-2021-2022EC 101', 'BSCA-2021-2022', '2', '2', 'EC 101', 'International Marketing', '3', '3', '0', 'ECON 101', '3'),
	(154, 'BSCA-2021-2022EC 102', 'BSCA-2021-2022', '2', '2', 'EC 102', 'Enterpreneurial Management', '3', '3', '0', 'ECON 101', '3'),
	(155, 'BSCA-2021-2022SCM 103', 'BSCA-2021-2022', '2', '2', 'SCM 103', 'Procurement and Inventory Management', '3', '3', '0', 'SCM 102', '3'),
	(156, 'BSCA-2021-2022CM 104', 'BSCA-2021-2022', '2', '2', 'CM 104', 'Customs Proceedings', '5', '3', '0', 'CM 103', '3'),
	(157, 'BSCA-2021-2022TM 103', 'BSCA-2021-2022', '2', '2', 'TM 103', 'Customs Valuation System', '5', '5', '0', 'TM 102', '5'),
	(158, 'BSCA-2021-2022PE 104', 'BSCA-2021-2022', '2', '2', 'PE 104', 'Physical Education 4 (Team Sports)', '2', '2', '0', 'PE 103', '2'),
	(159, 'BSCA-2021-2022MSCED 204', 'BSCA-2021-2022', '2', '2', 'MSCED 204', 'Advisorship Time', '0', '1', '0', 'MSCED 203', '1'),
	(160, 'BSCA-2021-2022FL 102', 'BSCA-2021-2022', '3', '1', 'FL 102', 'Foreign Language 2', '2', '2', '0', 'FL 101', '2'),
	(161, 'BSCA-2021-2022FIL 102', 'BSCA-2021-2022', '3', '1', 'FIL 102', 'Kontekstwalissadong Filipino', '3', '3', '0', 'FIL 101', '3'),
	(162, 'BSCA-2021-2022LIT 102', 'BSCA-2021-2022', '3', '1', 'LIT 102', 'Philippine Literature', '3', '3', '0', 'LIT 101', '3'),
	(163, 'BSCA-2021-2022LED 1', 'BSCA-2021-2022', '3', '1', 'LED 1', 'Labor Education', '3', '3', '0', 'None', '3'),
	(164, 'BSCA-2021-2022GEE 103', 'BSCA-2021-2022', '3', '1', 'GEE 103', 'Philippine Indigenous Communities', '3', '3', '0', 'GEE 102', '3'),
	(165, 'BSCA-2021-2022CM 106', 'BSCA-2021-2022', '3', '1', 'CM 106', 'Customs Post Clearance Audit and Fraud Detection', '5', '5', '0', 'CM 105', '5'),
	(166, 'BSCA-2021-2022TM 105', 'BSCA-2021-2022', '3', '1', 'TM 105', 'Excise Taxes, Liquidation of Duty and Surcharges', '5', '5', '0', 'TM 104', '5'),
	(167, 'BSCA-2021-2022CA RES 102', 'BSCA-2021-2022', '3', '1', 'CA RES 102', 'Customs Research 2', '3', '3', '0', 'CA RES 101', '3'),
	(168, 'BSCA-2021-2022MSCED 206', 'BSCA-2021-2022', '3', '1', 'MSCED 206', 'Advisorship Time', '0', '1', '0', 'MSCED 205', '1'),
	(169, 'BSCA-2021-2022FIL 103', 'BSCA-2021-2022', '3', '3', 'FIL 103', 'Malayuning Komunikasyon', '3', '3', '0', 'FIL 102', '9'),
	(170, 'BSCA-2021-2022CM 107', 'BSCA-2021-2022', '3', '3', 'CM 107', 'Ethics and Standards of Custom Broker', '3', '3', '0', 'CM 106', '9'),
	(171, 'BSCA-2021-2022TM 106', 'BSCA-2021-2022', '3', '3', 'TM 106', 'Special Duties and Trade Remedies', '3', '3', '0', 'TM 105', '9'),
	(172, 'BSCA-2021-2022CA 101', 'BSCA-2021-2022', '4', '1', 'CA 101', 'Integration Review for Cutoms Laws', '1.5', '1.5', '0', '4th Year Standing', '1.5 (3)'),
	(173, 'BSCA-2021-2022CA 102', 'BSCA-2021-2022', '4', '1', 'CA 102', 'IntegrationReview for Tariff Management', '1.5', '1.5', '0', '4th Year Standing', '1.5 (3)'),
	(174, 'BSCA-2021-2022TM 107', 'BSCA-2021-2022', '4', '1', 'TM 107', 'International Trade Organizations, Agreements and Rules of Origin', '5', '5', '0', 'TM 106', '5'),
	(175, 'BSCA-2021-2022CBMEC 102', 'BSCA-2021-2022', '4', '1', 'CBMEC 102', 'Operations Management', '3', '3', '0', 'CBMEC 101', '3'),
	(176, 'BSCA-2021-2022MSCED 207', 'BSCA-2021-2022', '4', '1', 'MSCED 207', 'Advisorship Time', '0', '1', '0', 'MSCED 206', '1'),
	(177, 'BSCA-2021-2022CM 108', 'BSCA-2021-2022', '4', '2', 'CM 108', 'Competency Assessment in Customs Management', '5', '5', '0', '4th Year Standing', '5'),
	(178, 'BSCA-2021-2022TM 108', 'BSCA-2021-2022', '4', '2', 'TM 108', 'Competency Assessment in Tariff Management', '5', '5', '0', '4th Year Standing', '5'),
	(179, 'BSCA-2021-2022CA OCL', 'BSCA-2021-2022', '4', '2', 'CA OCL', 'Off-Campus Learning, Customs Brokerage Industry (200 hrs), Freight Forwarding/Logistics/Shipping  or Airline Companies, Govenrment Agencies(200hrs)', '3', '', 'Field', '4th Year Standing', '24'),
	(180, 'BSCA-2021-2022MSCED 208', 'BSCA-2021-2022', '4', '2', 'MSCED 208', 'Advisorship Time', '0', '1', '1', 'MS CED 207', '1');

-- Dumping structure for table model_test_db.departments
CREATE TABLE IF NOT EXISTS `departments` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `campus` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.departments: ~2 rows (approximately)
INSERT INTO `departments` (`id`, `code`, `description`, `campus`) VALUES
	(1, 'ADMIN', 'ADMINISTRATION', 'MAIN'),
	(3, 'CITE', 'COLLEGE OF INFORMATION TECHNOLOGY AND ENGINEERING', 'MAIN'),
	(4, 'CBEM', 'College of Business Entrepreneur and Management', 'ISAP');

-- Dumping structure for table model_test_db.discount_setup
CREATE TABLE IF NOT EXISTS `discount_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `discount_percentage` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.discount_setup: ~3 rows (approximately)
INSERT INTO `discount_setup` (`id`, `code`, `description`, `discount_percentage`) VALUES
	(1, 'Discount1', 'Discount Number 1', 100),
	(2, 'Discount2', 'Discount Number 2', 50),
	(3, 'Discount3', 'Discount Number 3', 75);

-- Dumping structure for table model_test_db.fee_type
CREATE TABLE IF NOT EXISTS `fee_type` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `course` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `year_level` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `category` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `total` decimal(20,3) NOT NULL DEFAULT '0.000',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.fee_type: ~0 rows (approximately)

-- Dumping structure for table model_test_db.instructors
CREATE TABLE IF NOT EXISTS `instructors` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `fullname` varchar(255) NOT NULL,
  `department` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.instructors: ~2 rows (approximately)
INSERT INTO `instructors` (`id`, `fullname`, `department`, `position`) VALUES
	(1, 'Manglallan, Derrick D.', 'CITE', 'Instructor 1'),
	(2, 'Pingad, Airon Jim', 'CITE', 'Instructor 1');

-- Dumping structure for table model_test_db.lab_fee_setup
CREATE TABLE IF NOT EXISTS `lab_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` varchar(50) NOT NULL,
  `second_year` varchar(50) NOT NULL,
  `third_year` varchar(50) NOT NULL,
  `fourth_year` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.lab_fee_setup: ~3 rows (approximately)
INSERT INTO `lab_fee_setup` (`id`, `category`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(1, 'Chemistry Lab', 'MCNP', '456.75', '456.75', '456.75', '456.75'),
	(2, 'Computer Lab Fee', 'ISAP', '256.65', '345.45', '521.65', '689.01'),
	(3, 'Criminology Lab Fee', 'ISAP', '245.65', '345.65', '445.75', '545.85'),
	(4, 'Physics Lab', 'ISAP', '450.02', '450.02', '450.02', '450.02');

-- Dumping structure for table model_test_db.levels
CREATE TABLE IF NOT EXISTS `levels` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.levels: ~3 rows (approximately)
INSERT INTO `levels` (`id`, `code`, `description`, `status`) VALUES
	(1, 'KINDER', 'KINDERGARTEN', 'Active'),
	(2, 'ELEMENTARY', 'ELEMENTARY LEVEL', 'Active'),
	(3, 'COLLEGE', 'COLLEGE LEVEL', 'Active');

-- Dumping structure for table model_test_db.miscellaneous_fee_setup
CREATE TABLE IF NOT EXISTS `miscellaneous_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  `second_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  `third_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  `fourth_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.miscellaneous_fee_setup: ~2 rows (approximately)
INSERT INTO `miscellaneous_fee_setup` (`id`, `category`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(17, 'Chemistry Lab/unit', 'MCNP', 949.500, 949.500, 949.500, 949.500),
	(19, 'PE Uniform Fee', 'ISAP', 265.450, 365.500, 456.620, 512.000);

-- Dumping structure for table model_test_db.other_fees
CREATE TABLE IF NOT EXISTS `other_fees` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(100) NOT NULL,
  `first_year` varchar(100) NOT NULL,
  `second_year` varchar(100) NOT NULL,
  `third_year` varchar(100) NOT NULL,
  `fourth_year` varchar(100) NOT NULL,
  `instersession` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.other_fees: ~0 rows (approximately)

-- Dumping structure for table model_test_db.school_year
CREATE TABLE IF NOT EXISTS `school_year` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `school_year_from` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `school_year_to` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `semester` varchar(50) NOT NULL,
  `is_current` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.school_year: ~2 rows (approximately)
INSERT INTO `school_year` (`id`, `code`, `description`, `school_year_from`, `school_year_to`, `semester`, `is_current`) VALUES
	(2, '2023-2024-1', 'School Year 2023-2024, 1st Semester', '11-27-2023', '11-27-2024', '1', 'Yes'),
	(4, '2024-2025-1', 'SCHOOL YEAR 2024-2025, 1ST SEMESTER', '01-27-2024', '01-27-2025', '1', '');

-- Dumping structure for table model_test_db.sections
CREATE TABLE IF NOT EXISTS `sections` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `unique_id` varchar(255) NOT NULL,
  `section_code` varchar(255) NOT NULL,
  `course` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `year_level` varchar(255) NOT NULL,
  `section` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `semester` varchar(255) NOT NULL,
  `number_of_students` int NOT NULL,
  `max_number_of_students` int NOT NULL,
  `status` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `remarks` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.sections: ~4 rows (approximately)
INSERT INTO `sections` (`id`, `unique_id`, `section_code`, `course`, `year_level`, `section`, `semester`, `number_of_students`, `max_number_of_students`, `status`, `remarks`) VALUES
	(16, '0', 'BSIT-1-A', 'BSIT', '1', 'A', '1', 4, 4, 'Full', 'Regular'),
	(17, 'BSIT-1-BBSIT11', 'BSIT-1-B', 'BSIT', '1', 'B', '1', 5, 50, 'Available', 'Regular'),
	(21, 'BSIT-1-CBSIT11', 'BSIT-1-C', 'BSIT', '1', 'C', '1', 0, 50, 'Available', 'Regular'),
	(22, 'BSIT-1-ABSIT12', 'BSIT-1-A', 'BSIT', '1', 'A', '2', 0, 50, 'Available', 'Regular'),
	(23, 'BSCA-1-ABSCA11', 'BSCA-1-A', 'BSCA', '1', 'A', '1', 2, 50, 'Available', 'Regular'),
	(25, 'BSCA-1-ABSCA12', 'BSCA-1-A', 'BSCA', '1', 'A', '2', 1, 50, 'Available', 'Regular');

-- Dumping structure for table model_test_db.section_subjects
CREATE TABLE IF NOT EXISTS `section_subjects` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `unique_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '0',
  `section_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `curriculum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `course` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `year_level` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `semester` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `subject_code` varchar(50) NOT NULL,
  `descriptive_title` varchar(50) NOT NULL,
  `total_units` decimal(20,1) NOT NULL DEFAULT '0.0',
  `lecture_units` decimal(20,1) NOT NULL DEFAULT '0.0',
  `lab_units` decimal(20,1) NOT NULL DEFAULT '0.0',
  `pre_requisite` varchar(50) NOT NULL,
  `time` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `day` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `room` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `instructor` varchar(50) DEFAULT NULL,
  `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.section_subjects: ~18 rows (approximately)
INSERT INTO `section_subjects` (`id`, `unique_id`, `section_code`, `curriculum`, `course`, `year_level`, `semester`, `subject_code`, `descriptive_title`, `total_units`, `lecture_units`, `lab_units`, `pre_requisite`, `time`, `day`, `room`, `instructor`, `status`) VALUES
	(29, 'BSIT-A-BSIT 2023-2024-BSIT-1-1-GEC 1', 'BSIT-A', 'BSIT 2023-2024', 'BSIT', '1', '1', 'GEC 1', 'UNDERSTANDING THE SELF', 3.0, 3.0, 0.0, 'NONE', NULL, NULL, NULL, NULL, NULL),
	(30, 'BSIT-A-BSIT 2023-2024-BSIT-1-1-GEC 4', 'BSIT-A', 'BSIT 2023-2024', 'BSIT', '1', '1', 'GEC 4', 'MATHEMATICS IN THE MODERN WORLD', 3.0, 3.0, 0.0, 'NONE', '03:15 pm-5:00 pm', 'MWF', 'FNC-201', NULL, NULL),
	(32, 'BSIT-1-B-BSIT 2023-2024-BSIT-1-1-GEC 1', 'BSIT-1-B', 'BSIT 2023-2024', 'BSIT', '1', '1', 'GEC 1', 'UNDERSTANDING THE SELF', 3.0, 3.0, 0.0, 'NONE', '09:00 AM - 10:30 AM', 'TTH', 'NAB-102', NULL, NULL),
	(38, 'BSIT-1-1-BSIT 2023-2024-BSIT-1--GEC 1', 'BSIT-1-1', 'BSIT 2023-2024', 'BSIT', '1', '', 'GEC 1', 'UNDERSTANDING THE SELF', 3.0, 3.0, 0.0, 'NONE', '9:00-10:00', 'MWF', 'NAB-101', NULL, NULL),
	(40, 'BSIT-1-1-BSIT 2023-2024-BSIT-1--GEC 4', 'BSIT-1-1', 'BSIT 2023-2024', 'BSIT', '1', '', 'GEC 4', 'MATHEMATICS IN THE MODERN WORLD', 3.0, 3.0, 0.0, 'NONE', '', '', '', NULL, NULL),
	(44, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-CC 101', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'CC 101', 'INTRODUCTION TO COMPUTING', 5.0, 2.0, 3.0, 'NONE', '7:00-8:00AM Lec 10-12AM Lab', 'MWF Lec TTH Lab', 'NAB-101 Lec, CL-A Lec', 'Manglallan, Derrick D.', NULL),
	(45, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-CC 102', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'CC 102', 'COMPUTER PROGRAMMING 1', 5.0, 2.0, 3.0, 'NONE', '7-10 lec, 10-12', 'MWF lec, TTH Lab', 'NAB 102', NULL, NULL),
	(46, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-MATH 11', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'MATH 11', 'MATHEMATICS IN THE MODERN WORLD', 3.0, 3.0, 0.0, 'NONE', '10-12', 'TTH', 'NAB-201', NULL, NULL),
	(47, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-SOC SCI 11', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'SOC SCI 11', 'UNDERSTANDING THE SELF', 3.0, 3.0, 0.0, 'NONE', '7-10', 'MWF', 'NAB-202', NULL, NULL),
	(48, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-ENG 11', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'ENG 11', 'PURPOSIVE COMMUNICATION', 3.0, 3.0, 0.0, 'NONE', '3-5', 'MWF', 'C-101', NULL, NULL),
	(49, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-FIL 11', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'FIL 11', 'Kontekswalisadong Komunikasyon sa Filipino ', 3.0, 3.0, 0.0, 'NONE', '5-6', 'TTH', 'C-102', NULL, NULL),
	(50, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-SOC SCI 13', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'SOC SCI 13', 'READINGS IN PHILIPPINE HISTORY', 3.0, 3.0, 0.0, 'NONE', '8-9', 'MWF', 'C-103', NULL, NULL),
	(51, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-PE 11', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'PE 11', 'MOVEMENT ENHANCEMENT', 3.0, 3.0, 0.0, 'NONE', '7-8', 'S', 'C201', NULL, NULL),
	(52, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-NSTP 11', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'NSTP 11', 'CIVIC WELFARE TRAINING SERVICE 1', 3.0, 3.0, 0.0, 'NONE', '12-1', 'MWF', 'C203', NULL, NULL),
	(53, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-1-NSTP 12', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '1', 'NSTP 12', 'RESERVED OFFICERS TRAINING CORPS', 3.0, 3.0, 0.0, 'NONE', '2-3', 'TTH', 'GYMNASIUM', NULL, NULL),
	(54, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-2-CC 103', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '2', 'CC 103', 'INTRODUCTION TO COMPUTER INTERACTION', 3.0, 3.0, 0.0, 'CC 101', '', '', '', NULL, NULL),
	(55, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-2-CC 104', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '2', 'CC 104', 'COMPUTER PROGRAMMING 2', 5.0, 2.0, 3.0, 'CC 102', '', '', '', NULL, NULL),
	(56, 'BSIT-1-A-BSIT-2019-2020-BSIT-1-2-CC 105', 'BSIT-1-A', 'BSIT-2019-2020', 'BSIT', '1', '2', 'CC 105', 'FUNDAMENTALS OF DATABASE SYSTEMS', 5.0, 2.0, 3.0, 'CC 101', '', '', '', NULL, NULL),
	(57, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-GEC 1', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'GEC 1', 'Understanding the Self', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(58, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-GEC 2', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'GEC 2', 'Readings in the Philippine History', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(59, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-GEC 3', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'GEC 3', 'The Contemporary World', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(60, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-GEC 4', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'GEC 4', 'Mathematics in the Modern World', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(61, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-SBEC 100', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'SBEC 100', 'International Trade', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(62, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-GEC 5', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'GEC 5', 'Purposive Communication', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(63, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-PE 101', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 2.0, 2.0, 0.0, 'None', '', '', '', '', NULL),
	(65, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-NSTP 1', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'NSTP 1', 'National Service Training Program 1', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(66, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-ETHICS 100', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'ETHICS 100', 'ISAPian Education with Values Formation', 1.5, 1.5, 0.0, 'None', '', '', '', NULL, NULL),
	(67, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-1-MSCED 201', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '1', 'MSCED 201', 'Advisorship Time', 0.0, 1.0, 0.0, 'None', '', '', '', NULL, NULL),
	(68, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-GEC 6', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'GEC 6', 'Art Apreciation', 3.0, 3.0, 0.0, 'None', '8:30', 'TTH', '1', '', NULL),
	(69, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-GEC 7', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'GEC 7', 'Science, Technology and Society', 3.0, 3.0, 0.0, 'None', 'SA', 'SA', 'SA', '', NULL),
	(70, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-SCM 101', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'SCM 101', 'Introduction to Supply Chain Management', 3.0, 3.0, 0.0, 'SBEC 100', '12', '22', '2', '', NULL),
	(71, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-CM 101', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'CM 101', 'Border Control and Security', 3.0, 3.0, 0.0, 'SBEC 100', '1', '1', '1', 'Manglallan, Derrick D.', NULL),
	(72, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-TM 101', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'TM 101', 'Fundamentals of Customs and Tariff Management', 3.0, 3.0, 0.0, 'SBEC 100', '1', '1', '1', '', NULL),
	(73, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-GEC 8', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'GEC 8', 'Ethics', 3.0, 3.0, 0.0, 'None', '1', '1', '1', '', NULL),
	(75, 'BSCA-1-A-BSCA-2021-2022-BSCA-1-2-ECON 101', 'BSCA-1-A', 'BSCA-2021-2022', 'BSCA', '1', '2', 'ECON 101', 'International Economics', 3.0, 3.0, 0.0, 'SBEC 100', '1', '11', '1', 'Pingad, Airon Jim', NULL);

-- Dumping structure for table model_test_db.statements_of_accounts
CREATE TABLE IF NOT EXISTS `statements_of_accounts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `reference_no` varchar(50) NOT NULL,
  `Particulars` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `debit` decimal(20,2) NOT NULL DEFAULT '0.00',
  `credit` decimal(20,2) NOT NULL DEFAULT '0.00',
  `balance` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  UNIQUE KEY `reference_no` (`reference_no`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.statements_of_accounts: ~0 rows (approximately)

-- Dumping structure for table model_test_db.student_accounts
CREATE TABLE IF NOT EXISTS `student_accounts` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL DEFAULT '',
  `school_year` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `fullname` varchar(100) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `civil_status` varchar(50) NOT NULL,
  `date_of_birth` varchar(50) NOT NULL,
  `place_of_birth` varchar(50) NOT NULL,
  `nationality` varchar(50) NOT NULL,
  `religion` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_number` (`id_number`),
  UNIQUE KEY `fullname` (`fullname`)
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_accounts: ~10 rows (approximately)
INSERT INTO `student_accounts` (`id`, `id_number`, `school_year`, `fullname`, `last_name`, `first_name`, `middle_name`, `gender`, `civil_status`, `date_of_birth`, `place_of_birth`, `nationality`, `religion`, `status`) VALUES
	(65, '2023-1-0001', '2023-2024-1', 'Manglallan, Derrick Daniel', 'Manglallan', 'Derrick', 'Daniel', 'Male', 'Single', '07-31-1996', 'Tuguegarao City, Cagayan', 'Filipino', 'Roman Catholic', 'Accounting'),
	(66, '2023-1-0002', '2023-2024-1', 'Pingad, Airon Jimboy', 'Pingad', 'Airon', 'Jimboy', 'Male', 'Single Forever', 'dik amo', 'dik amo', 'dik amo', 'dik ngarud amo', 'Accounting'),
	(67, '2023-1-0003', '2023-2024-1', 'Buguina, Melenio ', 'Buguina', 'Melenio', '', 'Male', 'dik amo', 'dik amo', 'dik amo', 'Filipino', 'dik amo', 'Accounting'),
	(68, '2023-1-0004', '2023-2024-1', ',  ', '', '', '', '', '', '', '', '', '', 'Accounting'),
	(70, '2023-1-0005', '2023-2024-1', 'asfd, adsf ', 'asfd', 'adsf', '', '', '', '', '', '', '', 'Pending'),
	(71, '2023-1-0006', '2023-2024-1', 'afdsf,  ', 'afdsf', '', '', '', '', '', '', '', '', 'Pending'),
	(72, '2023-1-0007', '2023-2024-1', 'asdfasd, adsffdassdf ', 'asdfasd', 'adsffdassdf', '', '', '', '', '', '', '', 'Pending'),
	(73, '2023-1-0008', '2023-2024-1', 'asdfasdfdf,  ', 'asdfasdfdf', '', '', '', '', '', '', '', '', 'Pending'),
	(74, '2023-1-0009', '2023-2024-1', 'fghfghfgh,  ', 'fghfghfgh', '', '', '', '', '', '', '', '', 'Pending'),
	(76, '2023-1-0010', '2023-2024-1', 'pokfpoekr, sdlkfj ', 'pokfpoekr', 'sdlkfj', '', '', '', '', '', '', '', 'Pending'),
	(77, '2023-1-0011', '2023-2024-1', 'Alan, Charity T', 'Alan', 'Charity', 'T', '', '', '12-20-2023', '', '', '', 'Accounting'),
	(78, '2023-1-0012', '2023-2024-1', 'PAGELA, CHRISTIAN S', 'PAGELA', 'CHRISTIAN', 'S', '', '', '12-21-2023', '', '', '', 'For Enrollment'),
	(79, '2023-1-0013', '2023-2024-1', 'quintana, ronnel s', 'quintana', 'ronnel', 's', 'm', 'married', '12-27-2023', '', '', '', 'Accounting');

-- Dumping structure for table model_test_db.student_assessment
CREATE TABLE IF NOT EXISTS `student_assessment` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `school_year` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `fee_type` varchar(50) NOT NULL,
  `amount` decimal(20,2) NOT NULL DEFAULT '0.00',
  `units` varchar(50) NOT NULL DEFAULT '0',
  `computation` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_assessment: ~0 rows (approximately)

-- Dumping structure for table model_test_db.student_course
CREATE TABLE IF NOT EXISTS `student_course` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `course` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `campus` varchar(50) DEFAULT NULL,
  `curriculum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `year_level` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `section` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `semester` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_number` (`id_number`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_course: ~7 rows (approximately)
INSERT INTO `student_course` (`id`, `id_number`, `course`, `campus`, `curriculum`, `year_level`, `section`, `semester`) VALUES
	(58, '2023-1-0001', 'BSIT', 'ISAP', 'BSIT-2019-2020', '1', 'BSIT-1-B', '1'),
	(59, '2023-1-0002', 'BSIT', 'ISAP', 'BSIT-2019-2020', '1', 'BSIT-1-B', '1'),
	(60, '2023-1-0003', 'BSCA', 'ISAP', 'BSCA-2021-2022', '1', 'BSCA-1-A', '1'),
	(61, '2023-1-0011', 'BSCA', 'ISAP', 'BSCA-2021-2022', '2', 'BSCA-2-A', '2'),
	(62, '2023-1-0012', NULL, NULL, NULL, NULL, NULL, NULL),
	(63, '2023-1-0013', 'BSCA', 'ISAP', 'BSCA-2021-2022', '1', 'BSCA-1-A', '2'),
	(64, '2023-1-0004', 'BSCA', 'ISAP', 'BSCA-2021-2022', '1', 'BSCA-1-A', '1');

-- Dumping structure for table model_test_db.student_discounts
CREATE TABLE IF NOT EXISTS `student_discounts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `discount_percentage` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_discounts: ~0 rows (approximately)
INSERT INTO `student_discounts` (`id`, `id_number`, `code`, `description`, `discount_percentage`) VALUES
	(11, '2023-1-0001', 'Discount3', 'Discount Number 3', 75),
	(12, '2023-1-0002', 'Discount2', 'Discount Number 2', 50);

-- Dumping structure for table model_test_db.student_documents
CREATE TABLE IF NOT EXISTS `student_documents` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `student_id` varchar(50) NOT NULL,
  `document_type` varchar(50) NOT NULL,
  `location` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_documents: ~0 rows (approximately)

-- Dumping structure for table model_test_db.student_subjects
CREATE TABLE IF NOT EXISTS `student_subjects` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `unique_id` varchar(50) NOT NULL DEFAULT '0',
  `school_year` varchar(50) NOT NULL DEFAULT '0',
  `subject_code` varchar(50) NOT NULL,
  `descriptive_title` varchar(50) NOT NULL,
  `pre_requisite` varchar(50) NOT NULL,
  `total_units` varchar(50) NOT NULL,
  `lecture_units` varchar(50) NOT NULL,
  `lab_units` varchar(50) NOT NULL,
  `time` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `day` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `room` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `instructor` varchar(50) DEFAULT NULL,
  `grade` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `remarks` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=288 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_subjects: ~27 rows (approximately)
INSERT INTO `student_subjects` (`id`, `id_number`, `unique_id`, `school_year`, `subject_code`, `descriptive_title`, `pre_requisite`, `total_units`, `lecture_units`, `lab_units`, `time`, `day`, `room`, `instructor`, `grade`, `remarks`) VALUES
	(261, '2023-1-0001', '2023-1-0001-2023-1-CC 101', '2023-2024-1', 'CC 101', 'INTRODUCTION TO COMPUTING', 'NONE', '5.0', '2.0', '3.0', '7:00-8:00AM Lec 10-12AM Lab', 'MWF Lec TTH Lab', 'NAB-101 Lec, CL-A Lec', 'Manglallan, Derrick D.', NULL, NULL),
	(262, '2023-1-0001', '2023-1-0001-2023-1-CC 102', '2023-2024-1', 'CC 102', 'COMPUTER PROGRAMMING 1', 'NONE', '5.0', '2.0', '3.0', '7-10 lec, 10-12', 'MWF lec, TTH Lab', 'NAB 102', '', NULL, NULL),
	(263, '2023-1-0001', '2023-1-0001-2023-1-MATH 11', '2023-2024-1', 'MATH 11', 'MATHEMATICS IN THE MODERN WORLD', 'NONE', '3.0', '3.0', '0.0', '10-12', 'TTH', 'NAB-201', '', NULL, NULL),
	(264, '2023-1-0001', '2023-1-0001-2023-1-SOC SCI 11', '2023-2024-1', 'SOC SCI 11', 'UNDERSTANDING THE SELF', 'NONE', '3.0', '3.0', '0.0', '7-10', 'MWF', 'NAB-202', '', NULL, NULL),
	(265, '2023-1-0001', '2023-1-0001-2023-1-ENG 11', '2023-2024-1', 'ENG 11', 'PURPOSIVE COMMUNICATION', 'NONE', '3.0', '3.0', '0.0', '3-5', 'MWF', 'C-101', '', NULL, NULL),
	(266, '2023-1-0001', '2023-1-0001-2023-1-FIL 11', '2023-2024-1', 'FIL 11', 'Kontekswalisadong Komunikasyon sa Filipino ', 'NONE', '3.0', '3.0', '0.0', '5-6', 'TTH', 'C-102', '', NULL, NULL),
	(267, '2023-1-0001', '2023-1-0001-2023-1-SOC SCI 13', '2023-2024-1', 'SOC SCI 13', 'READINGS IN PHILIPPINE HISTORY', 'NONE', '3.0', '3.0', '0.0', '8-9', 'MWF', 'C-103', '', NULL, NULL),
	(268, '2023-1-0001', '2023-1-0001-2023-1-PE 11', '2023-2024-1', 'PE 11', 'MOVEMENT ENHANCEMENT', 'NONE', '3.0', '3.0', '0.0', '7-8', 'S', 'C201', '', NULL, NULL),
	(269, '2023-1-0001', '2023-1-0001-2023-1-NSTP 11', '2023-2024-1', 'NSTP 11', 'CIVIC WELFARE TRAINING SERVICE 1', 'NONE', '3.0', '3.0', '0.0', '12-1', 'MWF', 'C203', '', NULL, NULL),
	(270, '2023-1-0001', '2023-1-0001-2023-1-NSTP 12', '2023-2024-1', 'NSTP 12', 'RESERVED OFFICERS TRAINING CORPS', 'NONE', '3.0', '3.0', '0.0', '2-3', 'TTH', 'GYMNASIUM', '', NULL, NULL),
	(271, '2023-1-0013', '2023-1-0013-2023-2-GEC 6', '2023-2024-1', 'GEC 6', 'Art Apreciation', 'None', '3.0', '3.0', '0.0', '8:30', 'TTH', '1', '', NULL, NULL),
	(272, '2023-1-0013', '2023-1-0013-2023-2-GEC 7', '2023-2024-1', 'GEC 7', 'Science, Technology and Society', 'None', '3.0', '3.0', '0.0', 'SA', 'SA', 'SA', '', NULL, NULL),
	(273, '2023-1-0013', '2023-1-0013-2023-2-SCM 101', '2023-2024-1', 'SCM 101', 'Introduction to Supply Chain Management', 'SBEC 100', '3.0', '3.0', '0.0', '12', '22', '2', '', NULL, NULL),
	(274, '2023-1-0013', '2023-1-0013-2023-2-CM 101', '2023-2024-1', 'CM 101', 'Border Control and Security', 'SBEC 100', '3.0', '3.0', '0.0', '1', '1', '1', 'Manglallan, Derrick D.', NULL, NULL),
	(275, '2023-1-0013', '2023-1-0013-2023-2-TM 101', '2023-2024-1', 'TM 101', 'Fundamentals of Customs and Tariff Management', 'SBEC 100', '3.0', '3.0', '0.0', '1', '1', '1', '', NULL, NULL),
	(276, '2023-1-0013', '2023-1-0013-2023-2-GEC 8', '2023-2024-1', 'GEC 8', 'Ethics', 'None', '3.0', '3.0', '0.0', '1', '1', '1', '', NULL, NULL),
	(277, '2023-1-0013', '2023-1-0013-2023-2-ECON 101', '2023-2024-1', 'ECON 101', 'International Economics', 'SBEC 100', '3.0', '3.0', '0.0', '1', '11', '1', 'Pingad, Airon Jim', NULL, NULL),
	(278, '2023-1-0004', '2023-1-0004-2023-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', NULL, NULL),
	(279, '2023-1-0004', '2023-1-0004-2023-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', NULL, NULL),
	(280, '2023-1-0004', '2023-1-0004-2023-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', NULL, NULL),
	(281, '2023-1-0004', '2023-1-0004-2023-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', NULL, NULL),
	(282, '2023-1-0004', '2023-1-0004-2023-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', NULL, NULL),
	(283, '2023-1-0004', '2023-1-0004-2023-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', NULL, NULL),
	(284, '2023-1-0004', '2023-1-0004-2023-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', NULL, NULL),
	(285, '2023-1-0004', '2023-1-0004-2023-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', NULL, NULL),
	(286, '2023-1-0004', '2023-1-0004-2023-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', NULL, NULL),
	(287, '2023-1-0004', '2023-1-0004-2023-1-GEC 1', '2023-2024-1', 'GEC 1', 'UNDERSTANDING THE SELF', 'NONE', '3.0', '3.0', '0.0', '09:00 AM - 10:30 AM', 'TTH', 'NAB-102', '', NULL, NULL);

-- Dumping structure for table model_test_db.subjects
CREATE TABLE IF NOT EXISTS `subjects` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `semester` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `descriptive_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `total_units` varchar(50) NOT NULL,
  `lecture_units` varchar(50) NOT NULL,
  `lab_units` varchar(50) NOT NULL,
  `pre_requisite` varchar(50) NOT NULL,
  `total_hrs_per_week` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.subjects: ~13 rows (approximately)
INSERT INTO `subjects` (`id`, `semester`, `code`, `descriptive_title`, `total_units`, `lecture_units`, `lab_units`, `pre_requisite`, `total_hrs_per_week`, `status`) VALUES
	(7, '1', 'CC 101', 'INTRODUCTION TO COMPUTING', '5', '2', '3', 'NONE', '3', 'Active'),
	(8, '1', 'CC 102', 'COMPUTER PROGRAMMING 1', '5', '2', '3', 'NONE', '3', 'Active'),
	(9, '1', 'MATH 11', 'MATHEMATICS IN THE MODERN WORLD', '3', '3', '0', 'NONE', '3', ''),
	(10, '1', 'SOC SCI 11', 'UNDERSTANDING THE SELF', '3', '3', '0', 'NONE', '3', 'Active'),
	(11, '1', 'ENG 11', 'PURPOSIVE COMMUNICATION', '3', '3', '0', 'NONE', '3', ''),
	(12, '1', 'FIL 11', 'Kontekswalisadong Komunikasyon sa Filipino ', '3', '3', '0', 'NONE', '3', ''),
	(13, '1', 'SOC SCI 13', 'READINGS IN PHILIPPINE HISTORY', '3', '3', '0', 'NONE', '3', ''),
	(14, '1', 'PE 11', 'MOVEMENT ENHANCEMENT', '3', '3', '0', 'NONE', '3', ''),
	(15, '1', 'NSTP 11', 'CIVIC WELFARE TRAINING SERVICE 1', '3', '3', '0', 'NONE', '3', 'Active'),
	(17, '1', 'NSTP 12', 'RESERVED OFFICERS TRAINING CORPS', '3', '3', '0', 'NONE', '3', 'Active'),
	(18, '2', 'CC 103', 'INTRODUCTION TO COMPUTER INTERACTION', '3', '3', '0', 'CC 101', '3', 'Active'),
	(19, '2', 'CC 104', 'COMPUTER PROGRAMMING 2', '5', '2', '3', 'CC 102', '3', 'Active'),
	(20, '2', 'CC 105', 'FUNDAMENTALS OF DATABASE SYSTEMS', '5', '2', '3', 'CC 101', '3', 'Active');

-- Dumping structure for table model_test_db.tuition_fee_setup
CREATE TABLE IF NOT EXISTS `tuition_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `second_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `third_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `fourth_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.tuition_fee_setup: ~2 rows (approximately)
INSERT INTO `tuition_fee_setup` (`id`, `category`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(5, 'Tuition Fee/Unit', 'MCNP', 265.15, 345.75, 401.32, 500.25),
	(6, 'Tuition Fee/Unit', 'ISAP', 265.15, 345.75, 401.32, 500.25);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
