namespace Markdown.Tokens;

public class HeaderToken : PairToken
{
    public override string MdView => "# ";
    public override string HtmlTagOpen => "<h1>";
    public override string HtmlTagClose => "</h1>";
}