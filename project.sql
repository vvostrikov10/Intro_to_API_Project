CREATE DATABASE `dndcharacterservice` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
CREATE TABLE `characterclasses` (
  `CharaClassID` varchar(20) NOT NULL,
  `Proficiencies` varchar(1000) NOT NULL,
  `ClassFeatures` varchar(10000) NOT NULL,
  PRIMARY KEY (`CharaClassID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `characters` (
  `CharacterName` varchar(50) NOT NULL,
  `Strength` int NOT NULL,
  `Dexterity` int NOT NULL,
  `Constitution` int NOT NULL,
  `Intelligence` int NOT NULL,
  `Wisdom` int NOT NULL,
  `Charisma` int NOT NULL,
  `CharaSubClassID` varchar(40) NOT NULL,
  `CharaClassID` varchar(40) NOT NULL,
  PRIMARY KEY (`CharacterName`),
  KEY `FK_class` (`CharaClassID`),
  KEY `FK_subclass` (`CharaSubClassID`),
  CONSTRAINT `FK_class` FOREIGN KEY (`CharaClassID`) REFERENCES `characterclasses` (`CharaClassID`),
  CONSTRAINT `FK_subclass` FOREIGN KEY (`CharaSubClassID`) REFERENCES `charactersubclasses` (`CharaSubClassID`),
  CONSTRAINT `characters_chk_1` CHECK ((substr(`characlassid`,1,4) = substr(`charasubclassid`,1,4)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `charactersubclasses` (
  `CharaSubClassID` varchar(40) NOT NULL,
  `SubClassFeatures` varchar(10000) NOT NULL,
  PRIMARY KEY (`CharaSubClassID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
