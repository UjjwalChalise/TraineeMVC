using System.ComponentModel.DataAnnotations;
namespace TraineeMVC.ViewModels;

public class ModuleCreateViewModel
{
    [Required] [StringLength(200)] public string Name { get; set; } = string.Empty;

    [StringLength(2000)] public string? Description { get; set; }

}


public class ModuleUpdateViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }
}

public class ModuleDetailViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int CourseCount { get; set; }
}


public class ModuleDeleteViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int CourseCount { get; set; }
}
