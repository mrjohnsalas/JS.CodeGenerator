﻿SELECT 
MAX(CONVERT(INT, SUBSTRING(OBJ.NAME, 12, 100))) AS SP_COUNT
FROM DBO.SYSOBJECTS OBJ 
WHERE 
OBJ.XTYPE = 'P'
AND OBJ.NAME LIKE ?