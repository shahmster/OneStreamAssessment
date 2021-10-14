﻿using Leads.Api.Dtos;
using Leads.Api.Integration.WebServiceMethod.Abstractions;
using LeadsWebService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Api.Core.Domain.Services
{
    public enum WebMethod
    {
        Dial = 1,
        Insert = 2
    }
    public class LeadService : ILeadsService
    {
        private readonly IWebServiceMethod<DialDetails, string> _dial;
        private readonly IUnitOfWork _uow;

        public LeadService(
            IWebServiceMethod<DialDetails, string> dial,
            IUnitOfWork uow)
        {
            this._dial = dial;
            this._uow = uow;
        }
        public async Task<string> Dial(DialDetails request)
        {
            return await Call(request, _dial.ExecuteAsync, WebMethod.Dial);
        }


        private async Task<TResponse> Call<TResponse, TRequest>(TRequest request, Func<TRequest, Task<TResponse>> func, WebMethod webMethod)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var log = new LeadsRequestResponseDetail
            {
                RequestPayload = JsonConvert.SerializeObject(request),
                RequestTimeStamp = DateTime.Now,
                WebMethodId = (int)webMethod
            };

            _uow.LogRequestResponseRepository.Add(log);

            TResponse result = default;

            try
            {
                result = await func.Invoke(request);
            }
            catch (Exception e)
            {
                log.ResponseTimeStamp = DateTime.Now;
                log.ResponsePayload = e.Message;

            }
            finally
            {
                log.ResponseTimeStamp = DateTime.Now;
                log.ResponsePayload = JsonConvert.SerializeObject(result);
            }
            _uow.Complete();

            return result;

        }
        public Task<string> Insert(LeadDetails lead)
        {
            throw new NotImplementedException();
        }
    }
}