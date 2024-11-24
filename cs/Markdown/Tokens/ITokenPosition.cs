namespace Markdown.Tokens;

public interface ITokenPosition
{
    public string MdView { get; }
    public int Position { get; set; }
    public string HtmlView { get; }
}