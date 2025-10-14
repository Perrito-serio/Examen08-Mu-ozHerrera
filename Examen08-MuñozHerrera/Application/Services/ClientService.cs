using Examen08_MuñozHerrera.DTOs;
using Examen08_MuñozHerrera.Core.Interfaces;

namespace Examen08_MuñozHerrera.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        return _clientRepository.GetClientWithMostOrdersAsync();
    }
}
