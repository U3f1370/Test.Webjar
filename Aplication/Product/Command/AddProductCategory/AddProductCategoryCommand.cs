using BusinessLayout.Configuration.Commands;
using Entities.Product;
using Services;

namespace Application.Product.Command.AddProductCategory
{
    public class AddProductCategoryCommand: CommandBase<ServiceResult>
    {
        public string Title { get; set; }
        public AddProductCategoryCommand(string title)
        {
            Title = title;
        }
    }
}
