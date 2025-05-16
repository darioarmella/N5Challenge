using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
	public record UpdatePermissionDto(
		[Required] int Id,
		[Range(1, int.MaxValue)] int PermissionType,
		DateTime PermissionDate
	);
}
