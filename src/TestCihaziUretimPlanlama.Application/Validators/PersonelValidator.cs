using FluentValidation;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Application.Validators
{
    public class PersonelCreateDtoValidator : AbstractValidator<PersonelCreateDto>
    {
        public PersonelCreateDtoValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Ad zorunludur")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Ad sadece harf ve boşluk içerebilir");

            RuleFor(x => x.Soyad)
                .NotEmpty().WithMessage("Soyad zorunludur")
                .MaximumLength(100).WithMessage("Soyad en fazla 100 karakter olabilir")
                .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ ]+$").WithMessage("Soyad sadece harf ve boşluk içerebilir");

            RuleFor(x => x.PersonelNo)
                .NotEmpty().WithMessage("Personel numarası zorunludur")
                .MaximumLength(50).WithMessage("Personel numarası en fazla 50 karakter olabilir")
                .Matches("^[A-Z0-9]+$").WithMessage("Personel numarası sadece büyük harf ve rakam içerebilir");

            RuleFor(x => x.DepartmanId)
                .GreaterThan(0).WithMessage("Geçerli bir departman seçiniz");

            RuleFor(x => x.CalismaSekli)
                .IsInEnum().WithMessage("Geçerli bir çalışma şekli seçiniz");

            // Sabit çalışma için vardiya tipi zorunlu
            When(x => x.CalismaSekli == CalismaSekli.Sabit, () =>
            {
                RuleFor(x => x.SabitVardiyaTipi)
                    .NotNull().WithMessage("Sabit çalışma için vardiya tipi seçimi zorunludur")
                    .Must(x => x == VardiyaTipi.Normal || x == VardiyaTipi.Gunduz)
                    .WithMessage("Sabit çalışma için sadece Normal veya Gündüz vardiyası seçilebilir");
            });

            // Döner çalışma için vardiya bilgileri zorunlu
            When(x => x.CalismaSekli == CalismaSekli.Doner, () =>
            {
                RuleFor(x => x.DonerVardiyaBaslangicTipi)
                    .NotNull().WithMessage("Döner çalışma için başlangıç vardiyası seçimi zorunludur")
                    .Must(x => x == VardiyaTipi.A || x == VardiyaTipi.B)
                    .WithMessage("Döner çalışma için sadece A veya B vardiyası seçilebilir");

                RuleFor(x => x.DonerVardiyaBaslangicTarihi)
                    .NotNull().WithMessage("Döner çalışma için başlangıç tarihi zorunludur")
                    .Must(x => x <= DateTime.Now.Date)
                    .WithMessage("Başlangıç tarihi bugünden ileri olamaz");
            });
        }
    }
}
