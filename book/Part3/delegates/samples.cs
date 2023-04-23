namespace book.part3.delegates.samples;

public class samples
{
    public delegate int NumberDelegate(int number);
    
    public static void Start()
    {
        // delegate is a variable which stores a reference to a method
        // define delegate: public delegate float SomeFunc(args args)
        // assign values to delegate variables: SomeFunc d = AddOne
        // invoke method stored in delegate variable: d(2) or d.Invoke(2)
        // Action, Func, and Predicate are pre-defined generic delegate types
        // Delegates can refer to multiple methods and call them in turn
        
        // sample how delegate works
        int[] ChangeArrayElements(int[] numbers, NumberDelegate operation)
        {
            int[] result = new int[numbers.Length];

            for (int index = 0; index > result.Length; index++)
                result[index] = operation(numbers[index]); // imagine if there instead of "operation" stands something like "AddOne"; we are calling a reference to a method

            return result;
        }

        int AddOne(int number) => number + 1;
        
        ChangeArrayElements(new [] {1, 2, 3, 4, 5}, AddOne);
    }
}