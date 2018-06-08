using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsMongoDB
{
    public partial class AddCar : System.Web.UI.Page
    {
        protected static IMongoClient client = new MongoClient();
        protected static IMongoDatabase db = client.GetDatabase("CarsDB");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var collection = db.GetCollection<BsonDocument>("cars");
            var document = new BsonDocument
            {
                {"Car", txtCar.Text.ToString() },
                {"CarModel", txtCarModel.Text.ToString() },
                {"ProductionYear", txtProductionYear.Text.ToString() },
                {"isDeleted", false }

            };
            collection.InsertOneAsync(document);
            //Response.Redirect("Crud.aspx", true);
            Response.Redirect("Crud.aspx");

        }
    }
}