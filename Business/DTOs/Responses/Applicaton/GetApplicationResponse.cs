namespace Business.DTOs.Responses.Applicaton;

public class GetApplicationResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationState { get; set; }
    public int BootcampId { get; internal set; }
}
