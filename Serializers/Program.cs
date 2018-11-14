using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Script.Serialization;


namespace Serializers
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            var jsonData1 = "[{ \"user\" : { \"name\" : \"Manas\", \"gender\" : \"Male\", \"birthday\" : \"1987-8-8\"} }, "           +  
                            "{ \"user\" : { \"name\" : \"Mohapatra\", \"gender\" : \"Female\", \"birthday\" : \"1987-7-7\"} }"         + 
                           "]";
*/

            var jsonData2 = "[ { \"name\" : \"Manas\",       \"gender\" : \"Male\",      \"birthday\" : \"1987-8-8\"}, "    +
                              "{ \"name\" : \"Mohapatra\",   \"gender\" : \"Female\",    \"birthday\" : \"1987-7-7\"} "    +
                            "]";


            // Deserializing json data to object 

            JavaScriptSerializer js = new JavaScriptSerializer();
            User[]  usrObj = js.Deserialize<User[]>(jsonData2);

            string name = usrObj[0].Name;
            string gender = usrObj[0].Gender;
/*
            // Other way to whithout help of BlogSites class  
            dynamic blogObject = js.Deserialize<dynamic>(jsonData);
            string name = blogObject["Name"];
            string description = blogObject["Description"];
*/

        }

    }

    public class User
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
