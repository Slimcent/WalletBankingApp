using System;

namespace Wallet.Entities.Dto.Response
{
    public class NetworkProviderResponseDto
    {
        public Guid Id { get; set; }
        public string NetworkProvider { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
