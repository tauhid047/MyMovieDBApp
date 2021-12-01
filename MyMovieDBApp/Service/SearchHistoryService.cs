using MyMovieDBApp.Models;
using MyMovieDBApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace MyMovieDBApp.Service
{
    public class SearchHistoryservice : ISearchHistory
    {
        private UserContext _userContext;

        public SearchHistoryservice(UserContext userContext)
        {
            _userContext = userContext;
        }

        public SearchHistory CreateSearchHistory(SearchHistory SearchHistory)
        {
            _userContext.SearchHistory.Add(SearchHistory);
            _userContext.SaveChanges();
            return SearchHistory;
        }

        public void DeleteSearchHistory(int SearchHistoryId)
        {
            _userContext.SearchHistory.Remove(GetSearchHistory(SearchHistoryId));
            _userContext.SaveChanges();
        }

        public SearchHistory GetSearchHistory(int id)
        {
            return _userContext.SearchHistory.Find(id);
        }

        public IEnumerable<SearchHistory> GetSearchHistory()
        {
            return _userContext.SearchHistory;
        }
    }
}
