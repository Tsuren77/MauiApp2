namespace MauiApp2.Models;

public class Location
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string dimension { get; set; }
    public string[] residents { get; set; }
    public string url { get; set; }
    public DateTime created { get; set; }
}

public class RootObject
{
    public Info info { get; set; }
    public Results[] results { get; set; }
}



public class Info
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
    public string type { get; set; }
    public string dimension { get; set; }
    public string[] residents { get; set; }
    public string url { get; set; }
    public string created { get; set; }
}


