using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Configuration;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using Machine.Specifications.DevelopWithPassion.Extensions;
using nothinbutdotnetstore.specs.utility;
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
        public class when_validating_an_item_and_the_item_has_issues : concern
        {
            Establish c = () =>
            {
                rule_set = the_dependency<RuleSet<Person>>();
                error_message = "blah";
                person = new Person();
                notifications = new FakeNotifications();
                errors = new List<string> {"1", "2"};

                rule_set.Stub(x => x.is_broken_by(person))
                    .Return(true);

                rule_set.Stub(x => x.all_messages()).Return(errors);
            };


            Because b = () =>
                sut.validate(person, notifications);

            It should_add_the_message_of_each_of_the_broken_rules_to_the_notifications = () =>
            {

            };


            static Notifications notifications;
            static Person person;
            static string error_message;
            static RuleSet<Person> rule_set;
            static IEnumerable<string> errors;
        }

        public class FakeNotifications : Notifications
        {
            public bool contains_errors()
            {
                return true;
            }

            public void add_error(string message)
            {
            }
        }
        public class Person
        {
        }
    }
}