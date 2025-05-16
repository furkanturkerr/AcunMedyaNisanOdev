namespace Business.DTOs.Responses.Applicaton;

public class GetAllApplicationsResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationState { get; set; }
}
