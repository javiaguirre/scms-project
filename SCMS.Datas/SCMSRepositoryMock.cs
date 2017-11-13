﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models;
using SCMS.Models.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
using SCMS.Models.ViewModels;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace SCMS.Datas
{
    public class SCMSRepositoryMock : ISCMS
    {

        static List<User> _users = new List<User>
        {
            new User { Id = "admin", UserName = "scms", Nickname = "scms", Email = "scms@gmail.com", PasswordHash = "123456", IsActive = true },
            new User { Id = "Na", UserName = "Na", Nickname = "Na", Email = "na@gmail.com", PasswordHash = "123456", IsActive = true },
            new User { Id = "Nik", UserName = "Nik", Nickname = "Nik", Email = "nik@gmail.com", PasswordHash = "123456", IsActive = false },
            new User { Id = "Javier", UserName = "Javier", Nickname = "Javier", Email = "javier@gmail.com", PasswordHash = "123456" , IsActive = true}
        };

        static List<Info> _infos = new List<Info>
        {
            new Info{ InfoId = 1, Title = "11111", FDate = DateTime.Parse("11/01/2017"), TDate = DateTime.Parse("11/10/2017"), Description = "Description for 11111" },
            new Info{ InfoId = 2, Title = "22222", FDate = DateTime.Parse("11/15/2017"), TDate = DateTime.Parse("12/11/2017"), Description = "Description for 22222" },
            new Info{ InfoId = 3, Title = "11111", FDate = DateTime.Parse("10/01/2017"), TDate = DateTime.Parse("12/01/2017"), Description = "Description for 33333" },
            new Info{ InfoId = 4, Title = "11111", FDate = DateTime.Parse("12/25/2017"), TDate = DateTime.Parse("01/31/2018"), Description = "Description for 44444" },
            new Info{ InfoId = 5, Title = "11111", FDate = DateTime.Parse("11/15/2017"), TDate = DateTime.Parse("11/30/2018"), Description = "Description for 55555" }
        };


        static List<Category> _categories = new List<Category>
        {
            new Category{ CategoryId = 1, Description = "Food" },
            new Category{ CategoryId = 2, Description = "Love" },
            new Category{ CategoryId = 3, Description = "Culture" },
            new Category{ CategoryId = 4, Description = "Science" },
            new Category{ CategoryId = 5, Description = "Bedtime Story" }
        };

        static List<Intimacy> _intimacies = new List<Intimacy>
        {
            new Intimacy{ IntimacyId = 1, Description = "Low"},
            new Intimacy{ IntimacyId = 2, Description = "Medium"},
            new Intimacy{ IntimacyId = 3, Description = "High"}
        };

        static List<Story> _stories = new List<Story> {
            new Story{StoryId = 1, CategoryId = _categories[0].CategoryId, Category = _categories[0],  Title = "How to make a creemy cubcake",
                        Content = "Creemy cubcake blah blah blah....", IntimacyId = _intimacies[0].IntimacyId, Intimacy = _intimacies[0], Picture = null,
                        ApproveStatue = 'P', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StoryId = 2, CategoryId = _categories[1].CategoryId, Category = _categories[1],  Title = "My love story",
                        Content = "When I first meet her....", IntimacyId = _intimacies[1].IntimacyId, Intimacy = _intimacies[1], Picture = null,
                        ApproveStatue = 'P', NoView = 5000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StoryId = 3, CategoryId = _categories[2].CategoryId, Category = _categories[2],  Title = "Angkor Wat",
                        Content = "In 11th century....", IntimacyId = _intimacies[2].IntimacyId, Intimacy = _intimacies[2], Picture = null,
                        ApproveStatue = 'P', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StoryId = 4, CategoryId = _categories[3].CategoryId, Category = _categories[3],  Title = "Discover Mars",
                        Content = "A group of scientist from USA, Russia and China....", IntimacyId = _intimacies[2].IntimacyId, Intimacy = _intimacies[2], Picture = null,
                        ApproveStatue = 'P', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StoryId = 5, CategoryId = _categories[4].CategoryId, Category = _categories[4],  Title = "Mr and Mrs Poor",
                        Content = "Once upon time....", IntimacyId = _intimacies[1].IntimacyId, Intimacy = _intimacies[1], Picture = null,
                        ApproveStatue = 'P', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},

        };
        static List<Hashtag> _hashtags = new List<Hashtag> {
                new Hashtag{ HashtagId = 1, Description = "yummy", Stories = _stories},
                new Hashtag{ HashtagId = 2, Description = "sweet", Stories = _stories},
                new Hashtag{ HashtagId = 3, Description = "thousandyear", Stories = _stories},
                new Hashtag{ HashtagId = 4, Description = "Mars", Stories = _stories},
                new Hashtag{ HashtagId = 5, Description = "fly", Stories = _stories}
        };
        
        static List<Comment> _comments = new List<Comment> {
                new Comment{ CommentId =1, Descriptiopn = "Such a great story", StoryId = 1, Story = _stories[1]},
                new Comment{ CommentId =2, Descriptiopn = "Yeah, that's so romantic", StoryId = 1, Story = _stories[1]},
                new Comment{ CommentId =3, Descriptiopn = "We'll be able to live on Mars soon", StoryId = 4, Story = _stories[4]},
                new Comment{ CommentId =4, Descriptiopn = "I've been there one time, it's amazing", StoryId = 3, Story = _stories[3]},
                new Comment{ CommentId =5, Descriptiopn = "I will visit there one time", StoryId = 3, Story = _stories[3]},
        };
        static List<Blog> _blogs = new List<Blog>
        {
            new Blog{ BlogId = 1, Title= "First Blog", Content= "This is the first blog", User = _users[0], UserId = _users[0].Id},
            new Blog{ BlogId = 2, Title= "Second Blog", Content= "This is the second blog", User = _users[0], UserId = _users[0].Id},
            new Blog{ BlogId = 3, Title= "Third Blog", Content= "This is the third blog", User = _users[0], UserId = _users[0].Id}
        };

        #region "Other"
        public Response ReturnSuccess()
        {
            return new Response() { Success = true, ErrorMessage = "" };
        }

        public byte[] ConvertImgToByte(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }
        #endregion


        #region "Infos"
        public List<Info> GetInfoList()
        {
            return _infos;
        }

        public List<Info> GetInfoByDate(DateTime FD, DateTime TD)
        {
            return GetInfoList().Where(n => n.FDate >= FD && n.TDate <= TD).ToList();
        }

        public Info GetInfoById(int InfoId)
        {
            return GetInfoList().FirstOrDefault(n => n.InfoId == InfoId);
        }

        public int AddInfo(Info news)
        {
            if (_infos.Count <= 0)
            {
                news.InfoId = 1;
            }
            else
            {
                news.InfoId = _infos.Max(n => n.InfoId) + 1;
            }
            _infos.Add(news);
            return news.InfoId;
        }

        public bool UpdateInfo(Info news)
        {
            _infos.RemoveAll(n => n.InfoId == news.InfoId);
            _infos.Add(news);
            return true;
        }

        public bool DeleteInfo(int InfoId)
        {
            _infos.RemoveAll(n => n.InfoId == InfoId);
            return true;
        }
        #endregion

        #region "Category"
        public List<Category> GetCategoryList()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return GetCategoryList().FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public int AddCategory(Category category)
        {
            if (_categories.Count <= 0)
            {
                category.CategoryId = 1;
            }
            else
            {
                category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            }
            _categories.Add(category);
            return category.CategoryId;
        }

        public bool UpdateCategory(Category category)
        {
            _categories.RemoveAll(c => c.CategoryId == category.CategoryId);
            _categories.Add(category);
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            _categories.RemoveAll(c => c.CategoryId == categoryId);
            return true;
        }
        #endregion

        #region "Intimacy"
        public List<Intimacy> GetIntimacyList()
        {
            return _intimacies;
        }
        
        public Intimacy GetIntimacyById(int itimacyId)
        {
            return _intimacies.FirstOrDefault(i => i.IntimacyId == itimacyId);
        }
        public int AddIntimacy(Intimacy intimacy)
        {
            if (_intimacies.Count <= 0)
            {
                intimacy.IntimacyId = 1;
            }
            else
            {
                intimacy.IntimacyId = _intimacies.Max(c => c.IntimacyId) + 1;
            }
            _intimacies.Add(intimacy);
            return intimacy.IntimacyId;
        }

        public bool UpdateIntimacy(Intimacy intimacy)
        {
            _intimacies.RemoveAll(i => i.IntimacyId == intimacy.IntimacyId);
            _intimacies.Add(intimacy);
            return true;
        }
        public bool DeleteIntimacy(int intimacyId)
        {
            _intimacies.RemoveAll(i => i.IntimacyId == intimacyId);
            return true;
        }

        #endregion

        #region "Story"
        public List<Story> GetStoryList()
        {
            return _stories;
        }

        public List<Story> GetStoryByStatus(char status)
        {
            return GetStoryList().Where(s => s.ApproveStatue == status).ToList();
        }

        public List<Story> GetStoryByUser(string userId)
        {
            return GetStoryList().Where(s => s.UserId == userId).ToList();
        }

        public Story GetStoryById(int storyId)
        {
            return _stories.FirstOrDefault(s => s.StoryId == storyId);
        }

        public StoryVM GetStoryVMById(int storyId)
        {
            Story story = GetStoryList().FirstOrDefault(s => s.StoryId == storyId);
            StoryVM storyVM = new StoryVM
            {

                StoryId = story.StoryId,
                CategoryId = story.CategoryId,
                IntimacyId = story.IntimacyId,
                Title = story.Title,
                Content = story.Content,
                HashtagWord = story.HashtagWord,
                Picture = story.Picture,
                NoView = story.NoView,
                ApproveStatue = story.ApproveStatue,
                UserId = story.UserId,

                Category = story.Category,
                Intimacy = story.Intimacy,

                Hashtags = story.Hashtags
            };
            return storyVM;
        }

        public int AddStory(StoryVM storyVM)
        {
            if (_stories.Count <= 0)
            {
                storyVM.StoryId = 1;
            }
            else
            {
                storyVM.StoryId = _stories.Max(c => c.StoryId) + 1;
            }
            Story story = new Story
            {

                StoryId = storyVM.StoryId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatue = storyVM.ApproveStatue,
                UserId = storyVM.UserId,

                Category = storyVM.Category,
                Intimacy = storyVM.Intimacy,

                Hashtags = storyVM.Hashtags
            };

            _stories.Add(story);
            return story.StoryId;
        }

        public bool UpdateStory(StoryVM storyVM)
        {
            Story story = new Story
            {

                StoryId = storyVM.StoryId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatue = storyVM.ApproveStatue,
                UserId = storyVM.UserId,

                Category = storyVM.Category,
                Intimacy = storyVM.Intimacy,

                Hashtags = storyVM.Hashtags
            };
            _stories.RemoveAll(s => s.StoryId == story.StoryId);
            _stories.Add(story);
            return true;
        }

        public bool ApproveStory(int storyId, string feedback)
        {
            Story story = GetStoryById(storyId);
            story.ApproveStatue = 'Y';
            story.Feedback = feedback;
            _stories.RemoveAll(s => s.StoryId == story.StoryId);
            _stories.Add(story);
            return true;
        }

        public bool DenyStory (int storyId, string feedback)
        {
            Story story = GetStoryById(storyId);
            story.Feedback = feedback;
            story.ApproveStatue = 'N';
            _stories.RemoveAll(s => s.StoryId == story.StoryId);
            _stories.Add(story);
            return true;
        }

        public bool DeleteStory(int storyId)
        {
            _stories.RemoveAll(s => s.StoryId == storyId);
            return true;
        }


        #endregion

        #region "Comment"
        public List<Comment> GetCommentList()
        {
            return _comments;
        }

        public Comment GetCommentById(int commentId)
        {
            return _comments.FirstOrDefault(c => c.CommentId == commentId);
        }

        public List<Comment> GetCommentByStory(int storyId)
        {
            return _comments.Where(c => c.StoryId == storyId).ToList();
        }

        public int AddComment(Comment comment)
        {
            if (_comments.Count <= 0)
            {
                comment.CommentId = 1;
            }
            else
            {
                comment.CommentId = _comments.Max(c => c.CommentId) + 1;
            }
            _comments.Add(comment);
            return comment.CommentId;
        }

        public bool UpdateComment(Comment comment)
        {
            _comments.RemoveAll(c => c.CommentId == comment.CommentId);
            _comments.Add(comment);
            return true;
        }
        public bool DeleteCommentById(int commentId)
        {
            _comments.RemoveAll(c => c.CommentId == commentId);
            return true;
        }

        public bool DeleteCommentByStory(int storyId)
        {
            _comments.RemoveAll(c => c.StoryId == storyId);
            return true;
        }
        #endregion

        #region "Hashtag"
        public List<Hashtag> GetHashtagList()
        {
            return _hashtags;
        }

        public Hashtag GetHashtagById(int hastagId)
        {
            return _hashtags.FirstOrDefault(h => h.HashtagId == hastagId);
        }

        public Hashtag GetHashtagByDesc(string description)
        {
            return GetHashtagList().FirstOrDefault(h => h.Description == description);
        }

        public List<Hashtag> GetHashtagByStory(int storyId)
        {
            return _hashtags.Where(h => h.Stories.Any(s => s.StoryId == storyId)).ToList();
        }

        public int AddHashtag(Hashtag hashtag)
        {
            if (_hashtags.Count <= 0)
            {
                hashtag.HashtagId = 1;
            }
            else
            {
                hashtag.HashtagId = _hashtags.Max(h => h.HashtagId) + 1;
            }
            _hashtags.Add(hashtag);
            return hashtag.HashtagId;
        }


        public bool AddHashtagByStory(Story story)
        {
            string[] tmpHashtag = story.HashtagWord.Split();
            for (int i = 0; i < tmpHashtag.Length; i++)
            {
                if (tmpHashtag[i].Trim() == "") continue;

                Hashtag hashtag;
                if (!GetHashtagList().Any(h => h.Description == tmpHashtag[i]))
                {
                    hashtag = new Hashtag { Description = tmpHashtag[i] };
                    hashtag.Stories.Add(story);
                    _hashtags.Add(hashtag);
                }
                else
                {
                    hashtag = GetHashtagList().FirstOrDefault(h => h.Description == tmpHashtag[i]);
                    hashtag.Stories.Add(story);                    
                }
            }

            return true;
        }

        public bool UpdateHashtag(Hashtag hashtag)
        {
            _hashtags.RemoveAll(h => h.HashtagId == hashtag.HashtagId);
            _hashtags.Add(hashtag);
            return true;
        }

        public bool DeleteHashtagById(int hashtagId)
        {
            _hashtags.RemoveAll(h => h.HashtagId == hashtagId);
            return true;
        }

        public bool DeleteHashtagByStory(int storyId)
        {
            _hashtags.RemoveAll(h => h.Stories.Any(s => s.StoryId == storyId));
            return true;
        }

        #endregion

        #region "User"
        public User ConvertVMToUser(UserVM input)
        {
            User result = new User()
            {
                Id = input.Id,
                PasswordHash = input.PasswordHash,
                UserName = input.UserName,
                Nickname = input.Nickname,
                Phone = input.Phone,
                ProfilePic = input.ProfilePic,
                Quote = input.Quote
             };
            return result;
        }

        public UserVM ConvertUserToVM(User input)
        {
            UserVM result = new UserVM()
            {
                Id = input.Id,
                PasswordHash = input.PasswordHash,
                UserName = input.UserName,
                Nickname = input.Nickname,
                Phone = input.Phone,
                ProfilePic = input.ProfilePic,
                Quote = input.Quote,
                Result = ReturnSuccess()
            };
            return result;
        }

        public List<User> GetUserList()
        {
            return _users;
        }

        public List<User> GetUserListByRole(string role)
        {
            //return GetUserList().Where(u => u.Roles.Any(r => r.RoleId == role)).ToList();
            return GetUserList().ToList();
        }

        public User GetUserById(string userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public UserVM GetUserVMEditById(string userId)
        {
            return ConvertUserToVM(GetUserById(userId));
        }

        public User GetUserByUserName(string userName)
        {
            return _users.FirstOrDefault(u => u.UserName == userName);
        }

        //public UserVM AddUser(UserVM user, string role)
        //{
        //    user.Id = _users.Max(c => c.Id) + 1;
        //    _users.Add(ConvertVMToUser(user));
        //    user.Result = ReturnSuccess();
        //    return user;
        //}

        public UserVM AddUser(UserVM user, string role)
        {
            User userTmp = new User();
            userTmp.UserName = user.UserName;
            userTmp.Nickname = role == Role.admin.ToString() ? user.UserName : user.Nickname;
            userTmp.Email = user.Email;
            userTmp.Phone = user.Phone;
            userTmp.Quote = user.Quote;
            userTmp.ProfilePic = user.ProfilePic;
            userTmp.PasswordHash = user.PasswordHash;
            userTmp.IsActive = true;
            userTmp.Id = _users.Max(c => c.Id) + 1;

            _users.Add(userTmp);
            user.Result = ReturnSuccess();
            return user;
        }

        public bool DeactivateUser(string userName)
        {
            User user = GetUserByUserName(userName);
            if (user != null)
            {
                user.IsActive = false;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
            }
            return true;
        }

        public bool ReactivateUser(string userName)
        {
            User user = GetUserByUserName(userName);
            if (user != null)
            {
                user.IsActive = true;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
            }
            return true;
        }

        public bool ChangePassword(string userName, string currentPassword, string newPassword)
        {
            User user = GetUserByUserName(userName);
            if (user != null && user.PasswordHash == currentPassword)
            {
                user.PasswordHash = newPassword;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
                return true;
            }
            return false;
        }

        public bool UpdateUser(User user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            _users.Add(user);
            return true;
        }

        public UserVM UpdateUser(UserVM user, string role)
        {
            _users.RemoveAll(u => u.Id == user.Id);

            User userTmp = new User();
            userTmp.UserName = user.UserName;
            userTmp.Nickname = role == Role.admin.ToString() ? user.UserName : user.Nickname;
            userTmp.Email = user.Email;
            userTmp.Phone = user.Phone;
            userTmp.Quote = user.Quote;
            userTmp.ProfilePic = user.ProfilePic;

            _users.Add(userTmp);
            user.Result = ReturnSuccess();
            return user;
        }

        public bool DeleteUser(string userId)
        {
            _users.RemoveAll(u => u.Id == userId);
            return true;
        }

        public bool Login(string userName, string password)
        {
            if (_users.Any(u => u.UserName == userName && u.PasswordHash == password))
            {
                var userMgr = HttpContext.Current.GetOwinContext().GetUserManager<UserManager<User>>();
                //User user = _users.FirstOrDefault(u => u.UserName == userName);
                User user = userMgr.Find(userName, password);
                var identity = userMgr.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                var authManager = HttpContext.Current.GetOwinContext().Authentication;
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                CurrentUser.User = user;
                return true;
            }
            return false;
        }


        public bool Logout()
        {
            var ctx = HttpContext.Current.GetOwinContext();
            var authMgr = ctx.Authentication;
            authMgr.SignOut("ApplicationCookie");

            return true;
        }
        #endregion

        #region Blog

        public List<Blog> GetBlogList()
        {
            return _blogs;
        }

        public Blog GetBlogById(int id)
        {
            return _blogs.FirstOrDefault(b => b.BlogId == id);
        }

        public int AddBlog(Blog blog)
        {
            if (_blogs.Count <= 0)
            {
                blog.BlogId = 1;
            }
            else
            {
                blog.BlogId = _blogs.Max(b => b.BlogId) + 1;
            }
            Blog newBlog = new Blog
            {

                Title = blog.Title,
                Content = blog.Content,
                User = blog.User,
                UserId = blog.UserId
            };
            _blogs.Add(newBlog);
            return newBlog.BlogId;
        }

        public bool UpdateBlog(Blog blog)
        {
            Blog update = new Blog()
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                Content = blog.Content,
                UserId = blog.UserId,
                User = blog.User

            };

            _blogs.RemoveAll(b => b.BlogId == update.BlogId);
            _blogs.Add(update);
            return true;
        }

        public bool DeleteBlog(int id)
        {
            _blogs.RemoveAll(b => b.BlogId == id);
            return true;
        }

        #endregion
    }
}
