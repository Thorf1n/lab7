

namespace Repository
{
    
   
        public class GenericRepository<T>
        {
            public delegate bool Criteria<T>(T item);

            private List<T> items = new List<T>();
            private Random random = new Random();

            public void Add(T item)
            {
                items.Add(item);
            }

            public List<T> Find(Criteria<T> criteria)
            {
                if (criteria == null)
                {
                    throw new ArgumentNullException(nameof(criteria), "Criteria cannot be null.");
                }

                List<T> result = new List<T>();

                foreach (T item in items)
                {
                    if (criteria(item))
                    {
                        result.Add(item);
                    }
                }

                return result;
            }

            public void DisplayRandomNumbers(int count)
            {
                Console.WriteLine($"Random Numbers (count: {count}):");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(random.Next());
                }
            }
      
        }
 }

