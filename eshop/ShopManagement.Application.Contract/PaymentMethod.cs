using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract
{
    public class PaymentMethod
    {
        public int Id { get;private set; }
        public string Name { get;private set; }



        public string Description { get;private set; }

        private PaymentMethod(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }


        public static List<PaymentMethod> GetList()
        {
            return  new List<PaymentMethod>()
            {
                new PaymentMethod(1,"خرید از طریق درگاه اینترنتی زرین پال",
                    "در مدل شما به درگاه پرداخت اینترنتی هدایت شده و درلحظه پرداخت وجه را انجام خواهید داد"),
                new PaymentMethod(2,"خرید  نقدی",
                    "در این مدل ابتدا سفارش ثبت شده و سپس وجه به صورت نقدی در زمان تحویل کالا دریافت خواهد شد"),
            };
        }

        public static PaymentMethod GetBy(long id)
        {

            var Payment = GetList().FirstOrDefault(c => c.Id == id);

            return Payment;

        }

    }

   
}
