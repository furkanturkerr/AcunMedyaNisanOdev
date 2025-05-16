namespace Business.DTOs.Responses.Bootcamp;

public class GetBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string StartDate { get; set; }  
    public string EndDate { get; set; }
    public string BootcampState { get; set; }
}
