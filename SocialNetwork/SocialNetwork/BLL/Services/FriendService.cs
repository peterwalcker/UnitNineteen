using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriend(FriendAdditionData friendAdditionData)
        {
            var findUserEntity = this.userRepository.FindByEmail(friendAdditionData.FriendEmail);
            if (findUserEntity == null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                friend_id = findUserEntity.id,
                user_id = friendAdditionData.UsertId
            };

            if (this.friendRepository.Create(friendEntity) == 0) 
                throw new Exception();
        }

        public int GetFriendsCountByUserId(int userId)
        {
            return friendRepository.FindAllByUserId(userId).Count();
        }

        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            var friends = new List<User>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var userService = new UserService();
                var user = userService.FindById(f.user_id);

                friends.Add(user);
            });

            return friends;
        }
    }
}
