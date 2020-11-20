using CoachUp.DAL.Interfaces;
using CoachUp.DAL.Repositories;

namespace CoachUp.BLL.Infrastructure
{
    public class ServiceModule
    {
        public UnitOfWork DB { get; set; }
        public ServiceModule()
        {
            DB = new UnitOfWork();
        }
    }
}