using TrustBank_BusinessLayer.Abstract;
using TrustBank_DataAccessLayer.Abstract;
using TrustBank_EntityLayer.Concrete;

namespace TrustBank_BusinessLayer.Concrete
{
    public class CustomerAccountActivityManager : ICustomerAccountActivityService
    {
        private readonly ICustomerAccountActivityDal _customerAccountActivityDal;

        public CustomerAccountActivityManager(ICustomerAccountActivityDal customerAccountActivityDal)
        {
            _customerAccountActivityDal = customerAccountActivityDal;
        }

        public void TDelete(CustomerAccountActivity entity)
        {
            _customerAccountActivityDal.Delete(entity);
        }

        public List<CustomerAccountActivity> TGetAll()
        {
            return _customerAccountActivityDal.GetAll();
        }

        public CustomerAccountActivity TGetById(int id)
        {
            return _customerAccountActivityDal.GetById(id);
        }

        public void TInsert(CustomerAccountActivity entity)
        {
            _customerAccountActivityDal.Insert(entity);
        }

        public void TUpdate(CustomerAccountActivity entity)
        {
            _customerAccountActivityDal.Update(entity);
        }
    }
}
