using StackOverflowLikeWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class SearchController : Controller
{
    private readonly StackOverflow2010Context _context;

    public SearchController(StackOverflow2010Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IQueryable<Post> GetSearchResults(string searchQuery)
    {
        var searchResults = _context.Posts
            .Where(p => p.Title.Contains(searchQuery) || p.Body.Contains(searchQuery) || p.Tags.Contains(searchQuery))
            .Take(100)
            .Select(p => new Post
            {
                Id = p.Id,
                Title = p.Title ?? "",
                Body = p.Body ?? "",
                AnswerCount = p.AnswerCount ?? 0,
                VoteCount = p.Votes.Count(),
                UserReputation = p.OwnerUserId != null
                    ? _context.Users
                        .Where(u => u.Id == p.OwnerUserId)
                        .Select(u => u.Reputation)
                        .FirstOrDefault()
                    : 0,
                UserName = p.OwnerUserId != null
                    ? _context.Users
                        .Where(u => u.Id == p.OwnerUserId)
                        .Select(u => u.DisplayName)
                        .FirstOrDefault()
                    : "",
                UserBadgeCount = p.OwnerUserId != null
                    ? _context.Badges
                        .Where(b => b.UserId == p.OwnerUserId)
                        .Count()
                    : 0
            });
        return searchResults;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchQuery(string searchQuery, int pageNumber)
    {
        // Ensure page number is atleast 1
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }

        int pageSize = 10;

        // Perform search based on the searchQuery
        var searchResults = GetSearchResults(searchQuery);

        // Pass the search results to the view
        return View("Search", await PaginatedList<Post>.CreateAsync(searchResults, pageNumber, pageSize, searchQuery));
    }

    [HttpGet]
    public async Task<IActionResult> SearchPage(string searchQuery, int pageNumber)
    {
        // Ensure page number is atleast 1
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }

        int pageSize = 10;

        // Perform search based on the searchQuery
        var searchResults = GetSearchResults(searchQuery);

        // Pass the search results to the view
        return View("Search", await PaginatedList<Post>.CreateAsync(searchResults, pageNumber, pageSize, searchQuery));
    }
}