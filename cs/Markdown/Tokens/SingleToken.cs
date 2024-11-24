namespace Markdown.Tokens;

public abstract class SingleToken : ITokenPosition
{
    public abstract string MdView { get; }
    public abstract string HtmlTagOpen { get; }

    public string HtmlView => HtmlTagOpen;
    public int Position { get; set; }
}