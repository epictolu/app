using System.Configuration;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class ValidatorSpecs
    {
        public abstract class concern : Observes<Validator<Person>,
                                            DefaultValidator<Person>>
        {
        }

        [Subject(typeof(DefaultValidator))]
        public class when_validating_an_item_and_the_item_has_no_issues : concern
        {
            Establish c = () =>
            {
                person = new Person();
                notifications = an<Notifications>();
            };

            Because b = () =>
                sut.validate(person, notifications);
                

            It should_not_change_the_state_of_the_notifications = () =>
                notifications.never_received(x => x.add_error(Arg<string>.Is.Anything));

            static Notifications notifications;
            static Person person;
        }

        public class Person
        {
        }
    }
}