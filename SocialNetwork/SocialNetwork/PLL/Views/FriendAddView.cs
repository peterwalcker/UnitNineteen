using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        FriendService friendService;
        UserService userService;

        public FriendAddView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }
        
        public void Show(User user)
        {
            var friendAdditionData = new FriendAdditionData();
            friendAdditionData.UsertId = user.Id;

            Console.WriteLine("Введите электронный адрес друга: ");
            friendAdditionData.FriendEmail = Console.ReadLine();

            try
            {
                friendService.AddFriend(friendAdditionData);

                SuccessMessage.Show("Друг добавлен!");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Ошибка при добавлении друга!");
            }
        }
    }
}
