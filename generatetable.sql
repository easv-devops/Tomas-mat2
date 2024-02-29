


DROP TABLE IF EXISTS calculation;


create table calculation
(
    id      SERIAL PRIMARY KEY,
    val1    numeric  NOT NULL,
    val2    numeric   not NULL,
    val3    numeric   not NULL,
    operator text   not NULL
    
);

INSERT INTO calculation (val1 ,val2, val3, operator)
VALUES
(1, 1, 2, '+')