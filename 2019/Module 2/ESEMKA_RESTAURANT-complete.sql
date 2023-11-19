CREATE DATABASE DB_PC_XX_Module
GO
USE DB_PC_XX_Module

CREATE TABLE menu_category(
	id INT IDENTITY(1,1) PRIMARY KEY,
	[name] VARCHAR(100) NOT NULL,
)

CREATE TABLE menu(
	id INT IDENTITY(1,1) PRIMARY KEY,
	menu_category_id INT NOT NULL,
	[name] VARCHAR(100) NOT NULL,
	[price] DECIMAL(8,2) NOT NULL,
	[description] VARCHAR(200),
	[is_favourite] BIT,
	FOREIGN KEY (menu_category_id) REFERENCES [menu_category](id),
)

CREATE TABLE promotion(
	id INT IDENTITY(1,1) PRIMARY KEY,
	[code] VARCHAR(20) NOT NULL,
	[discount] DECIMAL(5,2) NOT NULL,
	[minimum_spent] DECIMAL(10,2) NOT NULL,
	[start_time] DATETIME NOT NULL,
	[end_time] DATETIME NOT NULL,
)

CREATE TABLE header_order(
	id INT IDENTITY(1,1) PRIMARY KEY,
	[order_made_time] DATETIME NOT NULL,
	[table_number] INT NOT NULL,
	[customer_name] VARCHAR(100) NOT NULL,
)

CREATE TABLE detail_order(
	id INT IDENTITY(1,1) PRIMARY KEY,
	[header_order_id] INT NOT NULL,
	[menu_id] INT NOT NULL,
	[order_price] DECIMAL(8,2) NOT NULL,
	[quantity] INT NOT NULL,
	[order_placed_time] DATETIME NOT NULL,
	FOREIGN KEY (header_order_id) REFERENCES [header_order](id),
	FOREIGN KEY (menu_id) REFERENCES [menu](id),
)

CREATE TABLE payment(
	id INT IDENTITY(1,1) PRIMARY KEY,
	[header_order_id] INT NOT NULL,
	[promotion_id] INT,
	[payment_type] VARCHAR(20) NOT NULL,
	[amount_to_pay] DECIMAL(10,2) NOT NULL,
	[amount_paid] DECIMAL(10,2) NOT NULL,
	FOREIGN KEY (header_order_id) REFERENCES [header_order](id),
	FOREIGN KEY (promotion_id) REFERENCES [promotion](id),
)

INSERT INTO menu_category (name) VALUES ('Foods')
INSERT INTO menu_category (name) VALUES ('Drinks')
INSERT INTO menu_category (name) VALUES ('Snacks')
INSERT INTO menu_category (name) VALUES ('Others')

INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (1, 'Beef Martabak', 55000, 'With sour sweet sauce and pickles', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (1, 'Spaghetti Bolognaise', 97000, 'Spaghettie with minced beef and tomato sauce', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (1, 'Gado gado', 50000, 'Mixed boiled vegetable served with rice cake and peanut sauce', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (1, 'Grilled Sirloin', 200000, 'Steak and fries served with mushroom sauce', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (1, 'Deluxe Burger', 45000, 'Beef patty with melted extra double cheese, tomato, and pickle', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (1, 'Iga Bakar', 50000, 'Served with Sambal Ijo, rice, and soup', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (2, 'Tropical Punch', 40000, 'The perfect blend of cherry, orange and pineapple flavor', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (2, 'Cappuccino', 25000, '', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (2, 'Juices', 20000, 'Avocado, Pineapple, Orange, Mango', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (2, 'Mineral Water', 10000, '', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (2, 'Soft Drinks', 15000, 'Cola, Sprite, Fanta', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (3, 'Cheese and choco pancake', 30000, 'With maple or rum sauce', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (3, 'Ice Mochi', 30000, 'Salted Caramel, Rd Bean, Coffee, Green Tea, Chocolate', 1)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (3, 'Tiramisu', 25000, '', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (4, 'Miso Soup', 10000, '', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (4, 'Rice', 10000, '', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (4, 'Mushroom Steak Salad', 30000, 'Served with sesame or thousand islands dressing', 0)
INSERT INTO menu (menu_category_id, name, price, description, is_favourite) VALUES (4, 'Spicy Edamame', 20000, 'Edamame served with chili flakes', 0)

INSERT INTO promotion (code, discount, minimum_spent, start_time, end_time) VALUES ('HEMATBGT', 20, '150000', '2019-10-01 00:00:00', '2019-10-31 00:00:00')
INSERT INTO promotion (code, discount, minimum_spent, start_time, end_time) VALUES ('KUMPULRAME', 5, '50000', '2019-10-01 00:00:00', '2019-10-31 00:00:00')
INSERT INTO promotion (code, discount, minimum_spent, start_time, end_time) VALUES ('TANGGALTUA', 10, '100000', '2019-10-25 00:00:00', '2019-10-31 00:00:00')
INSERT INTO promotion (code, discount, minimum_spent, start_time, end_time) VALUES ('ABISGAJIAN', 5, '75000', '2019-11-01 00:00:00', '2019-11-07 00:00:00')

INSERT INTO header_order (order_made_time, table_number, customer_name) VALUES ('2019-10-18 11:13:00', 3, 'Fanny')
INSERT INTO header_order (order_made_time, table_number, customer_name) VALUES ('2019-10-18 12:00:23', 1, 'Rina')
INSERT INTO header_order (order_made_time, table_number, customer_name) VALUES ('2019-10-18 13:00:56', 3, 'Reni')
INSERT INTO header_order (order_made_time, table_number, customer_name) VALUES ('2019-10-18 13:28:00', 4, 'Budiman')
INSERT INTO header_order (order_made_time, table_number, customer_name) VALUES ('2019-10-18 13:30:00', 2, 'Danu')
INSERT INTO header_order (order_made_time, table_number, customer_name) VALUES ('2019-10-18 13:55:31', 5, 'Antika')

INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (1, 6, 50000, 1, '2019-10-18 11:13:20')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (1, 9, 20000, 1, '2019-10-18 11:13:25')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (2, 2, 97000, 1, '2019-10-18 12:00:30')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (2, 3, 50000, 1, '2019-10-18 12:00:35')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (2, 10, 10000, 2, '2019-10-18 12:00:40')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 4, 100000, 1, '2019-10-18 13:01:05')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 6, 50000, 1, '2019-10-18 13:01:10')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 5, 45000, 2, '2019-10-18 13:05:05')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 9, 20000, 2, '2019-10-18 13:05:25')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 10, 10000, 4, '2019-10-18 13:05:35')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (4, 1, 55000, 1, '2019-10-18 13:28:10')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (4, 3, 50000, 2, '2019-10-18 13:28:15')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 15, 10000, 3, '2019-10-18 13:30:35')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (3, 14, 25000, 1, '2019-10-18 13:30:45')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (5, 17, 30000, 1, '2019-10-18 13:55:40')
INSERT INTO detail_order (header_order_id, menu_id, order_price, quantity, order_placed_time) VALUES (5, 12, 30000, 1, '2019-10-18 13:55:44')

INSERT INTO payment(header_order_id, promotion_id, payment_type, amount_to_pay, amount_paid) VALUES (1, NULL, 'Cash', 80500, 100000)
INSERT INTO payment(header_order_id, promotion_id, payment_type, amount_to_pay, amount_paid) VALUES (2, 2, 'Credit', 182447.5, 182447.5)
INSERT INTO payment(header_order_id, promotion_id, payment_type, amount_to_pay, amount_paid) VALUES (4, 1, 'Cash', 142600, 150000)