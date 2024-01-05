using Xunit;

namespace ToStringSourceGenerator.Tests;

public sealed partial class ToStringTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void EqualsToStringResultsBetweenClassAndRecordTest(
        Class.SampleEntity entity,
        Record.SampleEntity recordEntity)
    {
        var entityAsString = entity.ToString();
        var recordEntityAsString = recordEntity.ToString();

        Assert.Equal(recordEntityAsString, entityAsString);
    }
}
