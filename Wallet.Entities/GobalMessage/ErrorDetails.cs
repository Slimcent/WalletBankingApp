using System.Text.Json;
using Wallet.Entities.Enumerators;

namespace Wallet.Entities.GobalError
{
    public class ErrorDetails
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);

    }
}
