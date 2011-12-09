using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure.containers.basic
{
    public class DependencyFactoryRegistry : IFindDependencyFactories
    {
        IEnumerable<ICreateASingleDependency> factories;
        readonly MissingDependencyFactoryException exception;

        public DependencyFactoryRegistry(IEnumerable<ICreateASingleDependency> factories,
                                         MissingDependencyFactoryException exception)
        {
            this.factories = factories;
            this.exception = exception;
        }

        public ICreateASingleDependency get_factory_that_can_create(Type dependency)
        {
            try
            {
                return factories.First(x => x.can_create(dependency));
            }
            catch
            {
                throw exception.Invoke(dependency);
            }
        }
    }
}