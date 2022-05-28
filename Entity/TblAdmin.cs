using System.ComponentModel.DataAnnotations;


public class TblAdmin
{
    [Key]
    public int Id { get; set; }
    public string Admin { get; set; }
    public int PassWord { get; set; }
}
