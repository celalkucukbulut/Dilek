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
    [Table("Images", Schema = "dbo")]
    public class Images  : AuditableEntity<int>
    {
        public string Code { get; set; }
        public string FilePath { get; set; }
        public string Text { get; set; }
        public int DBCode { get; set; }
    }

    public class ImagesValidator : AbstractValidator<Images>
    {
        public ImagesValidator()
        {
            RuleFor(image => image.FilePath).NotEmpty().WithMessage("FilePath is Required");
            RuleFor(image => image.DBCode).NotEmpty().WithMessage("DBCode is Required");
            RuleFor(image => image.Text).Length(2,200).WithMessage("Text is Required");
            RuleFor(image => image.Code).Length(2,100).WithMessage("Code is Required");
        }
    }

}
