using System;
using System.Collections.Generic;
using System.Text;
using GPS.Core.Domain;
using GPS.Data;

namespace GPS.Service.Category
{
    public class ProfessionalCategory : IProfessionalCategory
    {
        private readonly IRepository<Core.Domain.ProfessionalCategory> _repository;

        public ProfessionalCategory(IRepository<Core.Domain.ProfessionalCategory> repository)
        {
            this._repository = repository;
            
        }
        public IEnumerable<Core.Domain.ProfessionalCategory> GetCategories()
        {
            return _repository.GetAll();
        }
    }
}
