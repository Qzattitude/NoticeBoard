namespace NoticeBoard.Repositories
{
    public interface IUserRepository
    {
        public void Add(string username, string password);
        public void GetAllUser();

    }
}
