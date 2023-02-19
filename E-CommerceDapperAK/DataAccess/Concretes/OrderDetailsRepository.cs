using Dapper;
using E_CommerceDapperAK.DataAccess.Abstractions;
using E_CommerceDapperAK.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapperAK.DataAccess.Concretes
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private string ConnectionString { get; set; }
        public OrderDetailsRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
        public void Add(OrderDetails data)
        {
            using (var conn=new SqlConnection(ConnectionString))
            {
                var sql = @"INSERT INTO [Order Details]([OrderID],[ProductID],[UnitPrice],[Quantity],[Discount])
                            VALUES(10248,@pId,@pPrice,@pQuantity,@pDiscount)";
                conn.Execute(sql,new {pId=data.ProductID,pPrice=data.UnitPrice,pQuantity=data.Quantity
                    ,pDiscount=0});   
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetails data)
        {
            throw new NotImplementedException();
        }
    }
}
