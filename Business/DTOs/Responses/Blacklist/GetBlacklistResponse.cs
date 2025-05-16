namespace Business.DTOs.Responses.Blacklist;

public class GetBlacklistResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string Reason { get; set; }
    public string Date { get; set; }    
}
