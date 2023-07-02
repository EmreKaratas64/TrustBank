using TrustBank_DataAccessLayer.Abstract;
using TrustBank_DataAccessLayer.Repositories;
using TrustBank_EntityLayer.Concrete;

namespace TrustBank_DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountActivityDal : GenericRepository<CustomerAccountActivity>, ICustomerAccountActivityDal
    {
    }
}
