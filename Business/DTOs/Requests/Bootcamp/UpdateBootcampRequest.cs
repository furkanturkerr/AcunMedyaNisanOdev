using Entities;

namespace Business.DTOs.Requests.Bootcamp;

public class UpdateBootcampRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public BootcampState BootcampState { get; set; }
}
