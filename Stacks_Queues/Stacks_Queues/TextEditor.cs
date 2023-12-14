using System.Text;

class TextEditor
{
    private readonly Stack<string> undoStack;
    private readonly StringBuilder currentText;

    public TextEditor()
    {
        undoStack = new Stack<string>();
        currentText = new StringBuilder();
    }

    public void Type(string text)
    {
        undoStack.Push(currentText.ToString());
        currentText.Append(text);
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            string previousState = undoStack.Pop();
            currentText.Clear();
            currentText.Append(previousState);
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
    public void Display()
    {
        Console.WriteLine("Current Text: " + currentText.ToString());
    }

}