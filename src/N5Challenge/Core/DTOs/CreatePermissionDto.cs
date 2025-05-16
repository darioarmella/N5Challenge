using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
	public record CreatePermissionDto(
		[Required] string EmployeeForename,
		[Required] string EmployeeSurname,
		[Range(1, int.MaxValue)] int PermissionType,
		DateTime PermissionDate
	);
}
