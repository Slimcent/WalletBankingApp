using System;
using System.Collections;
using System.Linq;

namespace Wallet.Entities.Helpers
{
    public static class EnumConverter
    {
        public static IEnumerable ConvertEnumToList(Enum model)
        {
            var agencyNames = Enum.GetNames(model.GetType());

            return agencyNames.ToList();
        }
    }
}
