using System.ComponentModel.DataAnnotations;

namespace WebBookingHotel.Models;

public class DatPhongViewModel
{
	[Required(ErrorMessage = "Full name cannot be left blank")]
	public string Hoten { get; set; }

	[Required(ErrorMessage = "Email cannot be blank")]
	[EmailAddress(ErrorMessage = "Invalid email")]
	public string Email { get; set; }

	[Required(ErrorMessage = "Phone number can not be left blank")]
	[RegularExpression(@"^\d+$", ErrorMessage = "Phone numbers can only be entered numerically")]
	public string Sdt { get; set; }

	[Required(ErrorMessage = "Number of people cannot be left blank")]
	[Range(1, 20, ErrorMessage = "The number of people must be between 1 and 20")]
	public int SoLuongNg { get; set; }

	[Required(ErrorMessage = "Days cannot be left blank")]
	[Range(0, 30, ErrorMessage = "The number of days does not range from 1 to 30")]
	public int SoLuongTgoLai { get; set; }

	[Required(ErrorMessage = "Check-in time cannot be left blank")]
	[DataType(DataType.DateTime, ErrorMessage = "Check-in time is invalid")]
	public DateTime ThoiGianNhanPhong { get; set; }
}
