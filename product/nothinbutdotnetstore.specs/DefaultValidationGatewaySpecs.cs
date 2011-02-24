using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
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
                validator = an<Validator<TheItem>>();
                all_the_notifications = an<Notifications>();
                our_item = new TheItem();


                validator_registry.Stub(x => x.get_validator_for<TheItem>())
                    .Return(validator);

                notification_factory.Stub(x => x.create_empty())
                    .Return(all_the_notifications);
            };

            Because b = () =>
                result = sut.validate(our_item);

            It should_process_the_validator_against_the_item_to_validate = () =>
                validator.received(x => x.validate(our_item, all_the_notifications));
  
            It should_return_the_result_of_validating_the_item_with_the_item_validator = () =>
                result.ShouldEqual(all_the_notifications);

            static Notifications result;
            static Notifications all_the_notifications;
            static TheItem our_item;
            static NotificationFactory notification_factory;
            static ValidatorRegistry validator_registry;
            static Validator<TheItem> validator;
        }

        public class TheItem
        {
        }
    }
}