using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendlistView
    {
        FriendService friendService = new FriendService();
        public void Show(User user)
        {
            Console.WriteLine("Список друзей:");

            var friends = friendService.GetFriendsByUserId(user.Id);
            if (friends.Count() == 0)
                Console.WriteLine("Пока тут пусто.");
            else
            {
                foreach (var friend in friends)
                {
                    Console.WriteLine($"{friend.FirstName} {friend.LastName}, контактный адрес: {friend.Email}");
                }
            }
        }
    }
}
