using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace SocialNetwork.Tests
{
    public class FriendServiceTests
    {
        [Fact]
        public void GetFriendsCountByUserId_MustReturnZero()
        {
            var friendService = new FriendService();
            var expected = 0;
            var testId = 2;

            Assert.True(expected == friendService.GetFriendsCountByUserId(testId));
        }

        [Fact]
        public void GetFriendsByUserId_MustReturnListOfUsers()
        {
            var friendService = new FriendService();
            var expected = typeof(List<User>);
            var testId = 1;

            Assert.True(expected == friendService.GetFriendsByUserId(testId).GetType());
        }
    }
}
