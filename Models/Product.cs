using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Models;

public class Product {
    [Key]
    public long Id {get;set;}
    [NotNull]
    public string? Name {get;set;}
    [AllowNull]
    public string? Description {get;set;}
    [AllowNull]
    public string? ImgUrl {get;set;}
    [NotNull]
    public int CategoryId {get;set;}

}