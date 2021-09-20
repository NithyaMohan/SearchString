using System;
using Xunit;
using SearchString;

namespace SearchStringTest
{
    public class BoyerMooreSearchTest
    {
        [Theory]
        [InlineData("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly")]
        [InlineData("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "polly")]
        public void Task_Search_Subtext_Inside_A_Text_Case_Insensitive_Test(string text, string subText)
        {

            int[] expectedValue = new int[] { 1, 26, 51 };

            //Act
            var occurencePosition = Search.BoyerMooreSearch(text.ToLower(), subText.ToLower());

            //Assert
            Assert.Equal(expectedValue, occurencePosition);
        }

        [Theory]
        [InlineData("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "X", new int[] { })]
        [InlineData("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "poly", new int[] { })]
        public void Search_Subtext_Inside_A_Text_Returns_NoMatch(string text, string subText,int[] expectedValue)
        {
            //Act
            var occurencePosition = Search.BoyerMooreSearch(text.ToLower(), subText.ToLower());

            //Assert
            Assert.Equal(expectedValue, occurencePosition);
        }

        [Theory]
        [InlineData("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "ll", new int[] { 3,28,53,78,82 })]
        [InlineData("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Ll", new int[] { 3, 28, 53, 78, 82 })]
        public void Search_Subtext_Inside_A_Text_Returns_Case_InSensitive_Test2(string text, string subText, int[] expectedValue)
        {
            //Act
            var occurencePosition = Search.BoyerMooreSearch(text.ToLower(), subText.ToLower());

            //Assert
            Assert.Equal(expectedValue, occurencePosition);
        }
    }
}
