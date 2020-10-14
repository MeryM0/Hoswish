/*
SQLyog Ultimate v12.09 (64 bit)
MySQL - 8.0.17 : Database - hoswish
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hoswish` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `hoswish`;

/*Table structure for table `tb_hos` */

DROP TABLE IF EXISTS `tb_hos`;

CREATE TABLE `tb_hos` (
  `Hos_id` int(10) DEFAULT NULL,
  `Hos_name` varchar(100) DEFAULT NULL,
  `Hos_detail` text,
  `Hos_how` int(10) DEFAULT NULL,
  `Hos_title` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tb_hos` */

insert  into `tb_hos`(`Hos_id`,`Hos_name`,`Hos_detail`,`Hos_how`,`Hos_title`) values (1011,'大岭山医院','不明',2,NULL),(1012,'广东省人民医院','广东省人民医院',1,NULL),(1013,'东莞中医院','始建于1965年，现拥有总院本部和莞城2个院区，以及总院中心门诊、莞城分院门诊、莞翠中门诊等3个门诊部，并沿设有东莞市中医药研究所、东莞市老年病防治研究所等',3,'东莞地区唯一一家“三级甲等中医医院”'),(1014,'东华医院','东华医院',1,NULL),(1015,'广东医科大学附属医院','似乎没有详细信息',2,''),(1016,'湛江市附属医院','位于湛江市',1,NULL);

/*Table structure for table `tb_score` */

DROP TABLE IF EXISTS `tb_score`;

CREATE TABLE `tb_score` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `formula` text,
  `endresult` varchar(50) DEFAULT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `tb_score` */

insert  into `tb_score`(`id`,`username`,`formula`,`endresult`) values (1,'郭金川','condition_0:初始成绩:80;condition_1:创新创业分:5;condition_2:技能培养分:4;','5686'),(6,'陈观汉','condition_0:初始成绩:80;condition_1:创新创业分:1;condition_2:技能培养分:20;condition_3:文化活动分:3;','5808'),(7,'1','condition_0:初始成绩:70;condition_1:创新创业分:5;condition_2:技能培养分:4;','4986');

/*Table structure for table `tb_student` */

DROP TABLE IF EXISTS `tb_student`;

CREATE TABLE `tb_student` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `miaoshu` varchar(50) DEFAULT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `tb_student` */

insert  into `tb_student`(`id`,`username`,`password`,`miaoshu`) values (1,'郭金川','1100','学生'),(2,'陈观汉','123','学生'),(3,'1','1','测试'),(6,'2','442','学生');

/*Table structure for table `tb_stumes` */

DROP TABLE IF EXISTS `tb_stumes`;

CREATE TABLE `tb_stumes` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `number` varchar(50) DEFAULT NULL,
  `major` varchar(50) DEFAULT NULL,
  `stuclass` varchar(50) DEFAULT NULL,
  `pic` varchar(50) DEFAULT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `tb_stumes` */

insert  into `tb_stumes`(`id`,`username`,`number`,`major`,`stuclass`,`pic`) values (1,'郭金川','17209120401','信息资源管理','12\r\n',NULL),(2,'陈观汉','17207020070','信息资源管理','12',NULL),(3,'1','1720945678','武当','01',NULL),(6,'俞莲舟','1720900000','武当派','七侠',NULL),(7,'3','1878','少林','12',NULL);

/*Table structure for table `tb_teacher` */

DROP TABLE IF EXISTS `tb_teacher`;

CREATE TABLE `tb_teacher` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `miaoshu` varchar(50) DEFAULT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `tb_teacher` */

insert  into `tb_teacher`(`id`,`username`,`password`,`miaoshu`) values (1,'向老师','1200','教师'),(2,'夏老师','1300','教师'),(3,'0','0','测试');

/*Table structure for table `tb_user` */

DROP TABLE IF EXISTS `tb_user`;

CREATE TABLE `tb_user` (
  `id` int(10) NOT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL,
  `power` int(10) DEFAULT NULL,
  `miaoshu` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `PK_tb_User` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tb_user` */

insert  into `tb_user`(`id`,`Username`,`Password`,`power`,`miaoshu`) values (1001,'guihua','123',1,'桂花老师'),(1002,'lanzi','456',0,'兰子同学'),(1003,'shanquan','789',1,'山泉老师'),(1004,'nongfu','753',0,'农夫同学'),(1005,'nihao','159',1,'你好老师');

/*Table structure for table `tb_wish` */

DROP TABLE IF EXISTS `tb_wish`;

CREATE TABLE `tb_wish` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `tb_first` varchar(255) DEFAULT NULL,
  `tb_second` varchar(255) DEFAULT NULL,
  `tb_third` varchar(255) DEFAULT NULL,
  `tb_result` varchar(255) DEFAULT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `tb_wish` */

insert  into `tb_wish`(`id`,`username`,`tb_first`,`tb_second`,`tb_third`,`tb_result`) values (1,'1','东莞中医院','广东省人民医院','大岭山医院','东莞中医院'),(2,'郭金川','东莞中医院','广东省人民医院','广东医科大学附属医院','东莞中医院'),(3,'陈观汉','广东省人民医院','湛江市附属医院',NULL,'广东省人民医院'),(6,'俞莲舟',NULL,NULL,NULL,'');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
