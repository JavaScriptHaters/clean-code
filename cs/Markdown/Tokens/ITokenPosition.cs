namespace Markdown.Tokens;

public interface ITokenPosition
{
    public int Position { get; set; }
    public string HtmlView { get; }
}