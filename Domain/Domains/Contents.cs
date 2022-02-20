using Core.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains
{
    [Table("Contents", Schema = "dbo")]
    public class Contents : AuditableEntity<int>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int DBCode { get; set; }
    }
    
    public class ContentsValidator : AbstractValidator<Contents>
    {
        public ContentsValidator()
        {
            RuleFor(content => content.Text).NotEmpty().WithMessage("Text is Required");
            RuleFor(content => content.Title).NotEmpty().WithMessage("Title is Required").Length(1, 200);
        }
    }
}
