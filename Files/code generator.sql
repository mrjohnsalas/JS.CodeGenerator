DECLARE @TABLE_NAME AS NVARCHAR(50)
SET @TABLE_NAME = 'CL_DETCUS'

----TABLES
--SELECT 
--* 
--FROM OUTB TB
--WHERE
--TB.TableName = @TABLE_NAME

SELECT 
* 
FROM CUFD CO
WHERE
--CO.TableID = '@' + @TABLE_NAME AND 
EditType = 'T'
ORDER BY EditType
--NULL
-- 
--T
--TIPO
--(A) - ALFANUMERICO
----() - REGULAR
----() - DIRECCION
----() - NUMERO DE TELEFONO
----(M) - TEXTO

--(N) - NUMERICO
----(T) - HORA

--(D) - FECHA Y HORA
----(D) - FECHA

--(B) - UNIDADES Y TOTALES
----(R) - TARIFA
----(S) - IMPORTE
----(P) - PRECIO
----(Q) - CANTIDAD
----(%) - PORCENTAJE
----() - MEDIDA

--(M) - GENERAL
----(B) - ENLACE
----() - IMAGEN