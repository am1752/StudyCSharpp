using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BougustTestApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //SampleCustomerRepository repository = new SampleCustomerRepository();
            //IEnumerable<Customer> customers = repository.GetCustomers();

            var repository = new SampleCustomerRepository();
            var customers = repository.GetCustomers();

            Console.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented));//자동으로 들여쓰기
            
        }
    }
}
