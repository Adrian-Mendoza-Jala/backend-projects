public class Solution
{
    public bool IsValid(string s)
    {
        var bracketStack = new Stack<char>();

        var matchingBrackets = new Dictionary<char, char> {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (char currentChar in s)
        {
            switch (currentChar)
            {
                case '(':
                case '{':
                case '[':
                    bracketStack.Push(currentChar);
                    break;
                case ')':
                case '}':
                case ']':
                    if (bracketStack.Count == 0 || bracketStack.Pop() != matchingBrackets[currentChar])
                        return false;
                    break;
            }
        }

        return bracketStack.Count == 0;
    }
}