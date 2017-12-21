﻿using System;
using System.Collections.Generic;
using System.Linq;
using ICT13580570EndB.Models;
using SQLite;

namespace ICT13580570EndB.Helpers
{
    public class DbHelper
    {
		SQLiteConnection db;

		public DbHelper(string dbPath)
		{
			db = new SQLiteConnection(dbPath);
			db.CreateTable<Product>();
		}
        public int AddProduct(Product product)
		{
            db.Insert(product);
            return product.Id;
		}
        public List<Product> GetProduct()
		{
            return db.Table<Product>().ToList();
		}
        public int UpdateProduct(Product product)
		{
            return db.Update(product);
		}

		public int DeleteProduct(Product product)
		{
			return db.Delete(product);
		}
	}
}