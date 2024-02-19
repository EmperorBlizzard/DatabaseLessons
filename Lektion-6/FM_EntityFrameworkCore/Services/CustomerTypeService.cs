﻿using FM_EntityFrameworkCore.Entities;
using FM_EntityFrameworkCore.Repositories;

namespace FM_EntityFrameworkCore.Services;

internal class CustomerTypeService
{
    private readonly CustomerTypeRepository _customerTypeRepo;

    public CustomerTypeService(CustomerTypeRepository customerTypeRepo)
    {
        _customerTypeRepo = customerTypeRepo;
    }

    public async Task<bool> CreatCustomerTypeAsync(CustomerTypeEntity entity)
    {
        if (!await _customerTypeRepo.ExistsAsync(x => x.TypeName == entity.TypeName))
        {
            await _customerTypeRepo.CreatAsync(entity);
            return true;
        }
        else
        {
            return false;
        }
    }
}
