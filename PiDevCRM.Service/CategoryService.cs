﻿using PiDevCRM.Data.Infrastructure;
using PiDevCRM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Service
{
    public class CategoryService : Service<CategoryService>, ICategoryService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(Factory);
        public CategoryService() : base(UTK)
        {

        }
    }
}
