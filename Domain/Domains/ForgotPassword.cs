using Core.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains
{
    [Table("ForgotPassword", Schema = "dbo")]
    public class ForgotPassword : AuditableEntity<int>
    {
        public string Hash { get; set; }
        public int AdminId { get; set; }
        public bool IsUsed { get; set; }
    }

    public class ForgotPasswordValidator : AbstractValidator<ForgotPassword>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(content => content.Hash).NotEmpty().WithMessage("Hash is Required");
            RuleFor(content => content.AdminId).NotEmpty().WithMessage("AdminId is Required");
        }
    }
}
