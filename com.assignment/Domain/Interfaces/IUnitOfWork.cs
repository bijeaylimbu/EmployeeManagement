using com.assignment.Common;
using Microsoft.AspNetCore.Mvc;

namespace com.assignment.Domain.Interfaces;

public interface IUnitOfWork: IDisposable
{
    Task<ResponseMessage> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}