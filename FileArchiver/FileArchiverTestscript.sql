USE [ETRM_Support]
GO



SELECT top 20 *
  FROM [dbo].[ErrorControl] ec
  join [dbo].[ErrorLogs] el on ec.ErrorControlID=el.ErrorControlID
  
order by ErrorDateTime desc


