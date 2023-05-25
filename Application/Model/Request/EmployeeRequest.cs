namespace Application.Model.Request;

public class EmployeeRequest
{
    public string FullName { get; set; } = null!;
    public string? Mobile { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
}

public class EmployeeSort
{
    public string? Column { get; set; }
    public bool? Desc { get; set; }
}
