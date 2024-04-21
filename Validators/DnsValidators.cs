using abstractests.Models;
using FluentValidation;

namespace abstractests.Validators
{
    public static class MyCustomValidators
    {
        public static IRuleBuilderOptions<T, string> ip4Address<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Length<T>(1, 2);
        }
    }

    public class CustomerValidator : AbstractValidator<AAARecord>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.ip6address).ip4Address();
        }
    }

    public class ARecordvalidator : AbstractValidator<ARecord>
    {
        public ARecordvalidator()
        {
            RuleFor(customer => customer.ip4address).ip4Address();
        }
    }

    public class truevalidator : AbstractValidator<RecordSetBase>
    {
        public truevalidator()
        {
            // use AValidator or BValidator dependend on the concrete type of each element
            RuleForEach(x => x.records).SetInheritanceValidator(v =>
            {
                v.Add<AAARecord>(new CustomerValidator());
                v.Add<ARecord>(new ARecordvalidator());

            });
        }
    }
}
