using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ViewModels
{
    public class UserFollowers
    {
        public Users User1 { get; set; }
        public Users User2 { get; set; }
        public Followers Follower { get; set; }
    }
}