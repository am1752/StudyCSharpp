using System;

namespace BougustTestApp
{
    public class Order
    {
        //유니크한 id->중복되지 않는 아이디를 만들어준다.
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal OrderValue { get; set; }
        public bool Shipped { get; set; } //배송날짜
    }
}
