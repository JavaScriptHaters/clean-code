using System.Collections;
using Markdown.Tags;
using Markdown.Token;

namespace Markdown;

public class TagParser
{
    private readonly Dictionary<TagType, Stack<ITag> > TagsOrder = new();
    private readonly Dictionary<TagType, Stack<IToken>> TokensOrder = new();
    private readonly List<(Func<char, int, TagKind>, ITag)> Rules = new();

    public TagParser(List<ITag> tags)
    {
        foreach (var tag in tags)
        {
            Rules.Add((tag.TagRule, tag));
            TagsOrder.Add(tag.Type, new Stack<ITag>());
            TokensOrder.Add(tag.Type, new Stack<IToken>());
            tag.GetCurrentStack(TagsOrder[tag.Type]);
        }
    }

    public List<IToken> GetTokens(string text)
    {
        var tokens = new List<IToken> {};
        var globalContext = TagType.None;
        var textPointer = 0;
        while (textPointer != text.Length)
        {
            foreach (var rule in Rules)
            {
                var result = rule.Item1(text[textPointer], textPointer);
                if (result == TagKind.Open)
                {
                    globalContext = rule.Item2.Type;
                    var sourceText = rule.Item2.MdView;
                    var convertedText = rule.Item2.Head;
                    var pos = rule.Item2.TokenPosition;
                    TokensOrder[rule.Item2.Type].Push(new Token.Token(sourceText, convertedText, pos));
                    ResetAllRules();
                    break;
                }
                if (result == TagKind.Close)
                {
                    IToken prevToken;
                    if (TokensOrder[rule.Item2.Type].TryPop(out prevToken))
                    {
                        tokens.Add(prevToken);
                        var sourceText = rule.Item2.MdView;
                        var convertedText = rule.Item2.Tail;
                        var pos = rule.Item2.TokenPosition;
                        tokens.Add(new Token.Token(sourceText, convertedText, pos));
                    }
                    globalContext = rule.Item2.Type;
                    ResetAllRules();
                    break;
                }
            }

            textPointer++;
        }

        return tokens;
    }

    private void ResetAllRules()
    {
        foreach (var rule in Rules)
        {
            rule.Item2.ResetRule();
        }
    }
}