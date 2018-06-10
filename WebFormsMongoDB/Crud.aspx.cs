﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using WebFormsMongoDB.Models;
using System.Data;
using MongoDB.Driver.Builders;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebFormsMongoDB
{
    public partial class Crud : System.Web.UI.Page
    {
        protected static IMongoClient client = new MongoClient();
        protected static IMongoDatabase db = client.GetDatabase("CarsDB");


        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string name = e.Row.Cells[2].Text;
        //        Response.Write(name);
        //    }
        //}





        protected void Page_Load(object sender, EventArgs e)
        {
            List<CarsInfo> Cars = new List<CarsInfo>();
            var collection = db.GetCollection<CarsInfo>("cars");
            var document = collection.Find(new BsonDocument()).ToList();

            var hideDeletedCars = document.Where(x => x._id == x._id).ToList();

            foreach (var item in hideDeletedCars)
            {
                if (item.isDeleted == true)
                {
                    //GridView1.Rows[0].Visible = false;
                }
            }
            //if (e.Row.Cells[1].Text == "")
            //    e.Row.Visible = false;

            

            //foreach (var item in hideDeletedCars)
            //{
            //    if(item.isDeleted == true)
            //    {
            //        Response.Write("haeee");
            //        //GridView1.Visible = false;
            //    }
            //}


            GridView1.DataSource = document;
            GridView1.DataBind();


            if (!IsPostBack)
            {
                DropDownListCar.DataSource = document;
                DropDownListCar.DataBind();
                //DropDownListCar.Items.Insert(0, new ListItem("-- აირჩიეთ მანქანა --", string.Empty));
            }

            if (!IsPostBack)
            {
                DropDownListCarModel.DataSource = document;
                DropDownListCarModel.DataBind();
                //DropDownListCarModel.Items.Insert(0, new ListItem("-- აირჩიეთ მოდელი --", string.Empty));
            }

            if (!IsPostBack)
            {
                DropDownListProductionYear.DataSource = document;
                DropDownListProductionYear.DataBind();
                //DropDownListProductionYear.Items.Insert(0, new ListItem("-- აირჩიეთ გამოშვების წელი --", string.Empty));
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownListCar.SelectedValue == "-1" || DropDownListCarModel.SelectedValue == "-1" || DropDownListProductionYear.SelectedValue == "-1")
            {
                Response.Write("<span style='color:red'>აირჩიეთ მანქანა, მანქანის მოდელი, გამოშვების თარიღი</span>");
            }
            else
            {
                var collection = db.GetCollection<BsonDocument>("cars");
                var document = new BsonDocument
                {
                    {"Car", DropDownListCar.SelectedItem.Text },
                    {"CarModel", DropDownListCarModel.SelectedItem.Text },
                    {"ProductionYear", DropDownListProductionYear.SelectedItem.Text },
                    {"isDeleted", false }
                };
                collection.InsertOneAsync(document);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

      

        [WebMethod]
        public static void DeleteRecord(string id)
        {
            try
            {
                var collection = db.GetCollection<CarsInfo>("cars");
                var filter = Builders<CarsInfo>.Filter.Eq("_id", ObjectId.Parse(id));

                var document = collection.Find(new BsonDocument()).ToList();

                var carToUpdate = document.Where(x => x._id == ObjectId.Parse(id)).FirstOrDefault();

                CarsInfo carsinfo = new CarsInfo();
                carsinfo._id = ObjectId.Parse(id);
                carsinfo.Car = carToUpdate.Car;
                carsinfo.CarModel = carToUpdate.CarModel;
                carsinfo.ProductionYear = carToUpdate.ProductionYear;
                carsinfo.isDeleted = true;
                

                collection.ReplaceOne(filter, carsinfo);


            }
            catch(Exception ex)
            {
                var message = ex.Message;
            }
        }

    }
}











//var client = new MongoClient();
//var db = client.GetDatabase("CarsDB");








































//[WebMethod]
//public static void DeleteRecord(string id)
//{
//    try
//    {
//        var collection = db.GetCollection<BsonDocument>("cars");

//        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

//        collection.DeleteOne(filter);
//    }
//    catch (Exception ex)
//    {
//        var message = ex.Message;

//    }
//}

//var collection = db.GetCollection<CarsInfo>("cars");
//var filter = Builders<CarsInfo>.Filter.Eq("_id", ObjectId.Parse(id));

//var document = collection.Find(new BsonDocument()).ToList();

//var carToUpdate = document.Where(x => x._id == ObjectId.Parse(id)).FirstOrDefault();

//CarsInfo carsinfo = new CarsInfo();
//carsinfo._id = ObjectId.Parse(id);
//carsinfo.Car = carToUpdate.Car;
//carsinfo.CarModel = carToUpdate.CarModel;
//carsinfo.ProductionYear = carToUpdate.ProductionYear;
//carsinfo.isDeleted = "true";

//collection.ReplaceOne(filter, carsinfo);






//OnSelectedIndexChanged="OnSelectedIndexChanged"
//protected void btnSave_Click(object sender, EventArgs e)
//{

//    //var client = new MongoClient();
//    //var db = client.GetDatabase("CarsDB");

//    var collection = db.GetCollection<BsonDocument>("cars");
//    var document = new BsonDocument
//        {
//             { "Car", txtCar.Text.ToString() },
//             { "CarModel", txtCarModel.Text.ToString() },
//             { "ProductionYear", txtProductionYear.Text.ToString() }
//        };
//    collection.InsertOneAsync(document);
//    Response.Redirect(Request.Url.AbsoluteUri);

//}

//protected void OnSelectedIndexChanged(object sender, EventArgs e)
//{
//    GridViewRow row = GridView1.SelectedRow;
//    //ViewState["Eval"] = row.Cells[1].Text;

//    txtCar.Text = row.Cells[2].Text;
//    txtCarModel.Text = row.Cells[3].Text;
//    txtProductionYear.Text = row.Cells[4].Text;
//}

//protected void btnUpdate_Click(object sender, EventArgs e)
//{
//    try
//    {

//        GridViewRow row = GridView1.SelectedRow;

//        string id = row.Cells[1].Text;


//        //var client = new MongoClient();
//        //var db = client.GetDatabase("CarsDB");
//        var collection = db.GetCollection<BsonDocument>("cars");

//        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

//        CarsInfo c = new CarsInfo();
//        c._id = ObjectId.Parse(id);
//        c.Car = txtCar.Text;
//        c.CarModel = txtCarModel.Text;
//        c.ProductionYear = txtProductionYear.Text;


//        collection.ReplaceOne(filter, c.ToBsonDocument());
//        Response.Redirect(Request.Url.AbsoluteUri);
//    }
//    catch (Exception)
//    {
//        lblErrorMessage.Text = "აირჩიეთ ავტომობილი";
//        txtCar.Text = "";
//        txtCarModel.Text = "";
//        txtProductionYear.Text = "";
//    }

//}

//protected void btnDelete_Click(object sender, EventArgs e)
//{

//    try
//    {
//        GridViewRow row = GridView1.SelectedRow;

//        string id = row.Cells[1].Text;

//        if (id == null)
//        {
//            Response.Write("id is null");
//        }

//        //var client = new MongoClient();
//        //var db = client.GetDatabase("CarsDB");
//        var collection = db.GetCollection<BsonDocument>("cars");

//        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

//        collection.DeleteOne(filter);
//        Response.Redirect(Request.Url.AbsoluteUri);
//    }
//    catch (Exception)
//    {
//        lblErrorMessage.Text = "აირჩიეთ ავტომობილი";
//        txtCar.Text = "";
//        txtCarModel.Text = "";
//        txtProductionYear.Text = "";
//    }

//}