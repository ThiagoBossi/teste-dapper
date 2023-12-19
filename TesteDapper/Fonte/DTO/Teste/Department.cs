using System.Collections.Generic;

namespace TesteDapper.Fonte.DTO.Teste
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<Door> Doors { get; set; }
    }
}
