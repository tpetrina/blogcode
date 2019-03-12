using System;

namespace sample_resultobject
{
    class Program
    {
        static ResultObject<bool, string> Foo(int param)
        {
            if (param != 0)
                return "An error";

            return true;
        }

        static DomainResult<int> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ValidationError(nameof(name), "Name is required");
            }

            if (name == "John")
            {
                return "Already taken";
            }

            if (name == "Mary")
            {
                return CommonErrors.NotFound;
            }

            return 1;
        }

        static DomainResult<int> ComplexCall()
        {
            var (id, createError) = Create("");

            if (createError != null)
                return createError;

            return id;
        }

        static string SwitchExpression(string name)
        {
            // var (id, createError) = Create("");

            // if (createError != null)
            // return createError;

            Console.Write($"{name}: ");

            return Create(name) switch
            {
                // (var id, BaseError.None) => "OK",
                // (var id, null) => "OK",
                (var id, _) when id > 0 => "OK",
                (_, var error) => error switch
                {
                    ValidationError e => $"{e.Field} - {e.Description}",
                    CommonError ce => $"{ce}",
                    _ => "Unhandled error"
                },
                _ => $"Unknown"
            };
        }

        static void Main(string[] args)
        {
            var (result, error) = Foo(0);

            Console.WriteLine(SwitchExpression(""));
            Console.WriteLine(SwitchExpression("John"));
            Console.WriteLine(SwitchExpression("Mary"));
            Console.WriteLine(SwitchExpression("Gary"));
        }
    }
}
