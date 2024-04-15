using Billy.Web.Models;

namespace Billy.Web.Services
{
    public interface IBillService
    {
        void AddBillDetails(List<BillDetails> details);
        void AddBill(Bill bill);

    }
}
