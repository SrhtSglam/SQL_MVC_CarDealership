using Microsoft.AspNetCore.Mvc;
using SQL_MVC_CarDealership.Models;
using System.Data.SqlClient;

public class MenuController : Controller{

    public MyViewModel model;

    public ActionResult Index(){
        SqlMethod();

        return View("Index", model);
    }

    public ActionResult Privacy(){
        SqlMethod();

        return View("Index", model);
    }

    string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Northwind;User Id=sqlsa;Password=Abc123+";
    int count = 0;

    public void SqlMethod(){
        if(model == null){
            model = new MyViewModel();
        }
        if(model.cars == null){
            model.cars = new List<Cars>();
        }
        if(model.company == null){
            model.company = new List<Company>();
        }
        if(model.price == null){
            model.price = new List<Price>();
        }
        SqlConnection connect = new SqlConnection(ConnectionString);
        connect.Open();
        string query = "SELECT * FROM TestTable1 tb";
        SqlCommand cmd = new SqlCommand(query, connect);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read()){
            model.cars.Add(new Cars(){
                Id = Convert.ToInt32(dr["ID"]),
                CID = Convert.ToInt32(dr["CATEGORYID"]),
                Model = dr["TITLE"].ToString()
            });
            model.company.Add(new Company(){
                Totals = count += 1
            });
            model.price.Add(new Price(){
                carPrice = Convert.ToInt32(dr["PRICE"])
            });
        }
        dr.Close();
        connect.Close();
        
    }
}