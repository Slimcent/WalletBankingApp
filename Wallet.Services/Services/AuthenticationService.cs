using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wallet.Data.Interfaces;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;

namespace Wallet.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IServiceFactory _serviceFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
               
        public AuthenticationService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _userManager = _serviceFactory.GetServices<UserManager<User>>();
            _mapper = _serviceFactory.GetServices<IMapper>();
            _mapper = _serviceFactory.GetServices<IMapper>();
        }
        
    }
}
