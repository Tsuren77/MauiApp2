
namespace MauiApp2.Models
{
    public class Personajes
    {
        public Info info { get; set; }
        
       public Results[] results { get; set; }
      
    }

    public  class Info
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
        public object prev { get; set; }
    }

    public class Results
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public Origin origin { get; set; }
        public Location location { get; set; }
        public string image { get; set; }
        public string[] episode { get; set; }
        public string url { get; set; }
        public string created { get; set; }
    }

    public class Origin
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Location
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}