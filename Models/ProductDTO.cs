using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Models;

public class ProductDTO {
    public required string? Name {get;set;}
    public string? Description {get;set;}
    public string? ImgUrl {get;set;}
    public required int CategoryId {get;set;}

}