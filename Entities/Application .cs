namespace Entities;

public class Application
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public ApplicationState ApplicationState { get; set; }

    public Bootcamp Bootcamp { get; set; }

    public Application() { }

    public Application(int ıd, int applicantId, int bootcampId, ApplicationState applicationState, Bootcamp bootcamp)
    {
        Id = ıd;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationState = applicationState;
        Bootcamp = bootcamp;
    }
}



public enum ApplicationState
{
    PENDING = 0,
    APPROVED = 1,
    REJECTED = 2,
    IN_REVIEW = 3,
    CANCELLED = 4
}
