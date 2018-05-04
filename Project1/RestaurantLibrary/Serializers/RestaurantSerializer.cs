using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using RestaurantLibrary.Models;

namespace RestaurantLibrary.Serializers
{
    public static class RestaurantSerializer
    {
       

        public static void SerializeMethod(Restaurant res, string filepath)
        {
            XmlSerializer resSerializer = new XmlSerializer(typeof(Restaurant));
            TextWriter writer = new StreamWriter(filepath);  
            resSerializer.Serialize(writer, res);
            writer.Close();

        }

    }
}
