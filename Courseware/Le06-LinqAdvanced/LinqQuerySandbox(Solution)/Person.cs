using System.Collections.Generic;

namespace LinqQuerySandbox
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public List<Car> Cars { get; set; }
    }
}
