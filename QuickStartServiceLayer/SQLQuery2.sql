USE QuickStartDB
GO


Insert into Roles values ('Admin')
Insert into Roles values ('Customer')

Insert Into Users values ('Franken@gmail.com', 'Franken123', 2, 'F', '1980-01-01', '123 Main St, Springfield, USA')
Insert Into Users values ('Henriot@gmail.com', 'Henriot123', 2, 'F', '1975-05-15', '456 Elm St, Springfield, USA')
Insert Into Users values ('Hernadez@gmail.com', 'Hernadez123', 2, 'M', '1990-10-10', '789 Oak St, Springfield, USA')
Insert Into Users values ('Durgesh@gmail.com', 'Durgesh123', 1, 'M', '1985-03-20', 'MP, India')
Insert Into Users values ('Harsh@gmail.com', 'Harsh123', 2, 'M', '1992-07-30', 'Delhi, India')
Insert Into Users values ('Animesh@gmail.com', 'Animesh123', 2, 'M', '1988-12-25', 'Mumbai, India')
Insert Into Users values ('John@gmail.com', 'John123', 2, 'M', '1995-06-15', 'New York, USA')
Insert Into Users values ('Bill@gmail.com', 'Bill123', 2, 'M', '1982-11-05', 'Los Angeles, USA')
Insert Into Users values ('Lata@gmail.com', 'Lata123', 2, 'F', '1998-04-18', 'Bangalore, India')

Insert into Categories values ('Motors')
Insert into Categories values ('Fashion')
Insert into Categories values ('Electronics')
Insert into Categories values ('Arts')
Insert into Categories values ('Home')
Insert into Categories values ('Sporting Goods')
Insert into Categories values ('Toys')


Insert into Products values ('P001', 'BMW X1', 1, 15000000, 10)
Insert into Products values ('P002', 'Honda Accord', 1, 30000000, 10)
Insert into Products values ('P003', 'Samsung Galaxy S21', 3, 80000, 50)
Insert into Products values ('P004', 'Nike Air Max', 2, 12000, 100)
Insert into Products values ('P005', 'Sony Bravia 55"', 3, 60000, 20)
Insert into Products values ('P006', 'Dell XPS 13', 3, 90000, 15)
Insert into Products values ('P007', 'Canon EOS R5', 3, 250000, 5)
Insert into Products values ('P008', 'Apple MacBook Pro', 3, 150000, 8)
Insert into Products values ('P009', 'Adidas Ultraboost', 2, 15000, 30)
Insert into Products values ('P010', 'Kundan jewellery set', 4, 50000, 12)
Insert into Products values ('P011', 'Hand-painted vase', 4, 2000, 25)
Insert into Products values ('P012', 'Wooden dining table', 5, 30000, 5)
Insert into Products values ('P013', 'Leather sofa set', 5, 80000, 3)
Insert into Products values ('P014', 'Camping tent', 6, 15000, 20)
Insert into Products values ('P015', 'Yoga mat', 6, 2000, 50)
Insert into Products values ('P016', 'Action figure', 7, 500, 100)
Insert into Products values ('P017', 'Board game set', 7, 3000, 40)
Insert into Products values ('P018', 'Kids educational toy', 7, 1500, 60)
Insert into Products values ('P019', 'Smartwatch', 3, 25000, 25)

Insert into PurchaseDetails values ('Franken@gmail.com', 'P001', 1, '2023-10-01')
Insert into PurchaseDetails values ('Franken@gmail.com', 'P002', 1, '2023-10-02')
Insert into PurchaseDetails values ('Henriot@gmail.com', 'P003', 2, '2023-10-03')
Insert into PurchaseDetails values ('Henriot@gmail.com', 'P004', 1, '2023-10-04')
Insert into PurchaseDetails values ('Harsh@gmail.com', 'P005', 1, '2023-10-05')
Insert into PurchaseDetails values ('Harsh@gmail.com', 'P006', 1, '2023-10-06')
Insert into PurchaseDetails values ('Animesh@gmail.com', 'P007', 1, '2023-10-07')
Insert into PurchaseDetails values ('Animesh@gmail.com', 'P008', 1, '2023-10-08')
Insert into PurchaseDetails values ('John@gmail.com', 'P009', 2, '2023-10-09')
Insert into PurchaseDetails values ('John@gmail.com', 'P010', 1, '2023-10-10')
Insert into PurchaseDetails values ('Bill@gmail.com', 'P011', 1, '2023-10-11')
Insert into PurchaseDetails values ('Bill@gmail.com', 'P012', 1, '2023-10-12')
Insert into PurchaseDetails values ('Lata@gmail.com', 'P013', 1, '2023-10-13')
Insert into PurchaseDetails values ('Lata@gmail.com', 'P014', 1, '2023-10-14')
Insert into PurchaseDetails values ('Hernadez@gmail.com', 'P015', 1, '2023-10-15')
Insert into PurchaseDetails values ('Hernadez@gmail.com', 'P016', 1, '2023-10-16')
Insert into PurchaseDetails values ('Hernadez@gmail.com', 'P017', 1, '2023-10-17')
Insert into PurchaseDetails values ('Hernadez@gmail.com', 'P018', 1, '2023-10-18')
Insert into PurchaseDetails values ('Hernadez@gmail.com', 'P019', 1, '2023-10-19')
Insert into PurchaseDetails values ('Harsh@gmail.com', 'P001', 1, '2023-10-20')
Insert into PurchaseDetails values ('Lata@gmail.com', 'P002', 1, '2023-10-21')

Insert into CardDetails values (1234567890123456, 'Franken', 'V', 123, '2025-12-31', 100000.00)
Insert into CardDetails values (2345678901234567, 'Henriot', 'M', 456, '2026-01-31', 200000.00)
Insert into CardDetails values (3456789012345678, 'Hernadez', 'A', 789, '2025-11-30', 150000.00)
Insert into CardDetails values (4567890123456789, 'Durgesh', 'V', 321, '2025-10-31', 500000.00)
Insert into CardDetails values (5678901234567890, 'Harsh', 'M', 654, '2026-02-28', 300000.00)
Insert into CardDetails values (6789012345678901, 'Animesh', 'A', 987, '2025-09-30', 250000.00)
Insert into CardDetails values (7890123456789012, 'John', 'V', 111, '2026-03-31', 400000.00)
Insert into CardDetails values (8901234567890123, 'Bill', 'M', 222, '2025-08-31', 600000.00)
Insert into CardDetails values (9012345678901234, 'Lata', 'A', 333, '2025-07-31', 700000.00)


select * from Roles;
select * from Users;
Select * from Categories;
Select * from Products;
Select * from PurchaseDetails;
Select * from CardDetails;




