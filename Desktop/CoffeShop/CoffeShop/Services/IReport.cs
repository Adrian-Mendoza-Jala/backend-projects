using QuestPDF.Infrastructure;

namespace CoffeShop.Services;

public interface IReport<T> : IDocument
{
    public void SetData(T data);
}
