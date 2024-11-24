namespace Markdown.Tokens;

public class BoldToken : PairToken
{
    public override string MdView => "__";
    public override string HtmlTagOpen => "<strong>";
    public override string HtmlTagClose => "</strong>";
}