using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IClientService
{
    Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync();
}
