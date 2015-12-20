using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  FluentValidation;

namespace util.Core
{

    public enum Sex
    {
        Male,
        Female,
        Transgender
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public Address Address { get; set; }

        public int Age() { return DateTime.Now.Year - BirthDate.Year; }
    }

    public class Address
    {
        public string Label { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }    


    }
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now.AddYears(-10));

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(10, 20);

            RuleFor(x => x.Sex)
                .NotEmpty()
                .Must(IsValidSex);
            
            When(x => x.Address != null, () =>
            {
                RuleFor(x => x.Address)
                    .SetValidator(new AddressValidator());
            });
        }

        bool IsValidSex(string sex)
        {
            return Enum.IsDefined(typeof (Sex), sex);
        }
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Label)
                .NotEmpty()
                .WithMessage("'Address label' is required to identify this addresss.");

            RuleFor(x => x.City)
                .NotEmpty();

            RuleFor(x => x.State)
                .NotEmpty()
                .Length(2, 2);

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Length(5, 10);


        }
    }
}
