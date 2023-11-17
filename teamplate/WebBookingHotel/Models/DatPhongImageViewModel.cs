using System.ComponentModel.DataAnnotations;

namespace WebBookingHotel.Models;

public class DatPhongImageViewModel
{
	[Required(ErrorMessage = "Phone number can not be left blank")]
	[RegularExpression(@"^\d+$", ErrorMessage = "Phone numbers can only be entered numerically")]
	public string Sdt { get; set; }
	[Required(ErrorMessage = "Images cannot be blank")]
	[DataType(DataType.Upload)]
	[MaxFileSize(5 * 1024 * 1024, ErrorMessage = "File size must not exceed 5 MB")]
	[AllowedFileExtensions(new string[] { ".jpg", ".png", ".gif" }, ErrorMessage = "Only accept files in .jpg, .png or .gif format")]
	public IFormFile HinhAnh { get; set; }
}
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class MaxFileSizeAttribute : ValidationAttribute
{
	private readonly int _maxFileSize;

	public MaxFileSizeAttribute(int maxFileSize)
	{
		_maxFileSize = maxFileSize;
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var file = value as IFormFile;

		if (file != null)
		{
			if (file.Length > _maxFileSize)
			{
				return new ValidationResult(ErrorMessage);
			}
		}

		return ValidationResult.Success;
	}
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class AllowedFileExtensionsAttribute : ValidationAttribute
{
	private readonly string[] _extensions;

	public AllowedFileExtensionsAttribute(string[] extensions)
	{
		_extensions = extensions;
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var file = value as IFormFile;

		if (file != null)
		{
			var extension = Path.GetExtension(file.FileName);

			if (!_extensions.Contains(extension.ToLower()))
			{
				return new ValidationResult(ErrorMessage);
			}
		}

		return ValidationResult.Success;
	}
}
