using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.validation.attributes;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class FallsInRangeSpecs
    {
        public abstract class when_validating_an_property : Observes<IntegerFallsInRangeAttribute>
        {
            Establish c = () =>
            {
                item = new ItemToValidate();
                item_property = an<ItemProperty>();
                start = 18;
                end = 50;
                create_sut_using(() => new IntegerFallsInRangeAttribute(start, end));
                add_pipeline_behaviour_against_sut(x => x.property_to_validate = item_property);
            };

            Because b = () =>
                result = sut.is_in_range(item);

            static PropertyInfo property_info;
        }

        [Subject(typeof(IntegerFallsInRangeAttribute))]
        public class property_value_is_in_range : when_validating_an_property
        {
            Establish c = () =>
                item_property.Stub(x => x.get_value_from(item)).Return(22);

            It should_be_true = () =>
                result.ShouldBeTrue();
        }

        [Subject(typeof(IntegerFallsInRangeAttribute))]
        public class property_value_is_below_the_range : when_validating_an_property
        {
            Establish c = () =>
                item_property.Stub(x => x.get_value_from(item)).Return(17);

            It should_be_true = () =>
                result.ShouldBeFalse();
        }


        [Subject(typeof(IntegerFallsInRangeAttribute))]
        public class property_value_is_above_the_range : when_validating_an_property
        {
            Establish c = () =>
                item_property.Stub(x => x.get_value_from(item)).Return(51);

            It should_be_true = () =>
                result.ShouldBeFalse();
        }
        static int start;
        static int end;
        static ItemToValidate item;
        static ItemProperty item_property;
        static bool result;

    }
    
}