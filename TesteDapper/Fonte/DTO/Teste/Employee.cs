using System;
using System.Collections.Generic;

namespace TesteDapper.Fonte.DTO.Teste
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime AdmissionDate { get; set; }

        public List<Department> Departments { get; set; }
    }
}
