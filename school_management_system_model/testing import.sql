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

-- Dumping structure for table model_test_db.access_level
CREATE TABLE IF NOT EXISTS `access_level` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `access_level` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `office` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.access_level: ~1 rows (approximately)
INSERT INTO `access_level` (`id`, `access_level`, `office`) VALUES
	(1, 'Administrator', '');

-- Dumping structure for table model_test_db.activity_logger
CREATE TABLE IF NOT EXISTS `activity_logger` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `access_level` varchar(100) NOT NULL,
  `activity` varchar(100) NOT NULL,
  `date` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.activity_logger: ~0 rows (approximately)

-- Dumping structure for table model_test_db.admission_schedule
CREATE TABLE IF NOT EXISTS `admission_schedule` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `schedule_from` varchar(50) NOT NULL,
  `schedule_to` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.admission_schedule: ~2 rows (approximately)
INSERT INTO `admission_schedule` (`id`, `code`, `description`, `schedule_from`, `schedule_to`) VALUES
	(1, 'Enrollment', 'Enrollment schedule for school year 2023-2024, 1st semester', '2024-01-07', '2024-01-31'),
	(3, 'Adding and Dropping', 'Schedule for adding and dropping of students', '2024-01-12', '2024-01-19');

-- Dumping structure for table model_test_db.assessment_breakdown
CREATE TABLE IF NOT EXISTS `assessment_breakdown` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `school_year` varchar(50) NOT NULL,
  `fee_type` varchar(50) NOT NULL,
  `amount` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.assessment_breakdown: ~5 rows (approximately)
INSERT INTO `assessment_breakdown` (`id`, `id_number`, `school_year`, `fee_type`, `amount`) VALUES
	(6, '2024-1-0003', '2023-2024-1', 'TUITION FEE/UNIT', 0.00),
	(7, '2024-1-0003', '2023-2024-1', 'PE UNIFORM', 387.87),
	(8, '2024-1-0003', '2023-2024-1', 'INTERNET FEE', 500.12),
	(9, '2024-1-0003', '2023-2024-1', 'Student Information and Accounting Systems', 652.15),
	(10, '2024-1-0003', '2023-2024-1', 'Learning Management System', 652.15);

-- Dumping structure for table model_test_db.authentication_logger
CREATE TABLE IF NOT EXISTS `authentication_logger` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `access_level` varchar(100) NOT NULL,
  `date` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.authentication_logger: ~29 rows (approximately)
INSERT INTO `authentication_logger` (`id`, `name`, `access_level`, `date`, `time`) VALUES
	(1, 'Manglallan, Derrick Daniel', 'Administrator', '01-08-2024', '08:35:02 am'),
	(2, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:28:40 am'),
	(3, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:30:41 am'),
	(4, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:32:31 am'),
	(5, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:37:39 am'),
	(6, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:38:32 am'),
	(7, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:50:25 AM'),
	(8, 'Alan, Charity T', 'Cashier', '01-08-2024', '09:51:11 AM'),
	(9, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:04:38 AM'),
	(10, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:06:13 AM'),
	(11, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:19:44 AM'),
	(12, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:22:04 AM'),
	(13, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:23:44 AM'),
	(14, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:28:28 AM'),
	(15, 'Alan, Charity T', 'Cashier', '01-08-2024', '10:30:23 AM'),
	(16, 'Manglallan, Derrick Daniel', 'Administrator', '01-08-2024', '01:01:02 PM'),
	(17, 'Alan, Charity T', 'Cashier', '01-08-2024', '01:08:12 PM'),
	(18, 'Alan, Charity T', 'Cashier', '01-08-2024', '01:10:35 PM'),
	(19, 'Alan, Charity T', 'Cashier', '01-08-2024', '01:12:27 PM'),
	(20, 'Alan, Charity T', 'Cashier', '01-08-2024', '01:16:51 PM'),
	(21, 'Manglallan, Derrick Daniel', 'Administrator', '01-08-2024', '01:21:11 PM'),
	(22, 'Alan, Charity T', 'Cashier', '01-08-2024', '01:24:08 PM'),
	(23, 'Alan, Charity T', 'Cashier', '01-08-2024', '01:26:04 PM'),
	(24, 'Manglallan, Derrick Daniel', 'Administrator', '01-08-2024', '01:52:36 PM'),
	(25, 'Manglallan, Derrick Daniel', 'Administrator', '01-08-2024', '01:55:21 PM'),
	(26, 'Alan, Charity T', 'Cashier', '01-08-2024', '02:04:33 PM'),
	(27, 'Alan, Charity T', 'Cashier', '01-08-2024', '02:12:02 PM'),
	(28, 'Alan, Charity T', 'Cashier', '01-08-2024', '02:44:57 PM'),
	(29, 'Alan, Charity T', 'Cashier', '01-08-2024', '04:14:01 PM');

-- Dumping structure for table model_test_db.campuses
CREATE TABLE IF NOT EXISTS `campuses` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.campuses: ~2 rows (approximately)
INSERT INTO `campuses` (`id`, `code`, `description`, `address`, `status`) VALUES
	(6, 'MCNP', 'MEDICAL COLLEGES OF NORTHERN PHILIPPINES', '', 'Active'),
	(7, 'ISAP', 'INTERNATIONAL SCHOOL OF ASIA AND THE PACIFIC', '', 'Active');

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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.courses: ~1 rows (approximately)
INSERT INTO `courses` (`id`, `code`, `description`, `level`, `campus`, `department`, `max_units`, `status`) VALUES
	(7, 'BSCA', 'BSCA', 'COL', 'ISAP', 'CBEM', '30', 'Active');

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

-- Dumping data for table model_test_db.course_fees: ~0 rows (approximately)

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.curriculums: ~1 rows (approximately)
INSERT INTO `curriculums` (`id`, `code`, `description`, `campus`, `course`, `effective`, `expires`, `status`) VALUES
	(6, 'BSCA 2021-2022', 'BACHELOR OF SCIENCE IN CUSTOMS ADMINISTRATION', 'ISAP', 'BSCA', '06-12-2023', '05-12-2023', 'Active');

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
) ENGINE=InnoDB AUTO_INCREMENT=301 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.curriculum_subjects: ~60 rows (approximately)
INSERT INTO `curriculum_subjects` (`id`, `curriculumIdCode`, `curriculum`, `year_level`, `semester`, `code`, `descriptive_title`, `total_units`, `lecture_units`, `lab_units`, `pre_requisite`, `total_hrs_per_week`) VALUES
	(241, 'BSCA 2021-2022GEC 1', 'BSCA 2021-2022', '1', '1', 'GEC 1', 'Understanding the Self', '3', '3', '0', 'None', '3'),
	(242, 'BSCA 2021-2022GEC 2', 'BSCA 2021-2022', '1', '1', 'GEC 2', 'Readings in the Philippine History', '3', '3', '0', 'None', '3'),
	(243, 'BSCA 2021-2022GEC 3', 'BSCA 2021-2022', '1', '1', 'GEC 3', 'The Contemporary World', '3', '3', '0', 'None', '3'),
	(244, 'BSCA 2021-2022GEC 4', 'BSCA 2021-2022', '1', '1', 'GEC 4', 'Mathematics in the Modern World', '3', '3', '0', 'None', '3'),
	(245, 'BSCA 2021-2022SBEC 100', 'BSCA 2021-2022', '1', '1', 'SBEC 100', 'International Trade', '3', '3', '0', 'None', '3'),
	(246, 'BSCA 2021-2022GEC 5', 'BSCA 2021-2022', '1', '1', 'GEC 5', 'Purposive Communication', '3', '3', '0', 'None', '3'),
	(247, 'BSCA 2021-2022PE 101', 'BSCA 2021-2022', '1', '1', 'PE 101', 'Physical Education 1 (Physical Fitness)', '2', '2', '0', 'None', '2'),
	(248, 'BSCA 2021-2022NSTP 1', 'BSCA 2021-2022', '1', '1', 'NSTP 1', 'National Service Training Program 1', '3', '3', '0', 'None', '3'),
	(249, 'BSCA 2021-2022ETHICS 100', 'BSCA 2021-2022', '1', '1', 'ETHICS 100', 'ISAPian Education with Values Formation', '1.5', '1.5', '0', 'None', '1.5'),
	(250, 'BSCA 2021-2022MSCED 201', 'BSCA 2021-2022', '1', '1', 'MSCED 201', 'Advisorship Time', '0', '1', '0', 'None', '1'),
	(251, 'BSCA 2021-2022GEC 6', 'BSCA 2021-2022', '1', '2', 'GEC 6', 'Art Apreciation', '3', '3', '0', 'None', '3'),
	(252, 'BSCA 2021-2022GEC 7', 'BSCA 2021-2022', '1', '2', 'GEC 7', 'Science, Technology and Society', '3', '3', '0', 'None', '3'),
	(253, 'BSCA 2021-2022SCM 101', 'BSCA 2021-2022', '1', '2', 'SCM 101', 'Introduction to Supply Chain Management', '3', '3', '0', 'SBEC 100', '3'),
	(254, 'BSCA 2021-2022CM 101', 'BSCA 2021-2022', '1', '2', 'CM 101', 'Border Control and Security', '3', '3', '0', 'SBEC 100', '3'),
	(255, 'BSCA 2021-2022TM 101', 'BSCA 2021-2022', '1', '2', 'TM 101', 'Fundamentals of Customs and Tariff Management', '3', '3', '0', 'SBEC 100', '3'),
	(256, 'BSCA 2021-2022GEC 8', 'BSCA 2021-2022', '1', '2', 'GEC 8', 'Ethics', '3', '3', '0', 'None', '3'),
	(257, 'BSCA 2021-2022ECON 101', 'BSCA 2021-2022', '1', '2', 'ECON 101', 'International Economics', '3', '3', '0', 'SBEC 100', '3'),
	(258, 'BSCA 2021-2022PE 102', 'BSCA 2021-2022', '1', '2', 'PE 102', 'Physical Education 2 (Gymnastics)', '2', '2', '0', 'PE 1', '2'),
	(259, 'BSCA 2021-2022NSTP 2', 'BSCA 2021-2022', '1', '2', 'NSTP 2', 'National Service Training Program 2', '3', '3', '0', 'NSTP 1', '3'),
	(260, 'BSCA 2021-2022MSCED 202', 'BSCA 2021-2022', '1', '2', 'MSCED 202', 'Advisorship Time', '0', '1', '0', 'MSCED 201', '1'),
	(261, 'BSCA 2021-2022GEC 9', 'BSCA 2021-2022', '2', '1', 'GEC 9', 'Rizal\'s Life and Works', '3', '3', '0', 'None', '3'),
	(262, 'BSCA 2021-2022LIT 101', 'BSCA 2021-2022', '2', '1', 'LIT 101', 'Panitikang Pilipino ', '3', '3', '0', 'None', '3'),
	(263, 'BSCA 2021-2022SBEC 101', 'BSCA 2021-2022', '2', '1', 'SBEC 101', 'Income and Business Taxation', '3', '3', '0', 'SBEC 100', '3'),
	(264, 'BSCA 2021-2022SCM102', 'BSCA 2021-2022', '2', '1', 'SCM102', 'Warehoues Operations Management', '3', '3', '0', 'SCM 100', '3'),
	(265, 'BSCA 2021-2022SBEC 102', 'BSCA 2021-2022', '2', '1', 'SBEC 102', 'Business Law', '3', '3', '0', 'SBEC 100', '3'),
	(266, 'BSCA 2021-2022CM 102', 'BSCA 2021-2022', '2', '1', 'CM 102', 'Customs Operations and Cargo Handling with Educ. Tour', '3', '3', '0', 'CM 101', '3'),
	(267, 'BSCA 2021-2022CM 103', 'BSCA 2021-2022', '2', '1', 'CM 103', 'Customs Warehousing', '5', '5', '0', 'CM 101', '5'),
	(268, 'BSCA 2021-2022TM 102', 'BSCA 2021-2022', '2', '1', 'TM 102', 'Commodity Classification System', '3', '3', '0', 'TM 101', '3'),
	(269, 'BSCA 2021-2022PE 103', 'BSCA 2021-2022', '2', '1', 'PE 103', 'Physical Education  3 (Swimming)', '2', '2', '0', 'PE 102', '2'),
	(270, 'BSCA 2021-2022MSCED 203', 'BSCA 2021-2022', '2', '1', 'MSCED 203', 'Advisorship Time', '0', '1', '0', 'MSCED 202', '1'),
	(271, 'BSCA 2021-2022GEE 101', 'BSCA 2021-2022', '2', '2', 'GEE 101', 'Philippine Popular Culture', '3', '3', '0', 'None', '3'),
	(272, 'BSCA 2021-2022CBMEC 101', 'BSCA 2021-2022', '2', '2', 'CBMEC 101', 'Strategic Management', '3', '3', '0', 'None', '3'),
	(273, 'BSCA 2021-2022EC 101', 'BSCA 2021-2022', '2', '2', 'EC 101', 'International Marketing', '3', '3', '0', 'ECON 101', '3'),
	(274, 'BSCA 2021-2022EC 102', 'BSCA 2021-2022', '2', '2', 'EC 102', 'Enterpreneurial Management', '3', '3', '0', 'ECON 101', '3'),
	(275, 'BSCA 2021-2022SCM 103', 'BSCA 2021-2022', '2', '2', 'SCM 103', 'Procurement and Inventory Management', '3', '3', '0', 'SCM 102', '3'),
	(276, 'BSCA 2021-2022CM 104', 'BSCA 2021-2022', '2', '2', 'CM 104', 'Customs Proceedings', '5', '3', '0', 'CM 103', '3'),
	(277, 'BSCA 2021-2022TM 103', 'BSCA 2021-2022', '2', '2', 'TM 103', 'Customs Valuation System', '5', '5', '0', 'TM 102', '5'),
	(278, 'BSCA 2021-2022PE 104', 'BSCA 2021-2022', '2', '2', 'PE 104', 'Physical Education 4 (Team Sports)', '2', '2', '0', 'PE 103', '2'),
	(279, 'BSCA 2021-2022MSCED 204', 'BSCA 2021-2022', '2', '2', 'MSCED 204', 'Advisorship Time', '0', '1', '0', 'MSCED 203', '1'),
	(280, 'BSCA 2021-2022FL 102', 'BSCA 2021-2022', '3', '1', 'FL 102', 'Foreign Language 2', '2', '2', '0', 'FL 101', '2'),
	(281, 'BSCA 2021-2022FIL 102', 'BSCA 2021-2022', '3', '1', 'FIL 102', 'Kontekstwalissadong Filipino', '3', '3', '0', 'FIL 101', '3'),
	(282, 'BSCA 2021-2022LIT 102', 'BSCA 2021-2022', '3', '1', 'LIT 102', 'Philippine Literature', '3', '3', '0', 'LIT 101', '3'),
	(283, 'BSCA 2021-2022LED 1', 'BSCA 2021-2022', '3', '1', 'LED 1', 'Labor Education', '3', '3', '0', 'None', '3'),
	(284, 'BSCA 2021-2022GEE 103', 'BSCA 2021-2022', '3', '1', 'GEE 103', 'Philippine Indigenous Communities', '3', '3', '0', 'GEE 102', '3'),
	(285, 'BSCA 2021-2022CM 106', 'BSCA 2021-2022', '3', '1', 'CM 106', 'Customs Post Clearance Audit and Fraud Detection', '5', '5', '0', 'CM 105', '5'),
	(286, 'BSCA 2021-2022TM 105', 'BSCA 2021-2022', '3', '1', 'TM 105', 'Excise Taxes, Liquidation of Duty and Surcharges', '5', '5', '0', 'TM 104', '5'),
	(287, 'BSCA 2021-2022CA RES 102', 'BSCA 2021-2022', '3', '1', 'CA RES 102', 'Customs Research 2', '3', '3', '0', 'CA RES 101', '3'),
	(288, 'BSCA 2021-2022MSCED 206', 'BSCA 2021-2022', '3', '1', 'MSCED 206', 'Advisorship Time', '0', '1', '0', 'MSCED 205', '1'),
	(289, 'BSCA 2021-2022FIL 103', 'BSCA 2021-2022', '3', '3', 'FIL 103', 'Malayuning Komunikasyon', '3', '3', '0', 'FIL 102', '9'),
	(290, 'BSCA 2021-2022CM 107', 'BSCA 2021-2022', '3', '3', 'CM 107', 'Ethics and Standards of Custom Broker', '3', '3', '0', 'CM 106', '9'),
	(291, 'BSCA 2021-2022TM 106', 'BSCA 2021-2022', '3', '3', 'TM 106', 'Special Duties and Trade Remedies', '3', '3', '0', 'TM 105', '9'),
	(292, 'BSCA 2021-2022CA 101', 'BSCA 2021-2022', '4', '1', 'CA 101', 'Integration Review for Cutoms Laws', '1.5', '1.5', '0', '4th Year Standing', '1.5 (3)'),
	(293, 'BSCA 2021-2022CA 102', 'BSCA 2021-2022', '4', '1', 'CA 102', 'IntegrationReview for Tariff Management', '1.5', '1.5', '0', '4th Year Standing', '1.5 (3)'),
	(294, 'BSCA 2021-2022TM 107', 'BSCA 2021-2022', '4', '1', 'TM 107', 'International Trade Organizations, Agreements and Rules of Origin', '5', '5', '0', 'TM 106', '5'),
	(295, 'BSCA 2021-2022CBMEC 102', 'BSCA 2021-2022', '4', '1', 'CBMEC 102', 'Operations Management', '3', '3', '0', 'CBMEC 101', '3'),
	(296, 'BSCA 2021-2022MSCED 207', 'BSCA 2021-2022', '4', '1', 'MSCED 207', 'Advisorship Time', '0', '1', '0', 'MSCED 206', '1'),
	(297, 'BSCA 2021-2022CM 108', 'BSCA 2021-2022', '4', '2', 'CM 108', 'Competency Assessment in Customs Management', '5', '5', '0', '4th Year Standing', '5'),
	(298, 'BSCA 2021-2022TM 108', 'BSCA 2021-2022', '4', '2', 'TM 108', 'Competency Assessment in Tariff Management', '5', '5', '0', '4th Year Standing', '5'),
	(299, 'BSCA 2021-2022CA OCL', 'BSCA 2021-2022', '4', '2', 'CA OCL', 'Off-Campus Learning, Customs Brokerage Industry (200 hrs), Freight Forwarding/Logistics/Shipping  or Airline Companies, Govenrment Agencies(200hrs)', '3', '', 'Field', '4th Year Standing', '24'),
	(300, 'BSCA 2021-2022MSCED 208', 'BSCA 2021-2022', '4', '2', 'MSCED 208', 'Advisorship Time', '0', '1', '1', 'MS CED 207', '1');

-- Dumping structure for table model_test_db.departments
CREATE TABLE IF NOT EXISTS `departments` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `campus` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.departments: ~1 rows (approximately)
INSERT INTO `departments` (`id`, `code`, `description`, `campus`) VALUES
	(8, 'CBEM', 'CBEM', 'ISAP');

-- Dumping structure for table model_test_db.discount_setup
CREATE TABLE IF NOT EXISTS `discount_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `discount_target` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `discount_percentage` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.discount_setup: ~2 rows (approximately)
INSERT INTO `discount_setup` (`id`, `code`, `discount_target`, `description`, `discount_percentage`) VALUES
	(4, 'Dean-Lister-25%', 'Tuition Fee', 'Dean Lister Discount', 25),
	(5, 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75);

-- Dumping structure for table model_test_db.fee_breakdown
CREATE TABLE IF NOT EXISTS `fee_breakdown` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(100) DEFAULT NULL,
  `school_year` varchar(100) DEFAULT NULL,
  `downpayment` decimal(20,2) DEFAULT NULL,
  `prelim` decimal(20,2) DEFAULT NULL,
  `midterm` decimal(20,2) DEFAULT NULL,
  `semi_finals` decimal(20,2) DEFAULT NULL,
  `finals` decimal(20,2) DEFAULT NULL,
  `total` decimal(20,2) DEFAULT NULL,
  `downpayment_original` decimal(20,2) DEFAULT NULL,
  `prelim_original` decimal(20,2) DEFAULT NULL,
  `midterm_original` decimal(20,2) DEFAULT NULL,
  `semi_finals_original` decimal(20,2) DEFAULT NULL,
  `finals_original` decimal(20,2) DEFAULT NULL,
  `total_original` decimal(20,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.fee_breakdown: ~2 rows (approximately)
INSERT INTO `fee_breakdown` (`id`, `id_number`, `school_year`, `downpayment`, `prelim`, `midterm`, `semi_finals`, `finals`, `total`, `downpayment_original`, `prelim_original`, `midterm_original`, `semi_finals_original`, `finals_original`, `total_original`) VALUES
	(10, '2023-1-0001', '2023-2024-1', 0.00, 421.82, 460.91, 460.91, 460.91, 1804.55, 780.30, 780.30, 780.30, 780.30, 780.30, 3901.48),
	(11, '2023-1-0002', '2023-2024-1', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 460.91, 460.91, 460.91, 460.91, 460.91, 2304.54),
	(13, '2024-1-0003', '2023-2024-1', 0.00, 0.00, 0.00, 453.84, 1738.46, 2192.30, 1738.46, 1738.46, 1738.46, 1738.46, 1738.46, 8692.29);

-- Dumping structure for table model_test_db.fee_summary
CREATE TABLE IF NOT EXISTS `fee_summary` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL DEFAULT '0',
  `school_year` varchar(50) NOT NULL DEFAULT '0',
  `current_assessment` decimal(20,2) unsigned NOT NULL DEFAULT '0.00',
  `discounts` decimal(20,2) unsigned NOT NULL DEFAULT '0.00',
  `previous_balance` decimal(20,2) unsigned NOT NULL DEFAULT '0.00',
  `current_receivable` decimal(20,2) unsigned NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.fee_summary: ~2 rows (approximately)
INSERT INTO `fee_summary` (`id`, `id_number`, `school_year`, `current_assessment`, `discounts`, `previous_balance`, `current_receivable`) VALUES
	(2, '2023-1-0001', '2023-2024-1', 8692.29, 4790.81, 0.00, 3901.48),
	(5, '2023-1-0002', '2023-2024-1', 8692.29, 6387.75, 0.00, 2304.54),
	(7, '2024-1-0003', '2023-2024-1', 8692.29, 0.00, 0.00, 8692.29);

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

-- Dumping data for table model_test_db.instructors: ~0 rows (approximately)

-- Dumping structure for table model_test_db.lab_fee_setup
CREATE TABLE IF NOT EXISTS `lab_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` varchar(50) NOT NULL,
  `second_year` varchar(50) NOT NULL,
  `third_year` varchar(50) NOT NULL,
  `fourth_year` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.lab_fee_setup: ~4 rows (approximately)
INSERT INTO `lab_fee_setup` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(5, 'Laboratory Fee', 'CHEMISTRY LAB', 'MCNP', '450.25', '450.25', '450.25', '450.25'),
	(6, 'Laboratory Fee', 'PHYSICS LAB', 'MCNP', '450.25', '450.25', '450.25', '450.25'),
	(7, 'Laboratory Fee', 'PHYSICAL THERAPY LAB', 'MCNP', '205.50', '205.50', '205.50', '205.50'),
	(8, 'Laboratory Fee', 'RAD TECH LAB', 'MCNP', '125.25', '125.25', '125.25', '125.25');

-- Dumping structure for table model_test_db.lab_fee_subjects
CREATE TABLE IF NOT EXISTS `lab_fee_subjects` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `lab_fee_id` int NOT NULL DEFAULT '0',
  `subject_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `descriptive_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`id`),
  UNIQUE KEY `subject_code` (`subject_code`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.lab_fee_subjects: ~1 rows (approximately)
INSERT INTO `lab_fee_subjects` (`id`, `lab_fee_id`, `subject_code`, `descriptive_title`) VALUES
	(2, 6, 'GEC 7', 'Science, Technology and Society');

-- Dumping structure for table model_test_db.levels
CREATE TABLE IF NOT EXISTS `levels` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.levels: ~1 rows (approximately)
INSERT INTO `levels` (`id`, `code`, `description`, `status`) VALUES
	(7, 'COL', 'COLLEGE', 'Active');

-- Dumping structure for table model_test_db.miscellaneous_fee_setup
CREATE TABLE IF NOT EXISTS `miscellaneous_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `description` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  `second_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  `third_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  `fourth_year` decimal(20,3) NOT NULL DEFAULT '0.000',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.miscellaneous_fee_setup: ~4 rows (approximately)
INSERT INTO `miscellaneous_fee_setup` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(20, 'Miscellaneous Fee', 'PE UNIFORM', 'MCNP', 450.500, 450.500, 450.500, 450.500),
	(21, 'Miscellaneous Fee', 'Internet Fee', 'MCNP', 500.120, 500.120, 500.120, 500.120),
	(22, 'Miscellaneous Fee', 'PE UNIFORM', 'ISAP', 500.120, 500.120, 500.120, 500.120),
	(23, 'Miscellaneous Fee', 'INTERNET FEE', 'ISAP', 500.120, 500.120, 500.120, 500.120);

-- Dumping structure for table model_test_db.other_fees
CREATE TABLE IF NOT EXISTS `other_fees` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `campus` varchar(100) NOT NULL,
  `first_year` varchar(100) NOT NULL,
  `second_year` varchar(100) NOT NULL,
  `third_year` varchar(100) NOT NULL,
  `fourth_year` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.other_fees: ~2 rows (approximately)
INSERT INTO `other_fees` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(1, 'Other Fees', 'Student Information and Accounting Systems', 'ISAP', '652.15', '652.15', '652.15', '652.15'),
	(2, 'Other Fees', 'Learning Management System', 'ISAP', '652.15', '652.15', '652.15', '652.15');

-- Dumping structure for table model_test_db.reference_number_setup
CREATE TABLE IF NOT EXISTS `reference_number_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `reference_number` int unsigned DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.reference_number_setup: ~1 rows (approximately)
INSERT INTO `reference_number_setup` (`id`, `reference_number`) VALUES
	(1, 1000313);

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.school_year: ~1 rows (approximately)
INSERT INTO `school_year` (`id`, `code`, `description`, `school_year_from`, `school_year_to`, `semester`, `is_current`) VALUES
	(9, '2023-2024-1', 'SY 2023-2024, 1ST Semester', '12-06-2023', '12-13-2023', '1', 'Yes');

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
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.sections: ~8 rows (approximately)
INSERT INTO `sections` (`id`, `unique_id`, `section_code`, `course`, `year_level`, `section`, `semester`, `number_of_students`, `max_number_of_students`, `status`, `remarks`) VALUES
	(33, 'BSCA-1-ABSCA11', 'BSCA-1-A', 'BSCA', '1', 'A', '1', 18, 50, 'Available', 'Regular'),
	(34, 'BSCA-2-ABSCA21', 'BSCA-2-A', 'BSCA', '2', 'A', '1', 3, 50, 'Available', 'Regular'),
	(35, 'BSCA-1-ABSCA12', 'BSCA-1-A', 'BSCA', '1', 'A', '2', 2, 50, 'Available', 'Regular'),
	(36, 'BSCA-2-ABSCA22', 'BSCA-2-A', 'BSCA', '2', 'A', '2', 0, 50, 'Available', 'Regular'),
	(37, 'BSCA-3-ABSCA31', 'BSCA-3-A', 'BSCA', '3', 'A', '1', 0, 50, 'Available', 'Regular'),
	(38, 'BSCA-3-ABSCA32', 'BSCA-3-A', 'BSCA', '3', 'A', '2', 0, 50, 'Available', 'Regular'),
	(39, 'BSCA-4-ABSCA41', 'BSCA-4-A', 'BSCA', '4', 'A', '1', 0, 50, 'Available', 'Regular'),
	(40, 'BSCA-4-ABSCA42', 'BSCA-4-A', 'BSCA', '4', 'A', '2', 0, 50, 'Available', 'Regular');

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
  `descriptive_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=203 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.section_subjects: ~58 rows (approximately)
INSERT INTO `section_subjects` (`id`, `unique_id`, `section_code`, `curriculum`, `course`, `year_level`, `semester`, `subject_code`, `descriptive_title`, `total_units`, `lecture_units`, `lab_units`, `pre_requisite`, `time`, `day`, `room`, `instructor`, `status`) VALUES
	(132, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-GEC 1', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'GEC 1', 'Understanding the Self', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(133, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-GEC 2', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'GEC 2', 'Readings in the Philippine History', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(134, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-GEC 3', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'GEC 3', 'The Contemporary World', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(135, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-GEC 4', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'GEC 4', 'Mathematics in the Modern World', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(136, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-SBEC 100', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'SBEC 100', 'International Trade', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(137, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-GEC 5', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'GEC 5', 'Purposive Communication', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(138, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-PE 101', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 2.0, 2.0, 0.0, 'None', '', '', '', NULL, NULL),
	(139, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-NSTP 1', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'NSTP 1', 'National Service Training Program 1', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(140, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-ETHICS 100', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'ETHICS 100', 'ISAPian Education with Values Formation', 1.5, 1.5, 0.0, 'None', '', '', '', NULL, NULL),
	(141, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-1-MSCED 201', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '1', 'MSCED 201', 'Advisorship Time', 0.0, 1.0, 0.0, 'None', '', '', '', NULL, NULL),
	(142, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-GEC 9', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'GEC 9', 'Rizal\'s Life and Works', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(143, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-LIT 101', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'LIT 101', 'Panitikang Pilipino ', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(144, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-SBEC 101', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'SBEC 101', 'Income and Business Taxation', 3.0, 3.0, 0.0, 'SBEC 100', '', '', '', NULL, NULL),
	(145, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-SCM102', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'SCM102', 'Warehoues Operations Management', 3.0, 3.0, 0.0, 'SCM 100', '', '', '', NULL, NULL),
	(146, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-SBEC 102', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'SBEC 102', 'Business Law', 3.0, 3.0, 0.0, 'SBEC 100', '', '', '', NULL, NULL),
	(147, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-CM 102', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'CM 102', 'Customs Operations and Cargo Handling with Educ. Tour', 3.0, 3.0, 0.0, 'CM 101', '', '', '', NULL, NULL),
	(148, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-CM 103', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'CM 103', 'Customs Warehousing', 5.0, 5.0, 0.0, 'CM 101', '', '', '', NULL, NULL),
	(149, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-TM 102', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'TM 102', 'Commodity Classification System', 3.0, 3.0, 0.0, 'TM 101', '', '', '', NULL, NULL),
	(150, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-PE 103', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'PE 103', 'Physical Education  3 (Swimming)', 2.0, 2.0, 0.0, 'PE 102', '', '', '', NULL, NULL),
	(151, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-1-MSCED 203', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'MSCED 203', 'Advisorship Time', 0.0, 1.0, 0.0, 'MSCED 202', '', '', '', NULL, NULL),
	(152, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-GEC 6', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'GEC 6', 'Art Apreciation', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(153, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-GEC 7', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'GEC 7', 'Science, Technology and Society', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(154, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-SCM 101', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'SCM 101', 'Introduction to Supply Chain Management', 3.0, 3.0, 0.0, 'SBEC 100', '', '', '', NULL, NULL),
	(155, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-CM 101', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'CM 101', 'Border Control and Security', 3.0, 3.0, 0.0, 'SBEC 100', '', '', '', NULL, NULL),
	(156, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-TM 101', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'TM 101', 'Fundamentals of Customs and Tariff Management', 3.0, 3.0, 0.0, 'SBEC 100', '', '', '', NULL, NULL),
	(157, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-GEC 8', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'GEC 8', 'Ethics', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(158, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-ECON 101', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'ECON 101', 'International Economics', 3.0, 3.0, 0.0, 'SBEC 100', '', '', '', NULL, NULL),
	(159, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-PE 102', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'PE 102', 'Physical Education 2 (Gymnastics)', 2.0, 2.0, 0.0, 'PE 1', '', '', '', NULL, NULL),
	(160, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-NSTP 2', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'NSTP 2', 'National Service Training Program 2', 3.0, 3.0, 0.0, 'NSTP 1', '', '', '', NULL, NULL),
	(161, 'BSCA-1-A-BSCA 2021-2022-BSCA-1-2-MSCED 202', 'BSCA-1-A', 'BSCA 2021-2022', 'BSCA', '1', '2', 'MSCED 202', 'Advisorship Time', 0.0, 1.0, 0.0, 'MSCED 201', '', '', '', NULL, NULL),
	(162, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-GEE 101', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'GEE 101', 'Philippine Popular Culture', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(163, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-CBMEC 101', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'CBMEC 101', 'Strategic Management', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(164, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-EC 101', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'EC 101', 'International Marketing', 3.0, 3.0, 0.0, 'ECON 101', '', '', '', NULL, NULL),
	(165, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-EC 102', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'EC 102', 'Enterpreneurial Management', 3.0, 3.0, 0.0, 'ECON 101', '', '', '', NULL, NULL),
	(166, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-SCM 103', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'SCM 103', 'Procurement and Inventory Management', 3.0, 3.0, 0.0, 'SCM 102', '', '', '', NULL, NULL),
	(167, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-CM 104', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'CM 104', 'Customs Proceedings', 5.0, 3.0, 0.0, 'CM 103', '', '', '', NULL, NULL),
	(168, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-TM 103', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'TM 103', 'Customs Valuation System', 5.0, 5.0, 0.0, 'TM 102', '', '', '', NULL, NULL),
	(169, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-PE 104', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'PE 104', 'Physical Education 4 (Team Sports)', 2.0, 2.0, 0.0, 'PE 103', '', '', '', NULL, NULL),
	(170, 'BSCA-2-A-BSCA 2021-2022-BSCA-2-2-MSCED 204', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'MSCED 204', 'Advisorship Time', 0.0, 1.0, 0.0, 'MSCED 203', '', '', '', NULL, NULL),
	(171, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-FL 102', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'FL 102', 'Foreign Language 2', 2.0, 2.0, 0.0, 'FL 101', '', '', '', NULL, NULL),
	(172, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-FIL 102', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'FIL 102', 'Kontekstwalissadong Filipino', 3.0, 3.0, 0.0, 'FIL 101', '', '', '', NULL, NULL),
	(173, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-LIT 102', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'LIT 102', 'Philippine Literature', 3.0, 3.0, 0.0, 'LIT 101', '', '', '', NULL, NULL),
	(174, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-LED 1', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'LED 1', 'Labor Education', 3.0, 3.0, 0.0, 'None', '', '', '', NULL, NULL),
	(175, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-GEE 103', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'GEE 103', 'Philippine Indigenous Communities', 3.0, 3.0, 0.0, 'GEE 102', '', '', '', NULL, NULL),
	(176, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-CM 106', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'CM 106', 'Customs Post Clearance Audit and Fraud Detection', 5.0, 5.0, 0.0, 'CM 105', '', '', '', NULL, NULL),
	(177, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-TM 105', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'TM 105', 'Excise Taxes, Liquidation of Duty and Surcharges', 5.0, 5.0, 0.0, 'TM 104', '', '', '', NULL, NULL),
	(178, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-CA RES 102', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'CA RES 102', 'Customs Research 2', 3.0, 3.0, 0.0, 'CA RES 101', '', '', '', NULL, NULL),
	(179, 'BSCA-3-A-BSCA 2021-2022-BSCA-3-1-MSCED 206', 'BSCA-3-A', 'BSCA 2021-2022', 'BSCA', '3', '1', 'MSCED 206', 'Advisorship Time', 0.0, 1.0, 0.0, 'MSCED 205', '', '', '', NULL, NULL),
	(180, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-1-CA 101', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '1', 'CA 101', 'Integration Review for Cutoms Laws', 1.5, 1.5, 0.0, '4th Year Standing', '', '', '', NULL, NULL),
	(181, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-1-CA 102', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '1', 'CA 102', 'IntegrationReview for Tariff Management', 1.5, 1.5, 0.0, '4th Year Standing', '', '', '', NULL, NULL),
	(182, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-1-TM 107', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '1', 'TM 107', 'International Trade Organizations, Agreements and Rules of Origin', 5.0, 5.0, 0.0, 'TM 106', '', '', '', NULL, NULL),
	(183, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-1-CBMEC 102', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '1', 'CBMEC 102', 'Operations Management', 3.0, 3.0, 0.0, 'CBMEC 101', '', '', '', NULL, NULL),
	(184, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-1-MSCED 207', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '1', 'MSCED 207', 'Advisorship Time', 0.0, 1.0, 0.0, 'MSCED 206', '', '', '', NULL, NULL),
	(185, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-2-CM 108', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '2', 'CM 108', 'Competency Assessment in Customs Management', 5.0, 5.0, 0.0, '4th Year Standing', '', '', '', NULL, NULL),
	(186, 'BSCA-4-A-BSCA 2021-2022-BSCA-4-2-TM 108', 'BSCA-4-A', 'BSCA 2021-2022', 'BSCA', '4', '2', 'TM 108', 'Competency Assessment in Tariff Management', 5.0, 5.0, 0.0, '4th Year Standing', '', '', '', NULL, NULL),
	(196, '2023-1-0001-2023-2024-1-GEC 9', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '1', 'GEC 9', 'Rizal\'s Life and Works', 0.0, 3.0, 0.0, 'None', '', '', '', '', ''),
	(199, '2023-1-0001-2023-2024-1-SCM 103', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'SCM 103', 'Procurement and Inventory Management', 0.0, 3.0, 0.0, 'SCM 102', '', '', '', '', ''),
	(201, '2023-1-0011-2023-2024-1-SCM 103', 'BSCA-2-A', 'BSCA 2021-2022', 'BSCA', '2', '2', 'SCM 103', 'Procurement and Inventory Management', 0.0, 3.0, 0.0, 'SCM 102', '', '', '', '', '');

-- Dumping structure for table model_test_db.statements_of_accounts
CREATE TABLE IF NOT EXISTS `statements_of_accounts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `school_year` varchar(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `course` varchar(50) NOT NULL,
  `year_level` varchar(50) NOT NULL,
  `semester` varchar(50) NOT NULL,
  `reference_no` int NOT NULL DEFAULT '0',
  `particulars` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `debit` decimal(20,2) NOT NULL DEFAULT '0.00',
  `credit` decimal(20,2) NOT NULL DEFAULT '0.00',
  `balance` decimal(20,2) NOT NULL DEFAULT '0.00',
  `cashier_in_charge` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `reference_no` (`reference_no`)
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.statements_of_accounts: ~9 rows (approximately)
INSERT INTO `statements_of_accounts` (`id`, `id_number`, `school_year`, `date`, `course`, `year_level`, `semester`, `reference_no`, `particulars`, `debit`, `credit`, `balance`, `cashier_in_charge`) VALUES
	(67, '2023-1-0001', '2023-2024-1', '12-26-2023', 'BSCA', '1', '1', 1000302, 'Total Assessment as of: 2023-2024-1', 8692.29, 0.00, 8692.29, ''),
	(68, '2023-1-0001', '2023-2024-1', '12-26-2023', 'BSCA', '1', '1', 1000303, 'President Lister Discount', 8692.29, 4790.81, 3901.48, ''),
	(69, '2023-1-0002', '2023-2024-1', '12-29-2023', 'BSCA', '1', '1', 1000304, 'Total Assessment as of: 2023-2024-1', 8692.29, 0.00, 8692.29, ''),
	(70, '2023-1-0002', '2023-2024-1', '12-29-2023', 'BSCA', '1', '1', 1000305, 'President Lister Discount', 8692.29, 4790.81, 3901.48, ''),
	(71, '2023-1-0002', '2023-2024-1', '12-29-2023', 'BSCA', '1', '1', 1000306, 'Dean Lister Discount', 3901.48, 1596.94, 2304.54, ''),
	(72, '2023-1-0001', '2023-2024-1', '01-06-2024', 'BSCA', '1', '1', 1000307, 'Downpayment', 3901.48, 500.00, 3401.48, ''),
	(73, '2023-1-0001', '2023-2024-1', '01-06-2024', 'BSCA', '1', '1', 1000308, 'Downpayment for Prelims', 3401.48, 5000.00, -1598.52, ''),
	(74, '2023-1-0001', '2023-2024-1', '01-06-2024', 'BSCA', '1', '1', 1000309, '', -1598.52, 500.00, -2098.52, ''),
	(75, '2023-1-0002', '2023-2024-1', '01-06-2024', 'BSCA', '1', '1', 1000310, 'Balance Collection', 2304.54, 2500.00, -195.46, ''),
	(77, '2024-1-0003', '2023-2024-1', '01-08-2024', 'BSCA', '1', '1', 1000312, 'Total Assessment as of: 2023-2024-1', 8692.29, 0.00, 8692.29, ''),
	(78, '2024-1-0003', '2023-2024-1', '01-08-2024', 'BSCA', '1', '1', 1000313, 'Prelims Payment', 8692.29, 6500.00, 2192.29, '');

-- Dumping structure for table model_test_db.student_accounts
CREATE TABLE IF NOT EXISTS `student_accounts` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL DEFAULT '',
  `sy_enrolled` varchar(50) NOT NULL DEFAULT '',
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
  `contact_no` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `elem` varchar(50) NOT NULL,
  `jhs` varchar(50) NOT NULL,
  `shs` varchar(50) NOT NULL,
  `elem_year` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `jhs_year` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `shs_year` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `mother_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `mother_no` varchar(50) NOT NULL,
  `father_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `father_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `home_address` varchar(50) NOT NULL,
  `m_occupation` varchar(50) NOT NULL,
  `f_occupation` varchar(50) NOT NULL,
  `type_of_student` varchar(50) NOT NULL,
  `date_of_admission` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_number` (`id_number`),
  UNIQUE KEY `fullname` (`fullname`)
) ENGINE=InnoDB AUTO_INCREMENT=141 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_accounts: ~2 rows (approximately)
INSERT INTO `student_accounts` (`id`, `id_number`, `sy_enrolled`, `school_year`, `fullname`, `last_name`, `first_name`, `middle_name`, `gender`, `civil_status`, `date_of_birth`, `place_of_birth`, `nationality`, `religion`, `status`, `contact_no`, `email`, `elem`, `jhs`, `shs`, `elem_year`, `jhs_year`, `shs_year`, `mother_name`, `mother_no`, `father_name`, `father_no`, `home_address`, `m_occupation`, `f_occupation`, `type_of_student`, `date_of_admission`) VALUES
	(138, '2023-1-0001', '2023-2024-1', '2023-2024-1', 'Manglallan, Derrick Daniel', 'Manglallan', 'Derrick', 'Daniel', '', '', '', '', '', '', 'Officially Enrolled for School Year 2023-2024-1', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'Freshmen', '26/12/2023'),
	(139, '2023-1-0002', '2023-2024-1', '2023-2024-1', 'Pagela, John Christian ', 'Pagela', 'John Christian', '', '', '', '', '', '', '', 'Officially Enrolled for School Year 2023-2024-1', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'Transferee', '29/12/2023'),
	(140, '2024-1-0003', '2023-2024-1', '2023-2024-1', 'Pingad, Airon Jim Aquilo', 'Pingad', 'Airon Jim', 'Aquilo', 'Male', 'Widowed', '', '', '', '', 'Officially Enrolled for School Year 2023-2024-1', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'Freshmen', '1/8/2024');

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
) ENGINE=InnoDB AUTO_INCREMENT=270 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_assessment: ~10 rows (approximately)
INSERT INTO `student_assessment` (`id`, `id_number`, `school_year`, `fee_type`, `amount`, `units`, `computation`) VALUES
	(240, '2023-1-0001', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, '26', 6387.75),
	(241, '2023-1-0001', '2023-2024-1', 'PE UNIFORM', 500.12, '1', 500.12),
	(242, '2023-1-0001', '2023-2024-1', 'INTERNET FEE', 500.12, '1', 500.12),
	(243, '2023-1-0001', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, '1', 652.15),
	(244, '2023-1-0001', '2023-2024-1', 'Learning Management System', 652.15, '1', 652.15),
	(255, '2023-1-0002', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, '26', 6387.75),
	(256, '2023-1-0002', '2023-2024-1', 'PE UNIFORM', 500.12, '1', 500.12),
	(257, '2023-1-0002', '2023-2024-1', 'INTERNET FEE', 500.12, '1', 500.12),
	(258, '2023-1-0002', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, '1', 652.15),
	(259, '2023-1-0002', '2023-2024-1', 'Learning Management System', 652.15, '1', 652.15),
	(265, '2024-1-0003', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, '26', 6387.75),
	(266, '2024-1-0003', '2023-2024-1', 'PE UNIFORM', 500.12, '1', 500.12),
	(267, '2024-1-0003', '2023-2024-1', 'INTERNET FEE', 500.12, '1', 500.12),
	(268, '2024-1-0003', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, '1', 652.15),
	(269, '2024-1-0003', '2023-2024-1', 'Learning Management System', 652.15, '1', 652.15);

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
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_course: ~2 rows (approximately)
INSERT INTO `student_course` (`id`, `id_number`, `course`, `campus`, `curriculum`, `year_level`, `section`, `semester`) VALUES
	(94, '2023-1-0001', 'BSCA', 'ISAP', 'BSCA 2021-2022', '1', 'BSCA-1-A', '1'),
	(95, '2023-1-0002', 'BSCA', 'ISAP', 'BSCA 2021-2022', '1', 'BSCA-1-A', '1'),
	(96, '2024-1-0003', 'BSCA', 'ISAP', 'BSCA 2021-2022', '1', 'BSCA-1-A', '1');

-- Dumping structure for table model_test_db.student_discounts
CREATE TABLE IF NOT EXISTS `student_discounts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `discount_target` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `discount_percentage` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_discounts: ~6 rows (approximately)
INSERT INTO `student_discounts` (`id`, `id_number`, `code`, `discount_target`, `description`, `discount_percentage`) VALUES
	(15, '2023-1-0002', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75),
	(16, '2023-1-0002', 'Dean-Lister-25%', 'Tuition Fee', 'Dean Lister Discount', 25),
	(17, '2023-1-0001', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75),
	(18, '2023-1-0003', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75),
	(19, '2023-1-0008', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75),
	(20, '2023-1-0004', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75);

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
  `descriptive_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `pre_requisite` varchar(50) NOT NULL,
  `total_units` varchar(50) NOT NULL,
  `lecture_units` varchar(50) NOT NULL,
  `lab_units` varchar(50) NOT NULL,
  `time` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `day` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `room` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `instructor` varchar(50) DEFAULT NULL,
  `grade` int unsigned DEFAULT NULL,
  `remarks` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=618 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_subjects: ~20 rows (approximately)
INSERT INTO `student_subjects` (`id`, `id_number`, `unique_id`, `school_year`, `subject_code`, `descriptive_title`, `pre_requisite`, `total_units`, `lecture_units`, `lab_units`, `time`, `day`, `room`, `instructor`, `grade`, `remarks`) VALUES
	(588, '2023-1-0001', '2023-1-0001-2023-1-GEC 1', '2023-2024-1', 'GEC 1', 'Understanding the Self', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(589, '2023-1-0001', '2023-1-0001-2023-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(590, '2023-1-0001', '2023-1-0001-2023-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(591, '2023-1-0001', '2023-1-0001-2023-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(592, '2023-1-0001', '2023-1-0001-2023-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(593, '2023-1-0001', '2023-1-0001-2023-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(594, '2023-1-0001', '2023-1-0001-2023-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', 0, 'Pending'),
	(595, '2023-1-0001', '2023-1-0001-2023-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(596, '2023-1-0001', '2023-1-0001-2023-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', 0, 'Pending'),
	(597, '2023-1-0001', '2023-1-0001-2023-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending'),
	(598, '2023-1-0002', '2023-1-0002-2023-1-GEC 1', '2023-2024-1', 'GEC 1', 'Understanding the Self', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(599, '2023-1-0002', '2023-1-0002-2023-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(600, '2023-1-0002', '2023-1-0002-2023-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(601, '2023-1-0002', '2023-1-0002-2023-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(602, '2023-1-0002', '2023-1-0002-2023-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(603, '2023-1-0002', '2023-1-0002-2023-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(604, '2023-1-0002', '2023-1-0002-2023-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', 0, 'Pending'),
	(605, '2023-1-0002', '2023-1-0002-2023-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(606, '2023-1-0002', '2023-1-0002-2023-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', 0, 'Pending'),
	(607, '2023-1-0002', '2023-1-0002-2023-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending'),
	(608, '2024-1-0003', '2024-1-0003-2024-1-GEC 1', '2023-2024-1', 'GEC 1', 'Understanding the Self', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(609, '2024-1-0003', '2024-1-0003-2024-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(610, '2024-1-0003', '2024-1-0003-2024-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(611, '2024-1-0003', '2024-1-0003-2024-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(612, '2024-1-0003', '2024-1-0003-2024-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(613, '2024-1-0003', '2024-1-0003-2024-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(614, '2024-1-0003', '2024-1-0003-2024-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', 0, 'Pending'),
	(615, '2024-1-0003', '2024-1-0003-2024-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(616, '2024-1-0003', '2024-1-0003-2024-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', 0, 'Pending'),
	(617, '2024-1-0003', '2024-1-0003-2024-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending');

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

-- Dumping data for table model_test_db.subjects: ~0 rows (approximately)

-- Dumping structure for table model_test_db.tuition_fee_setup
CREATE TABLE IF NOT EXISTS `tuition_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `second_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `third_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `fourth_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.tuition_fee_setup: ~2 rows (approximately)
INSERT INTO `tuition_fee_setup` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(7, 'Tuition Fee', 'TUITION FEE/UNIT', 'MCNP', 250.50, 250.50, 250.50, 250.50),
	(8, 'Tuition Fee', 'TUITION FEE/UNIT', 'ISAP', 250.50, 250.50, 250.50, 250.50);

-- Dumping structure for table model_test_db.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `last_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `middle_name` varchar(100) NOT NULL,
  `fullname` varchar(100) NOT NULL,
  `employee_id` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `department` varchar(100) NOT NULL,
  `access_level` varchar(100) NOT NULL,
  `is_add` tinyint(1) NOT NULL DEFAULT '0',
  `is_edit` tinyint(1) NOT NULL DEFAULT '0',
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `is_administrator` tinyint(1) NOT NULL DEFAULT '0',
  `picture` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `employee_id` (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.users: ~4 rows (approximately)
INSERT INTO `users` (`id`, `last_name`, `first_name`, `middle_name`, `fullname`, `employee_id`, `email`, `password`, `department`, `access_level`, `is_add`, `is_edit`, `is_delete`, `is_administrator`, `picture`) VALUES
	(2, 'Manglallan', 'Derrick', 'Daniel', 'Manglallan, Derrick Daniel', '353', 'dmanglallan@isap.edu.ph', '$2a$11$TOu36yb4Tz39siePu3yynOmdXU3EU2hqeb8kC4dZNUxnoAsVzyQzu', 'Finance', 'Administrator', 1, 1, 1, 1, NULL),
	(4, 'Buguina', 'Melenio', 'M', 'Buguina, Melenio M', '456', 'mbuguina@isap.edu.ph', '$2a$11$DVprbLEx8EDm871WeGSwOedkvB2aOgQajCHtbf.e7ndpvPEgIYz/m', 'Registrar', 'User', 1, 0, 0, 0, NULL),
	(5, 'Pingad', 'Airon', 'Jim', 'Pingad, Airon Jim', '465', 'apingad@isap.edu.ph', '$2a$11$UcXUgEDrguxicXmZHDc8W.j1HXpp4EsZcfyWLV68S3ABSpdp8mFy.', '', 'Finance User', 1, 0, 0, 0, NULL),
	(6, 'Alan', 'Charity', 'T', 'Alan, Charity T', '437', 'charlan@isap.edu.ph', '$2a$11$DPX8ta.xEPMBuHJf8ml6y.biLFItS0F7Oz901aewnDYleGO3DB5iu', 'Finance', 'Cashier', 1, 1, 0, 0, NULL);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
