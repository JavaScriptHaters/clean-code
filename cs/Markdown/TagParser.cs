using System.Collections;
using Markdown.Tags;
using Markdown.Token;

namespace Markdown;

public class TagParser
{
    //private readonly Dictionary<TagType, Stack<ITag> > TagsOrder = new();
    //private readonly Dictionary<TagType, Stack<IToken>> TokensOrder = new();
    //private readonly List<(Func<char, int, TagKind>, ITag)> Rules = new();

    private readonly List<Rule.Rule> Rules = new();

    public TagParser(List<ITag> tags)
    {
        foreach (var tag in tags)
        {
            //Rules.Add((tag.TagRule, tag));
            //TagsOrder.Add(tag.Type, new Stack<ITag>());
            //TokensOrder.Add(tag.Type, new Stack<IToken>());
            //tag.GetCurrentStack(TagsOrder[tag.Type]);
            //tag.InitialzeStates();

            Rules.Add(new Rule.Rule(tag));
        }
    }

    public List<IToken> GetTokens(string text)
    {
        var tokens = new List<IToken> {};
        var textPointer = 0;
        while (textPointer != text.Length)
        {
            //foreach (var rule in Rules)
            //{
            //    var result = rule.Item1(text[textPointer], textPointer);
            //    if (result == TagKind.Close)
            //    {
            //        tokens.Add(new Token.Token(rule.Item2.MdView, rule.Item2.Head, rule.Item2.Positions[0]));
            //        tokens.Add(new Token.Token(rule.Item2.MdView, rule.Item2.Tail, rule.Item2.Positions[1]));
            //    }
            //}

            foreach (var rule in Rules)
            {
                var result = rule.MoveByRule(text[textPointer], textPointer);
                if (result == TagKind.Close)
                {
                    tokens.AddRange(rule.GetTokens());
                }
            }

            textPointer++;
        }

        foreach (var rule in Rules)
        {
            var result = rule.MoveByRule('\0', textPointer - 1);
            if (result == TagKind.Close)
            {
                tokens.AddRange(rule.GetTokens());
            }
        }

        //foreach (var rule in Rules)
        //{
        //    var result = rule.Item1('\0', textPointer - 1);
        //    if (result == TagKind.Close)
        //    {
        //        tokens.Add(new Token.Token(rule.Item2.MdView, rule.Item2.Head, rule.Item2.Positions[0]));
        //        tokens.Add(new Token.Token(rule.Item2.MdView, rule.Item2.Tail, rule.Item2.Positions[1]));
        //    }
        //}

        return tokens;
    }

    //private void ResetAllRules()
    //{
    //    foreach (var rule in Rules)
    //    {
    //        rule.Item2.ResetRule();
    //    }
    //}
}