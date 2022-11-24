namespace AspCore_JWT.Models;
public class Client
{
    public string ClientId { get; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;

    public Client()
    {
        // https://stackoverflow.com/questions/11313205/generate-a-unique-id
        ClientId = Guid.NewGuid().ToString("N");
    }

}