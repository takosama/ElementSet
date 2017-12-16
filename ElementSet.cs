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
