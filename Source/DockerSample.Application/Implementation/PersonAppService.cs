using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DockerSample.Application.Interfaces;
using DockerSample.Application.ViewModels;
using DockerSample.Domain.Contract;
using DockerSample.Domain.Contract.Repositories;
using DockerSample.Domain.Models;

namespace DockerSample.Application.Implementation
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonAppService(IUnitOfWork unitOfWork, IPersonRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _personRepository = repository;
            _mapper = mapper;
        }

        public bool Save(PersonVm obj)
        {
            using (_unitOfWork)
            {
                _personRepository.Add(_mapper.Map<Person>(obj));
                return _unitOfWork.Commit();
            }

        }

        public IEnumerable<PersonVm> GetAll(Expression<Func<Person,bool>> predicate)
        {
            var person = _personRepository.GetAll();
            if (predicate != null)
                person = person.Where(predicate);

            return _mapper.Map<IEnumerable<Person>, IEnumerable<PersonVm>>(person);
        }

        public PersonVm GetById(Guid id)
        {
            return _mapper.Map<PersonVm>(_personRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            using (_unitOfWork)
            {
                _personRepository.Remove(id);
                _unitOfWork.Commit();
            }
        }

        public void Update(PersonVm obj)
        {
            using (_unitOfWork)
            {
                _personRepository.Update(_mapper.Map<Person>(obj));
                _unitOfWork.Commit();
            }
        }
    }
}
