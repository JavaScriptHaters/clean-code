using Markdown.Tags;

namespace Markdown.Rule;

public interface IRule
{
    public TagKind MoveByRule(char ch, int position);

    public List<Token.Token> GetTokens();

    public void ClearTokens();
}