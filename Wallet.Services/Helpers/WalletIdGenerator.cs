﻿using System;
using System.Security.Cryptography;

namespace Wallet.Services.Helpers
{
    public static class WalletIdGenerator
    {
        public static string GenerateWalletId()
        {
            string startWith = "62";
            var miliseconds = string.Format("{0:000}", DateTime.Now.Millisecond);
            var year = DateTime.Now.ToString("yy");
            var day = RandomNumberGenerator.GetInt32(100, 999).ToString();
            var accountNumber = startWith + miliseconds + year + day;

            return accountNumber;
        }
    }
}
