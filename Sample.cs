   //this algorithm think by claclator
    class ElementSet<T> where T : IEquatable<T>
    {
        public IEnumerable<T> nums;
        public ElementSet(IEnumerable<T> nums) => this.nums = nums;
        public ElementSet(ElementSet<T> e) => this.nums = e.nums;

        public static ElementSet<T> operator -(ElementSet<T> a, ElementSet<T>  b) 
        {
            List<T> rtn = new List<T>();
            foreach (var num in a.nums)
            {
                if (b.nums.All(x => !x.Equals(num)))
                    rtn.Add(num);
            }
            return new ElementSet<T>(rtn);  
        }

        public static ElementSet<T> operator +(ElementSet<T> a, ElementSet<T> b)
        {
            var rtn = new List<T>();
            rtn.AddRange(a.nums);
            rtn.AddRange(b.nums);
            return new ElementSet<T>(rtn.Distinct().ToArray());
        }

        public static ElementSet<T> operator *(ElementSet<T> a, ElementSet<T> b)
        {
            var rtn = new List<T>();
            foreach (var num in a.nums)
            {
                if (b.nums.Contains(num))
                    rtn.Add(num);
            }
            return new ElementSet<T>(rtn.ToArray());
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        //input
 //       3
//1 2 4 3 NO
//8 5 6 7 NO
//0 1 2 3 NO
// output 
//9
            ElementSet<int> mother = new ElementSet<int>(Enumerable.Range(0, 10));
            ElementSet<int> rtn = new ElementSet<int>(Enumerable.Range(0, 10));
            Console.ReadLine();
            while (true)
            {

                var tmp = Console.ReadLine();
                if (tmp == null || tmp == "") break;
                var spl = tmp.Split(' ');
                var inputs = spl.Take(4).Select(x => int.Parse(x)).ToArray();
                var flag = spl.Last() == "YES" ? true : false;
                ElementSet<int> input;
                if (flag)
                    input = new ElementSet<int>(inputs);
                else
                    input = new ElementSet<int>(mother - new ElementSet<int>(inputs));
                rtn *= input;
            }

            Console.WriteLine(
                rtn.nums.ToArray()[0]);
        }
    }
