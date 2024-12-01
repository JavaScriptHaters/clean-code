using Markdown.Tags;

namespace Markdown.Rule;

public class BoldRule : IRule
{
    private readonly ITag tag = new BoldTag();
    private List<Token.Token> tokens = new();
    private bool isItalicInStart;
    private bool isItalicInMiddle;
    private bool isTagClosed;
    private int currentState;

    // TODO List
    // 1. Жирный начался в одном слове но кончился в другом

    public TagKind MoveByRule(char ch, int position)
    {
        var symbol = SymbolStatusParser.ParseSymbolStatus(ch);

        if (!tag.UsedSymbols.Contains(symbol))
        {
            symbol = SymbolStatus.anotherSymbol;
        }

        currentState = tag.States[currentState][symbol];

        if (currentState == 0)
        {
            ClearTokens();
        }

        if (currentState == tag.InputStateNumber)
        {
            tokens.Add(new Token.Token(tag.MdView, tag.Head, position - (tag.MdView.Length - 1)));
        }
        else if (currentState == tag.OutputStateNumber)
        {
            tokens.Add(new Token.Token(tag.MdView, tag.Tail, position - (tag.MdView.Length - 1)));
            isTagClosed = true;
        }
        else if (currentState == 9)
        {
            if (isItalicInMiddle)
            {
                isItalicInStart = false;
                isItalicInMiddle = false;
                isTagClosed = false;
                currentState = 0;
                tokens.Clear();
            }
            else
            {
                isItalicInStart = !isItalicInStart;
            }
        }
        else if (currentState == 10 || currentState == 12)
        {
            if (isItalicInStart)
            {
                isItalicInStart = false;
                isItalicInMiddle = false;
                isTagClosed = false;
                currentState = 0;
                tokens.Clear();
            }
            else
            {
                isItalicInMiddle = !isItalicInMiddle;
            }
            
        }

        // (!isItalicInStart || symbol == SymbolStatus.eof)
        if (isTagClosed && ((!isItalicInMiddle && !isItalicInStart) || symbol == SymbolStatus.eof)) // (!isItalicInMiddle && !isItalicInStart)
        {
            isTagClosed = false;
            currentState = 0;
            return TagKind.Close;
        }

        return TagKind.None;
    }

    public List<Token.Token> GetTokens() { return tokens; }

    public void ClearTokens() { tokens.Clear(); }
}