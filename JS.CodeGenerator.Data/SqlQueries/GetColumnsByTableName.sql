SELECT 
CONVERT(INT, T0.FieldID) AS Id,
T0.AliasID AS ColumnName,
T0.Descr AS Description,
T0.NotNull AS NotNull,
CONVERT(INT, T0.SizeID) AS Size,
REPLACE(T0.TableID, '@', '') AS TableName
FROM CUFD T0
WHERE
T0.TableID = '@' + ?