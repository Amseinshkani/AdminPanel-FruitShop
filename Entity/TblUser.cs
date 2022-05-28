using System.ComponentModel.DataAnnotations;


public class TblUser
{
    [Key]
    public long Id { get; set; }

    public string UserName { get; set; }

    public int PassWord { get; set; }

}
