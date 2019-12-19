# Windows实验

## 测试准备

1. 由于本实验使用了MySQL 8.0.18版本，因而所需MySQL 8.0.18、MySQL Connector Net 8.0.18、MySQL for Visual Studio。使用其他版本有可能出错。
2. 更改`.\WindowsExperiment\DatabaseApplication\App.config`最后一行的connectStrings中的connectionString，其中user id 为数据库账号名，password为数据库密码。
3. 本实验的数据库结构及其数据在`.\WindowsExperiment`下的`education_system.sql`中，使用Navicat Premium 12.0导出。
4. 在开始测试前务必先还原NUGET包。