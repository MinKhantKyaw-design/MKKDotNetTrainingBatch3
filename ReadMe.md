
// Database base Scaffold Command
dotnet ef dbcontext scaffold "Server=.;Database=MKKBatch3MiniPOS;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f

Homework
- ADO.NET - Project - 1
- Dapper - Project - 1
- EFCore Database First - Project - 2 (ConsoleApp + Database)

``Product sql
CREATE TABLE [dbo].[Tbl_Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[DeleteFlag] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


``` Sale sql
Sale (Create, Read)
- SaleId
- ProductId
- Quantity
- Price
- DeleteFlag
- CreatedDateTime

``` Procedure for Sale
- Validation (Quantity <, Quantity -)


 
SELECT 
    dc.name AS DefaultConstraintName
FROM sys.default_constraints dc
INNER JOIN sys.columns c ON dc.parent_object_id = c.object_id AND dc.parent_column_id = c.column_id
INNER JOIN sys.tables t ON t.object_id = c.object_id
WHERE t.name = 'Tbl_Products' AND c.name = 'DeleteFlag';

ALTER TABLE Tbl_Products DROP CONSTRAINT DF__Product__DeletFl__49C3F6B7;

ALTER TABLE Tbl_Sales
ADD CONSTRAINT DF_Tbl_Sales_DeleteFlag DEFAULT (0) FOR DeleteFlag;