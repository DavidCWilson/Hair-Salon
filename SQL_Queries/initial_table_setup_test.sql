USE hair_salon_test;
CREATE TABLE stylists (id INT IDENTITY(1,1), firstName VARCHAR(25), lastName VARCHAR(50), specialty VARCHAR(25));
CREATE TABLE clients (id INT IDENTITY(1,1), firstName VARCHAR(25), stylist_id INT);
