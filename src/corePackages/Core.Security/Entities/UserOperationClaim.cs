using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class UserOperationClaim : Entity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId, bool status) : base(id, status)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
        Status = status;
    }
}