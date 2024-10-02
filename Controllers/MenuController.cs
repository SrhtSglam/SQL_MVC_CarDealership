using Microsoft.AspNetCore.Mvc;
using SQL_MVC_CarDealership.Models;
using System.Data.SqlClient;

public class MenuController : Controller{
    public ActionResult Index(){
        SqlMethod();

        return View("Index", carsList);
    }
    public List<Cars> carsList = new List<Cars>();

    string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Northwind;User Id=sqlsa;Password=Abc123+";

    public void SqlMethod(){
        SqlConnection connect = new SqlConnection(ConnectionString);
        connect.Open();
        string query = "SELECT * FROM TestTable1 tb";
        SqlCommand cmd = new SqlCommand(query, connect);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read()){
            carsList.Add(new Cars(){
                Id = Convert.ToInt32(dr["ID"]),
                CID = Convert.ToInt32(dr["CATEGORYID"]),
                Model = dr["TITLE"].ToString()
            });
        }
        dr.Close();
        connect.Close();
        
    }
}