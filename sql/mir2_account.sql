/*
 Navicat Premium Data Transfer

 Source Server         : 10.10.0.199
 Source Server Type    : MySQL
 Source Server Version : 50727
 Source Host           : 10.10.0.199:3306
 Source Schema         : mir2_account

 Target Server Type    : MySQL
 Target Server Version : 50727
 File Encoding         : 65001

 Date: 03/12/2022 19:07:54
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account`  (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `Account` char(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '账号',
  `PassWord` char(21) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '密码',
  `PassFailCount` tinyint(4) NULL DEFAULT NULL COMMENT '密码输错次数',
  `PassFailTime` int(13) NULL DEFAULT NULL COMMENT '失败时间',
  `ValidFrom` datetime NULL DEFAULT NULL,
  `ValidUntil` datetime NULL DEFAULT NULL,
  `PayMode` tinyint(2) NOT NULL DEFAULT 0 COMMENT '付费模式(0:免费 1:点卡 2:月卡 3:试玩 4:永久免费)',
  `Seconds` int(11) NOT NULL COMMENT '剩余游戏时间',
  `StopUntil` datetime NULL DEFAULT NULL,
  `State` tinyint(2) NOT NULL DEFAULT 0 COMMENT '账号状态(0:正常 1:删除 2:禁用)',
  `CreateTime` int(13) NOT NULL DEFAULT 0 COMMENT '注册时间',
  `ModifyTime` int(13) NOT NULL DEFAULT 0 COMMENT '修改时间',
  `LastLoginTime` int(13) NOT NULL COMMENT '最后登陆时间',
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `_WA_Sys_FLD_LOGINID_5535A963`(`Account`) USING BTREE,
  INDEX `_WA_Sys_FLD_PASSWORD_5535A963`(`PassWord`) USING BTREE,
  INDEX `_WA_Sys_FLD_PASSFAILCOUNT_5535A963`(`PassFailCount`) USING BTREE,
  INDEX `_WA_Sys_FLD_PASSFAILTIME_5535A963`(`PassFailTime`) USING BTREE,
  INDEX `_WA_Sys_FLD_VALIDFROM_5535A963`(`ValidFrom`) USING BTREE,
  INDEX `_WA_Sys_FLD_VALIDUNTIL_5535A963`(`ValidUntil`) USING BTREE,
  INDEX `_WA_Sys_FLD_SECONDS_5535A963`(`Seconds`) USING BTREE,
  INDEX `_WA_Sys_FLD_STOPUNTIL_5535A963`(`StopUntil`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6106 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '账号' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for account_friend
-- ----------------------------
DROP TABLE IF EXISTS `account_friend`;
CREATE TABLE `account_friend`  (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `AccountId` bigint(20) NOT NULL DEFAULT 0 COMMENT '账号ID',
  `FriendId` bigint(20) NOT NULL DEFAULT 0 COMMENT '好友账号ID',
  `GameStatus` tinyint(2) NOT NULL DEFAULT 0 COMMENT '好友游戏状态(0:离线 1:在线 2:离开)',
  `GameType` tinyint(2) NOT NULL DEFAULT 0 COMMENT '好友游戏类型(待定)',
  `State` tinyint(2) NOT NULL DEFAULT 0 COMMENT '好友状态(0:正常 1:删除)',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `ModifyTIme` datetime NOT NULL COMMENT '修改时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '好友信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for account_protection
-- ----------------------------
DROP TABLE IF EXISTS `account_protection`;
CREATE TABLE `account_protection`  (
  `AccountId` bigint(25) NOT NULL COMMENT '账号Id',
  `UserName` char(21) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '姓名',
  `IdCard` char(18) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '身份证号码',
  `Birthday` char(11) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '出生年月',
  `Phone` char(14) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '电话',
  `MobilePhone` char(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '手机',
  `ADDRESS1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '地址1',
  `ADDRESS2` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '地址2',
  `EMail` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '邮箱',
  `Quiz1` char(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '问题1',
  `Answer1` char(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '回答1',
  `Quiz2` char(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '问题2',
  `Answer2` char(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '回答2',
  PRIMARY KEY (`AccountId`) USING BTREE,
  INDEX `_WA_Sys_FLD_LOGINID_29572725`(`AccountId`) USING BTREE,
  INDEX `_WA_Sys_FLD_SSNO_29572725`(`IdCard`) USING BTREE,
  INDEX `_WA_Sys_FLD_BIRTHDAY_29572725`(`Birthday`) USING BTREE,
  INDEX `_WA_Sys_FLD_PHONE_29572725`(`Phone`) USING BTREE,
  INDEX `_WA_Sys_FLD_MOBILEPHONE_29572725`(`MobilePhone`) USING BTREE,
  INDEX `_WA_Sys_FLD_ADDRESS1_29572725`(`ADDRESS1`) USING BTREE,
  INDEX `_WA_Sys_FLD_ADDRESS2_29572725`(`ADDRESS2`) USING BTREE,
  INDEX `_WA_Sys_FLD_EMAIL_29572725`(`EMail`) USING BTREE,
  INDEX `_WA_Sys_FLD_QUIZ1_29572725`(`Quiz1`) USING BTREE,
  INDEX `_WA_Sys_FLD_ANSWER1_29572725`(`Answer1`) USING BTREE,
  INDEX `_WA_Sys_FLD_QUIZ2_29572725`(`Quiz2`) USING BTREE,
  INDEX `_WA_Sys_FLD_ANSWER2_29572725`(`Answer2`) USING BTREE,
  INDEX `_WA_Sys_FLD_USERNAME_29572725`(`UserName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '账号安全密保信息' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_conncheckuser
-- ----------------------------
DROP TABLE IF EXISTS `tbl_conncheckuser`;
CREATE TABLE `tbl_conncheckuser`  (
  `FLD_ID` char(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FLD_ISDEL` int(11) NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_connectlogs
-- ----------------------------
DROP TABLE IF EXISTS `tbl_connectlogs`;
CREATE TABLE `tbl_connectlogs`  (
  `Account` char(21) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LoginIp` char(16) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LoginTime` datetime NOT NULL,
  `GameType` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  INDEX `_WA_Sys_FLD_LOGINID_2B3F6F97`(`Account`) USING BTREE,
  INDEX `_WA_Sys_FLD_LOGINIP_2B3F6F97`(`LoginIp`) USING BTREE,
  INDEX `_WA_Sys_FLD_LOGINTIME_2B3F6F97`(`LoginTime`) USING BTREE,
  INDEX `_WA_Sys_FLD_GAMETYPE_2B3F6F97`(`GameType`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_countlogs
-- ----------------------------
DROP TABLE IF EXISTS `tbl_countlogs`;
CREATE TABLE `tbl_countlogs`  (
  `FLD_COUNT` int(11) NULL DEFAULT NULL,
  `FLD_MAXCOUNT` int(11) NULL DEFAULT NULL,
  `FLD_TIME` datetime NULL DEFAULT NULL,
  `FLD_GAMETYPE` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_gmip
-- ----------------------------
DROP TABLE IF EXISTS `tbl_gmip`;
CREATE TABLE `tbl_gmip`  (
  `LoginIp` char(16) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `GameType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_itemgive
-- ----------------------------
DROP TABLE IF EXISTS `tbl_itemgive`;
CREATE TABLE `tbl_itemgive`  (
  `FLD_GAMETYPE` varchar(4) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_SERVER` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_CHARACTER` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_FROM` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_TYPE` int(11) NULL DEFAULT NULL,
  `FLD_VALUE` int(11) NULL DEFAULT NULL,
  `FLD_UNTIL` datetime NULL DEFAULT NULL,
  `FLD_REGISTER` datetime NULL DEFAULT NULL,
  `FLD_DONE` varchar(3) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_STATUS` int(11) NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_m2premiumuser
-- ----------------------------
DROP TABLE IF EXISTS `tbl_m2premiumuser`;
CREATE TABLE `tbl_m2premiumuser`  (
  `FLD_LOGINID` char(25) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_SERVERNAME` char(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_CHARNAME` char(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_SPECIALFLAG` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_BASICFLAG` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_ENDDATE` char(23) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_BIRTHDAY` char(11) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_FORCEDATE` char(23) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_pubips
-- ----------------------------
DROP TABLE IF EXISTS `tbl_pubips`;
CREATE TABLE `tbl_pubips`  (
  `FLD_PUBIP` char(16) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_DESCRIPTION` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_GAMETYPE` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_selectgateips
-- ----------------------------
DROP TABLE IF EXISTS `tbl_selectgateips`;
CREATE TABLE `tbl_selectgateips`  (
  `FLD_NAME` char(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FLD_IP` char(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_PORT` int(11) NULL DEFAULT NULL,
  `FLD_GAMETYPE` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_serverinfo
-- ----------------------------
DROP TABLE IF EXISTS `tbl_serverinfo`;
CREATE TABLE `tbl_serverinfo`  (
  `FLD_SERVERNAME` char(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_FREEMODE` tinyint(4) NULL DEFAULT NULL,
  `FLD_MAXUSERCOUNT` int(11) NULL DEFAULT NULL,
  `FLD_GAMETYPE` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for tbl_usercount
-- ----------------------------
DROP TABLE IF EXISTS `tbl_usercount`;
CREATE TABLE `tbl_usercount`  (
  `FLD_NAME` char(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FLD_INDEX` tinyint(4) NULL DEFAULT NULL,
  `FLD_TIME` datetime NULL DEFAULT NULL,
  `FLD_COUNT` int(11) NULL DEFAULT NULL,
  `FLD_MAXCOUNT` int(11) NULL DEFAULT NULL,
  `FLD_GAMETYPE` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
