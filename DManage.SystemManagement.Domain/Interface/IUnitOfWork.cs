namespace DManage.SystemManagement.Domain.Interface
{
    public interface IUnitOfWork
    {
        //IRepository<CensusFileDetail> CensusFileDetailRepository { get; }
        int Commit();
    }
}
