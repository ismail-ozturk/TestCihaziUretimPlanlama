using FluentValidation;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.Application.Validators
{
    public class DepartmanCreateDtoValidator : AbstractValidator<DepartmanCreateDto>
    {
        public DepartmanCreateDtoValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Departman adı zorunludur")
                .MaximumLength(100).WithMessage("Departman adı en fazla 100 karakter olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Departman adı sadece harf ve boşluk içerebilir");

            RuleFor(x => x.Aciklama)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir");
        }
    }

    public class DepartmanUpdateDtoValidator : AbstractValidator<DepartmanUpdateDto>
    {
        public DepartmanUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir departman ID'si giriniz");

            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Departman adı zorunludur")
                .MaximumLength(100).WithMessage("Departman adı en fazla 100 karakter olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Departman adı sadece harf ve boşluk içerebilir");

            RuleFor(x => x.Aciklama)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir");
        }
    }
}
