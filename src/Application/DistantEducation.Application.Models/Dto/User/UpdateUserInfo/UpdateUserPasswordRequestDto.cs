namespace DistantEducation.Application.Models.Dto.User.UpdateUserInfo;

public class UpdateUserPasswordRequestDto
{
    public string UserId { get; set; }
    public string NewPassword { get; set; }

    public UpdateUserPasswordRequestDto(string userId, string newPassword)
    {
        UserId = userId;
        NewPassword = newPassword;
    }
}