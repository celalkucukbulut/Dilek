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
    [Table("Messages", Schema = "dbo")]
    public class Messages : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
    }

    public class MessagesValidator : AbstractValidator<Messages>
    {
        public MessagesValidator()
        {
            RuleFor(Messages => Messages.Name).NotEmpty().WithMessage("Name is Required").Length(2,50);
            RuleFor(Messages => Messages.Text).NotEmpty().WithMessage("Text is Required");
            RuleFor(Messages => Messages.Phone).Length(0,11).WithMessage("Phone is Required");
            RuleFor(Messages => Messages.Mail).Length(0,50).WithMessage("Mail is Required");
        }
    }
}
