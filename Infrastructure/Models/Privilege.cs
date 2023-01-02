using System.Data.Common;

namespace Infrastructure.Models;

public partial class Data
{
    public class Privilege
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public Domain.Models.Privilege PrivilegeType { get; set; }
    }
}