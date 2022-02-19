using MahimaModhawala.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MahimaModhawala.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True;";
            sql.Open();
            SqlCommand view = new SqlCommand();
            view.Connection = sql;
            view.CommandType = System.Data.CommandType.StoredProcedure;
            view.CommandText = "index";
            List<Products> list = new List<Products>();
            try
            {
                SqlDataReader dr = view.ExecuteReader();
                while(dr.Read())
                {
                    Products ps = new Products();
                    ps.ProductId = (int)dr["ProductId"];
                    ps.ProductName = (string)dr["ProductName"];
                    ps.Rate = (decimal)dr["Rate"];
                    ps.Description = (string)dr["Description"];
                    ps.CategoryName = (string)dr["CategoryName"];
                    list.Add(ps);
                }

            }catch(Exception e)
            {
            }

            sql.Close();
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True;";
            sql.Open();
            SqlCommand view = new SqlCommand();
            view.Connection = sql;
            view.CommandType = System.Data.CommandType.StoredProcedure;
            view.CommandText = "updatebyid";
            //view.CommandText = "Select *  from Products where ProductId=@ProductId";
            view.Parameters.AddWithValue("@ProductId",id);
            SqlDataReader dr = view.ExecuteReader();
            Products pp = null;
            if(dr.Read())
            {
                pp = new Products { ProductId = (int)id, ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] }; 
            
            }
            sql.Close();
            return View(pp);
            
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Products obj)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practice;Integrated Security=True;";
            sql.Open();
            SqlCommand view = new SqlCommand();
            view.Connection = sql;
            view.CommandType = System.Data.CommandType.StoredProcedure;
            view.CommandText = "edit";
            //view.CommandText = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@ProductId";
            view.Parameters.AddWithValue("@ProductId",obj.ProductId);
            view.Parameters.AddWithValue("@ProductName",obj.ProductName);
            view.Parameters.AddWithValue("@Rate", obj.Rate);
            view.Parameters.AddWithValue("@Description", obj.Description);
            view.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
            view.ExecuteNonQuery();
            sql.Close();
            return View();

        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult welcome()
        {
            return View();
        }
    }
}
