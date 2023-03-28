using FluentValidation;

namespace FS.Identity.API.Model.Users.Validator
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterDTOValidator()
        {
            RuleFor(x => x.Email)
                    .NotEmpty().WithName("Email")
                    .WithMessage("The field {PropertyName} is required");
            RuleFor(x => x.Password)
                    .NotEmpty().WithName("Password")
                    .WithMessage("The field {PropertyName} is required");
            RuleFor(x => x.PasswordCompare)
                    .NotEmpty().WithName("PasswordCompare")
                    .WithMessage("The field {PropertyName} is required")
                    .Must((obj, value) => ComparePasswordIsEqual(obj, value));
        }

        private bool ComparePasswordIsEqual(UserRegisterDTO obj, string value)
        {
            return value.Equals(obj.Password);
        }
    }
}