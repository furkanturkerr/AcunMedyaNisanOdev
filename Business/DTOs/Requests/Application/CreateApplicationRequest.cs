using Entities;

namespace Business.DTOs.Requests;

public class CreateApplicationRequest
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public ApplicationState ApplicationState { get; internal set; }
}
