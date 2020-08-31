using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BougustTestApp
{
    class SampleCustomerRepository
    {
        //가상의 Enumerable List를 만든다
        public IEnumerable<Customer> GetCustomers()
        {
            Randomizer.Seed = new Random(123456);
            //가짜데이터를 Order 형태로 만들겠다
            var genOrder = new Faker<Order>()
                .RuleFor(o => o.Id, Guid.NewGuid)
                .RuleFor(o => o.Date, f => f.Date.Past(1))
                .RuleFor(o => o.OrderValue, f => f.Finance.Amount(10, 10000))
                .RuleFor(O => O.Shipped, f => f.Random.Bool(0.9f)); //10개중에 9개는 true 1개는 false

            var genCustomer = new Faker<Customer>()
                .RuleFor(o => o.Id, Guid.NewGuid)//괄호 붙이면 값 이상하게 나옴
                .RuleFor(o => o.Name, f => f.Company.CompanyName())//보거스에서 제공하는 가짜 회사이름
                .RuleFor(o => o.Address, f => f.Address.StreetAddress())
                .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber("010-####-####"))
                .RuleFor(o => o.ContactName, f => f.Name.FullName())
                .RuleFor(o => o.Orders, f => genOrder.Generate(f.Random.Number(0, 2))); //오더갯수가 0~2개까지 생성
           
            return genCustomer.Generate(10);//10명의 고객을 랜덤으로 생성하겠다.
        }
    }
}
