﻿using GestaoMais.Domain.Interfaces;
using GestaoMais.Entities.Entities;
using GestaoMais.Infrastructure.Repository.Generics;

namespace GestaoMais.Infrastructure.Repository.Repositories
{
    public class RepositoryCategoria : RepositoryGeneric<Categoria>, ICategoria { }
}