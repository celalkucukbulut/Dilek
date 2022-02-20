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
    [Table("Admins", Schema = "dbo")]
    public class Admin : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MailAddress { get; set; }
    }

    public class AdminsValidator : AbstractValidator<Admin>
    {
        public AdminsValidator()
        {
            RuleFor(content => content.Name).NotEmpty().WithMessage("Name is Required").Length(1, 100);
            RuleFor(content => content.Surname).NotEmpty().WithMessage("Surname is Required").Length(1, 100);
            RuleFor(content => content.Username).NotEmpty().WithMessage("Username is Required").Length(1, 50);
            RuleFor(content => content.Password).NotEmpty().WithMessage("Password is Required").Length(1, 100);
            RuleFor(content => content.MailAddress).NotEmpty().WithMessage("MailAddress is Required").Length(1, 100);
        }
    }
}
