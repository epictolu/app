namespace nothinbutdotnetstore.specs.utility
{
    public class ItObserves<Contract, Implementation> :
        Machine.Specifications.DevelopWithPassion.Rhino.Observes<Contract, Implementation>
        where Implementation : Contract
    {
        public static void the_sut_constructor_needs_a<Dependency>(Dependency item) 
        {
            provide_a_basic_sut_constructor_argument(item);
        }
        public static Dependency the_sut_constructor_needs_a<Dependency>() where Dependency : class
        {
            return the_dependency<Dependency>();
        }
    }
}