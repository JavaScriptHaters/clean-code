using System.Collections;
using System.ComponentModel.Design;
using System.Data;
using Markdown.Rule;
using Markdown.Tags;
using Markdown.Token;

namespace Markdown;

public class TagParser
{
    private List<IRule> Rules =
    [
        new BoldRule(),
        new ItalicRule(),
        new H1Rule()
    ];

    private IRule EscapeRule = new EscapeRule();

    public bool TryGoNextSymbol(int textPointer, string text)
    {
        if (textPointer + 1 < text.Length)
        {
            return true;
        }
        return false;
    }

    public List<IToken> GetTokens(string text)
    {
        var tokens = new List<IToken> {};
        var textPointer = 0;
        var isPointerTeleported = false;
        var isStateNotChanged = true;
        var skip = 0;
        while (textPointer != text.Length)
        {
            //if (textPointer == 5824)
            //{
            //    var p = text[5820..5830];
            //    //var pe = text[741..750];
            //    var z4 = text[5823];
            //    var z = text[5824];
            //    var z1 = text[5825];
            //    var z2 = text[5826];
            //    var z3 = text[5827];
            //    Console.WriteLine();
            //}

            if (skip != 0)
            {
                skip--;
            }
            else
            {
                var res = EscapeRule.MoveByRule(text[textPointer], textPointer);

                if (res == TagKind.Open)
                {
                    if (TryGoNextSymbol(textPointer, text))
                    {
                        textPointer++;
                        res = EscapeRule.MoveByRule(text[textPointer], textPointer);

                        if (res == TagKind.Close)
                        {
                            tokens.AddRange(EscapeRule.GetTokens());
                            EscapeRule.ClearTokens();
                            if (text[textPointer] == '\\')
                            {
                                textPointer--;
                                skip += 1;
                            }
                            else
                            {
                                textPointer++;
                                isPointerTeleported = true;
                                isStateNotChanged = false;
                            }
                        }
                        else
                        {
                            textPointer--;
                        }

                        if (!TryGoNextSymbol(textPointer, text))
                        {
                            break;
                        }
                    }
                }
            }

            if (isPointerTeleported && isStateNotChanged)
            {
                textPointer++;
                isPointerTeleported = false;
            }


            foreach (var rule in Rules)
            {
                var result = rule.MoveByRule(text[textPointer], textPointer);
                if (result == TagKind.Close)
                {
                    tokens.AddRange(rule.GetTokens());
                    rule.ClearTokens();
                }
            }

            if (!isPointerTeleported)
            {
                textPointer++;
            }
            else
            {
                isStateNotChanged = true;
            }
            
        }

        foreach (var rule in Rules)
        {
            var result = rule.MoveByRule('\0', textPointer - 1);
            if (result == TagKind.Close)
            {
                tokens.AddRange(rule.GetTokens());
            }
        }

        return tokens;
    }
}