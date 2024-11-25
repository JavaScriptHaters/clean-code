using System.Collections;
using Markdown.Tags;
using Markdown.Token;

namespace Markdown;

public class TagParser
{
    private readonly List<(Stack<ITag>, TagType)> TagsOrder;

    public TagParser(List<ITag> tags)
    {
        foreach (var tag in tags)
        {
            TagsOrder.Add((new Stack<ITag> {}, tag.Type));
        }
    }

    public List<IToken> GetTokens(string text)
    {
        var tokens = new List<IToken> {};
        // TODO some logic
        throw new NotImplementedException();
    }
}