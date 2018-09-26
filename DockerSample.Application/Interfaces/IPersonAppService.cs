using DockerSample.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DockerSample.Domain.Models;

namespace DockerSample.Application.Interfaces
{
    public interface IPersonAppService
    {
        bool Save(PersonVm obj);
        PersonVm GetById(Guid id);
        IEnumerable<PersonVm> GetAll(Expression<Func<Person, bool>> predicate);
        void Update(PersonVm obj);
        void Remove(Guid id);
    }

}
