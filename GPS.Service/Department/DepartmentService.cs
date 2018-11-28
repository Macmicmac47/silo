using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Department
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IRepository<Core.Domain.Department> _departmentRepository;

        public DepartmentService(IRepository<Core.Domain.Department> departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }
        public IEnumerable<Core.Domain.Department> GetDsepartments()
        {
            return _departmentRepository.GetAll();
        }
    }
}
