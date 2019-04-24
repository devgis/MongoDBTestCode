using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoRepository;

namespace MongoTest
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
