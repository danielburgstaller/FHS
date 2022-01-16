using FHS_Example.ViewModel;
using Microsoft.AspNetCore.Components;

namespace FHS_Example.View
{
    public partial class Libraries : ComponentBase
    {
        [Parameter]
        public int Limit
        {
            get; set;
        }


        [Inject]
        ILibrariesViewModel librariesVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await librariesVM.GetLibrariesAsync(Limit);
        }
    }
}
