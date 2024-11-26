using Markdown.Tags;
using Microsoft.VisualBasic;

namespace Markdown.Tags;

public class ItalicTextTag : ITag
{
    public string Head => "<em>";
    public string Tail => "</em>";
    public string MdView => "_";
    public TagType Type => TagType.ItalicText;
    private bool state;
    private Stack<ITag> currentStack;
    private int startPosition;
    public int TokenPosition { get; set; }

    public TagKind TagRule(char ch, int position)
    {
        if (state && char.IsLetter(ch) && currentStack.Count == 0)
        {
            state = false;
            currentStack.Push(CreateNewTag());
            return TagKind.Open;
        }
        if (state && (char.IsLetter(ch) || ch == ' '))
        {
            state = false;
            currentStack.Pop();
            return TagKind.Close;
        }
        if (ch == '_')
        {
            state = true;
            TokenPosition = position;
        }
        if (state && ch != '_')
        {
            state = false;
        }

        return TagKind.None;
    }

    public ITag CreateNewTag()
    {
        return new ItalicTextTag();
    }

    public void GetCurrentStack(in Stack<ITag> stack)
    {
        currentStack = stack;
    }

    public void ResetRule()
    {
        state = false;
    }
}