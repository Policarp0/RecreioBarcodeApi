namespace RecreioBarcode.WebUI.ViewModel;

public class CreateInventoryFromCsvViewModel
{
    public string Name { get; set; } = string.Empty;
    public IFormFile? File { get; set; }
}