using System.ComponentModel.DataAnnotations;
using Markdown.Tags;

namespace Markdown.Rule;

public class Rule
{
    private readonly SymbolStatus[] usedSymbols;
    private Dictionary<int, Dictionary<SymbolStatus, int>> states;
    private List<Token.Token> tokens = new();
    private readonly int inputStateNumber;
    private readonly int[] subOutputStateNumbers;
    private readonly int outputStateNumber;
    private int currentState;
    private ITag currentTag;

    public Rule(ITag tag)
    {
        usedSymbols = tag.UsedSymbols;
        states = tag.States;
        currentTag = tag;
        inputStateNumber = tag.InputStateNumber;
        subOutputStateNumbers = tag.SubOutputStateNumbers;
        outputStateNumber = tag.OutputStateNumber;
    }

    public TagKind MoveByRule(char ch, int position)
    {
        var symbol = SymbolStatusParser.ParseSymbolStatus(ch);

        if (!usedSymbols.Contains(symbol))
        {
            symbol = SymbolStatus.anotherSymbol;
        }

        currentState = states[currentState][symbol];

        if (symbol == SymbolStatus.eof && (currentState == outputStateNumber || subOutputStateNumbers.Contains(currentState)))
        {
            tokens.Add(new Token.Token(currentTag.MdView, currentTag.Tail, position + 1));
            return TagKind.Close;
        }

        if (currentState == inputStateNumber)
        {
            tokens.Add(new Token.Token(currentTag.MdView, currentTag.Head, position - (currentTag.MdView.Length - 1)));
        }
        else if (subOutputStateNumbers.Contains(currentState))
        {
            tokens.Add(new Token.Token(currentTag.MdView, currentTag.Tail, position - (currentTag.MdView.Length - 1))); // ?
        }
        else if (currentState == outputStateNumber)
        {
            tokens.Add(new Token.Token(currentTag.MdView, currentTag.Tail, position - (currentTag.MdView.Length - 1))); // ?
            return TagKind.Close;
        }
        else if (currentState == 0)
        {
            tokens.Clear();
        }

        return TagKind.None;
    }

    public List<Token.Token> GetTokens() { return tokens; }
}