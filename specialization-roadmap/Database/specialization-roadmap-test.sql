-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 24, 2023 at 11:23 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `specialization-roadmap-test`
--

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `CourseID` int(11) NOT NULL,
  `CourseName` varchar(100) NOT NULL,
  `CourseDescription` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`CourseID`, `CourseName`, `CourseDescription`) VALUES
(1, 'HTML', 'HTML stands for HyperText Markup Language. It is a standard markup language for web page creation. It allows the creation and structure of sections, paragraphs, and links using HTML elements (the building blocks of a web page) such as tags and attributes. \r\n\r\n'),
(2, 'CSS', 'CSS or Cascading Style Sheets is the language used to style the frontend of any website. CSS is a cornerstone technology of the World Wide Web, alongside HTML and JavaScript.'),
(3, 'JavaScript', 'JavaScript allows you to add interactivity to your pages. Common examples that you may have seen on the websites are sliders, click interactions, popups and so on.'),
(4, 'Git', 'Git is a free and open source distributed version control system designed to handle everything from small to very large projects with speed and efficiency.'),
(5, 'Internet', 'The Internet is a global network of computers connected to each other which communicate through a standardized set of protocols.'),
(6, 'PHP', 'PHP is a general purpose scripting language often used for making dynamic and interactive Web pages. It was originally created by Danish-Canadian programmer Rasmus Lerdorf in 1994. The PHP reference implementation is now produced by The PHP Group and supported by PHP Foundation. PHP supports procedural and object-oriented styles of programming with some elements of functional programming as well.');

-- --------------------------------------------------------

--
-- Table structure for table `resources`
--

CREATE TABLE `resources` (
  `ResourceID` int(11) NOT NULL,
  `CourseID` int(11) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `Link` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `resources`
--

INSERT INTO `resources` (`ResourceID`, `CourseID`, `Title`, `Link`) VALUES
(1, 1, 'HTML Basics Explained', 'https://www.hostinger.ph/tutorials/what-is-html'),
(2, 1, 'W3Schools: Learn HTML', 'https://www.w3schools.com/html/html_intro.asp'),
(3, 2, 'Learn CSS - Codecademy', 'https://www.codecademy.com/learn/learn-css'),
(4, 2, 'CSS Complete Course', 'https://youtu.be/n4R2E7O-Ngo'),
(5, 3, 'W3Schools – JavaScript Tutorial', 'https://www.w3schools.com/js/'),
(6, 3, 'The Modern JavaScript Tutorial', 'https://javascript.info/'),
(7, 4, 'Git & GitHub Crash Course For Beginners', 'https://www.youtube.com/watch?v=SWYqp7iY_Tc'),
(8, 4, 'Tutorial: Git for Absolutely Everyone', 'https://thenewstack.io/tutorial-git-for-absolutely-everyone/'),
(9, 5, 'How does the Internet Work?', 'https://cs.fyi/guide/how-does-internet-work'),
(10, 5, 'The Internet Explained', 'https://www.vox.com/2014/6/16/18076282/the-internet'),
(11, 6, 'Learn PHP - W3Schools', 'https://www.w3schools.com/php/'),
(12, 6, 'PHP for Beginners', 'https://www.youtube.com/watch?v=U2lQWR6uIuo&list=PL3VM-unCzF8ipG50KDjnzhugceoSG3RTC');

-- --------------------------------------------------------

--
-- Table structure for table `roadmap`
--

CREATE TABLE `roadmap` (
  `RoadmapID` int(11) NOT NULL,
  `SpecializationID` int(11) NOT NULL,
  `CourseID` int(11) NOT NULL,
  `Step` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `roadmap`
--

INSERT INTO `roadmap` (`RoadmapID`, `SpecializationID`, `CourseID`, `Step`) VALUES
(1, 1, 5, 1),
(2, 1, 1, 2),
(3, 1, 2, 3),
(4, 1, 3, 4),
(5, 1, 4, 6),
(6, 2, 5, 1),
(7, 2, 4, 2),
(8, 2, 3, 3),
(9, 2, 6, 4);

-- --------------------------------------------------------

--
-- Table structure for table `specialization`
--

CREATE TABLE `specialization` (
  `SpecializationID` int(11) NOT NULL,
  `SpecializationName` varchar(100) NOT NULL,
  `SpecializationDescription` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `specialization`
--

INSERT INTO `specialization` (`SpecializationID`, `SpecializationName`, `SpecializationDescription`) VALUES
(1, 'Frontend Developer', 'Front-end development is the development of visual and interactive elements of a website that users interact with directly. It\'s a combination of HTML, CSS and JavaScript, where HTML provides the structure, CSS the styling and layout, and JavaScript the dynamic behaviour and interactivity.\r\n\r\nAs a front-end developer, you\'ll be responsible for creating the user interface of a website, to ensure it looks good and is easy to use, with great focus on design principles and user experience. You\'ll be'),
(2, 'Backend Developer', 'Backend web development is the part of web development that deals with the server-side of a web application. This includes creating and managing the server-side logic, connecting the application to a database, creating server-side APIs, handling user authentication and authorization, and processing and responding to user requests. It often involves the use of programming languages such as Python, Java, Ruby, PHP, JavaScript (Node.js), and .NET languages.\r\n\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `UserID` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`UserID`, `username`, `email`, `password`) VALUES
(1, 'Jesriel Ledesma', 'jesriel@gmail.com', 'jesriel123'),
(2, 'Test ', 'test@gmail.com', 'test123'),
(3, 'Aky Ligsay', 'ligsay@gmail.com', 'ligsay123'),
(4, 'CL Boceso', 'boceso@gmail.com', 'boceso'),
(5, 'Kristof Pambid', 'pambid@gmail.com', 'pambid123'),
(6, 'Decelyn Kalaw', 'kalaw@gmail.com', 'kalaw123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`CourseID`);

--
-- Indexes for table `resources`
--
ALTER TABLE `resources`
  ADD PRIMARY KEY (`ResourceID`);

--
-- Indexes for table `roadmap`
--
ALTER TABLE `roadmap`
  ADD PRIMARY KEY (`RoadmapID`);

--
-- Indexes for table `specialization`
--
ALTER TABLE `specialization`
  ADD PRIMARY KEY (`SpecializationID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `CourseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `resources`
--
ALTER TABLE `resources`
  MODIFY `ResourceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `roadmap`
--
ALTER TABLE `roadmap`
  MODIFY `RoadmapID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `specialization`
--
ALTER TABLE `specialization`
  MODIFY `SpecializationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
