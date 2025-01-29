-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 29, 2025 at 05:54 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sms`
--

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `student_id` varchar(100) DEFAULT NULL,
  `student_name` varchar(100) DEFAULT NULL,
  `student_gender` varchar(100) DEFAULT NULL,
  `student_address` varchar(100) DEFAULT NULL,
  `student_grade` varchar(100) DEFAULT NULL,
  `student_section` varchar(100) DEFAULT NULL,
  `student_image` varchar(100) DEFAULT NULL,
  `student_status` varchar(100) DEFAULT NULL,
  `date_insert` date DEFAULT NULL,
  `date_update` date DEFAULT NULL,
  `date_delete` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `student_id`, `student_name`, `student_gender`, `student_address`, `student_grade`, `student_section`, `student_image`, `student_status`, `date_insert`, `date_update`, `date_delete`) VALUES
(2, 'S002', 'Test 2', 'Male', 'Test 2', 'Grade 11', 'E', NULL, 'Pending', '2025-01-29', NULL, NULL),
(3, 'S003', 'Test 3', 'Female', 'Test 3', 'Grade 4', 'B', NULL, 'Graduated', '2025-01-29', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE `teachers` (
  `id` int(11) NOT NULL,
  `teacher_id` varchar(100) DEFAULT NULL,
  `teacher_name` varchar(100) DEFAULT NULL,
  `teacher_gender` varchar(100) DEFAULT NULL,
  `teacher_address` varchar(100) DEFAULT NULL,
  `teacher_image` varchar(100) DEFAULT NULL,
  `teacher_status` varchar(100) DEFAULT NULL,
  `date_insert` date DEFAULT NULL,
  `date_update` date DEFAULT NULL,
  `date_delete` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`id`, `teacher_id`, `teacher_name`, `teacher_gender`, `teacher_address`, `teacher_image`, `teacher_status`, `date_insert`, `date_update`, `date_delete`) VALUES
(1, 'T001', 'Test', 'Female', 'Test', NULL, 'Active', NULL, NULL, NULL),
(2, 'T002', 'Test2', 'Male', 'Test 2 changed', NULL, 'Active', '0000-00-00', NULL, NULL),
(3, 'T003', 'Test 3', 'Others', 'Test 3', NULL, 'Active', '2024-12-22', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`) VALUES
(1, 'admin', '123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `teachers`
--
ALTER TABLE `teachers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
