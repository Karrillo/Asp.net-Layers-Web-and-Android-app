﻿using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.ProductsProviders
{
    public class ProductsProvidersAccess
    {
        private ContextDb db;

        public ProductsProvidersAccess()
        {
            db = new ContextDb();
        }

        //Get All Products Provideres
        public List<Products> GetAll(Int64 id)
        {
            List<Products> products = new List<Products>();
            try
            {
                products = db.Provider_Products(id).ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        //Get Products Provideres
        public Products GetById(Int64 id)
        {
            Products products = new Products();
            try
            {
                return db.View_Product(id);
            }
            catch (Exception)
            {
                return products;
            }
        }

        //Update Products Provideres
        public int Update(Products products, Int64 id)
        {
            try
            {
                String code = db.Check_CodeProduct(products.Code);

                if (code == null || code == GetById(id).Code)
                {
                    db.Update_Product(products, id);
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Create Products Provideres
        public int Create(Products products)
        {
            try
            {
                if (db.Check_CodeProduct(products.Code) == null)
                {
                    db.Insert_Product(products);
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Delete Products Provideres
        public int Delete(int id)
        {
            try
            {
                db.Delete_Product(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Get All Providers Name 
        public List<List_Providers> GetAllProviders()
        {
            List<List_Providers> providers = new List<List_Providers>();

            try
            {
                providers = db.List_Providers().ToList();
                return providers;
            }
            catch (Exception)
            {
                return providers;
            }
        }
    }
}
