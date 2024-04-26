using Music.Studio.Api.Dto;
using Music.Studio.Api.Repositories.Interfaces;
using Music.Studio.Api.Services.Interfaces;
using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
    public async Task<bool> ClientExist(int idClient)
    {
        var client= await _clientRepository.GetByIdAsync(idClient);
        return (client != null);
    }

    public async Task<ClientDto> SaveAsync(ClientDto clientDto)
    {
        var client = new Client
        {
            Name = clientDto.Name,
            Address = clientDto.Address,
            Phone = clientDto.Phone,
            Email = clientDto.Email,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        client = await _clientRepository.SaveAsync(client);
        clientDto.idClient = clientDto.idClient;
        return clientDto;
    }

    public async Task<ClientDto> UpdateAsync(ClientDto clientDto)
    {
        var client = await _clientRepository.GetByIdAsync(clientDto.idClient);

        if (client == null)
        {
            throw new Exception("Client not found");
        }

        client.Name = clientDto.Name;
        client.Address = clientDto.Address;
        client.Phone = clientDto.Phone;
        client.Email = clientDto.Email;
        client.UpdatedBy = "";
        client.UpdatedDate = DateTime.Now;
        await _clientRepository.UpdateAsync(client);
        return clientDto;
    }

    public async Task<List<ClientDto>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        var clientsDto = clients.Select(c => new ClientDto(c)).ToList();
        return clientsDto;
    }

    public async Task<bool> DeleteAsync(int idClient)
    {
        return await _clientRepository.DeleteAsync(idClient);
    }

    public async Task<ClientDto> GetByIdAsync(int idClient)
    {
        var client = await _clientRepository.GetByIdAsync(idClient);
        if (client == null)
        {
            throw new Exception("Client not Found");
        }

        var clientDto = new ClientDto(client);
        return clientDto;
    }
}