using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("Employee_ID")]
    public int EmployeeId { get; set; }

    [Column("First_Name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("Middle_Name")]
    [StringLength(50)]
    public string? MiddleName { get; set; }

    [Column("Last_Name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Telephone { get; set; } = null!;

    [StringLength(50)]
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    [Column("Role_ID")]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string? Image { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeLocation> EmployeeLocations { get; set; } = new List<EmployeeLocation>();

    [InverseProperty("Employee")]
    public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; } = new List<EmployeeSchedule>();

    [InverseProperty("Employee")]
    public virtual ICollection<Pickup> Pickups { get; set; } = new List<Pickup>();

    [ForeignKey("RoleId")]
    [InverseProperty("Employees")]
    public virtual Role Role { get; set; } = null!;
}
