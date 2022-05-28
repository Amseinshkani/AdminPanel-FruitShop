using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


public class TblProduct
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public int Count { get; set; }

    public string upimg { get; set; }

    public int Requestedweight { get; set; }

    public int totalweight { get; set; }
}
