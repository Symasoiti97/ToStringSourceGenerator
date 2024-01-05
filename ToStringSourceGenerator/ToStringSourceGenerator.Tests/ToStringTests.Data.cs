using System.Collections.Generic;

namespace ToStringSourceGenerator.Tests;

public sealed partial class ToStringTests
{
    public static IEnumerable<object[]> Data()
    {
        yield return new object[]
        {
            new Class.SampleEntity(null, 0, null),
            new Record.SampleEntity(null, 0, null)
        };

        yield return new object[]
        {
            new Class.SampleEntity("Text 1", 1, new Class.SampleEntity("Text 2", 2, null)),
            new Record.SampleEntity("Text 1", 1, new Record.SampleEntity("Text 2", 2, null))
        };
    }

    public static partial class Record
    {
        public sealed record SampleEntity(string? Text, int Number, SampleEntity? Entity);
    }

    public static partial class Class
    {
        [Generators.ToString]
        public partial class SampleEntity
        {
            public SampleEntity(string? text, int number, SampleEntity? entity)
            {
                Text = text;
                Number = number;
                Entity = entity;
            }

            public string? Text { get; }
            public int Number { get; }
            public SampleEntity? Entity { get; }
        }
    }
}
