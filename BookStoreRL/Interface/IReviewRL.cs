using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IReviewRL
    {
        public review AddReview(string id, string userId, review review);

        public List<review> getReview(string bookId);
    }
}
