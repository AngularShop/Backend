using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Models;

public class Category {
    [Key]
    public int CategoryId {get;set;}
    [AllowNull]
    public int? ParentId {get;set;}
    [NotNull]
    public string? Title {get;set;}
}