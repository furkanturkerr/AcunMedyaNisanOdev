using Core.Exceptions.Types;
using Core.Rules;

namespace Business.Rules;

public class BlacklistBusinessRules : BaseBusinessRules
{
    public void CheckIfMultipleActiveBlacklistExists(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı aday için birden fazla aktif kara liste kaydı olamaz.");
    }

    public void CheckIfReasonIsEmpty(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new BusinessException("Sebep (reason) boş bırakılamaz.");
    }
}
