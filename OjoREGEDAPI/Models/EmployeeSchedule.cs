using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Employee_Schedule")]
public partial class EmployeeSchedule
{
    [Key]
    [Column("Employee_Schedule_ID")]
    public int EmployeeScheduleId { get; set; }

    [Column("Employee_ID")]
    public int EmployeeId { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("Max_Order")]
    public int MaxOrder { get; set; }

    [Column("Order_Scheduled")]
    public int OrderScheduled { get; set; }

    [Column("Start_Date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("End_Date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeSchedules")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("EmployeeSchedule")]
    public virtual ICollection<OrderPlaced> OrderPlaceds { get; set; } = new List<OrderPlaced>();
}
