using System.Collections.Generic;
using IdeasIntoCodeFirstVersion.Models;

namespace IdeasIntoCodeFirstVersion.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        List<Comment> GetCommentsOfFollowees(List<int> followees);
    }
}