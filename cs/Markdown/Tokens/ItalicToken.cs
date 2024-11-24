namespace Markdown.Tokens;

public class ItalicToken : PairToken
{
    public override string MdView => "_";
    public override string HtmlTagOpen => "<em>";
    public override string HtmlTagClose => "</em>";
}