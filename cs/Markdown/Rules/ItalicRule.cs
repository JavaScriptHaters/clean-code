using Markdown.Tags;

namespace Markdown.Rule;

public class ItalicRule : IRule
{
    // TODO List
    // 1. проверка обрыва строки (✓)
    // 2. старт тэга в странном месте, возможно проблема (✕)

    private readonly ITag tag = new ItalicTextTag();
    private List<Token.Token> tokens = new();
    private bool isBoldInMiddle;
    private bool isBoldInStart;
    private bool isTagClosed;
    private int currentState;

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

        if (currentState == tag.InputStateNumber || currentState == 14)
        {
            tokens.Add(new Token.Token(tag.MdView, tag.Head, position - (tag.MdView.Length - 1)));
        }
        else if (currentState == tag.OutputStateNumber)
        {
            if (symbol == SymbolStatus.eof)
            {
                tokens.Add(new Token.Token(tag.MdView, tag.Tail, position));
            }
            else
            {
                tokens.Add(new Token.Token(tag.MdView, tag.Tail, position - tag.MdView.Length));
            }
            isTagClosed = true;
            //return TagKind.Close;
        }
        else if (currentState == 10)
        {
            //isBoldInStart = !isBoldInStart;
            if (isBoldInMiddle)
            {
                isBoldInMiddle = false;
                isBoldInStart = false;
                isTagClosed = false;
                currentState = 0;
                tokens.Clear();
            }
            else
            {
                isBoldInStart = !isBoldInStart;
            }
        }
        else if (currentState == 7)
        {
            //isBoldInMiddle = !isBoldInMiddle;
            if (isBoldInStart)
            {
                isBoldInMiddle = false;
                isBoldInStart = false;
                isTagClosed = false;
                currentState = 0;
                tokens.Clear();
                
            }
            else
            {
                isBoldInMiddle = !isBoldInMiddle;
            }
        }

        if (isTagClosed && (!isBoldInMiddle || symbol == SymbolStatus.eof))
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