using System;
using Xunit;
using FundamentalTools.Resources;
using FundamentalTools.Helpers.Enumerator;

namespace FundamentalTools.Tests
{
    public class EnumeratorExtensionTests
    {
        [Fact]
        public void GetEnumDescription_HasDescription_ShouldReturnValue()
        {
            GenderEnum enumValue = GenderEnum.Male;
            var description = enumValue.GetDescription();
            Console.WriteLine(description);
            Assert.False(string.IsNullOrEmpty(description));
            Assert.Equal(description, "MaleDescription");
        }

        [Fact]
        public void GetEnumDescription_NoDescription_ShouldReturnEnumName()
        {
            GenderEnum enumValue = GenderEnum.Undefined;
            var description = enumValue.GetDescription();
            Assert.False(string.IsNullOrEmpty(description));
            Assert.Equal(description, "Undefined");
        }

        [Fact]
        public void Parse_String_To_Enum_Success()
        {
            var enumValue = "Male";
            var gender = EnumeratorExtensions.Parse<GenderEnum>(enumValue);
            Assert.Equal(gender, GenderEnum.Male);
        }

        [Fact]
        public void Parse_String_To_Enum_Fail()
        {
            var enumValue = "Error";
            Assert.Throws<ArgumentException>(() => EnumeratorExtensions.Parse<GenderEnum>(enumValue));
        }

        [Fact]
        public void TryParse_String_To_Enum_Success()
        {
            var enumValue = "Male";
            var result = default(GenderEnum);
            Assert.True(EnumeratorExtensions.TryParse<GenderEnum>(enumValue, out result));
            Assert.Equal(result, GenderEnum.Male);
        }

        [Fact]
        public void TryParse_String_To_Enum_Fail()
        {
            var enumValue = "Error";
            var result = default(GenderEnum);
            Assert.False(EnumeratorExtensions.TryParse<GenderEnum>(enumValue, out result));
            Assert.Equal(default(GenderEnum), result);
        }
    }
}
