using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Practicing_For_Work.Toolkit.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public abstract class ServiceBase
    {
        private IServiceProvider _serviceProvider;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IStringLocalizer _sharedLocalizer;

        public ServiceBase(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
            _httpContextAccessor = _serviceProvider.GetRequiredService<IHttpContextAccessor>();
            _sharedLocalizer = _serviceProvider.GetRequiredService<IStringLocalizer<SharedResource>>();
        }

        public HttpContext HttpContext => _httpContextAccessor.HttpContext;


    }
}
