using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Users
{
    [Service]
    public class GetPublicUsers
    {
        private IUserManager _userManager;
        public GetPublicUsers(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IndexViewModel GetPubUsers(int page)
        {
            var user = _userManager.GetUsersPublic();
            
            int pageSize = 4;
            var count = user.Count();
            var items = user.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel userViewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                UsersPublic = items.AsQueryable()
            };
            return userViewModel;
        }
        public IndexViewModel GetPubUsersBySearch(int page, string search)
        {
            var user = _userManager.GetUsersPublicBySearch(search);

            int pageSize = 4;
            var count = user.Count();
            var items = user.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel userViewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                UsersPublic = items.AsQueryable()
            };
            return userViewModel;
        }

        public class UserViewModel
        {
            public string Username { get; set; }
            public byte[] Avatar { get; set; }
            
        }

        public class IndexViewModel
        {
            public IQueryable<UserPublic> UsersPublic { get; set; }
            public PageViewModel PageViewModel { get; set; }
            public string Text { get; set; }
        }
    }
}
