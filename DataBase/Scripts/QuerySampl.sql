SELECT top 10 * 
FROM   dbo.Books
--WHERE  CONTAINS(file_stream, N'فرازهایی  near سخنرانی Near حضرت Near علامه  Near مراسم Near شهدا') 
WHERE  CONTAINS(file_stream, N'جِراحاتُ NEAR السِّنانِ NEAR لها NEAR التيامٌ') 

