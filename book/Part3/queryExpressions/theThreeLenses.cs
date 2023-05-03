namespace book.part3.queryExpressions.theThreeLenses;

public class theThreeLenses
{
    public static void Start()
    {
        int[] input = new[] {1, 9, 2, 8, 3, 7, 4, 6, 5};

        
        foreach (int number in SortMethod(input))
        {
            Console.WriteLine(number);
        }
        
        foreach (int number in SortQueryKeyword(input))
        {
            Console.WriteLine(number);
        }
        
        foreach (int number in SortQueryMethod(input))
        {
            Console.WriteLine(number);
        }

        IEnumerable<int> SortMethod(int[] input)
        {
            List<int> filtered = new List<int>();

            foreach (int number in input)
            {
                if(number % 2 == 0) filtered.Add(number * 2);
            }

            int[] results = filtered.ToArray();
            Array.Sort(results);

            return results;
        }

        IEnumerable<int> SortQueryKeyword(int[] input)
        {
            return from n in input
                where n % 2 == 0
                orderby n
                select n * 2;
        }
        
        IEnumerable<int> SortQueryMethod(int[] input)
        {
            return input
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .Select(n => n * 2);
        }
    }
}