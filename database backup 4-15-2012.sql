-- phpMyAdmin SQL Dump
-- version 3.3.10.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 15, 2012 at 04:42 PM
-- Server version: 5.0.91
-- PHP Version: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `teamchro_LATSQL`
--
CREATE DATABASE `teamchro_LATSQL` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `teamchro_LATSQL`;

-- --------------------------------------------------------

--
-- Table structure for table `Admin`
--

CREATE TABLE IF NOT EXISTS `Admin` (
  `ID` int(11) NOT NULL,
  PRIMARY KEY  (`ID`),
  KEY `AID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Admin`
--

INSERT INTO `Admin` (`ID`) VALUES
(1),
(16);

-- --------------------------------------------------------

--
-- Table structure for table `Employee Jobs`
--

CREATE TABLE IF NOT EXISTS `Employee Jobs` (
  `ID` int(11) NOT NULL,
  `JID` varchar(50) NOT NULL,
  `JPay` decimal(3,2) NOT NULL,
  KEY `EJID` (`ID`),
  KEY `EJJID` (`JID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Employee Jobs`
--

INSERT INTO `Employee Jobs` (`ID`, `JID`, `JPay`) VALUES
(1, 'Manager', '9.99'),
(2, 'Server', '3.75'),
(10, 'Server', '3.75'),
(10, 'Cook', '8.10'),
(11, 'Bartender', '8.00');

-- --------------------------------------------------------

--
-- Table structure for table `Employee`
--

CREATE TABLE IF NOT EXISTS `Employee` (
  `ID` int(11) NOT NULL auto_increment,
  `LName` text NOT NULL,
  `MName` varchar(20) NOT NULL,
  `FName` text NOT NULL,
  `SSN` text NOT NULL,
  `Phone` int(10) NOT NULL,
  `Email` text NOT NULL,
  `Address1` text,
  `Address2` text,
  `City` text NOT NULL,
  `State` text,
  `Zip` int(11) default NULL,
  `SDate` date NOT NULL,
  `EDate` date default NULL,
  `EReason` varchar(10) default NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Dumping data for table `Employee`
--

INSERT INTO `Employee` (`ID`, `LName`, `MName`, `FName`, `SSN`, `Phone`, `Email`, `Address1`, `Address2`, `City`, `State`, `Zip`, `SDate`, `EDate`, `EReason`) VALUES
(1, 'Example', 'A', 'Admin', '4adlxi9WErm1/if/kaZJpg==', 2147483647, 'test@aol.com', 'address1', 'te''s\\', 'Muncie', 'Indiana', 47304, '2012-03-01', NULL, ''),
(2, 'Scott', 'V', 'Kevin', 'JsXUt286opjhbgmSo3Ol/g==', 2147483647, '', '', '', '', 'Nebraska', 0, '2012-03-03', NULL, ''),
(4, 'Hynes', 'A', 'Jordan', 'w6bzPwuNo9bGOhYW5dwGsw==', 1234567890, '', '', '', '', 'Nebraska', 0, '2012-03-03', NULL, ''),
(10, 'Example', 'M', 'Manager', 'w6bzPwuNo9YWV/ClBxD5qw==', 2132159499, '', '', '', '', 'Nebraska', 48457, '2012-03-03', NULL, ''),
(11, 'Sneddon', 'Joseph', 'Bob', 'EnDYhZOTtcRpw9Z9lqqoNA==', 2147483647, 'bob.dole@compuserve.com', '1400 W, Jackson St', 'apartment 24', 'Funkytown', 'Indiana', 47306, '2012-03-03', NULL, ''),
(13, 'Royston', 'A', 'Alyssa', 'iz2ODJSdfwzF3xOG/rchfg==', 1854162165, 'a@msn.com', '6516251 sadfa', '', 'sdfa', 'Alabama', 51854, '2012-03-21', NULL, ''),
(16, 'Example', 'test', 'Employee', '+m7pXRIyTNQTII6VXsKgOg==', 2147483647, 'darasd@asdasd.com', 'test', '', 'test', 'Indiana', 55555, '2012-04-09', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `EmployeeNotes`
--

CREATE TABLE IF NOT EXISTS `EmployeeNotes` (
  `ID` int(11) NOT NULL,
  `Manager` varchar(50) NOT NULL,
  `Date` datetime NOT NULL,
  `Note` text NOT NULL,
  KEY `NoteEID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `EmployeeNotes`
--

INSERT INTO `EmployeeNotes` (`ID`, `Manager`, `Date`, `Note`) VALUES
(4, 'Jennifer Chavez', '2012-03-21 00:00:00', 'Employee Constantly asking me to "Take a Seat"'),
(10, 'Jennifer Chavez', '2012-03-14 00:00:00', 'Keeps telling me he''s rich'),
(10, 'Jennifer Chavez', '2012-03-22 00:00:00', 'Smoking Crack in the Freezer'),
(11, 'Jennifer Chavez', '2012-03-22 00:00:00', 'All he says is Bob Dole'),
(11, 'Jennifer Chavez', '2012-03-22 00:00:00', 'Bob Dole\nBob Dole\nBob Dole'),
(2, 'Jennifer Chavez', '2012-04-01 00:00:00', 'Mando, Man do'),
(10, 'Jennifer Chavez', '2012-04-05 00:00:00', '''stringttest'),
(10, 'Jennifer Chavez', '2012-04-05 00:00:00', 'stringttest2'),
(10, 'Jennifer Chavez', '2012-04-05 00:00:00', 'note''s test\\ 2'),
(10, 'Jennifer Chavez', '2012-04-05 00:00:00', 'te''s\\'),
(10, 'Jennifer Chavez', '2012-04-06 00:00:00', 'newtest'),
(1, 'Admin Example', '2012-04-14 21:20:19', 'test'),
(1, 'Admin Example', '2012-04-14 21:20:20', 'test'),
(1, 'Admin Example', '2012-04-14 21:20:22', 'test'),
(1, 'Admin Example', '2012-04-14 21:20:23', 'test'),
(1, 'Admin Example', '2012-04-14 21:20:23', 'test'),
(2, 'Admin Example', '2012-04-15 11:26:48', 'Was seen taking an unauthorized smoking break.');

-- --------------------------------------------------------

--
-- Table structure for table `Hours Worked`
--

CREATE TABLE IF NOT EXISTS `Hours Worked` (
  `ID` int(11) NOT NULL,
  `Date` date NOT NULL,
  `Start` time default NULL,
  `End` time default NULL,
  `Tips` decimal(10,2) default NULL,
  `JID` varchar(50) NOT NULL,
  `B1out` time default NULL,
  `B1in` time default NULL,
  `B2out` time default NULL,
  `B2in` time default NULL,
  `Lout` time default NULL,
  `Lin` time default NULL,
  `Status` varchar(20) default NULL,
  KEY `HWID` (`ID`),
  KEY `HWJID` (`JID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Hours Worked`
--

INSERT INTO `Hours Worked` (`ID`, `Date`, `Start`, `End`, `Tips`, `JID`, `B1out`, `B1in`, `B2out`, `B2in`, `Lout`, `Lin`, `Status`) VALUES
(1, '2012-03-04', '21:55:00', '22:38:00', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(11, '2012-03-04', '22:01:29', '03:03:09', NULL, 'Bartender', NULL, NULL, NULL, NULL, '23:45:00', '00:15:00', 'OUT'),
(1, '2012-03-05', '03:02:06', '17:36:44', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-03-10', '22:02:17', '22:03:13', NULL, 'Bartender', '22:02:31', '22:02:47', '22:03:07', '22:03:08', '22:02:53', '22:02:55', 'OUT'),
(10, '2012-03-11', '23:00:00', '04:00:00', NULL, 'Bartender', '23:07:00', '23:24:00', NULL, NULL, NULL, NULL, 'OUT'),
(10, '2012-03-12', '01:20:00', '02:34:00', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-03-12', '03:32:00', '04:32:00', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(11, '2012-03-12', '00:30:00', '02:00:00', NULL, 'Security', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(11, '2012-03-13', '10:44:30', '10:19:44', NULL, 'Dishwasher', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-03-23', '08:45:00', '09:08:31', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-03-23', '09:00:00', '09:08:31', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-03-23', '09:15:00', '09:08:31', NULL, 'Manager', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(11, '2012-03-26', '19:00:00', '19:06:06', '69.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(11, '2012-03-26', '19:00:00', '19:06:06', NULL, 'Security', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-03-26', '19:15:00', '19:34:22', '9001.00', 'Bartender', '19:13:57', '19:13:58', '19:13:58', '19:13:59', '19:13:55', '19:13:56', 'OUT'),
(16, '2012-04-12', '20:13:57', '21:08:46', NULL, 'Security', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-12', '00:00:00', '10:00:00', '0.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-13', '00:00:00', '10:00:00', '5.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-14', '00:00:00', '10:00:00', '5.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-15', '00:00:00', '10:23:00', '5.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-17', '00:00:00', '15:00:00', '5.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-16', '00:00:00', '10:00:00', '5.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(1, '2012-04-18', '00:00:00', '10:00:00', '5.00', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(10, '2012-04-14', '04:00:00', '09:00:00', NULL, 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT'),
(11, '2012-04-15', '12:13:00', '12:14:00', '15.04', 'Bartender', NULL, NULL, NULL, NULL, NULL, NULL, 'OUT');

-- --------------------------------------------------------

--
-- Table structure for table `Jobs`
--

CREATE TABLE IF NOT EXISTS `Jobs` (
  `JID` varchar(50) NOT NULL,
  `JSPay` decimal(10,2) NOT NULL,
  `TippedJob` varchar(5) character set latin1 collate latin1_bin default 'FALSE',
  `Filename` text,
  PRIMARY KEY  (`JID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Jobs`
--

INSERT INTO `Jobs` (`JID`, `JSPay`, `TippedJob`, `Filename`) VALUES
('Bartender', '5.00', 'True', 'Bartender.bmp'),
('Cook', '8.00', 'False', 'Cook.bmp'),
('Dishwasher', '7.00', 'False', 'Dishwasher.bmp'),
('Manager', '10.00', 'False', 'Manager.bmp'),
('Security', '8.00', 'False', 'Security.bmp'),
('Server', '3.60', 'True', 'Server.bmp');

-- --------------------------------------------------------

--
-- Table structure for table `Manager`
--

CREATE TABLE IF NOT EXISTS `Manager` (
  `ID` int(11) NOT NULL,
  PRIMARY KEY  (`ID`),
  KEY `MID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Manager`
--

INSERT INTO `Manager` (`ID`) VALUES
(10),
(11);

-- --------------------------------------------------------

--
-- Table structure for table `Requests`
--

CREATE TABLE IF NOT EXISTS `Requests` (
  `ID` int(11) NOT NULL,
  `SDate` date NOT NULL,
  `EDate` date NOT NULL,
  `Submitted Date` date default NULL,
  `Reason` text,
  KEY `RID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Requests`
--

INSERT INTO `Requests` (`ID`, `SDate`, `EDate`, `Submitted Date`, `Reason`) VALUES
(10, '2012-04-12', '2012-04-12', '2012-04-07', 'dave''s request'),
(16, '2012-04-09', '2012-04-11', '2012-04-09', 'I got shot'),
(1, '2012-04-20', '2012-04-28', '2012-04-14', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `Schedule`
--

CREATE TABLE IF NOT EXISTS `Schedule` (
  `ID` int(11) NOT NULL,
  `Date` date NOT NULL,
  `Start` time NOT NULL,
  `End` time NOT NULL,
  `JID` varchar(50) NOT NULL,
  KEY `SID` (`ID`),
  KEY `SJID` (`JID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Schedule`
--

INSERT INTO `Schedule` (`ID`, `Date`, `Start`, `End`, `JID`) VALUES
(1, '2012-02-16', '22:30:00', '05:00:00', 'Manager'),
(1, '2012-02-29', '02:00:00', '06:00:00', 'Cook'),
(10, '2012-02-25', '01:30:00', '23:30:00', 'Dishwasher'),
(4, '2012-02-25', '21:15:00', '20:30:00', 'Dishwasher'),
(10, '2012-02-27', '13:00:00', '23:00:00', 'Manager'),
(1, '2012-02-26', '05:30:00', '05:30:00', 'Cook'),
(11, '2012-03-04', '10:00:00', '14:30:00', 'Security'),
(1, '2012-03-04', '06:15:00', '10:30:00', 'Manager'),
(1, '2012-03-05', '03:15:00', '08:15:00', 'Bartender'),
(10, '2012-03-04', '11:15:00', '12:30:00', 'Security'),
(1, '2012-03-10', '22:00:00', '05:30:00', 'Bartender'),
(10, '2012-03-11', '04:15:00', '10:30:00', 'Bartender'),
(11, '2012-03-13', '10:45:00', '11:00:00', 'Dishwasher'),
(11, '2012-03-30', '10:00:00', '18:00:00', 'Security'),
(1, '2012-04-08', '05:30:00', '14:15:00', 'Manager'),
(1, '2012-04-13', '02:00:00', '10:00:00', 'Bartender'),
(1, '2012-04-10', '12:00:00', '16:30:00', 'Bartender'),
(1, '2012-04-16', '05:15:00', '06:30:00', 'Bartender'),
(1, '2012-04-18', '05:15:00', '06:30:00', 'Bartender'),
(1, '2012-04-19', '05:15:00', '06:45:00', 'Bartender'),
(16, '2012-04-18', '02:15:00', '05:30:00', 'Security');

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE IF NOT EXISTS `Users` (
  `ID` int(11) NOT NULL,
  `User` varchar(45) NOT NULL,
  `Password` varchar(84) NOT NULL,
  PRIMARY KEY  (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Users`
--

INSERT INTO `Users` (`ID`, `User`, `Password`) VALUES
(1, 'test', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz'),
(2, 'user', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz'),
(4, 'chris', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz'),
(10, 'dave', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz'),
(11, 'Bobdole', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz'),
(13, 'privtest', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz'),
(16, 'Manual ', 'W0D0Jklx1fuklSMlgo7E/6BY+YTp1oEX8gg24RNuS4tUbG0zQW5EUjN8YVRJdjNEbG1FbjVsMG5sTjVwQVsz');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Admin`
--
ALTER TABLE `Admin`
  ADD CONSTRAINT `AID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Employee Jobs`
--
ALTER TABLE `Employee Jobs`
  ADD CONSTRAINT `EJJID` FOREIGN KEY (`JID`) REFERENCES `Jobs` (`JID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `EJID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `EmployeeNotes`
--
ALTER TABLE `EmployeeNotes`
  ADD CONSTRAINT `ENID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Hours Worked`
--
ALTER TABLE `Hours Worked`
  ADD CONSTRAINT `HWJID` FOREIGN KEY (`JID`) REFERENCES `Jobs` (`JID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `HWID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Manager`
--
ALTER TABLE `Manager`
  ADD CONSTRAINT `MID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Requests`
--
ALTER TABLE `Requests`
  ADD CONSTRAINT `Rid` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Schedule`
--
ALTER TABLE `Schedule`
  ADD CONSTRAINT `SJID` FOREIGN KEY (`JID`) REFERENCES `Jobs` (`JID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `SID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Users`
--
ALTER TABLE `Users`
  ADD CONSTRAINT `ID` FOREIGN KEY (`ID`) REFERENCES `Employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
