CREATE TABLE `library`.`admin` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(512) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `library`.`member` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,	
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(512) NOT NULL,
  `phone` INT NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `library`.`book` (
  `id` INT PRIMARY KEY AUTO_INCREMENT,
  `title` VARCHAR(255) NOT NULL,
  `author` VARCHAR(255) NOT NULL,
  `category` VARCHAR(100) NOT NULL
);

CREATE TABLE `library`.`BookCopies` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `book_id` INT NOT NULL,
    `isAvailable` BOOLEAN NOT NULL DEFAULT TRUE,
    CONSTRAINT
    FOREIGN KEY (`book_id`) REFERENCES `Book` (`id`)
);

CREATE TABLE `library`.`bookloan` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `bookCopyId` INT NOT NULL,
  `membrId` INT NOT NULL,
  `loanDate` TIMESTAMP NOT NULL,
  `returnDate` TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT
    FOREIGN KEY (`bookCopyId`) REFERENCES `library`.`bookcopies` (`id`),
    FOREIGN KEY (`membrId`) REFERENCES `library`.`member` (`id`)
);