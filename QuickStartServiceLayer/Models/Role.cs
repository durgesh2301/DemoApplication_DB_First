using QuickStartDALLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickStartServiceLayer.Models;

public partial class Role
{
    public int RoleId { get; set; }
    [Required(ErrorMessage = "Role name is required.")]
    [StringLength(50, ErrorMessage = "Role name cannot exceed 50 characters.")]
    public string RoleName { get; set; }

}
