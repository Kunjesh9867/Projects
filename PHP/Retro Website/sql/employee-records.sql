CREATE TABLE RECORDS(
    ID INT PRIMARY KEY AUTO_INCREMENT,
    FIRST_NAME VARCHAR(50),
    LAST_NAME VARCHAR(50),
    EMAIL VARCHAR(100),
    PASS VARCHAR(1000),
    BIO VARCHAR(5000)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;