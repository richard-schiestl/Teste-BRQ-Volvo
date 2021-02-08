using System;
using System.Collections.Generic;
using System.Text;
using BRQ_Test.Domain.Enums;
using FluentValidation;

namespace BRQ_Test.Domain.ViewModel
{
    public class UpdateTruckViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }

    public class UpdateTruckViewModelValidator : AbstractValidator<UpdateTruckViewModel>
    {
        public UpdateTruckViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);

            RuleFor(x => x.ModelYear).NotNull().LessThanOrEqualTo(DateTime.Now.AddYears(1).Year)
                .GreaterThanOrEqualTo(DateTime.Now.Year);

            RuleFor(x => x.Model).Must(ValidateEnum).WithMessage("Informe um modelo válido");
        }

        private bool ValidateEnum(string model)
        {
            ModelEnum modelEnum;
            return Enum.TryParse(model, out modelEnum);
        }
    }
}
