using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Serializers
{
    public static class RestaurantDeserializer
    {
        public static Restaurant DeserializeMethod(string filepath)
        {
            Restaurant restaurant = new Restaurant();

            TextReader txtReader = new StreamReader(@filepath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Restaurant));

            restaurant = (Restaurant)xmlSerializer.Deserialize(txtReader);

            txtReader.Close();

            return restaurant;



        }
    }
}
