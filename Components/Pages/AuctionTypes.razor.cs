using AuctionTypesCMS.Entities;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;


namespace AuctionTypesCMS.Components.Pages
{
    public partial class AuctionTypes
    {
        private string searchString = "";
        private AuctionType auctionType = new AuctionType();
        private List<AuctionType> auctionTypes = new List<AuctionType>();
        IList<IBrowserFile> files = new List<IBrowserFile>();

        protected override async Task OnInitializedAsync()
        {
            GetAuctionTypes();
        }

        private List<AuctionType> GetAuctionTypes()
        {
            auctionTypes = auctionTypesService.GetAll();
            return auctionTypes;
        }

        private bool Search(AuctionType auctionType)
        {
            if (auctionType.NameEn.Contains(searchString))
            {
                return true;
            }
            return false;
        }

        private void Save()
        {
            auctionTypesService.Add(auctionType);
            auctionType = new AuctionType();
            snackBar.Add("Auction Type Saved", Severity.Success);
            GetAuctionTypes();
        }
        private void Edit(int id)
        {
            auctionType = auctionTypes.FirstOrDefault(c => c.Id == id);
        }

        private void Delete(int id)
        {
            auctionTypesService.Delete(id);
            snackBar.Add("Auction Type Deleted.", Severity.Success);
            GetAuctionTypes();
        }
        private Func<AuctionType, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            if (x.NameEn.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.NameAr.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;            

            return false;
        };

        private async Task UploadFiles(IBrowserFile file)
        {

            var fileName = Path.GetFileName(file.Name);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);

            SaveFileNameToDB(fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }
        }

        private void SaveFileNameToDB(string fileName)
        {
            auctionType.FileName = fileName;
            auctionTypesService.Update(auctionType);
        }

        
    }
}
