Create proc Sp_Login
@Admin_id NVARCHAR(100),
@Password NVARCHAR(100),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid = (SELECT COUNT(1)FROM admin WHERE nama=@Admin_id AND password=@Password )
end

select * from admin

DROP PROCEDURE dbo.Sp_Login;  
GO