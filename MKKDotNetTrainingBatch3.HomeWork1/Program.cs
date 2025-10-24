using MKKDotNetTrainingBatch3.HomeWork1.ProductServices;
using MKKDotNetTrainingBatch3.HomeWork1.SaleServices;

ProductSqlService productSQLService = new ProductSqlService();
//productSQLService.Create();
//productSQLService.Read();
//productSQLService.Update();
//productSQLService.Delete();

ProductDrapperService productDrapperService = new ProductDrapperService();
//productDrapperService.Create();
//productDrapperService.Update();
//productDrapperService.Delete();
//productDrapperService.Read();

ProductEFCoreModelService productEFCoreModelService = new ProductEFCoreModelService();
//productEFCoreModelService.Create();
//productEFCoreModelService.Update();
//productEFCoreModelService.Delete1();
//productEFCoreModelService.Delete2();
//productEFCoreModelService.Read();

ProductEFCoreDBService productEFCoreDBService = new ProductEFCoreDBService();
//productEFCoreDBService.Create();
//productEFCoreDBService.Update();
//productEFCoreDBService.Delete();
//productEFCoreDBService.Read();

SaleSqlService saleSqlService = new SaleSqlService();
//saleSqlService.Read();
//saleSqlService.Create();

SaleDrapperService saleDrapperService = new SaleDrapperService();
//saleDrapperService.Create();
//saleDrapperService.Read();

SaleEFCoreModelService saleEFCoreModelService = new SaleEFCoreModelService();
//saleEFCoreModelService.Create();
//saleEFCoreModelService.Read();

SaleEFCoreDBService saleEFCoreDBService = new SaleEFCoreDBService();
saleEFCoreDBService.Create();
saleEFCoreDBService.Read();

