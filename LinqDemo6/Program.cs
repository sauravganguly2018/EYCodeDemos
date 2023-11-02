namespace LinqDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 6, 7, 8, 9, 10 };

            // get all evens in ascending order

            // sql : select number from numbers where number mod 2 = 0 order by number

            // linq expression
            var result1 = from n in numbers
                          where n % 2 == 0
                          select n;


            // linq statement - extension methods, lamda
            Console.WriteLine("result 1");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

           // Func<int, bool> filter = new Func<int, bool>(IsEven);
            var result2 = numbers
                .Where(n => n % 2 == 0)
                .OrderByDescending(i => i)
                .Select(x => x);
            Console.WriteLine("result 2");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }

        //public static bool IsEven(int n)
        //{
        //    return n % 2 == 0;
        //}
    }
}