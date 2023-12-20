﻿using Server.Common.Requests.SpeditionRequest;
using Server.Data.Entities;
using Server.Data.Interfaces;
using Server.Domain.Interfaces;

namespace Server.Domain.Services
{
    public class RequestSpeditionService : IRequestSpeditionService
    {
        private readonly IUnitOfWork unitOfWork;
        public RequestSpeditionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<RequestSpedition?> Create(SpeditionRequest spedition)
        {
            RequestSpedition request = new RequestSpedition()
            {
                PhoneNumber = spedition.PhoneNumber,
                Name = spedition.Name,
                NumberOfPallets = spedition.NumberOfPallets,
                TotalWeight = spedition.TotalWeight,
                FromAddress = spedition.FromAddress,
                ToAddress = spedition.ToAddress,
                FromDate = spedition.FromDate,
                ToDate = spedition.ToDate,
                Email = spedition.Email,
            };

            await unitOfWork.RequestSpedition.AddAsync(request);
            await unitOfWork.CommitAsync();

            return request;
        }

        public Task<IEnumerable<RequestSpedition>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<RequestSpedition?> GetById(string id)
        {
            var request = await unitOfWork.RequestSpedition.GetByIdAsync(id);
            if (request == null)
            {
                return null;
            }
            return request;
        }
    }
}
