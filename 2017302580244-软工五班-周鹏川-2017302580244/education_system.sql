/*
 Navicat Premium Data Transfer

 Source Server         : myosotis
 Source Server Type    : MySQL
 Source Server Version : 80018
 Source Host           : localhost:3306
 Source Schema         : education_system

 Target Server Type    : MySQL
 Target Server Version : 80018
 File Encoding         : 65001

 Date: 19/12/2019 00:55:47
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account`  (
  `aid` int(11) NOT NULL AUTO_INCREMENT,
  `account` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` varchar(18) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `sid` int(11) NOT NULL,
  PRIMARY KEY (`aid`) USING BTREE,
  INDEX `sid`(`sid`) USING BTREE,
  CONSTRAINT `account_ibfk_1` FOREIGN KEY (`sid`) REFERENCES `student` (`sid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES (1, '2019302580111', 'password', 1);
INSERT INTO `account` VALUES (2, 'alicization', 'qwerty', 2);
INSERT INTO `account` VALUES (3, 'lucy', 'luck', 3);

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course`  (
  `cid` int(11) NOT NULL AUTO_INCREMENT,
  `cname` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `credit` tinyint(255) UNSIGNED NOT NULL,
  `total` mediumint(255) NOT NULL,
  `exist` mediumint(255) NOT NULL,
  `field` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `time` mediumint(9) UNSIGNED NOT NULL,
  `place` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tid` int(11) NOT NULL,
  PRIMARY KEY (`cid`) USING BTREE,
  INDEX `tid`(`tid`) USING BTREE,
  CONSTRAINT `course_ibfk_1` FOREIGN KEY (`tid`) REFERENCES `teacher` (`tid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES (1, 'hello', 1, 50, 0, 'ddd', 50, 'wq', 1);
INSERT INTO `course` VALUES (2, 'world', 2, 10, 2, 'ewq', 52, 'wq', 2);
INSERT INTO `course` VALUES (3, '!', 5, 1, 0, 'dqw', 53, 'qew', 3);
INSERT INTO `course` VALUES (4, 'Design', 2, 40, 2, 'quan', 23, 'qwe', 4);
INSERT INTO `course` VALUES (5, 'C', 2, 99, 50, 'it', 60, 'qdsad', 5);
INSERT INTO `course` VALUES (6, 'cpp', 2, 99, 60, 'it', 55, 'dasdsd', 6);

-- ----------------------------
-- Table structure for grade
-- ----------------------------
DROP TABLE IF EXISTS `grade`;
CREATE TABLE `grade`  (
  `scid` int(11) NOT NULL AUTO_INCREMENT,
  `grade` mediumint(9) NULL DEFAULT NULL,
  `sid` int(11) NOT NULL,
  `cid` int(11) NOT NULL,
  PRIMARY KEY (`scid`) USING BTREE,
  INDEX `sid`(`sid`) USING BTREE,
  INDEX `cid`(`cid`) USING BTREE,
  CONSTRAINT `grade_ibfk_1` FOREIGN KEY (`sid`) REFERENCES `student` (`sid`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `grade_ibfk_2` FOREIGN KEY (`cid`) REFERENCES `course` (`cid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of grade
-- ----------------------------
INSERT INTO `grade` VALUES (1, 50, 1, 1);
INSERT INTO `grade` VALUES (2, NULL, 1, 3);
INSERT INTO `grade` VALUES (3, NULL, 2, 2);
INSERT INTO `grade` VALUES (4, NULL, 3, 6);
INSERT INTO `grade` VALUES (5, NULL, 3, 3);
INSERT INTO `grade` VALUES (6, NULL, 3, 1);

-- ----------------------------
-- Table structure for student
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student`  (
  `sid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `studentid` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `idnum` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `sex` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `age` mediumint(9) NOT NULL,
  `grade` mediumint(9) NOT NULL,
  `college` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `profession` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`sid`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of student
-- ----------------------------
INSERT INTO `student` VALUES (1, 'John', '2019302580111', '350583111155555566', '男', 18, 2019, '计算机学院', '软件工程');
INSERT INTO `student` VALUES (2, 'Jack', '2018666523652', '665565656456446666', '男', 19, 2018, '新闻与传播学院', '传播学');
INSERT INTO `student` VALUES (3, 'Lucy', '2017366262655', '266565626465626236', '女', 20, 2017, '网络安全学院', '信息安全');

-- ----------------------------
-- Table structure for teacher
-- ----------------------------
DROP TABLE IF EXISTS `teacher`;
CREATE TABLE `teacher`  (
  `tid` int(11) NOT NULL AUTO_INCREMENT,
  `tname` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dept` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `job` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `sex` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `age` mediumint(9) NOT NULL,
  PRIMARY KEY (`tid`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of teacher
-- ----------------------------
INSERT INTO `teacher` VALUES (1, 'Peggy', '计算机', '教授', '男', 45);
INSERT INTO `teacher` VALUES (2, 'Mavericks', '新传', '副教授', '男', 40);
INSERT INTO `teacher` VALUES (3, 'Tom', '信管', '讲师', '男', 26);
INSERT INTO `teacher` VALUES (4, 'Lily', '哲学', '教授', '女', 46);
INSERT INTO `teacher` VALUES (5, 'Amy', '英语', '讲师', '女', 28);
INSERT INTO `teacher` VALUES (6, 'Alice', '数学', '副教授', '女', 35);

SET FOREIGN_KEY_CHECKS = 1;
