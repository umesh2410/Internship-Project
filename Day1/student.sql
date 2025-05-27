-- 1. Create Database and Connect
CREATE DATABASE studentdb;
\c studentdb

-- 2. Create Tables
CREATE TABLE department (
  dept_id SERIAL PRIMARY KEY,
  dept_name VARCHAR(50)
);

CREATE TABLE student (
  student_id SERIAL PRIMARY KEY,
  name VARCHAR(100),
  age INT,
  dept_id INT REFERENCES department(dept_id)
);

-- 3. Insert Data
INSERT INTO department (dept_name) VALUES 
('Computer Science'), 
('Mechanical'), 
('Information Technology'), 
('Electrical');

INSERT INTO student (name, age, dept_id) VALUES 
('Alice', 21, 1), 
('Bob', 22, 2), 
('Charlie', 20, 1), 
('David', 23, 3);

-- 4. Select Queries
SELECT * FROM student;
SELECT * FROM department;

SELECT s.name, s.age, d.dept_name
FROM student s
JOIN department d ON s.dept_id = d.dept_id;

-- 5. Update
UPDATE student SET age = 22 WHERE name = 'Alice';

-- 6. Delete
DELETE FROM student WHERE name = 'Bob';

-- 7. Subqueries & Sorting
SELECT * FROM student 
WHERE dept_id = (
  SELECT dept_id FROM department 
  WHERE dept_name = 'Computer Science'
);

SELECT * FROM student 
WHERE age > (
  SELECT AVG(age) FROM student
);

SELECT * FROM student ORDER BY student_id ASC;
SELECT * FROM student ORDER BY age DESC;

SELECT * FROM student 
WHERE dept_id = (
  SELECT dept_id FROM department 
  WHERE dept_name = 'Mechanical'
);

-- 8. Drop Table
DROP TABLE student;
