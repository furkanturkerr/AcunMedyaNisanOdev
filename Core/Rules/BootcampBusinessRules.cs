using Core.Exceptions.Types;
using Core.Rules;

namespace Business.Rules;

public class BootcampBusinessRules : BaseBusinessRules
{
    public void CheckIfStartDateBeforeEndDate(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new BusinessException("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
    }

    public void CheckIfBootcampNameExists(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı isimde bir bootcamp daha önce açılmıştır.");
    }

    public void CheckIfInstructorExists(bool exists)
    {
        if (!exists)
            throw new BusinessException("Eğitmen sistemde kayıtlı olmalıdır.");
    }

    public void CheckIfBootcampIsClosed(string status)
    {
        if (status == "CLOSED")
            throw new BusinessException("Başvuru durumu \"CLOSED\" olan bootcamp’e başvuru alınamaz.");
    }
}
