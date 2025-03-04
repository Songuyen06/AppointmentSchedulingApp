﻿using AppointmentSchedulingApp.Services.DTOs;
using AppointmentSchedulingApp.Domain.Entities;
using AutoMapper;
using AppointmentSchedulingApp.Domain.Repositories;

namespace AppointmentSchedulingApp.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceDTO>> GetListService()
        {
            var services = await _serviceRepository.GetAll();
            return _mapper.Map<List<ServiceDTO>>(services);
        }

        public async Task<ServiceDTO> GetServiceById(int id)
        {
            var service = await _serviceRepository.GetById(id);
            return _mapper.Map<ServiceDTO>(service);
        }

        public async Task AddService(ServiceDTO serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            await _serviceRepository.Add(service);
        }

        public async Task UpdateService(ServiceDTO serviceDto)
        {
            var service = _mapper.Map<Service>(serviceDto);
            await _serviceRepository.Update(service);
        }

        public async Task DeleteService(int id)
        {
            await _serviceRepository.Delete(id);
        }
    }
}
