using IvanovEvgeniyKT_41_20.Models;

namespace IvanovEvgeniyKT_41_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT4120_True()
        {
            var testGroup = new Group
            {
                GroupName = "КТ-41-20"
            };

            var result = testGroup.IsValidGroupName();

            Assert.True(result);
        }
    }
}