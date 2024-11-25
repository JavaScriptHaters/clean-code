using System.Text;
using Markdown.Tags;
using Markdown.Token;

namespace Markdown;

public static class Md
{
    private static List<ITag> availableTags =
    [
        new BoldTag(),
        new H1Tag(),
        new ItalicTextTag(),
        new EscapeTag()
    ];

    public static string Render(string text)
    {
        var parser = new TagParser(availableTags);
        return GenerateHtml(text, parser.GetTokens(text));
    }

    private static string GenerateHtml(string text, List<IToken> tokens)
    {
        // TODO some logic
        throw new NotImplementedException();
    }
}