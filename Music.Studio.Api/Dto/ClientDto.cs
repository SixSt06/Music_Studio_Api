using Music.Studio.Core.Entities;

namespace Music.Studio.Api.Dto;

public class ClientDto 
{
    public int idClient { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public ClientDto()
    {
        
    }

    public ClientDto(Client client)
    {
        idClient = client.idClient;
        Name = client.Name;
        Address = client.Address;
        Phone = client.Phone;
        Email = client.Email;
    }
}