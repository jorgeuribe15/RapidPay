-- USERS
--Insert Into [dbo].[User] Values ('uribej','paswordTest1', 'ADMIN')


--Insert Into Client Values ('Jorge Uribe', GETDATE(), 1)
--Insert Into Client Values ('Liz Chavira', GETDATE(), 1)
--Insert Into Client Values ('Rogelio Escobedo', GETDATE(), 1)


--Insert Into ClientCards Values (1, 3, 1)
--Insert Into ClientCards Values (2, 1, 1)
--Insert Into ClientCards Values (3, 2, 1)


-- CREATE TRANSACTIONS
--Insert Into Transactions Values (1, 25, GETDATE(), 'PLACE_ONE')
--Insert Into Transactions Values (2, 28, GETDATE(), 'PLACE_TWO')
--Insert Into Transactions Values (3, 32, GETDATE(), 'PLACE_THREE')
--Insert Into Transactions Values (1, 16, GETDATE(), 'PLACE_TWO')
--Insert Into Transactions Values (2, 51, GETDATE(), 'PLACE_THREE')
--Insert Into Transactions Values (3, 34, GETDATE(), 'PLACE_ONE')


-- Credit Ammount
--Insert Into  Credit Values (1, 500)
--Insert Into  Credit Values (2, 300)
--Insert Into  Credit Values (3, 700)


Select * From Client
Select * From Cards
Select * From ClientCards
Select * From Credit
Select * From Transactions
Select * From Payments
Select * From [dbo].[User]

Delete From Payments
