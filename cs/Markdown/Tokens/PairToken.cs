namespace Markdown.Tokens;

public abstract class PairToken : ITokenPosition
{
    public abstract string MdView { get; }
    public abstract string HtmlTagOpen { get; }
    public abstract string HtmlTagClose { get; }
    public string HtmlView => IsClosed ? HtmlTagOpen : HtmlTagClose;

    public bool IsClosed { get; set; }
    public int Position { get; set; }
}