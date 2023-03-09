using FluentValidation;

namespace FS.Identity.API.Model.Users.Validator
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterDTOValidator()
        {
            RuleFor(x => x.Email)
                    .NotNull()
                    .NotEmpty().WithName("Email")
                    .WithMessage("The field {PropertyName} is required");
            RuleFor(x => x.Password)
                    .NotNull()
                    .NotEmpty().WithName("Pwd")
                    .WithMessage("The field {PropertyName} is required");
            RuleFor(x => x.PasswordCompare)
                    .NotNull()
                    .NotEmpty().WithName("Password confirm")
                    .WithMessage("The field {PropertyName} is required")
                    .Equal(x => x.Password, StringComparer.CurrentCultureIgnoreCase)
                    .WithMessage("The field {PropertyName} is not equal for {ComparisonProperty}");
        }

        private bool ComparePasswordIsEqual(UserRegisterDTO obj, string value)
        {
            return value.Equals(obj.Password);
        }
    }
}