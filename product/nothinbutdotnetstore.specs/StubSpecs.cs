using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs
{
    public class StubSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Stub))]
        public class when_stubbing_a_provided_type : concern
        {
            Because b = () =>
                result = Stub.with<MyItem>();

            It should_return_an_instance_of_the_type_specified = () =>
                result.ShouldBeAn<MyItem>();


            static MyItem result;
        }

        public class MyItem
        {
        }
    }
}