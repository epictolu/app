﻿using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
      
    }
    public class when_attempting_to_add_a_negative_number:concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(2, 3));


      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();

    } 
    public class when_adding_two_numbers:concern
    {
      Because b = () =>
        result = sut.add(2, 3);


      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      static int result;
        
    } 
  }
}