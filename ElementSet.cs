    class ElementSet<T> where T : IEquatable<T>
    {
        public IEnumerable<T> nums;
        public Element(IEnumerable<T> nums) => this.nums = nums;
        public Element(Element<T> e) => this.nums = e.nums;

        public static Element<T> operator -(Element<T> a, Element<T>  b) 
        {
            List<T> rtn = new List<T>();
            foreach (var num in a.nums)
            {
                if (b.nums.All(x => !x.Equals(num)))
                    rtn.Add(num);
            }
            return new Element<T>(rtn);  
        }

        public static Element<T> operator +(Element<T> a, Element<T> b)
        {
            var rtn = new List<T>();
            rtn.AddRange(a.nums);
            rtn.AddRange(b.nums);
            return new Element<T>(rtn.Distinct().ToArray());
        }

        public static Element<T> operator *(Element<T> a, Element<T> b)
        {
            var rtn = new List<T>();
            foreach (var num in a.nums)
            {
                if (b.nums.Contains(num))
                    rtn.Add(num);
            }
            return new Element<T>(rtn.ToArray());
        }
    }
