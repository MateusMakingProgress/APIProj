using AuthProjectAPI.Models;

namespace TestPersonRoutes
{
    public class TestPersonRequest
    {
        [Fact]
        public void ShouldHaveNameProperty()
        {
            var request = new PersonRequest("John", string.Empty);
            Assert.Equal("John", request.name);
        }

        [Fact]
        public void ShouldHaveLastNameProperty()
        {
            var request = new PersonRequest(string.Empty, "Doe");
            Assert.Equal("Doe", request.lastName);
        }

        [Fact]
        public void ShoudlValidateRequest()
        {
            var validRequest = new PersonRequest("John", "Doe");
            var invalidRequest1 = new PersonRequest("", "Doe");
            var invalidRequest2 = new PersonRequest("John", "");
            var invalidRequest3 = new PersonRequest("", "");
            Assert.True(validRequest.IsValid());
            Assert.False(invalidRequest1.IsValid());
            Assert.False(invalidRequest2.IsValid());
            Assert.False(invalidRequest3.IsValid());
        }
    }
}