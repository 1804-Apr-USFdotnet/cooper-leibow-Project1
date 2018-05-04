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
    class ReviewDeserializer
    {
        public Review DeserializeMethod()
        {
            Review review = new Review();

            TextReader txtReader = new StreamReader(@"");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Review));

            review = (Review)xmlSerializer.Deserialize(txtReader);

            txtReader.Close();

            return review;



        }
    }
}
