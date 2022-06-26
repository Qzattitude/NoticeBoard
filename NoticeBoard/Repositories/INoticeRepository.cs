using NoticeBoard.Models;
using System.Collections.Generic;

namespace NoticeBoard.Repositories
{
    public interface INoticeRepository
    {
        public void UploadNotice(string Header, string Url, List<User> User);
    }
}
