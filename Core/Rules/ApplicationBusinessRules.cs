using Core.Exceptions.Types;
using Core.Rules;

namespace Business.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    public void CheckIfAlreadyApplied(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı kişi aynı bootcamp’e birden fazla başvuru yapamaz.");
    }

    public void CheckIfBootcampIsActive(bool isActive)
    {
        if (!isActive)
            throw new BusinessException("Başvuru yapılan bootcamp aktif olmalıdır.");
    }

    public void CheckIfApplicantBlacklisted(bool isBlacklisted)
    {
        if (isBlacklisted)
            throw new BusinessException("Kara listeye alınmış bir aday başvuru yapamaz.");
    }

    public void CheckIfStatusChangeAllowed(string currentStatus, string newStatus)
    {
        if (currentStatus == "CANCELLED" && newStatus == "PENDING")
            throw new BusinessException("Başvurunun durumu sadece belirli statülere geçirilebilir.");
    }
}

