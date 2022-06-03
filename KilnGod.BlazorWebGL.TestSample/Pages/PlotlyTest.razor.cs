using Microsoft.AspNetCore.Components;
using KilnGod.BlazorWebGL.PlotlyCharting;

namespace KilnGod.BlazorWebGL.TestSample.Pages
{
    public partial class PlotlyTest
    {

#nullable disable
        public PlotlyChart Chart1 { get; set; }

#nullable enable

        public bool DisabledButtons { get; set; } = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Chart1.PlotlyInitComplete += Chart1_InitComplete;
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async void Chart1_InitComplete(PlotlyChart obj)
        {
            DisabledButtons = false;
            StateHasChanged();



        }


    }
}
