using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
	public record CreatePermissionDto(
		[Required] string EmployeeForename,
		[Required] string EmployeeSurname,
		[Range(1, int.MaxValue)] int PermissionType,
		DateTime PermissionDate
	);

	public record PermissionDto
	{
		public int Id { get; set; }
		public string EmployeeForename { get; set; } = null!;
		public string EmployeeSurname { get; set; } = null!;
		public int PermissionType { get; set; } 
		public DateTime PermissionDate { get; set; }
	}
}
