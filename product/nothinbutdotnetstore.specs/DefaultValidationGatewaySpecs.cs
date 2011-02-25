using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.specs.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class DefaultValidationGatewaySpecs
    {
        public abstract class concern : Observes<ValidationGateway,
                                            DefaultValidationGateway>
        {
        }

        [Subject(typeof(DefaultValidationGateway))]
        public class when_validating_an_item : concern
        {
            Establish c = () =>
            {
                notification_factory = the_dependency<NotificationFactory>();
                validator_registry = the_dependency<ValidatorRegistry>();
                one_notification = an<Notifications>();
                all_the_notifications = an<Notifications>();
                rules = ObjectFactory.create_a_set_of(100, an<Rule<TheItem>>).ToList();
                our_item = new TheItem();
                rules.each(x => x.Stub(y => y.apply_to(our_item)).Return(one_notification));

                notification_factory.Stub(x => x.create_empty())
                    .Return(all_the_notifications);

                validator_registry.Stub(x => x.all_rules_for<TheItem>())
                    .Return(rules);
            };

            Because b = () =>
                result = sut.validate(our_item);

            It should_append_the_rule_messages_for_all_validation_rules_to_the_notification = () =>
                all_the_notifications.received(x => x.append(one_notification));

            It should_return_the_notifications = () =>
                result.ShouldEqual(all_the_notifications);

            static Notifications result;
            static Notifications all_the_notifications;
            static TheItem our_item;
            static NotificationFactory notification_factory;
            static ValidatorRegistry validator_registry;
            static IList<Rule<TheItem>> rules;
            static Notifications one_notification;
        }

        public class TheItem
        {
        }
    }
}