﻿namespace Wallet.Entities.Dto.Response
{
    public class EditUserClaimsDto
    {
        public string Email { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string OldValue { get; set; }
    }
}
