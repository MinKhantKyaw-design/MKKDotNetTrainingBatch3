using Microsoft.Data.SqlClient;
using MKKDotNetTrainingBatch3.ConsoleApp1;
using System.Data;

// Sql Query based implementation
ProductService productService = new ProductService();
productService.Read();
//productService.Create();
//productService.Update();
//productService.Delete();

// Dapper based implementation
ProductDapperService productDapperService = new ProductDapperService();
productDapperService.Read();
//productDapperService.Create();
//productDapperService.Update();
//productDapperService.Delete();

// EF Core based implementation
ProductEFCoreService productEFCoreService = new ProductEFCoreService();
// productEFCoreService.Create();
//productEFCoreService.Update();
// productEFCoreService.Delete();
productEFCoreService.Read();
