-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
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

-- Dumping data for table model_test_db.access_level: ~0 rows (approximately)
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
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.activity_logger: ~12 rows (approximately)
INSERT INTO `activity_logger` (`id`, `name`, `access_level`, `activity`, `date`, `time`) VALUES
	(1, 'Registrar, Administrator ', 'Administrator', 'Add: Bachelor of Science in Nursing 2021-2022', '00-16-2024', '03:00:55 pm'),
	(2, 'Registrar, Administrator ', 'Administrator', 'Edit: Bachelor of Science in Nursing Curriculum 2021-2022', '01-16-2024', '03:01:13 pm'),
	(3, 'Registrar, Administrator ', 'Administrator', 'Section Edit: BSCA-1-', '16-17-2024', '02:16:01 pm'),
	(4, 'Registrar, Administrator ', 'Administrator', 'Section Edit: BSCA-1-', '16-17-2024', '02:16:12 pm'),
	(5, 'Registrar, Administrator ', 'Administrator', 'Section Edit: BSCA-1-A', '16-17-2024', '02:16:27 pm'),
	(6, 'Registrar, Administrator ', 'Administrator', 'Course Add: STEM', '01-17-2024', '04:01:49 pm'),
	(7, 'Registrar, Administrator ', 'Administrator', 'Deleted All Curriculum: STEM', '03-17-2024', '04:03:17 pm'),
	(8, 'Registrar, Administrator ', 'Administrator', 'Deleted All Curriculum: STEM', '04-17-2024', '04:04:04 pm'),
	(9, 'Registrar, Administrator ', 'Administrator', 'Deleted All Curriculum: STEM', '05-17-2024', '04:05:35 pm'),
	(10, 'Registrar, Administrator ', 'Administrator', 'Deleted All Curriculum: STEM', '07-17-2024', '04:07:49 pm'),
	(11, 'Registrar, Administrator ', 'Administrator', 'Deleted All Curriculum: STEM', '10-17-2024', '04:10:46 pm'),
	(12, 'Registrar, Administrator ', 'Administrator', 'Curriculum File Import: HUMSS.xlsx', '10-17-2024', '04:10:54 pm'),
	(13, 'Registrar, Administrator ', 'Administrator', 'School Year Add: SY 2023-2024, 2nd Semester', '15-17-2024', '04:15:46 pm'),
	(14, 'Registrar, Administrator ', 'Administrator', 'Instructor Add: Manglallan, Derrick D.', '17-17-2024', '04:17:26 pm'),
	(15, 'Registrar, Administrator ', 'Administrator', 'Section Subject Select All', '18-17-2024', '04:18:03 pm'),
	(16, 'Registrar, Administrator ', 'Administrator', 'Account Creation: 2024-1-0007', '22-17-2024', '04:22:27 pm'),
	(17, 'Registrar, Administrator ', 'Administrator', 'Approve account: rhthskljfh, werthrehrh uhsdhwekjehih With a course: BSCA', '22-17-2024', '04:22:35 pm'),
	(18, 'Manglallan, Derrick Daniel', 'Administrator', 'Add Discount: top 1 class valedictorian', '14-18-2024', '02:14:53 pm'),
	(19, 'Manglallan, Derrick Daniel', 'Administrator', 'Discount Delete: Dean Lister Discount', '17-19-2024', '11:17:37 am'),
	(20, 'Manglallan, Derrick Daniel', 'Administrator', 'Discount Delete: President Lister Discount', '17-19-2024', '11:17:44 am'),
	(21, 'Manglallan, Derrick Daniel', 'Administrator', 'Discount Delete: top 1 class valedictorian', '17-19-2024', '11:17:47 am'),
	(22, 'Manglallan, Derrick Daniel', 'Administrator', 'Add Discount: 100% DISCOUNT TUITION AND MISCELLANEOUS', '20-19-2024', '11:20:05 am'),
	(23, 'Manglallan, Derrick Daniel', 'Administrator', 'Adding discount to student: Dela Cruz, Juan ', '07-21-2024', '04:07:18 pm'),
	(24, 'Manglallan, Derrick Daniel', 'Administrator', 'Adding discount to student: Dela Cruz, Juan ', '08-21-2024', '04:08:13 pm'),
	(25, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee per unit', '02-22-2024', '08:02:50 am'),
	(26, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee per unit', '03-22-2024', '08:03:33 am'),
	(27, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee per unit', '07-22-2024', '08:07:40 am'),
	(28, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee per unit', '07-22-2024', '08:07:52 am'),
	(29, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee per unit', '08-22-2024', '08:08:07 am'),
	(30, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition fee per unit', '16-22-2024', '08:16:02 am'),
	(31, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition fee per unit', '16-22-2024', '08:16:12 am'),
	(32, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition fee per unit', '16-22-2024', '08:16:43 am'),
	(33, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition fee per unit', '17-22-2024', '08:17:04 am'),
	(34, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: alskdjalskdjlkj', '48-22-2024', '09:48:56 am'),
	(35, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: 123123', '50-22-2024', '09:50:29 am'),
	(36, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: 123213', '51-22-2024', '09:51:36 am'),
	(37, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: asldkjhaslkjd', '53-22-2024', '09:53:54 am'),
	(38, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: 123', '55-22-2024', '09:55:48 am'),
	(39, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: sdssdsdsdsd', '57-22-2024', '09:57:58 am'),
	(40, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: TUITION FEE PER UNIT', '42-22-2024', '10:42:40 am'),
	(41, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: TUITION FEE PER UNIT', '44-22-2024', '10:44:21 am'),
	(42, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: TUITION FEE PER UNIT', '44-22-2024', '10:44:36 am'),
	(43, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: TUITION FEE PER UNIT', '45-22-2024', '10:45:30 am'),
	(44, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: TUITION FEE PER UNIT', '45-22-2024', '10:45:41 am'),
	(45, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '32-22-2024', '03:32:57 pm'),
	(46, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '33-22-2024', '03:33:08 pm'),
	(47, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '33-22-2024', '03:33:18 pm'),
	(48, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '33-22-2024', '03:33:30 pm'),
	(49, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '38-22-2024', '03:38:08 pm'),
	(50, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '38-22-2024', '03:38:18 pm'),
	(51, 'Manglallan, Derrick Daniel', 'Administrator', 'Tuition fee setup add: Tuition Fee Per Unit', '38-22-2024', '03:38:30 pm'),
	(52, 'Registrar, Administrator ', 'Administrator', 'Add: Bachelor of Science in Customs Administration 2021-2022', '02-23-2024', '03:02:15 pm'),
	(53, 'Registrar, Administrator ', 'Administrator', 'Department Add: College of Nursing', '18-23-2024', '03:18:05 pm'),
	(54, 'Registrar, Administrator ', 'Administrator', 'Course Add: Bachelor of Science in Nursing', '18-23-2024', '03:18:45 pm'),
	(55, 'Registrar, Administrator ', 'Administrator', 'Department Add: College of BEM', '22-23-2024', '03:22:09 pm'),
	(56, 'Registrar, Administrator ', 'Administrator', 'Department Add: College of Nursing', '22-23-2024', '03:22:22 pm'),
	(57, 'Registrar, Administrator ', 'Administrator', 'Department Edit: College of Business Education Management', '22-23-2024', '03:22:39 pm'),
	(58, 'Registrar, Administrator ', 'Administrator', 'Course Add: Bachelor of Science in Nursing', '23-23-2024', '03:23:53 pm'),
	(59, 'Registrar, Administrator ', 'Administrator', 'Course Add: Bachelor of Science in Customs Administration', '24-23-2024', '03:24:17 pm'),
	(60, 'Registrar, Administrator ', 'Administrator', 'Add: Bachelor of Science in Customs Administration', '24-23-2024', '03:24:56 pm'),
	(61, 'Registrar, Administrator ', 'Administrator', 'Edit: Bachelor of Science in Customs Administration', '25-23-2024', '03:25:01 pm'),
	(62, 'Registrar, Administrator ', 'Administrator', 'Department Add: PHYSICAL-THERAPY', '56-24-2024', '08:56:14 am'),
	(63, 'Registrar, Administrator ', 'Administrator', 'Course Add: Bachelor of Science in Physical Therapy', '56-24-2024', '08:56:43 am'),
	(64, 'Registrar, Administrator ', 'Administrator', 'Add: Bachelor of Science in Physical Therapy', '57-24-2024', '08:57:12 am'),
	(65, 'Registrar, Administrator ', 'Administrator', 'Curriculum File Import: BSPT.xlsx', '20-24-2024', '09:20:37 am'),
	(66, 'Registrar, Administrator ', 'Administrator', 'Curriculum File Import: BSPT.xlsx', '23-24-2024', '09:23:39 am'),
	(67, 'Registrar, Administrator ', 'Administrator', 'Curriculum File Import: BSPT.xlsx', '24-24-2024', '09:24:25 am'),
	(68, 'Registrar, Administrator ', 'Administrator', 'Curriculum File Import: BSPT.xlsx', '28-24-2024', '09:28:19 am'),
	(69, 'Registrar, Administrator ', 'Administrator', 'Curriculum Subject Update: 622', '30-24-2024', '02:30:47 pm'),
	(70, 'Registrar, Administrator ', 'Administrator', 'Section Add: BSPT-1-A', '18-24-2024', '06:18:41 pm'),
	(71, 'Registrar, Administrator ', 'Administrator', 'Section Edit: BSCA-1-A', '21-24-2024', '06:21:11 pm'),
	(72, 'Registrar, Administrator ', 'Administrator', 'Section Edit: BSPT-1-A', '21-24-2024', '06:21:17 pm');

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
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.assessment_breakdown: ~20 rows (approximately)
INSERT INTO `assessment_breakdown` (`id`, `id_number`, `school_year`, `fee_type`, `amount`) VALUES
	(6, '2024-1-0003', '2023-2024-1', 'TUITION FEE/UNIT', 5887.75),
	(7, '2024-1-0003', '2023-2024-1', 'PE UNIFORM', 500.12),
	(8, '2024-1-0003', '2023-2024-1', 'INTERNET FEE', 500.12),
	(9, '2024-1-0003', '2023-2024-1', 'Student Information and Accounting Systems', 652.15),
	(10, '2024-1-0003', '2023-2024-1', 'Learning Management System', 652.15),
	(11, '2024-1-0004', '2023-2024-1', 'TUITION FEE/UNIT', 2587.75),
	(12, '2024-1-0004', '2023-2024-1', 'PE UNIFORM', 500.12),
	(13, '2024-1-0004', '2023-2024-1', 'INTERNET FEE', 500.12),
	(14, '2024-1-0004', '2023-2024-1', 'Student Information and Accounting Systems', 652.15),
	(15, '2024-1-0004', '2023-2024-1', 'Learning Management System', 652.15),
	(16, '2024-1-0005', '2023-2024-1', 'TUITION FEE/UNIT', 0.00),
	(17, '2024-1-0005', '2023-2024-1', 'PE UNIFORM', 0.00),
	(18, '2024-1-0005', '2023-2024-1', 'INTERNET FEE', 0.00),
	(19, '2024-1-0005', '2023-2024-1', 'Student Information and Accounting Systems', 0.00),
	(20, '2024-1-0005', '2023-2024-1', 'Learning Management System', 0.00),
	(21, '2024-1-0006', '2023-2024-1', 'TUITION FEE/UNIT', 887.75),
	(22, '2024-1-0006', '2023-2024-1', 'PE UNIFORM', 500.12),
	(23, '2024-1-0006', '2023-2024-1', 'INTERNET FEE', 500.12),
	(24, '2024-1-0006', '2023-2024-1', 'Student Information and Accounting Systems', 652.15),
	(25, '2024-1-0006', '2023-2024-1', 'Learning Management System', 652.15);

-- Dumping structure for table model_test_db.authentication_logger
CREATE TABLE IF NOT EXISTS `authentication_logger` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `access_level` varchar(100) NOT NULL,
  `date` varchar(100) NOT NULL,
  `time` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=435 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.authentication_logger: ~374 rows (approximately)
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
	(29, 'Alan, Charity T', 'Cashier', '01-08-2024', '04:14:01 PM'),
	(30, 'Alan, Charity T', 'Cashier', '01-09-2024', '02:31:27 pm'),
	(31, 'Alan, Charity T', 'Cashier', '01-09-2024', '04:01:55 pm'),
	(32, 'Alan, Charity T', 'Cashier', '01-09-2024', '04:03:19 pm'),
	(33, 'Alan, Charity T', 'Cashier', '01-09-2024', '04:05:59 pm'),
	(34, 'Alan, Charity T', 'Cashier', '01-09-2024', '04:21:02 pm'),
	(35, 'Alan, Charity T', 'Cashier', '01-09-2024', '04:22:08 pm'),
	(36, 'Manglallan, Derrick Daniel', 'Administrator', '01-09-2024', '04:24:41 pm'),
	(37, 'Alan, Charity T', 'Cashier', '01-10-2024', '07:54:45 am'),
	(38, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '08:07:18 am'),
	(39, 'Alan, Charity T', 'Cashier', '01-10-2024', '08:14:37 am'),
	(40, 'Alan, Charity T', 'Cashier', '01-10-2024', '08:15:57 am'),
	(41, 'Alan, Charity T', 'Cashier', '01-10-2024', '08:16:59 am'),
	(42, 'Alan, Charity T', 'Cashier', '01-10-2024', '08:18:24 am'),
	(43, 'Alan, Charity T', 'Cashier', '01-10-2024', '09:37:12 am'),
	(44, 'Alan, Charity T', 'Cashier', '01-10-2024', '09:38:41 am'),
	(45, 'Alan, Charity T', 'Cashier', '01-10-2024', '09:48:47 am'),
	(46, 'Alan, Charity T', 'Cashier', '01-10-2024', '09:52:38 am'),
	(47, 'Alan, Charity T', 'Cashier', '01-10-2024', '09:56:51 am'),
	(48, 'Alan, Charity T', 'Cashier', '01-10-2024', '09:57:40 am'),
	(49, 'Alan, Charity T', 'Cashier', '01-10-2024', '10:09:21 am'),
	(50, 'Alan, Charity T', 'Cashier', '01-10-2024', '10:10:57 am'),
	(51, 'Alan, Charity T', 'Cashier', '01-10-2024', '10:13:20 am'),
	(52, 'Alan, Charity T', 'Cashier', '01-10-2024', '10:19:11 am'),
	(53, 'Alan, Charity T', 'Cashier', '01-10-2024', '10:19:55 am'),
	(54, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '11:23:44 am'),
	(55, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '11:24:47 am'),
	(56, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '11:33:13 am'),
	(57, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '11:37:23 am'),
	(58, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '01:05:49 pm'),
	(59, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:15:50 pm'),
	(60, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:16:41 pm'),
	(61, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:18:00 pm'),
	(62, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:19:13 pm'),
	(63, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:20:01 pm'),
	(64, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:24:08 pm'),
	(65, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:27:24 pm'),
	(66, 'Alan, Charity T', 'Cashier', '01-10-2024', '01:48:09 pm'),
	(67, 'Alan, Charity T', 'Cashier', '01-10-2024', '02:34:42 pm'),
	(68, 'Alan, Charity T', 'Cashier', '01-10-2024', '02:36:23 pm'),
	(69, 'Alan, Charity T', 'Cashier', '01-10-2024', '02:38:19 pm'),
	(70, 'Alan, Charity T', 'Cashier', '01-10-2024', '02:41:03 pm'),
	(71, 'Alan, Charity T', 'Cashier', '01-10-2024', '02:44:00 pm'),
	(72, 'Alan, Charity T', 'Cashier', '01-10-2024', '02:46:15 pm'),
	(73, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '02:48:53 pm'),
	(74, 'Alan, Charity T', 'Cashier', '01-10-2024', '03:09:50 pm'),
	(75, 'Alan, Charity T', 'Cashier', '01-10-2024', '03:10:51 pm'),
	(76, 'Alan, Charity T', 'Cashier', '01-10-2024', '03:14:10 pm'),
	(77, 'Manglallan, Derrick Daniel', 'Administrator', '01-10-2024', '04:01:57 pm'),
	(78, 'Manglallan, Derrick Daniel', 'Administrator', '01-16-2024', '08:39:16 am'),
	(79, 'Manglallan, Derrick Daniel', 'Administrator', '01-16-2024', '09:07:24 am'),
	(80, 'Geron, Richard T', 'Student Accounts', '01-16-2024', '09:12:23 am'),
	(81, 'Geron, Richard T', 'Student Accounts', '01-16-2024', '09:43:26 am'),
	(82, 'Manglallan, Derrick Daniel', 'Administrator', '01-16-2024', '09:43:44 am'),
	(83, 'Manglallan, Derrick Daniel', 'Administrator', '01-16-2024', '01:21:43 pm'),
	(84, 'Buguina, Melenio M', 'User', '01-16-2024', '01:22:27 pm'),
	(85, 'Buguina, Melenio M', 'User', '01-16-2024', '01:23:28 pm'),
	(86, 'Buguina, Melenio M', 'User', '01-16-2024', '01:36:51 pm'),
	(87, 'Buguina, Melenio M', 'User', '01-16-2024', '01:38:07 pm'),
	(88, 'Buguina, Melenio M', 'User', '01-16-2024', '01:38:46 pm'),
	(89, 'Buguina, Melenio M', 'User', '01-16-2024', '01:44:51 pm'),
	(90, 'Registrar, Administrator ', 'Administrator', '01-16-2024', '02:58:02 pm'),
	(91, 'Registrar, Administrator ', 'Administrator', '01-16-2024', '03:00:07 pm'),
	(92, 'Registrar, Administrator ', 'Administrator', '01-16-2024', '03:02:50 pm'),
	(93, 'Registrar, Administrator ', 'Administrator', '01-16-2024', '03:05:27 pm'),
	(94, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '08:04:33 am'),
	(95, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '11:14:15 am'),
	(96, 'Manglallan, Derrick Daniel', 'Administrator', '01-17-2024', '01:28:50 pm'),
	(97, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '01:42:06 pm'),
	(98, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '01:44:16 pm'),
	(99, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '01:51:20 pm'),
	(100, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '01:51:52 pm'),
	(101, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '01:53:00 pm'),
	(102, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:02:41 pm'),
	(103, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:03:26 pm'),
	(104, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:04:43 pm'),
	(105, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:05:21 pm'),
	(106, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:06:23 pm'),
	(107, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:08:46 pm'),
	(108, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:11:18 pm'),
	(109, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:14:46 pm'),
	(110, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '02:15:39 pm'),
	(111, 'Manglallan, Derrick Daniel', 'Administrator', '01-17-2024', '03:27:59 pm'),
	(112, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '03:39:23 pm'),
	(113, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:01:07 pm'),
	(114, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:07:22 pm'),
	(115, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:13:25 pm'),
	(116, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:15:06 pm'),
	(117, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:16:51 pm'),
	(118, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:21:34 pm'),
	(119, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:28:27 pm'),
	(120, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:29:11 pm'),
	(121, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:35:41 pm'),
	(122, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:37:10 pm'),
	(123, 'Registrar, Administrator ', 'Administrator', '01-17-2024', '04:38:32 pm'),
	(124, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '08:23:28 am'),
	(125, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '08:29:28 am'),
	(126, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '08:29:50 am'),
	(127, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '10:40:05 am'),
	(128, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '10:42:00 am'),
	(129, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '10:56:36 am'),
	(130, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:04:29 am'),
	(131, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:05:40 am'),
	(132, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:06:29 am'),
	(133, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:06:53 am'),
	(134, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:07:45 am'),
	(135, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:12:10 am'),
	(136, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:13:22 am'),
	(137, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:14:38 am'),
	(138, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:15:42 am'),
	(139, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:17:33 am'),
	(140, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:18:32 am'),
	(141, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:19:53 am'),
	(142, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:20:37 am'),
	(143, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:26:36 am'),
	(144, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:27:46 am'),
	(145, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:28:34 am'),
	(146, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:29:29 am'),
	(147, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:31:40 am'),
	(148, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:33:05 am'),
	(149, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:34:35 am'),
	(150, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:35:05 am'),
	(151, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:35:38 am'),
	(152, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:36:11 am'),
	(153, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:36:48 am'),
	(154, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:37:14 am'),
	(155, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:38:30 am'),
	(156, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:39:12 am'),
	(157, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:39:50 am'),
	(158, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:41:44 am'),
	(159, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:43:02 am'),
	(160, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:43:37 am'),
	(161, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '11:44:19 am'),
	(162, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '01:18:20 pm'),
	(163, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '01:23:43 pm'),
	(164, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '01:24:03 pm'),
	(165, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '01:26:55 pm'),
	(166, 'Registrar, Administrator ', 'Administrator', '01-18-2024', '01:36:37 pm'),
	(167, 'Manglallan, Derrick Daniel', 'Administrator', '01-18-2024', '02:13:16 pm'),
	(168, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '08:52:08 am'),
	(169, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '08:55:32 am'),
	(170, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '09:04:30 am'),
	(171, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '09:07:43 am'),
	(172, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '09:09:22 am'),
	(173, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '09:11:05 am'),
	(174, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '09:15:10 am'),
	(175, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '09:19:33 am'),
	(176, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '10:17:41 am'),
	(177, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '10:26:08 am'),
	(178, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '10:26:47 am'),
	(179, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '10:31:11 am'),
	(180, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '10:33:52 am'),
	(181, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '10:36:20 am'),
	(182, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '10:39:46 am'),
	(183, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '11:02:10 am'),
	(184, 'Registrar, Administrator ', 'Administrator', '01-19-2024', '11:03:53 am'),
	(185, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '11:16:00 am'),
	(186, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '11:26:11 am'),
	(187, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '11:29:21 am'),
	(188, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '11:29:57 am'),
	(189, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '01:16:01 pm'),
	(190, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '01:18:37 pm'),
	(191, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '01:19:22 pm'),
	(192, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '01:44:07 pm'),
	(193, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '01:47:49 pm'),
	(194, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '02:00:55 pm'),
	(195, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '02:01:40 pm'),
	(196, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '02:02:38 pm'),
	(197, 'Manglallan, Derrick Daniel', 'Administrator', '01-19-2024', '02:03:11 pm'),
	(198, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '01:44:11 pm'),
	(199, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '01:45:22 pm'),
	(200, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '01:48:24 pm'),
	(201, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '01:49:08 pm'),
	(202, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '04:06:39 pm'),
	(203, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '04:07:36 pm'),
	(204, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '04:10:40 pm'),
	(205, 'Manglallan, Derrick Daniel', 'Administrator', '01-21-2024', '04:38:43 pm'),
	(206, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '07:56:59 am'),
	(207, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:02:14 am'),
	(208, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:04:36 am'),
	(209, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:05:31 am'),
	(210, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:06:29 am'),
	(211, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:09:43 am'),
	(212, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:13:17 am'),
	(213, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:15:20 am'),
	(214, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:17:46 am'),
	(215, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:18:42 am'),
	(216, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:19:27 am'),
	(217, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:33:20 am'),
	(218, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:54:01 am'),
	(219, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:59:19 am'),
	(220, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '08:59:47 am'),
	(221, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:00:12 am'),
	(222, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:01:22 am'),
	(223, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:07:52 am'),
	(224, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:12:41 am'),
	(225, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:13:22 am'),
	(226, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:14:12 am'),
	(227, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:24:04 am'),
	(228, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:24:24 am'),
	(229, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:38:14 am'),
	(230, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:38:45 am'),
	(231, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:39:27 am'),
	(232, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:42:18 am'),
	(233, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:48:36 am'),
	(234, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:50:14 am'),
	(235, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:51:21 am'),
	(236, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:53:27 am'),
	(237, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:54:57 am'),
	(238, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:55:30 am'),
	(239, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '09:57:42 am'),
	(240, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:08:02 am'),
	(241, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:09:46 am'),
	(242, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:10:05 am'),
	(243, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:10:29 am'),
	(244, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:17:40 am'),
	(245, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:17:55 am'),
	(246, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:36:59 am'),
	(247, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:40:15 am'),
	(248, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:42:09 am'),
	(249, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:43:43 am'),
	(250, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:54:02 am'),
	(251, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:57:40 am'),
	(252, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:58:25 am'),
	(253, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '10:59:19 am'),
	(254, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:00:00 am'),
	(255, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:00:28 am'),
	(256, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:01:21 am'),
	(257, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:02:32 am'),
	(258, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:05:12 am'),
	(259, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:06:03 am'),
	(260, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:09:51 am'),
	(261, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:11:18 am'),
	(262, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:12:03 am'),
	(263, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:12:28 am'),
	(264, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:13:44 am'),
	(265, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:14:41 am'),
	(266, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:26:22 am'),
	(267, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:40:41 am'),
	(268, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '11:41:34 am'),
	(269, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:11:23 pm'),
	(270, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:13:14 pm'),
	(271, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:15:18 pm'),
	(272, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:17:22 pm'),
	(273, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:17:42 pm'),
	(274, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:18:09 pm'),
	(275, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:18:46 pm'),
	(276, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:34:10 pm'),
	(277, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:51:40 pm'),
	(278, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:53:42 pm'),
	(279, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:55:13 pm'),
	(280, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '01:56:15 pm'),
	(281, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '02:00:33 pm'),
	(282, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '02:56:51 pm'),
	(283, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '02:59:04 pm'),
	(284, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:00:04 pm'),
	(285, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:03:02 pm'),
	(286, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:08:20 pm'),
	(287, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:10:47 pm'),
	(288, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:12:40 pm'),
	(289, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:15:08 pm'),
	(290, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:15:59 pm'),
	(291, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:17:20 pm'),
	(292, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:19:30 pm'),
	(293, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:21:52 pm'),
	(294, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:29:44 pm'),
	(295, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:30:36 pm'),
	(296, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:32:38 pm'),
	(297, 'Manglallan, Derrick Daniel', 'Administrator', '01-22-2024', '03:59:37 pm'),
	(298, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '03:59:47 pm'),
	(299, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:00:48 pm'),
	(300, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:01:19 pm'),
	(301, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:07:56 pm'),
	(302, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:08:26 pm'),
	(303, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:09:14 pm'),
	(304, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:11:15 pm'),
	(305, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:13:03 pm'),
	(306, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:14:08 pm'),
	(307, 'Registrar, Administrator ', 'Administrator', '01-22-2024', '04:20:17 pm'),
	(308, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '08:54:10 am'),
	(309, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '08:59:12 am'),
	(310, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '09:14:38 am'),
	(311, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '09:15:20 am'),
	(312, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:09:18 am'),
	(313, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:10:08 am'),
	(314, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:11:05 am'),
	(315, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:19:30 am'),
	(316, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:20:29 am'),
	(317, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:21:51 am'),
	(318, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:23:07 am'),
	(319, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:29:35 am'),
	(320, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:30:50 am'),
	(321, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:33:00 am'),
	(322, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:33:25 am'),
	(323, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:33:49 am'),
	(324, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:34:22 am'),
	(325, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:35:41 am'),
	(326, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:36:54 am'),
	(327, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:38:13 am'),
	(328, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:38:59 am'),
	(329, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:39:58 am'),
	(330, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:40:39 am'),
	(331, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:42:02 am'),
	(332, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '10:46:31 am'),
	(333, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:13:00 am'),
	(334, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:15:06 am'),
	(335, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:21:12 am'),
	(336, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:27:06 am'),
	(337, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:28:14 am'),
	(338, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:28:38 am'),
	(339, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:29:19 am'),
	(340, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:33:13 am'),
	(341, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '11:35:12 am'),
	(342, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:32:35 pm'),
	(343, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:35:39 pm'),
	(344, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:44:37 pm'),
	(345, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:46:32 pm'),
	(346, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:51:59 pm'),
	(347, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:55:35 pm'),
	(348, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:59:14 pm'),
	(349, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '01:59:39 pm'),
	(350, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:00:12 pm'),
	(351, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:03:56 pm'),
	(352, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:04:21 pm'),
	(353, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:45:07 pm'),
	(354, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:46:14 pm'),
	(355, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:47:28 pm'),
	(356, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:50:15 pm'),
	(357, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:53:25 pm'),
	(358, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '02:58:54 pm'),
	(359, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '03:12:13 pm'),
	(360, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '03:16:18 pm'),
	(361, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '03:17:43 pm'),
	(362, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '03:21:03 pm'),
	(363, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '03:21:39 pm'),
	(364, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '03:23:12 pm'),
	(365, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:12:26 pm'),
	(366, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:12:50 pm'),
	(367, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:13:26 pm'),
	(368, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:14:32 pm'),
	(369, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:24:20 pm'),
	(370, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:25:25 pm'),
	(371, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:26:31 pm'),
	(372, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:27:07 pm'),
	(373, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:28:59 pm'),
	(374, 'Registrar, Administrator ', 'Administrator', '01-23-2024', '04:31:16 pm'),
	(375, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:43:30 am'),
	(376, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:45:36 am'),
	(377, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:46:34 am'),
	(378, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:48:44 am'),
	(379, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:50:31 am'),
	(380, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:53:05 am'),
	(381, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:55:20 am'),
	(382, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '08:58:15 am'),
	(383, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:00:43 am'),
	(384, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:02:07 am'),
	(385, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:04:23 am'),
	(386, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:05:59 am'),
	(387, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:20:16 am'),
	(388, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:22:38 am'),
	(389, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:23:19 am'),
	(390, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:23:53 am'),
	(391, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:25:03 am'),
	(392, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '09:27:50 am'),
	(393, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '01:44:37 pm'),
	(394, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '02:15:31 pm'),
	(395, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '02:30:14 pm'),
	(396, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '03:00:21 pm'),
	(397, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '03:01:49 pm'),
	(398, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '03:03:04 pm'),
	(399, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:18:25 pm'),
	(400, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:19:47 pm'),
	(401, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:21:30 pm'),
	(402, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:24:24 pm'),
	(403, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:27:28 pm'),
	(404, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:28:34 pm'),
	(405, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:30:49 pm'),
	(406, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:50:32 pm'),
	(407, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:54:44 pm'),
	(408, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:55:26 pm'),
	(409, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:56:32 pm'),
	(410, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '05:57:42 pm'),
	(411, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:03:17 pm'),
	(412, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:05:44 pm'),
	(413, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:06:22 pm'),
	(414, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:08:24 pm'),
	(415, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:09:35 pm'),
	(416, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:10:21 pm'),
	(417, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:11:30 pm'),
	(418, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:18:12 pm'),
	(419, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:20:10 pm'),
	(420, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '06:20:48 pm'),
	(421, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:00:15 pm'),
	(422, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:01:40 pm'),
	(423, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:02:17 pm'),
	(424, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:02:43 pm'),
	(425, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:03:19 pm'),
	(426, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:04:09 pm'),
	(427, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:11:51 pm'),
	(428, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:12:34 pm'),
	(429, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:14:36 pm'),
	(430, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:15:18 pm'),
	(431, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:16:26 pm'),
	(432, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:19:59 pm'),
	(433, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:21:48 pm'),
	(434, 'Registrar, Administrator ', 'Administrator', '01-24-2024', '07:23:00 pm');

-- Dumping structure for table model_test_db.campuses
CREATE TABLE IF NOT EXISTS `campuses` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE,
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
  `level_id` int NOT NULL DEFAULT '0',
  `campus_id` int NOT NULL DEFAULT '0',
  `department_id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `max_units` int NOT NULL DEFAULT '0',
  `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.courses: ~2 rows (approximately)
INSERT INTO `courses` (`id`, `code`, `description`, `level_id`, `campus_id`, `department_id`, `max_units`, `status`) VALUES
	(10, 'BSN', 'Bachelor of Science in Nursing', 7, 6, '11', 50, 'Active'),
	(11, 'BSCA', 'Bachelor of Science in Customs Administration', 7, 7, '10', 50, 'Active'),
	(12, 'BSPT', 'Bachelor of Science in Physical Therapy', 7, 6, '12', 50, 'Active');

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
  `campus_id` int NOT NULL DEFAULT '0',
  `course_id` int NOT NULL DEFAULT '0',
  `effective` varchar(50) NOT NULL,
  `expires` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.curriculums: ~0 rows (approximately)
INSERT INTO `curriculums` (`id`, `code`, `description`, `campus_id`, `course_id`, `effective`, `expires`, `status`) VALUES
	(11, 'BSCA 2021-2022', 'Bachelor of Science in Customs Administration', 7, 11, '01-01-2024', '31-01-2024', 'Active'),
	(12, 'BSPT 2021-2022', 'Bachelor of Science in Physical Therapy', 6, 12, '01-01-2024', '31-01-2024', 'Active');

-- Dumping structure for table model_test_db.curriculum_subjects
CREATE TABLE IF NOT EXISTS `curriculum_subjects` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `uid` varchar(750) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `curriculum_id` varchar(750) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `year_level` varchar(50) NOT NULL,
  `semester` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `descriptive_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `total_units` varchar(50) NOT NULL,
  `lecture_units` varchar(50) NOT NULL,
  `lab_units` varchar(50) NOT NULL,
  `pre_requisite` varchar(750) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `total_hrs_per_week` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `curriculumIdCode` (`uid`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=699 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.curriculum_subjects: ~77 rows (approximately)
INSERT INTO `curriculum_subjects` (`id`, `uid`, `curriculum_id`, `year_level`, `semester`, `code`, `descriptive_title`, `total_units`, `lecture_units`, `lab_units`, `pre_requisite`, `total_hrs_per_week`) VALUES
	(622, '12GEC 1', '12', '1', '1', 'GEC 1', 'Understanding the Self love', '3', '3', '0', 'None', '3'),
	(623, 'BSPT 2021-2022GEC 8', '12', '1', '1', 'GEC 8', 'Ethics', '3', '3', '0', 'None', '3'),
	(624, 'BSPT 2021-2022GEC 7', '12', '1', '1', 'GEC 7', 'Science, Technology and Society', '3', '3', '0', 'None', '3'),
	(625, 'BSPT 2021-2022GEC 5', '12', '1', '1', 'GEC 5', 'Purposive Communication', '3', '3', '0', 'None', '3'),
	(626, 'BSPT 2021-2022PE 1', '12', '1', '1', 'PE 1', 'Physical Education 1 (wellness & fitness)', '2', '2', '0', 'None', '2'),
	(627, 'BSPT 2021-2022NSTP 1', '12', '1', '1', 'NSTP 1', 'National Service Training Program 1', '3', '3', '0', 'None', '3'),
	(628, 'BSPT 2021-2022FIL 1', '12', '1', '1', 'FIL 1', 'Panitikang Filipino', '3', '3', '0', 'None', '3'),
	(629, 'BSPT 2021-2022MT 100', '12', '1', '1', 'MT 100', 'Medical Terminology', '3', '3', '0', 'None', '3'),
	(630, 'BSPT 2021-2022NAT SCI 2', '12', '1', '1', 'NAT SCI 2', 'Zoology', '5', '3', '2', 'None', '9'),
	(631, 'BSPT 2021-2022MSCED 201', '12', '1', '1', 'MSCED 201', 'Advisorship Time 1', '0', '0', '0', 'None', '1'),
	(632, 'BSPT 2021-2022GEC 2', '12', '1', '2', 'GEC 2', 'Readings in Philippine History', '3', '3', '0', 'None', '3'),
	(633, 'BSPT 2021-2022GEC 3', '12', '1', '2', 'GEC 3', 'The Contemporary World', '3', '3', '0', 'None', '3'),
	(634, 'BSPT 2021-2022GEC 6', '12', '1', '2', 'GEC 6', 'Art Appreciation', '3', '3', '0', 'None', '3'),
	(635, 'BSPT 2021-2022GEC 9', '12', '1', '2', 'GEC 9', 'Rizal\'s Life and Works', '3', '3', '0', 'None', '3'),
	(636, 'BSPT 2021-2022GEC 4', '12', '1', '2', 'GEC 4', 'Mathematics in the Modern World', '3', '3', '0', 'None', '3'),
	(637, 'BSPT 2021-2022FIL 2', '12', '1', '2', 'FIL 2', 'Masining na Pagpapahayag', '3', '3', '0', 'None', '3'),
	(638, 'BSPT 2021-2022PE2', '12', '1', '2', 'PE2', 'Physical Education 2 (Rhythmic Activities)', '2', '2', '0', 'None', '2'),
	(639, 'BSPT 2021-2022NSTP 2', '12', '1', '2', 'NSTP 2', 'National Training Service Proram 2', '3', '3', '0', 'NSTP 1', '3'),
	(640, 'BSPT 2021-2022ANA I', '12', '1', '2', 'ANA I', 'Regional Anatomy', '5', '3', '2', 'MT 100, NAT 2', '9'),
	(641, 'BSPT 2021-2022PHYSIO 1', '12', '1', '2', 'PHYSIO 1', 'Systemic Physiology', '3', '3', '0', 'MT 100, NAT SCI 2', '3'),
	(642, 'BSPT 2021-2022MSCED 202', '12', '1', '2', 'MSCED 202', 'Advisorship Time', '0', '0', '0', 'None', '1'),
	(643, 'BSPT 2021-2022PT 1 ', '12', '1', '3', 'PT 1 ', 'Introduction to Physical Therapy', '3', '3', '0', 'Ana 1,Physio I,MT 100', '3'),
	(644, 'BSPT 2021-2022HUM 1', '12', '1', '3', 'HUM 1', 'Logic with Critical Thinking', '3', '3', '0', 'None', '3'),
	(645, 'BSPT 2021-2022GEN ELEC 1', '12', '1', '3', 'GEN ELEC 1', 'Living in the IT Era', '3', '3', '0', 'None', '3'),
	(646, 'BSPT 2021-2022GEN ELEC 2', '12', '1', '3', 'GEN ELEC 2', 'People and the Earth\'s Ecosystems', '3', '3', '0', 'None', '3'),
	(647, 'BSPT 2021-2022PE 3', '12', '2', '1', 'PE 3', 'Physical Education 3 (individual/Dual Sports)', '2', '2', '0', 'None', '2'),
	(648, 'BSPT 2021-2022ANA 2', '12', '2', '1', 'ANA 2', 'Applied Anatomy and Kinesiology', '5', '3', '2', 'Ana 1,Physio 1', '9'),
	(649, 'BSPT 2021-2022PSYCH', '12', '2', '1', 'PSYCH', 'Pychiatric Foundations', '3', '3', '0', '1st year subjects', '2'),
	(650, 'BSPT 2021-2022PT 201', '12', '2', '1', 'PT 201', 'Principles of PT Evaluation', '4', '2', '2', '1st year subjects', '8'),
	(651, 'BSPT 2021-2022HGD', '12', '2', '1', 'HGD', 'Human Development', '2', '2', '0', '1st year subjects', '2'),
	(652, 'BSPT 2021-2022CBR 201', '12', '2', '1', 'CBR 201', 'Community-Based Rehabilitation 1', '2', '2', '0', '1st year subjects', '2'),
	(653, 'BSPT 2021-2022STRAT', '12', '2', '1', 'STRAT', 'Teaching and Learning', '3', '2', '1', '1st year subjects', '5'),
	(654, 'BSPT 2021-2022PT 202', '12', '2', '1', 'PT 202', 'Physical Agents and Electrotherapy', '2', '1', '1', '1st year subjects', '4'),
	(655, 'BSPT 2021-2022MSCED 103', '12', '2', '1', 'MSCED 103', 'Advisorship Time', '0', '0', '0', 'None', '1'),
	(656, 'BSPT 2021-2022PE 4', '12', '2', '2', 'PE 4', 'Physical Education 4 (Team Sports)', '2', '2', '0', 'None', '2'),
	(657, 'BSPT 2021-2022MS 201', '12', '2', '2', 'MS 201', 'Orthopedic/Rheumatology/Sports PT 1', '3', '2', '1', '1st year subjects', '5'),
	(658, 'BSPT 2021-2022ANA 3', '12', '2', '2', 'ANA 3', 'Neuroanatomy', '3', '3', '0', 'ANA 2', '3'),
	(659, 'BSPT 2021-2022CBR 202', '12', '2', '2', 'CBR 202', 'Community Based Rehabilitation 2', '3', '2', '1', '1st year subjects', '5'),
	(660, 'BSPT 2021-2022MS 202', '12', '2', '2', 'MS 202', 'Neurologic PT', '3', '2', '0', '1st year subjects', '5'),
	(661, 'BSPT 2021-2022GERIA', '12', '2', '2', 'GERIA', 'Geriatric PT', '3', '2', '1', '1st year subjects', '5'),
	(662, 'BSPT 2021-2022O & A', '12', '2', '2', 'O & A', 'Organization and Administration', '3', '2', '1', '1st year subjects', '5'),
	(663, 'BSPT 2021-2022STRAT 2', '12', '2', '2', 'STRAT 2', 'Teaching and Learning 2  (mass education)', '2', '1', '1', '1st year subjects', '4'),
	(664, 'BSPT 2021-2022PT 203', '12', '2', '2', 'PT 203', 'Assistive technologies', '2', '1', '1', '1st year subjects', '4'),
	(665, 'BSPT 2021-2022PEDIA', '12', '2', '2', 'PEDIA', 'Pediatric PT', '3', '2', '1', '1st year subjects', '5'),
	(666, 'BSPT 2021-2022RESEARCH 1', '12', '2', '2', 'RESEARCH 1', 'Introduction to Research', '3', '3', '0', '1st year subjects', '3'),
	(667, 'BSPT 2021-2022MSCED 104', '12', '2', '2', 'MSCED 104', 'Advisorship Time', '0', '0', '0', 'None', '1'),
	(668, 'BSPT 2021-2022MS 203', '12', '2', '3', 'MS 203', 'Orthopedic/ Rheuma /Sports PT 2', '3', '1', '2', '1-2 year subjects', '7'),
	(669, 'BSPT 2021-2022PT 204', '12', '2', '3', 'PT 204', 'Wellness and Health Promotion 1', '2', '1', '1', '1-2 year subjects', '4'),
	(670, 'BSPT 2021-2022GEN ELEC 3', '12', '2', '3', 'GEN ELEC 3', 'Entrepreneurial Mind', '3', '3', '0', '1-2 year subjects', '3'),
	(671, 'BSPT 2021-2022COM DEV', '12', '2', '3', 'COM DEV', 'Community Development', '1', '1', '0', '1-2 year subjects', '1'),
	(672, 'BSPT 2021-2022MS 301', '12', '3', '1', 'MS 301', 'Orthopedic/Rheuma/ Sports PT 3', '3', '2', '1', '1-2 year subjects', '5'),
	(673, 'BSPT 2021-2022NEURO 1', '12', '3', '1', 'NEURO 1', 'Neurologic PT', '3', '1', '2', '1-2 year subjects', '7'),
	(674, 'BSPT 2021-2022CardioPulmo', '12', '3', '1', 'CardioPulmo', 'Cardiopulmonary PT', '3', '2', '1', '1-2 year subjects', '5'),
	(675, 'BSPT 2021-2022PT 301', '12', '3', '1', 'PT 301', 'Industrial Rehabilitation', '1', '1', '0', '1-2 year subjects', '1'),
	(676, 'BSPT 2021-2022RESEARCH 2', '12', '3', '1', 'RESEARCH 2', 'Research Proposal Writing', '2', '1', '1', '1-2 year subjects', '3'),
	(677, 'BSPT 2021-2022PT 302', '12', '3', '1', 'PT 302', 'Innovations in PT Service Delivery I (clinical system)', '1', '1', '0', '1-2 year subjects', '1'),
	(678, 'BSPT 2021-2022MS 302', '12', '3', '1', 'MS 302', 'Integumentary PT', '2', '1', '1', '1-2 year subjects', '4'),
	(679, 'BSPT 2021-2022MSCED 105', '12', '3', '1', 'MSCED 105', 'Advisorship Time 5', '0', '0', '0', 'None', '1'),
	(680, 'BSPT 2021-2022PT 303', '12', '3', '2', 'PT 303', 'Wellness and Health Promotion 2', '3', '2', '1', '1-2 year subjects', '5'),
	(681, 'BSPT 2021-2022INFORMATICS', '12', '3', '2', 'INFORMATICS', 'Health Informatics', '3', '2', '1', '1-2 year subjects', '5'),
	(682, 'BSPT 2021-2022RESEARCH 3', '12', '3', '2', 'RESEARCH 3', 'Research Implementation', '3', '1', '2', '1-2 year subjects', '7'),
	(683, 'BSPT 2021-2022PT 304', '12', '3', '2', 'PT 304', 'Innovations in PT service Delivery2 (non clinical)', '2', '2', '0', '1-2 year subjects', '2'),
	(684, 'BSPT 2021-2022PT 305', '12', '3', '2', 'PT 305', 'Seminar', '2', '0', '2', '1-2 year subjects', '6'),
	(685, 'BSPT 2021-2022PROF ETH', '12', '3', '2', 'PROF ETH', 'Professional Ethics', '6', '6', '0', '1-2 year subjects', '6'),
	(686, 'BSPT 2021-2022MSCED 106', '12', '3', '2', 'MSCED 106', 'Advisorship Time 6', '0', '0', '0', 'None', '1'),
	(687, 'BSPT 2021-2022PT 306', '12', '3', '3', 'PT 306', 'Health and Social Media', '1', '1', '0', '1-3 year subjects', '1'),
	(688, 'BSPT 2021-2022RESEARCH 4', '12', '3', '3', 'RESEARCH 4', 'Research Dissemination', '2', '1', '1', '1-3 year subjects', '4'),
	(689, 'BSPT 2021-2022CA 1', '12', '3', '3', 'CA 1', 'Competency Appraisal 1', '2', '2', '0', '1-3 year subjects', '2'),
	(690, 'BSPT 2021-2022INTERNSHIP 1', '12', '4', '1', 'INTERNSHIP 1', 'Internship 1', '6', '0', '6', '1-3 year subjects', ''),
	(691, 'BSPT 2021-2022INTERNSHIP 2', '12', '4', '1', 'INTERNSHIP 2', 'Internship 2', '6', '0', '6', '1-3 year subjects', ''),
	(692, 'BSPT 2021-2022RESEARCH 5', '12', '4', '1', 'RESEARCH 5', 'Research Translation and Writing for Publication', '2', '2', '0', '1-3 year subjects', '2'),
	(693, 'BSPT 2021-2022CA 2', '12', '4', '1', 'CA 2', 'Competency Appraisal 2', '2', '2', '0', '1-3 year subjects', '2'),
	(694, 'BSPT 2021-2022MSCED 107', '12', '4', '1', 'MSCED 107', 'Advisorship Time 7', '0', '0', '0', 'None', '1'),
	(695, 'BSPT 2021-2022INTERNSHIP 3', '12', '4', '2', 'INTERNSHIP 3', 'Internship 3', '9', '0', '9', '1-3 year subjects', ''),
	(696, 'BSPT 2021-2022INTERNSHIP 4', '12', '4', '2', 'INTERNSHIP 4', 'Internship 4', '9', '0', '9', '1-3 year subjects', ''),
	(697, 'BSPT 2021-2022CA 3', '12', '4', '2', 'CA 3', 'Competency Appraisal 3', '2', '2', '0', '1-3 year subjects', '2'),
	(698, 'BSPT 2021-2022MSCED 108', '12', '4', '2', 'MSCED 108', 'Advisorship Time 8', '0', '0', '0', 'None', '1');

-- Dumping structure for table model_test_db.departments
CREATE TABLE IF NOT EXISTS `departments` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `campus_id` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.departments: ~2 rows (approximately)
INSERT INTO `departments` (`id`, `code`, `description`, `campus_id`) VALUES
	(10, 'CBEM', 'College of Business Education Management', 6),
	(11, 'NURSING', 'College of Nursing', 6),
	(12, 'PHYSICAL-THERAPY', 'PHYSICAL-THERAPY', 6);

-- Dumping structure for table model_test_db.discount_setup
CREATE TABLE IF NOT EXISTS `discount_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `code` varchar(50) NOT NULL,
  `discount_target` varchar(50) NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `discount_percentage` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.discount_setup: ~2 rows (approximately)
INSERT INTO `discount_setup` (`id`, `code`, `discount_target`, `description`, `discount_percentage`) VALUES
	(11, 'TOP 1', 'Tuition Fee', '100% DISCOUNT TUITION AND MISCELLANEOUS', 100),
	(12, 'TOP 1', 'Miscellaneous Fee', '100% DISCOUNT TUITION AND MISCELLANEOUS', 100);

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.fee_breakdown: ~6 rows (approximately)
INSERT INTO `fee_breakdown` (`id`, `id_number`, `school_year`, `downpayment`, `prelim`, `midterm`, `semi_finals`, `finals`, `total`, `downpayment_original`, `prelim_original`, `midterm_original`, `semi_finals_original`, `finals_original`, `total_original`) VALUES
	(10, '2023-1-0001', '2023-2024-1', 0.00, 421.82, 460.91, 460.91, 460.91, 1804.55, 780.30, 780.30, 780.30, 780.30, 780.30, 3901.48),
	(11, '2023-1-0002', '2023-2024-1', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 460.91, 460.91, 460.91, 460.91, 460.91, 2304.54),
	(13, '2024-1-0003', '2023-2024-1', 0.00, 0.00, 0.00, 0.00, 192.30, 192.30, 1738.46, 1738.46, 1738.46, 1738.46, 1738.46, 8692.29),
	(14, '2024-1-0004', '2023-2024-1', 0.00, 0.00, 1415.38, 1738.46, 1738.46, 4892.30, 1738.46, 1738.46, 1738.46, 1738.46, 1738.46, 8692.29),
	(15, '2024-1-0005', '2023-2024-1', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1738.46, 1738.46, 1738.46, 1738.46, 1738.46, 8692.29),
	(16, '2024-1-0006', '2023-2024-1', 0.00, 0.00, 0.00, 1453.84, 1738.46, 3192.30, 1738.46, 1738.46, 1738.46, 1738.46, 1738.46, 8692.29);

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.fee_summary: ~6 rows (approximately)
INSERT INTO `fee_summary` (`id`, `id_number`, `school_year`, `current_assessment`, `discounts`, `previous_balance`, `current_receivable`) VALUES
	(2, '2023-1-0001', '2023-2024-1', 8692.29, 4790.81, 0.00, 3901.48),
	(5, '2023-1-0002', '2023-2024-1', 8692.29, 6387.75, 0.00, 2304.54),
	(7, '2024-1-0003', '2023-2024-1', 8692.29, 0.00, 0.00, 8692.29),
	(8, '2024-1-0004', '2023-2024-1', 8692.29, 0.00, 0.00, 8692.29),
	(9, '2024-1-0005', '2023-2024-1', 8692.29, 0.00, 0.00, 8692.29),
	(10, '2024-1-0006', '2023-2024-1', 8692.29, 0.00, 0.00, 8692.29);

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
  `department_id` int NOT NULL DEFAULT '0',
  `position` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.instructors: ~0 rows (approximately)

-- Dumping structure for table model_test_db.lab_fee_setup
CREATE TABLE IF NOT EXISTS `lab_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  `second_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  `third_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  `fourth_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.lab_fee_setup: ~4 rows (approximately)
INSERT INTO `lab_fee_setup` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(5, 'Laboratory Fee', 'CHEMISTRY LAB', 'MCNP', 450.25, 450.25, 450.25, 450.25),
	(6, 'Laboratory Fee', 'PHYSICS LAB', 'MCNP', 450.25, 450.25, 450.25, 450.25),
	(7, 'Laboratory Fee', 'PHYSICAL THERAPY LAB', 'MCNP', 205.50, 205.50, 205.50, 205.50),
	(8, 'Laboratory Fee', 'RAD TECH LAB', 'MCNP', 125.25, 125.25, 125.25, 125.25);

-- Dumping structure for table model_test_db.lab_fee_subjects
CREATE TABLE IF NOT EXISTS `lab_fee_subjects` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `lab_fee_id` int NOT NULL DEFAULT '0',
  `subject_code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `descriptive_title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`id`),
  UNIQUE KEY `subject_code` (`subject_code`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.lab_fee_subjects: ~0 rows (approximately)
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.levels: ~2 rows (approximately)
INSERT INTO `levels` (`id`, `code`, `description`, `status`) VALUES
	(7, 'COL', 'COLLEGE', 'Active'),
	(8, 'JHS', 'Junior High School', 'Active');

-- Dumping structure for table model_test_db.miscellaneous_fee_setup
CREATE TABLE IF NOT EXISTS `miscellaneous_fee_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `description` varchar(50) NOT NULL,
  `campus` varchar(50) NOT NULL,
  `first_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `second_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `third_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  `fourth_year` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.miscellaneous_fee_setup: ~4 rows (approximately)
INSERT INTO `miscellaneous_fee_setup` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(20, 'Miscellaneous Fee', 'PE UNIFORM', 'MCNP', 450.50, 450.50, 450.50, 450.50),
	(21, 'Miscellaneous Fee', 'Internet Fee', 'MCNP', 500.12, 500.12, 500.12, 500.12),
	(22, 'Miscellaneous Fee', 'PE UNIFORM', 'ISAP', 500.12, 500.12, 500.12, 500.12),
	(23, 'Miscellaneous Fee', 'INTERNET FEE', 'ISAP', 500.12, 500.12, 500.12, 500.12);

-- Dumping structure for table model_test_db.other_fees
CREATE TABLE IF NOT EXISTS `other_fees` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `campus` varchar(100) NOT NULL,
  `first_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  `second_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  `third_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  `fourth_year` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.other_fees: ~2 rows (approximately)
INSERT INTO `other_fees` (`id`, `category`, `description`, `campus`, `first_year`, `second_year`, `third_year`, `fourth_year`) VALUES
	(1, 'Other Fees', 'Student Information and Accounting Systems', 'ISAP', 652.15, 652.15, 652.15, 652.15),
	(2, 'Other Fees', 'Learning Management System', 'ISAP', 652.15, 652.15, 652.15, 652.15);

-- Dumping structure for table model_test_db.reference_number_setup
CREATE TABLE IF NOT EXISTS `reference_number_setup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `reference_number` int unsigned DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.reference_number_setup: ~0 rows (approximately)
INSERT INTO `reference_number_setup` (`id`, `reference_number`) VALUES
	(1, 1000329);

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.school_year: ~2 rows (approximately)
INSERT INTO `school_year` (`id`, `code`, `description`, `school_year_from`, `school_year_to`, `semester`, `is_current`) VALUES
	(9, '2023-2024-1', 'SY 2023-2024, 1ST Semester', '12-06-2023', '12-13-2023', '1', 'Yes'),
	(10, '2023-2024-2', 'SY 2023-2024, 2nd Semester', '01-01-2024', '01-31-2024', '2', 'No');

-- Dumping structure for table model_test_db.sections
CREATE TABLE IF NOT EXISTS `sections` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `unique_id` varchar(255) NOT NULL,
  `section_code` varchar(255) NOT NULL,
  `course_id` int NOT NULL DEFAULT '0',
  `year_level` int NOT NULL DEFAULT '0',
  `section` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `semester` varchar(255) NOT NULL,
  `number_of_students` int NOT NULL,
  `max_number_of_students` int NOT NULL,
  `status` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `remarks` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.sections: ~0 rows (approximately)
INSERT INTO `sections` (`id`, `unique_id`, `section_code`, `course_id`, `year_level`, `section`, `semester`, `number_of_students`, `max_number_of_students`, `status`, `remarks`) VALUES
	(41, 'BSPT-1-ABSPT11', 'BSPT-1-A', 12, 1, 'A', '1', 0, 50, 'Available', 'Regular');

-- Dumping structure for table model_test_db.section_subjects
CREATE TABLE IF NOT EXISTS `section_subjects` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `unique_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '0',
  `section_code_id` int DEFAULT NULL,
  `curriculum_id` int DEFAULT NULL,
  `course_id` int DEFAULT NULL,
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
  `instructor_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_id` (`unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=213 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.section_subjects: ~0 rows (approximately)

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
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.statements_of_accounts: ~27 rows (approximately)
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
	(78, '2024-1-0003', '2023-2024-1', '01-08-2024', 'BSCA', '1', '1', 1000313, 'Prelims Payment', 8692.29, 6500.00, 2192.29, ''),
	(79, '2024-1-0003', '2023-2024-1', '01-09-2024', 'BSCA', '1', '1', 1000314, 'Semi-Finals Collection', 2192.29, 500.00, 1692.29, ''),
	(80, '2024-1-0003', '2023-2024-1', '01-09-2024', 'BSCA', '1', '1', 1000315, 'Finals Payment', 1692.29, 1000.00, 692.29, ''),
	(81, '2024-1-0003', '2023-2024-1', '01-09-2024', 'BSCA', '1', '1', 1000316, 'Additional Fee', 692.29, 500.00, 192.29, ''),
	(82, '2024-1-0004', '2023-2024-1', '01-09-2024', 'BSCA', '1', '1', 1000317, 'Total Assessment as of: 2023-2024-1', 8692.29, 0.00, 8692.29, ''),
	(83, '2024-1-0004', '2023-2024-1', '01-09-2024', 'BSCA', '1', '1', 1000318, 'Initial Downpayment', 8692.29, 500.00, 8192.29, ''),
	(84, '2024-1-0005', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000319, 'Total Assessment as of: 2023-2024-1', 8692.29, 0.00, 8692.29, ''),
	(85, '2024-1-0005', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000320, 'Downpayment', 8692.29, 6500.00, 2192.29, ''),
	(86, '2024-1-0005', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000321, '', 2192.29, 453.84, 1738.45, ''),
	(87, '2024-1-0005', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000322, '', 1738.45, 1192.30, 546.15, ''),
	(88, '2024-1-0004', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000323, '', 8192.29, 1238.46, 6953.83, ''),
	(89, '2024-1-0004', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000324, 'Prelims Payment', 6953.83, 1676.92, 5276.91, ''),
	(90, '2024-1-0006', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000325, 'Total Assessment as of: 2023-2024-1', 8692.29, 0.00, 8692.29, ''),
	(91, '2024-1-0006', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000326, '', 8692.29, 500.00, 8192.29, ''),
	(92, '2024-1-0006', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000327, 'Prelims', 8192.29, 738.46, 7453.83, ''),
	(93, '2024-1-0006', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000328, '', 7453.83, 1476.92, 5976.91, ''),
	(94, '2024-1-0006', '2023-2024-1', '01-10-2024', 'BSCA', '1', '1', 1000329, 'Midterms Payment', 5976.91, 1715.38, 4261.53, '');

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
) ENGINE=InnoDB AUTO_INCREMENT=150 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_accounts: ~0 rows (approximately)
INSERT INTO `student_accounts` (`id`, `id_number`, `sy_enrolled`, `school_year`, `fullname`, `last_name`, `first_name`, `middle_name`, `gender`, `civil_status`, `date_of_birth`, `place_of_birth`, `nationality`, `religion`, `status`, `contact_no`, `email`, `elem`, `jhs`, `shs`, `elem_year`, `jhs_year`, `shs_year`, `mother_name`, `mother_no`, `father_name`, `father_no`, `home_address`, `m_occupation`, `f_occupation`, `type_of_student`, `date_of_admission`) VALUES
	(149, '2024-1-0001', '2023-2024-1', '2023-2024-1', 'Manglallan, Derrick Daniel', 'Manglallan', 'Derrick', 'Daniel', 'Male', 'Single', '', '', '', '', 'Pending', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'Freshmen', '24/01/2024');

-- Dumping structure for table model_test_db.student_assessment
CREATE TABLE IF NOT EXISTS `student_assessment` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `school_year` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `fee_type` varchar(50) NOT NULL,
  `amount` decimal(20,2) NOT NULL DEFAULT '0.00',
  `units` decimal(20,2) NOT NULL DEFAULT '0.00',
  `computation` decimal(20,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=285 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_assessment: ~0 rows (approximately)
INSERT INTO `student_assessment` (`id`, `id_number`, `school_year`, `fee_type`, `amount`, `units`, `computation`) VALUES
	(240, '2023-1-0001', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, 26.00, 6387.75),
	(241, '2023-1-0001', '2023-2024-1', 'PE UNIFORM', 500.12, 1.00, 500.12),
	(242, '2023-1-0001', '2023-2024-1', 'INTERNET FEE', 500.12, 1.00, 500.12),
	(243, '2023-1-0001', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, 1.00, 652.15),
	(244, '2023-1-0001', '2023-2024-1', 'Learning Management System', 652.15, 1.00, 652.15),
	(255, '2023-1-0002', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, 26.00, 6387.75),
	(256, '2023-1-0002', '2023-2024-1', 'PE UNIFORM', 500.12, 1.00, 500.12),
	(257, '2023-1-0002', '2023-2024-1', 'INTERNET FEE', 500.12, 1.00, 500.12),
	(258, '2023-1-0002', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, 1.00, 652.15),
	(259, '2023-1-0002', '2023-2024-1', 'Learning Management System', 652.15, 1.00, 652.15),
	(265, '2024-1-0003', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, 26.00, 6387.75),
	(266, '2024-1-0003', '2023-2024-1', 'PE UNIFORM', 500.12, 1.00, 500.12),
	(267, '2024-1-0003', '2023-2024-1', 'INTERNET FEE', 500.12, 1.00, 500.12),
	(268, '2024-1-0003', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, 1.00, 652.15),
	(269, '2024-1-0003', '2023-2024-1', 'Learning Management System', 652.15, 1.00, 652.15),
	(270, '2024-1-0004', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, 26.00, 6387.75),
	(271, '2024-1-0004', '2023-2024-1', 'PE UNIFORM', 500.12, 1.00, 500.12),
	(272, '2024-1-0004', '2023-2024-1', 'INTERNET FEE', 500.12, 1.00, 500.12),
	(273, '2024-1-0004', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, 1.00, 652.15),
	(274, '2024-1-0004', '2023-2024-1', 'Learning Management System', 652.15, 1.00, 652.15),
	(275, '2024-1-0005', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, 26.00, 6387.75),
	(276, '2024-1-0005', '2023-2024-1', 'PE UNIFORM', 500.12, 1.00, 500.12),
	(277, '2024-1-0005', '2023-2024-1', 'INTERNET FEE', 500.12, 1.00, 500.12),
	(278, '2024-1-0005', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, 1.00, 652.15),
	(279, '2024-1-0005', '2023-2024-1', 'Learning Management System', 652.15, 1.00, 652.15),
	(280, '2024-1-0006', '2023-2024-1', 'TUITION FEE/UNIT', 250.50, 26.00, 6387.75),
	(281, '2024-1-0006', '2023-2024-1', 'PE UNIFORM', 500.12, 1.00, 500.12),
	(282, '2024-1-0006', '2023-2024-1', 'INTERNET FEE', 500.12, 1.00, 500.12),
	(283, '2024-1-0006', '2023-2024-1', 'Student Information and Accounting Systems', 652.15, 1.00, 652.15),
	(284, '2024-1-0006', '2023-2024-1', 'Learning Management System', 652.15, 1.00, 652.15);

-- Dumping structure for table model_test_db.student_course
CREATE TABLE IF NOT EXISTS `student_course` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number_id` int NOT NULL DEFAULT '0',
  `course_id` int DEFAULT NULL,
  `campus_id` int DEFAULT NULL,
  `curriculum_id` int DEFAULT NULL,
  `year_level` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `section_id` int DEFAULT NULL,
  `semester` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_number` (`id_number_id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_course: ~0 rows (approximately)
INSERT INTO `student_course` (`id`, `id_number_id`, `course_id`, `campus_id`, `curriculum_id`, `year_level`, `section_id`, `semester`) VALUES
	(102, 149, 11, 7, 11, NULL, NULL, 1);

-- Dumping structure for table model_test_db.student_discounts
CREATE TABLE IF NOT EXISTS `student_discounts` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `id_number` varchar(50) NOT NULL,
  `code` varchar(50) NOT NULL,
  `discount_target` varchar(50) NOT NULL,
  `description` varchar(50) NOT NULL,
  `discount_percentage` int NOT NULL DEFAULT '0',
  `duration_from` varchar(50) NOT NULL,
  `duration_to` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_discounts: ~0 rows (approximately)
INSERT INTO `student_discounts` (`id`, `id_number`, `code`, `discount_target`, `description`, `discount_percentage`, `duration_from`, `duration_to`) VALUES
	(17, '2023-1-0001', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75, '', ''),
	(18, '2023-1-0003', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75, '', ''),
	(19, '2023-1-0008', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75, '', ''),
	(20, '2023-1-0004', 'President-Lister-75%', 'Tuition Fee', 'President Lister Discount', 75, '', ''),
	(21, '2024-1-0007', 'top 1', 'Other Fee', 'top 1 class valedictorian', 100, '', ''),
	(23, '2023-1-0002', 'TOP 1', 'Miscellaneous Fee', '100% DISCOUNT TUITION AND MISCELLANEOUS', 100, '', ''),
	(24, '2024-1-0005', 'TOP 1', 'Miscellaneous Fee', '100% DISCOUNT TUITION AND MISCELLANEOUS', 100, '01-01-2024', '21-01-2025'),
	(25, '2024-1-0005', 'TOP 1', 'Tuition Fee', '100% DISCOUNT TUITION AND MISCELLANEOUS', 100, '21-01-2024', '21-01-2025');

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
) ENGINE=InnoDB AUTO_INCREMENT=648 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.student_subjects: ~0 rows (approximately)
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
	(617, '2024-1-0003', '2024-1-0003-2024-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending'),
	(618, '2024-1-0004', '2024-1-0004-2024-1-GEC 1', '2023-2024-1', 'GEC 1', 'Understanding the Self', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(619, '2024-1-0004', '2024-1-0004-2024-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(620, '2024-1-0004', '2024-1-0004-2024-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(621, '2024-1-0004', '2024-1-0004-2024-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(622, '2024-1-0004', '2024-1-0004-2024-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(623, '2024-1-0004', '2024-1-0004-2024-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(624, '2024-1-0004', '2024-1-0004-2024-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', 0, 'Pending'),
	(625, '2024-1-0004', '2024-1-0004-2024-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(626, '2024-1-0004', '2024-1-0004-2024-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', 0, 'Pending'),
	(627, '2024-1-0004', '2024-1-0004-2024-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending'),
	(628, '2024-1-0005', '2024-1-0005-2024-1-GEC 1', '2023-2024-1', 'GEC 1', 'Understanding the Self', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(629, '2024-1-0005', '2024-1-0005-2024-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(630, '2024-1-0005', '2024-1-0005-2024-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(631, '2024-1-0005', '2024-1-0005-2024-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(632, '2024-1-0005', '2024-1-0005-2024-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(633, '2024-1-0005', '2024-1-0005-2024-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(634, '2024-1-0005', '2024-1-0005-2024-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', 0, 'Pending'),
	(635, '2024-1-0005', '2024-1-0005-2024-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(636, '2024-1-0005', '2024-1-0005-2024-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', 0, 'Pending'),
	(637, '2024-1-0005', '2024-1-0005-2024-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending'),
	(638, '2024-1-0006', '2024-1-0006-2024-1-GEC 1', '2023-2024-1', 'GEC 1', 'Understanding the Self', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(639, '2024-1-0006', '2024-1-0006-2024-1-GEC 2', '2023-2024-1', 'GEC 2', 'Readings in the Philippine History', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(640, '2024-1-0006', '2024-1-0006-2024-1-GEC 3', '2023-2024-1', 'GEC 3', 'The Contemporary World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(641, '2024-1-0006', '2024-1-0006-2024-1-GEC 4', '2023-2024-1', 'GEC 4', 'Mathematics in the Modern World', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(642, '2024-1-0006', '2024-1-0006-2024-1-SBEC 100', '2023-2024-1', 'SBEC 100', 'International Trade', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(643, '2024-1-0006', '2024-1-0006-2024-1-GEC 5', '2023-2024-1', 'GEC 5', 'Purposive Communication', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(644, '2024-1-0006', '2024-1-0006-2024-1-PE 101', '2023-2024-1', 'PE 101', 'Physical Education 1 (Physical Fitness)', 'None', '2.0', '2.0', '0.0', '', '', '', '', 0, 'Pending'),
	(645, '2024-1-0006', '2024-1-0006-2024-1-NSTP 1', '2023-2024-1', 'NSTP 1', 'National Service Training Program 1', 'None', '3.0', '3.0', '0.0', '', '', '', '', 0, 'Pending'),
	(646, '2024-1-0006', '2024-1-0006-2024-1-ETHICS 100', '2023-2024-1', 'ETHICS 100', 'ISAPian Education with Values Formation', 'None', '1.5', '1.5', '0.0', '', '', '', '', 0, 'Pending'),
	(647, '2024-1-0006', '2024-1-0006-2024-1-MSCED 201', '2023-2024-1', 'MSCED 201', 'Advisorship Time', 'None', '0.0', '1.0', '0.0', '', '', '', '', 0, 'Pending');

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

-- Dumping structure for table model_test_db.tuitionfeesetup
CREATE TABLE IF NOT EXISTS `tuitionfeesetup` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `uid` varchar(755) NOT NULL DEFAULT '0',
  `category` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `description` varchar(255) NOT NULL,
  `campus_id` int NOT NULL DEFAULT '0',
  `level_id` int NOT NULL DEFAULT '0',
  `year_level` varchar(255) NOT NULL,
  `semester` varchar(255) NOT NULL,
  `amount` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uid` (`uid`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.tuitionfeesetup: ~0 rows (approximately)
INSERT INTO `tuitionfeesetup` (`id`, `uid`, `category`, `description`, `campus_id`, `level_id`, `year_level`, `semester`, `amount`) VALUES
	(26, 'Tuition Fee611', 'Tuition Fee', 'Tuition Fee Per Unit', 6, 7, '1', '1', 123.32),
	(27, 'Tuition Fee621', 'Tuition Fee', 'Tuition Fee Per Unit', 6, 7, '2', '1', 234.45),
	(28, 'Tuition Fee631', 'Tuition Fee', 'Tuition Fee Per Unit', 6, 7, '3', '1', 345.34),
	(29, 'Tuition Fee641', 'Tuition Fee', 'Tuition Fee Per Unit', 6, 7, '4', '1', 456.32),
	(30, 'Tuition Fee711', 'Tuition Fee', 'Tuition Fee Per Unit', 7, 7, '1', '1', 123.23),
	(31, 'Tuition Fee721', 'Tuition Fee', 'Tuition Fee Per Unit', 7, 7, '2', '1', 234.45),
	(32, 'Tuition Fee731', 'Tuition Fee', 'Tuition Fee Per Unit', 7, 7, '3', '1', 345.54);

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

-- Dumping data for table model_test_db.tuition_fee_setup: ~0 rows (approximately)
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table model_test_db.users: ~6 rows (approximately)
INSERT INTO `users` (`id`, `last_name`, `first_name`, `middle_name`, `fullname`, `employee_id`, `email`, `password`, `department`, `access_level`, `is_add`, `is_edit`, `is_delete`, `is_administrator`, `picture`) VALUES
	(2, 'Manglallan', 'Derrick', 'Daniel', 'Manglallan, Derrick Daniel', '353', '123', '$2a$11$DMNzmgLxhI7vHa/6FURPeO.vKvbx5tL8FJtgp.JB5kUpk3hJGNQKy', 'Finance', 'Administrator', 1, 1, 1, 1, NULL),
	(4, 'Buguina', 'Melenio', 'M', 'Buguina, Melenio M', '456', 'mbuguina@isap.edu.ph', '$2a$11$R/KM9DYyxO1MfmD.EceeUefnLihhbzxcKbycna8Z8VFu.UVBKrit2', 'Registrar', 'User', 1, 0, 0, 0, NULL),
	(5, 'Pingad', 'Airon', 'Jim', 'Pingad, Airon Jim', '465', 'apingad@isap.edu.ph', '$2a$11$UcXUgEDrguxicXmZHDc8W.j1HXpp4EsZcfyWLV68S3ABSpdp8mFy.', '', 'Finance User', 1, 0, 0, 0, NULL),
	(6, 'Alan', 'Charity', 'T', 'Alan, Charity T', '437', 'charlan@isap.edu.ph', '$2a$11$DPX8ta.xEPMBuHJf8ml6y.biLFItS0F7Oz901aewnDYleGO3DB5iu', 'Finance', 'Cashier', 1, 1, 0, 0, NULL),
	(8, 'Geron', 'Richard', 'T', 'Geron, Richard T', '656', 'rgeron@isap.edu.ph', '$2a$11$eStCGpUIIHEVBMUrXpBbZOOIWOPircEb2sZ1Ow5EJRXTAkIv3.EfC', 'Finance', 'Student Accounts', 1, 1, 1, 0, NULL),
	(9, 'Registrar', 'Administrator', '', 'Registrar, Administrator ', '333', 'reg.admin', '$2a$11$EaQYzygq2nVZEQfOkFtOteQYy8u85vBkOLWNq.TvM3SG7yWqDIQQK', 'Registrar', 'Administrator', 1, 1, 1, 1, NULL);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
