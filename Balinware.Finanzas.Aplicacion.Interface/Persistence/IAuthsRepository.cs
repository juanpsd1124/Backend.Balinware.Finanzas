﻿using Balinware.Finanzas.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balinware.Finanzas.Application.Interface.Persistence
{
    public interface IAuthsRepository
    {
        UserAuth Authenticate(string username, string password);

    }
}