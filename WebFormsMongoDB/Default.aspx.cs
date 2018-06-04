using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using WebFormsMongoDB.Models;

namespace WebFormsMongoDB
{
    public partial class Default : System.Web.UI.Page
    {
        string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            List<CarsInfo> carNames = new List<CarsInfo>();
            //1. Connect to MongoDB instance running on localhost
            var client = new MongoClient();
            //Access database named 'CarsDB'
            var database = client.GetDatabase("CarsDB");
            //Access collection named 'cars'
            var collection = database.GetCollection<CarsInfo>("cars");

            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (CarsInfo ACars in documents)
            {
                name = name + "<br/>" + ACars.Car + " " + ACars.CarModel + ", " + ACars.ProductionYear + " Production Year";

                carNames.Add(ACars);

            }
            nameLabel.Text = name;
        }

    }
}