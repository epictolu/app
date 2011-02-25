using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.validation.attributes;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class RequiredDetailSpecs
    {
        public abstract class when_validating_an_property : Observes<RequiredDetailAttribute>
        {
            Establish c = () =>
            {
                item = new ItemToValidate();
                item_property = an<ItemProperty>();
                add_pipeline_behaviour_against_sut(x => x.property_to_validate = item_property);
            };

            Because b = () =>
                result = sut.is_valid(item);

            static PropertyInfo property_info;
        }

        [Subject(typeof(RequiredDetailAttribute))]
        public class property_value_is_not_null : when_validating_an_property
        {
            Establish c = () =>
                item_property.Stub(x => x.get_value_from(item)).Return("sdssdf");

            It should_be_true = () =>
                result.ShouldBeTrue();
        }

        [Subject(typeof(RequiredDetailAttribute))]
        public class property_value_is_null : when_validating_an_property
        {
            Establish c = () =>
                item_property.Stub(x => x.get_value_from(item)).Return(null);

            It should_be_false = () =>
                result.ShouldBeFalse();
        }

        [Subject(typeof(RequiredDetailAttribute))]
        public class property_value_is_empty_string : when_validating_an_property
        {
            Establish c = () =>
                item_property.Stub(x => x.get_value_from(item)).Return(string.Empty);

            It should_be_false = () =>
                result.ShouldBeFalse();
        }

        static ItemToValidate item;
        static ItemProperty item_property;
        static bool result;
    }

    public class ItemToValidate
    {
        public string some_other_name { get; set; }
    }
}